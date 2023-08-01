using MakeYourTrip_API.Models;
using MakeYourTrip_API.ModelsDTO;

namespace MakeYourTrip_API.ModelsResponse
{
    public class FestivalResponse
    {
        public bool Status { get; set; }
        public string? Messsage { get; set; }
        public List<Festival>? Festival { get; set; }
    }
}
