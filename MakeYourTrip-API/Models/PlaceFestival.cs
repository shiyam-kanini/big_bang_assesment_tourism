using System.ComponentModel.DataAnnotations;

namespace MakeYourTrip_API.Models
{
    public class PlaceFestival
    {
        [Key]
        public string? PlaceFestivalId { get; set; }
        public Place? Place { get; set; }
        public Festival? Festival { get; set;}
    }
}
