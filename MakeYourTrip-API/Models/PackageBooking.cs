using System.ComponentModel.DataAnnotations;

namespace MakeYourTrip_API.Models
{
    public class PackageBooking
    {
        [Key]
        public string? PackageUserId { get; set; }
        public User? User_Id { get; set; }
        public Package? Package_Id { get; set; }
        public Coupon? Coupon_Id { get; set; }
        public Employee? Guide { get; set; }
        public int TotalCost { get; set; }
        public string? Hotel { get; set; }
        public int HotelCost { get; set; }
        public int GuideCost { get; set; }
        public int Gst { get; set; }
        public string? BookingDate { get; set; }
        public string? JourneyDate { get; set; }
        public int JourneyDays { get; set; }
        public bool isBooked { get; set; }
        public bool isBooking { get; set;}
        public bool isPlace { get; set; }

    }
}
