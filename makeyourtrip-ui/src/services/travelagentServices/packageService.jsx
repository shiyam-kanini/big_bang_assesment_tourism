import api from "../../api/api";

const PACKAGE_GET_URL = '/Package/actions/getallpackages'
const PACKAGE_POST_URL = '/Package/actions/insertpackage'
const PACKAGE_PUT_URL = '/Package/actions/updatepackage'
const PACKAGE_DELETE_URL = '/Package/actions/deletepackage'

const getAllPackages = async () => {
    try {
      const response = await api.get(PACKAGE_GET_URL, {
        headers: {
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };

  const postPackage = async (data) => {
    try {
      const response = await api.post(PACKAGE_POST_URL, data, {
        headers: {
            "Content-type" : "application/json",
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };

  const putPackage = async (data, id) => {
    try {
      const response = await api.put(`${PACKAGE_PUT_URL}?id=${id}`, data, {
        headers: {
            "Content-type" : "application/json",
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };

  const deletePackage = async (id) => {
    try {
      const response = await api.delete(`${PACKAGE_DELETE_URL}?id=${id}`, {
        headers: {
            "Content-type" : "text-plain",
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };

  export {getAllPackages, postPackage, putPackage, deletePackage}