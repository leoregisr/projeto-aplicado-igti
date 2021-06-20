const constantMock = window.fetch;
const HEADERS = new Headers({ 'Content-type': 'application/json; charset=utf-8' });

require("../Auth/PAFetch.js");

const TimeCardService = {

    ListClients() {
        return constantMock(`${process.env.REACT_APP_API}/Client/Clients`, {
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
        return constantMock(`${process.env.REACT_APP_API}/Client/${clientId}/Projects`, {
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
        return constantMock(`${process.env.REACT_APP_API}/TimeCard/ClockIn`, {
            method: "POST",
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
    EditTimeCardRegister(projectId) {
        return constantMock(`${process.env.REACT_APP_API}/TimeCard/TimeCard/EditTimeCardRegister`, {
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
        return constantMock(`${process.env.REACT_APP_API}/TimeCard/DeleteTimeCardRegister?id=${id}`, {
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
        return constantMock(`${process.env.REACT_APP_API}/TimeCard/ListTimeCardRegisterByDate?date=${date}&userName=${userName}`, {
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
        return constantMock(`${process.env.REACT_APP_API}/TimeCard/ListTimeCardRegisterByYearAndMonth?year=${year}&month=${month}&userName=${userName}`, {
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

export default TimeCardService;