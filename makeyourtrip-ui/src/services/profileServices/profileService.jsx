import axios from "../../api/api";

const PROFILE_EMPLOYEE_GET_URL = '/Profile/actions/getemployeeprofile' 
const PROFILE_USER_GET_URL = '/Profile/actions/getuserprofile'
const PROFILE_EMPLOYEE_UPDATE_URL = '/Profile/actions/updateemployeeprofile'
const PROFILE_USER_UPDATE_URL = '/Profile/actions/updateuserprofile'

const getEmployeeProfile = async(id) => {
    try{
        const response = await axios.get(`${PROFILE_EMPLOYEE_GET_URL}?id=${id}`, {
            headers : {
                "Content-Type" : 'text-plain'
            }
        })
        return response.data
    }
    catch(error){
        return error
    }
}

const getUserProfile = async(id) => {
    try{
        const response = await axios.get(`${PROFILE_USER_GET_URL}?id=${id}`, {
            headers : {
                "Content-Type" : 'text-plain'
            }
        })
        return response.data
    }
    catch(error){
        return error
    }
}

const updateEmployeeProfile = async(id, data) => {
    try{
        const response = await axios.put(`${PROFILE_EMPLOYEE_GET_URL}?id=${id}`, data, {
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

const updateUserProfile = async(id, data) => {
    try{
        const response = await axios.put(`${PROFILE_USER_UPDATE_URL}?id=${id}`, data, {
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

export {getEmployeeProfile, getUserProfile, updateEmployeeProfile, updateUserProfile}