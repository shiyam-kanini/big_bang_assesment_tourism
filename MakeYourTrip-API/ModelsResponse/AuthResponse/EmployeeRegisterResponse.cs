using MakeYourTrip_API.ModelDTO.AuthModels;
using MakeYourTrip_API.Models;

namespace MakeYourTrip_API.ModelsResponse.AuthResponse
{
    public class EmployeeRegisterResponse
    {
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public EmployeeRequest? Employee { get; set; }
    }
}
