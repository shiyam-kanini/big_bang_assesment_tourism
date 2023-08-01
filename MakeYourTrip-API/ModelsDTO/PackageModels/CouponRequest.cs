using MakeYourTrip_API.Models;

namespace MakeYourTrip_API.ModelsDTO.PackageModels
{
    public class CouponRequest
    {
        public string? CouponName { get; set; }
        public string? CouponDescription { get; set; }
        public string? CouponExpiration { get; set; }
        public int? CouponDiscountPercentage { get; set; }
        public string? ApplicablePackageId { get; set; }
    }
}
