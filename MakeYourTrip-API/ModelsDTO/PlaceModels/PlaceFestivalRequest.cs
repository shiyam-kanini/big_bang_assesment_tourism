using MakeYourTrip_API.Models;

namespace MakeYourTrip_API.ModelsDTO.PlaceModels
{
    public class PlaceFestivalRequest
    {
        public string? PlaceId { get; set; }
        public List<string>? Festival { get; set; }
    }
}
