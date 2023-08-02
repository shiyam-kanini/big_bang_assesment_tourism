using MakeYourTrip_API.Models;

namespace MakeYourTrip_API.ModelsDTO.PackageModels
{
    public class InitiateBooking
    {
        public string? User_Id { get; set; }
        public bool isBooking { get; set; }
    }
}
