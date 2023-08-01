using MakeYourTrip_API.Models;

namespace MakeYourTrip_API.ModelsResponse.PackageResponses
{
    public class CouponResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public List<Coupon>? Coupons { get; set; }
    }
}
