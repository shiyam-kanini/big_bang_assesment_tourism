using System.ComponentModel.DataAnnotations;

namespace MakeYourTrip_API.Models
{
    public class PackageBookingPlace
    {
        [Key]
        public string? PBPId { get; set; }
        public PackageBooking? PackageBooking_Id { get; set; }
        public Place? Place_PB_Id { get; set; }
    }
}
