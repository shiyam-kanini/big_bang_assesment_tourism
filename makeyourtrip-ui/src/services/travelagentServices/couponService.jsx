import api from "../../api/api";

const COUPON_GET_URL = '/Coupon/actions/getallcoupons'
const COUPON_GET_BY_ID = '/Coupon/actions/getcouponbyid'
const COUPON_POST_URL = '/Coupon/actions/insertcoupon'
const COUPON_PUT_URL = '/Coupon/actions/updatecoupon'
const COUPON_DELETE_URL = '/Coupon/actions/deletecoupon'

const getAllCoupons = async () => {
    try {
      const response = await api.get(COUPON_GET_URL, {
        headers: {
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };

  const getCouponById = async (id) => {
    try {
      const response = await api.get(`${COUPON_GET_BY_ID}?id=${id}`, {
        headers: {
            "Content-type" : "text-plain",
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };

  const postCoupon = async (data) => {
    try {
      const response = await api.post(COUPON_POST_URL, data, {
        headers: {
            "Content-type" : "application/json",
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };

  const putCoupon = async (data, id) => {
    try {
      const response = await api.put(`${COUPON_PUT_URL}?id=${id}`, data, {
        headers: {
            "Content-type" : "application/json",
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };

  const deleteCoupon = async (id) => {
    try {
      const response = await api.delete(`${COUPON_DELETE_URL}?id=${id}`, {
        headers: {
            "Content-type" : "text-plain",
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };

  export {getAllCoupons, getCouponById, postCoupon, putCoupon, deleteCoupon}