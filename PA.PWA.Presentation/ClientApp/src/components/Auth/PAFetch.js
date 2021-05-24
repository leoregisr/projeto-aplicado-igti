const constantMock = window.fetch;

window.fetch = function() {
    const url = arguments[0];
    let options = arguments[1];
    const loginIssuer = this.sessionStorage.getItem("AuthIssuer");    
    const isExternalLogin = loginIssuer !== null && loginIssuer !== '';    

    if (isExternalLogin) {
        let w4bToken = this.sessionStorage.getItem("W4BToken");

        options.headers = {
            ...options.headers,
            'Authorization': `Bearer ${w4bToken}`
        }        
        
    } else {
        options.headers = {
            ...options.headers,
            'credentials': 'include'
        }              
    }       

    if (options.method === 'POST'){
        options.headers = {
            ...options.headers,
            'Content-type': 'application/json; charset=utf-8',
            'Content-Encoding': 'gzip'
        }        
    }

    return constantMock(url, options);
}