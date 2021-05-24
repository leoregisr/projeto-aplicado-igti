const constantMock = window.fetch;
const HEADERS = new Headers({ 'Content-type': 'application/json; charset=utf-8' });

const W4BAuthenticationService = {

    Login(URL_BASE, issuer, applicationName, token) {
        return constantMock(`${URL_BASE}/auth`, {
            method: "POST",
            headers: HEADERS,
            body: JSON.stringify({
                Token: token,
                Issuer: issuer,
                Application: applicationName
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
        const loginIssuer = sessionStorage.getItem("AuthIssuer");
        const isExternalLogin = loginIssuer !== null && loginIssuer !== '';

        return (isExternalLogin && token !== null) //|| !isExternalLogin;
    }
}

export default W4BAuthenticationService;