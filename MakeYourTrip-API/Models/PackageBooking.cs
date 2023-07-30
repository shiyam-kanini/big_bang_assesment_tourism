using System.ComponentModel.DataAnnotations;

namespace MakeYourTrip_API.Models
{
    public class PackageBooking
    {
        [Key]
        public string? PackageUserId { get; set; }
        public User? User_Id { get; set; }
        public List<Place>? Places_Id { get; set; }
        public Package? Package_Id { get; set; }
        public Coupon? Coupon_Id { get; set; }
        public Employee? Guide { get; set; }
        public string? BookingDate { get; set; }
        public string? JourneyDate { get; set; }
        public int JourneyDays { get; set; }
    }
}
