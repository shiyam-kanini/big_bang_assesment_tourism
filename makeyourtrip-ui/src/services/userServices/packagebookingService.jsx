import axios from "../../api/api";

const BOOKING_INIIATE_URL = '/PackageBooking/actions/initiatesession'
const BOOKING_PACKAGE_URL = '/PackageBooking/actions/addpackage'
const BOOKING_PLACES_URL = '/PackageBooking/actions/addbookplaces'
const BOOKING_DATE_URL = '/PackageBooking/actions/pickdate'
const BOOKING_HOTEL_URL = '/PackageBooking/actions/choosehotel'
const BOOKING_GUIDE_URL = '/PackageBooking/actions/pickguide'

const initiateSession = async(data) => {
    try{
        const response = await axios.post(BOOKING_INIIATE_URL, data, {
            headers : {
                "Content-Type" : 'application/json'
            }
        })
        return response.data;
    }
    catch(error){
        return error;
    }
}

const bookPackage = async(packageId, bookId) => {
    try{
        const response = await axios.put(`${BOOKING_PACKAGE_URL}?packageId=${packageId}&bookId=${bookId}`, {
            headers : {
                "Content-Type" : 'text-plain'
            }
        })
        return response.data;
    }
    catch(error){
        return error;
    }
}

const bookPlaces = async(data) => {
    try{
        const response = await axios.put(BOOKING_PLACES_URL, data, {
            headers : {
                "Content-Type" : 'application/json'
            }
        })
        return response.data;
    }
    catch(error){
        return error;
    }
}

const pickDate = async(data) => {
    try{
        const response = await axios.put(BOOKING_DATE_URL, data, {
            headers : {
                "Content-Type" : 'application/json'
            }
        })
        return response.data;
    }
    catch(error){
        return error;
    }
}

const chooseHotel = async(data) => {
    try{
        const response = await axios.put(BOOKING_HOTEL_URL, data, {
            headers : {
                "Content-Type" : 'application/json'
            }
        })
        return response.data;
    }
    catch(error){
        return error;
    }
}

const pickGuide = async(data) => {
    try{
        const response = await axios.put(BOOKING_GUIDE_URL, data, {
            headers : {
                "Content-Type" : 'application/json'
            }
        })
        return response.data;
    }
    catch(error){
        return error;
    }
}

export {initiateSession, pickDate, bookPackage, bookPlaces, pickGuide, chooseHotel}