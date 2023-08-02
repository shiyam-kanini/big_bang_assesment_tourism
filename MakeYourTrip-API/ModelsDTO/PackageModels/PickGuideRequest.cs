namespace MakeYourTrip_API.ModelsDTO.PackageModels
{
    public class PickGuideRequest
    {
        public string? BookId { get; set; }
        public string? GuideId { get; set; }
        public int GuideCost { get; set; }
    }
}
