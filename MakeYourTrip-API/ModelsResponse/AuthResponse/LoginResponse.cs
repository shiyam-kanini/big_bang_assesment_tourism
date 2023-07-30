using MakeYourTrip_API.Models;

namespace MakeYourTrip_API.ModelsResponse.AuthResponse
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public LoginLog? LoginLog { get; set; }
    }
}
