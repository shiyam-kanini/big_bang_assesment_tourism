namespace MakeYourTrip_API.ModelsDTO.PlaceModels
{
    public class PlaceRequest
    {
        public string? PlaceName { get; set; }
        public string? PlaceType { get; set; }
        public string? PlaceDescription { get; set; }
        public string? placeCountry { get; set; }
        public string? PlaceState { get; set; }
        public bool PlaceStatus { get; set; }
        public string? PlaceUrl { get; set; }
        public bool AmenityParking { get; set; }
        public bool AmenityBathroom { get; set; }
        public int VisitingDay { get; set; }
        public int Price { get; set; }
    }
}
