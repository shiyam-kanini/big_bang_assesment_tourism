using System.ComponentModel.DataAnnotations;

namespace MakeYourTrip_API.Models
{
    public class PlaceImage
    {
        [Key]
        public string? PlaceImageId { get; set; }
        public Place? Place_Id_I { get; set; }
        public string? PlaceImageURL { get; set; }
    }
}
