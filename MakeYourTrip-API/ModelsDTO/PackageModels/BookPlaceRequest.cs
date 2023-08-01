namespace MakeYourTrip_API.ModelsDTO.PackageModels
{
    public class BookPlaceRequest
    {
        public string? bookId { get; set; }
        public List<string>? PlaceIds { get; set; }
    }
}
