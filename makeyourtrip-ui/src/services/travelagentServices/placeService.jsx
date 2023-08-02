import api from "../../api/api";

const PLACE_GET_ALL_PLACES_URL = 'Place/actions/getallplaces'
const PLACE_POST_URL = 'Place/actions/addplace'
const PLACE_POST_IMAGES_URL = 'Place/actions/addplaceimages'
const PLACE_POST_PLACE_FESTIVALS_URL = 'Place/actions/addplacefestivals'
const PLACE_DELETE_URL = 'Place/actions/deleteplace'
const PLACE_DELETE_PLACE_FESTIVAL_URL = 'Place/actions/deleteplacefestival'
const PLACE_DELETE_IMAGE_URL = 'Place/actions/deleteplaceimage'

const getAllPlaces = async () => {
    try{
        const response = await api.get(PLACE_GET_ALL_PLACES_URL)
        return response.data
    }
    catch(error){
        return error
    }
}
const postPlace = async(data) => {
    try{
        const response = await api.post(PLACE_POST_URL, data, {
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
const postPlaceImages = async(data) => {
    try{
        const response = await api.post(PLACE_POST_IMAGES_URL, data, {
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
const postPlaceFestivals = async(data) => {
    try{
        const response = await api.post(PLACE_POST_PLACE_FESTIVALS_URL, data, {
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
const deletePlace = async(id) => {
    try{
        const response = await api.delete(`${PLACE_DELETE_URL}?placeId=${id}`, {
            headers : {
                "Content-Type":'text-plain'
            }
        })
        return response.data
    }
    catch(error){
        return error
    }
}
const deletePlaceImage = async(id) => {
    try{
        const response = await api.delete(`${PLACE_DELETE_IMAGE_URL}?id=${id}`, {
            headers : {
                "Content-Type":'text-plain'
            }
        })
        return response.data
    }
    catch(error){
        return error
    }
}
const deletePlaceFestival = async(id) => {
    try{
        const response = await api.delete(`${PLACE_DELETE_PLACE_FESTIVAL_URL}?id=${id}`, {
            headers : {
                "Content-Type":'text-plain'
            }
        })
        return response.data
    }
    catch(error){
        return error
    }
}

export {getAllPlaces, postPlace, postPlaceFestivals, postPlaceImages, deletePlace, deletePlaceImage, deletePlaceFestival}