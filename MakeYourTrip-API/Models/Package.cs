using System.ComponentModel.DataAnnotations;

namespace MakeYourTrip_API.Models
{
    public class Package
    {
        [Key]
        public string? PackageId { get; set; }
        public string? PackageName { get; set; }
        public string? PackageType { get; set; }
        public string? PackageDescription { get; set; }
        public int PlaceCount { get; set; }
        public ICollection<Coupon>? Coupons { get; set; }
        public ICollection<PackageBooking> Bookings { get; set; }
    }
}
