using MakeYourTrip_API.Models;

namespace MakeYourTrip_API.ModelsResponse.PackageResponses
{
    public class PackageResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public List<Package>? Packages { get; set; }
    }
}
