const HEADERS = new Headers({ 'Content-type': 'application/json; charset=utf-8' });

require("../Auth/PAFetch.js");

const PendenciesService = {

    ListClients() {
        return fetch(`${process.env.REACT_APP_API}/Client/Clients`, {
            method: "GET",
            headers: HEADERS
        })
        .then(res => res.json())
        .then(data => {                
            return data
        })
        .catch(console.log);
    },
    ListClientProjects(clientId) {
        return fetch(`${process.env.REACT_APP_API}/Client/${clientId}/Projects`, {
            method: "GET",
            headers: HEADERS
        })
        .then(res => res.json())
        .then(data => {                
            return data
        })
        .catch(console.log);
    },
    ClockIn(projectId) {
        return fetch(`${process.env.REACT_APP_API}/TimeCard/ClockIn`, {
            method: "POST",
            headers: HEADERS,
            body: JSON.stringify(projectId)
        })
        .then(res => res.json())
        .then(data => {                
            return data
        })
        .catch(console.log);
    },
    EditTimeCardRegister(projectId) {
        return fetch(`${process.env.REACT_APP_API}/TimeCard/TimeCard/EditTimeCardRegister`, {
            method: "PUT",
            headers: HEADERS,
            body: JSON.stringify({
                projectId: projectId
            })
        })
        .then(res => res.json())
        .then(data => {                
            return data
        })
        .catch(console.log);
    },
    DeleteTimeCardRegister(id) {
        return fetch(`${process.env.REACT_APP_API}/TimeCard/DeleteTimeCardRegister/${id}`, {
            method: "DELETE",
            headers: HEADERS            
        })
        .then(res => res.json())
        .then(data => {                
            return data
        })
        .catch(console.log);
    },
    ListTimeCardRegisterByDate(date, userName) {
        return fetch(`${process.env.REACT_APP_API}/TimeCard/ListTimeCardRegisterByDate?date=${date}&userName=${userName}`, {
            method: "GET",
            headers: HEADERS            
        })
        .then(res => res.json())
        .then(data => {                
            return data
        })
        .catch(console.log);
    },
    ListTimeCardRegisterByYearAndMonth(year, month, userName) {
        return fetch(`${process.env.REACT_APP_API}/TimeCard/ListTimeCardRegisterByYearAndMonth?year=${year}&month=${month}&userName=${userName}`, {
            method: "GET",
            headers: HEADERS            
        })
        .then(res => res.json())
        .then(data => {                
            return data
        })
        .catch(console.log);
    }
}

export default PendenciesService;