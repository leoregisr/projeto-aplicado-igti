const constantMock = window.fetch;
const HEADERS = new Headers({ 'Content-type': 'application/json; charset=utf-8' });

const AuthenticationService = {

    Login(email, password) {
        return constantMock(`${process.env.REACT_APP_API}/Login/Login`, {
            method: "POST",
            headers: HEADERS,
            body: JSON.stringify({
                email: email,
                password: password
            })
        })
        .then(res => res.json())
        .then(data => {
                sessionStorage.setItem("AuthToken", data.token);
                sessionStorage.setItem("AuthUser", JSON.stringify(data.user));
                return data
        })
        .catch(console.log);
    },
    IsAuthenticated() {
        const token = sessionStorage.getItem("AuthToken");                

        return (token !== null);
    },
    GetUser() {
        return JSON.parse(sessionStorage.getItem("AuthUser")) || {}; 
    }
}

export default AuthenticationService;