namespace MakeYourTrip_API.ModelsDTO.PackageModels
{
    public class ChooseHotelRequest
    {
        public string? BookId { get; set; }
        public string? HotelId { get; set; }
        public int HotelCost { get; set; }
    }
}
