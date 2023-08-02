using MakeYourTrip_API.Models;

namespace MakeYourTrip_API.ModelsResponse.PlaceResponse
{
    public class PlaceGetResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public List<Place> Places { get; set; }
        public List<PlaceImage> PlaceImages { get; set; }
        public List<PlaceFestival> Festival { get; set; }
    }
}
