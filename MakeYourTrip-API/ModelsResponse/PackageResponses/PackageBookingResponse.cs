using MakeYourTrip_API.Models;

namespace MakeYourTrip_API.ModelsResponse.PackageResponses
{
    public class PackageBookingResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public PackageBooking? PackageBooking { get; set; }
    }
}
