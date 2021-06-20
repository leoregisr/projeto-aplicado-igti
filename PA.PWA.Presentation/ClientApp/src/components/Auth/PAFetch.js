import { authHeader } from '../../_helpers/auth-header';

const constantMock = window.fetch;

window.fetch = function() {
    const url = arguments[0];
    let options = arguments[1];

    let token = this.sessionStorage.getItem("AuthToken");

    options.headers = {
        ...options.headers,
        'Authorization': `Bearer ${token}`
    }
    
    options.headers = {
        ...options.headers,
        'credentials': 'include'
    }        
    console.log("aaaaaaaa")

    if (options.method === 'POST'){
        options.headers = {
            ...options.headers,
            'Content-type': 'application/json; charset=utf-8',
            'Content-Encoding': 'gzip'
            
        }        
    }

    return constantMock(url, options);
}