using MakeYourTrip_API.ModelsDTO.PackageModels;
using MakeYourTrip_API.ModelsResponse.PackageResponses;
using MakeYourTrip_API.Repositories.PackageRepo;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class CouponController : ControllerBase
    {
        private readonly IRepoCoupon _repoCoupon;
        public CouponController(IRepoCoupon repoCoupon)
        {
            _repoCoupon = repoCoupon;
        }
        [HttpGet]
        [Route("getallcoupons")]
        public async Task<CouponResponse> GetAllCoupons()
        {
            return await _repoCoupon.GetAllCoupons();
        }
        [HttpGet]
        [Route("getcouponbyid")]
        public async Task<CouponResponse> GetCouponById(string id)
        {
            return await _repoCoupon.GetCouponById(id);
        }
        [HttpPost]
        [Route("insertcoupon")]
        public async Task<CouponResponse> InsertCoupon(CouponRequest couponData)
        {
            return await _repoCoupon.PostCoupon(couponData);
        }
        [HttpPut]
        [Route("updatecoupon")]
        public async Task<CouponResponse> UpdateCoupon(CouponRequest couponData, string id)
        {
            return await  _repoCoupon.PutCoupon(couponData, id);
        }
        [HttpDelete]
        [Route("deletecoupon")]
        public async Task<CouponResponse> DeleteCoupon(string id)
        {
            return await _repoCoupon.DeleteCoupon(id);
        }
    }
}
