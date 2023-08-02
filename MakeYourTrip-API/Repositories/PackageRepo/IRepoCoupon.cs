using MakeYourTrip_API.ModelsDTO.PackageModels;
using MakeYourTrip_API.ModelsResponse.PackageResponses;

namespace MakeYourTrip_API.Repositories.PackageRepo
{
    public interface IRepoCoupon
    {
        Task<CouponResponse> GetAllCoupons();
        Task<CouponResponse> GetCouponById(string id);
        Task<CouponResponse> PostCoupon(CouponRequest couponData);
        Task<CouponResponse> PutCoupon(CouponRequest couponData, string id);
        Task<CouponResponse> DeleteCoupon(string id);
    }
}
