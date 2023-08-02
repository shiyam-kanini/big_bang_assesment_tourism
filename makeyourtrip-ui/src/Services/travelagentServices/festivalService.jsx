import api from "../../api/api";

const FESTIVAL_GET_URL = '/Festival/actions/getallfestivals'
const FESTIVAL_GET_BY_ID_URL = '/Festival/actions/getallfestivalbyid'
const FESTIVAL_POST_URL = '/Festival/actions/postfestival'
const FESTIVAL_PUT_URL = '/Festival/actions/putfestival'
const FESTIVAL_DELETE_URL = '/Festival/actions/deletefestival'

const getAllFestivals = async () => {
    try {
      const response = await api.get(FESTIVAL_GET_URL, {
        headers: {
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };

  const getFestivalById = async (id) => {
    try {
      const response = await api.get(`${FESTIVAL_GET_BY_ID_URL}?id=${id}`, {
        headers: {
            "Content-type" : "text/plain",
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };

  const postFestival = async (data) => {
    try {
      const response = await api.post(FESTIVAL_POST_URL, data, {
        headers: {
            "Content-type" : "application/json",
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };

  const putFestival = async (data, id) => {
    try {
      const response = await api.put(`${FESTIVAL_PUT_URL}?id=${id}`, data, {
        headers: {
            "Content-type" : "application/json",
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };

  const deleteFestival = async (id) => {
    try {
      const response = await api.delete(`${FESTIVAL_DELETE_URL}?id=${id}`, {
        headers: {
            "Content-type" : "text-plain",
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };

  export {getAllFestivals, getFestivalById, postFestival, putFestival, deleteFestival}