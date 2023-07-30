using System.ComponentModel.DataAnnotations;

namespace MakeYourTrip_API.Models
{
    public class Festival
    {
        [Key]
        public string? FestivalId { get; set; }
        public string? FestivalName { get; set; }
        public string? FestivalDescription { get; set; }
        public string? FestivalMonth { get; set; }
    }
}
