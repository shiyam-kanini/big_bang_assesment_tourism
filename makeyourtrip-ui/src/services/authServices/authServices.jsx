import axios from "../../api/api";

const AUTH_EMPLOYEE_LOGIN_URL = '/Auth/actions/login/employee'
const AUTH_EMPLOYEE_REGISTER_URL = 'Auth/actions/register/employee'
const AUTH_USER_LOGIN_URL = 'Auth/actions/login/user'
const AUTH_USER_REGISTER_URL = 'Auth/actions/register/user'
const AUTH_LOGOUT_URL = 'Auth/actions/logout'

const employeeRegister = async(data) => {
    try{
        const response = await axios.post(AUTH_EMPLOYEE_REGISTER_URL, data, {
            headers : {
                "Content-Type":'application/json'
            }
        })
        return response.data
    }
    catch(error){
        return error
    }
}
const employeeLogin = async(data) => {
    try{
        const response = await axios.post(AUTH_EMPLOYEE_LOGIN_URL, data, {
            headers : {
                "Content-Type":'application/json'
            }
        })
        return response.data
    }
    catch(error){
        return error
    }
}
const userRegister = async(data) => {
    try{
        const response = await axios.post(AUTH_USER_REGISTER_URL, data, {
            headers : {
                "Content-Type":'application/json'
            }
        })
        return response.data
    }
    catch(error){
        return error
    }
}
const userLogin = async(data) => {
    try{
        const response = await axios.post(AUTH_USER_LOGIN_URL, data, {
            headers : {
                "Content-Type":'application/json'
            }
        })
        return response.data
    }
    catch(error){
        return error
    }
}
const logout = async(id) => {
    try{
        const response = await axios.put(`${AUTH_LOGOUT_URL}?sessionId=${id}`, {
            headers : {
                "Content-Type" : 'application/json'
            }
        })
        return response.data
    }
    catch(error){
        return error
    }
}

export {employeeLogin, employeeRegister, userRegister, userLogin, logout}
