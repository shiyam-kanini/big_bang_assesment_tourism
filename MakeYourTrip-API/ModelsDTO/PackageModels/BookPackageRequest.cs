namespace MakeYourTrip_API.ModelsDTO.PackageModels
{
    public class BookPackageRequest
    {
        public string? PackageName { get; set; }
        public string? PackageType { get; set; }
        public string? PackageDescription { get; set; }
        public int PlaceCount { get; set; }
        public int PackagePrice { get; set; }
        public string? PackageImgURL { get; set; }
    }
}
