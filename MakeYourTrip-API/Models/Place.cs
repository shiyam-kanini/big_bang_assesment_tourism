using System.ComponentModel.DataAnnotations;

namespace MakeYourTrip_API.Models
{
    public class Place
    {
        [Key]
        public string? PlaceId { get; set; }
        public string? PlaceName { get; set; }
        public string? PlaceType { get; set;}
        public string? PlaceDescription { get; set; }
        public string? placeCountry { get; set; }
        public string? PlaceState { get; set; }
        public bool PlaceStatus { get; set;}
        public string? PlaceUrl { get; set;}
        public int PlaceRating { get; set; }
        public bool AmenityParking { get; set; }
        public bool AmenityBathroom { get; set; }
        public int VisitingDay { get; set; }
        public int? PlacePrice { get; set; }
        public ICollection<PlaceImage>? PlaceImages{ get; set; }
        public ICollection<PlaceFestival>? PlaceFestivals{ get; set; }
    }
}
