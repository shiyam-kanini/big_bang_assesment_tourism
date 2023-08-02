using System.ComponentModel.DataAnnotations;

namespace MakeYourTrip_API.Models
{
    public class Coupon
    {
        [Key]
        public string? CouponId { get; set; }
        public string? CouponName { get; set; }
        public string? CouponDescription { get; set; }
        public string? CouponExpiration { get; set; }
        public int? CouponDiscountPercentage { get; set; }
        public Package? ApplicablePackage { get; set; }
        public ICollection<PackageBooking>? Bookings { get; set; }
    }
}
