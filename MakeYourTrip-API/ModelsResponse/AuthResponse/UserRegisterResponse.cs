using MakeYourTrip_API.ModelDTO.AuthModels;
using MakeYourTrip_API.ModelsDTO.AuthModels;

namespace MakeYourTrip_API.ModelsResponse.AuthResponse
{
    public class UserRegisterResponse
    {
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public UserRequest? User { get; set; }
    }
}
