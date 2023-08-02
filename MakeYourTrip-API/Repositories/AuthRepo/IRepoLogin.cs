using MakeYourTrip_API.ModelDTO.AuthModels;
using MakeYourTrip_API.ModelsDTO.AuthModels;
using MakeYourTrip_API.ModelsResponse.AuthResponse;

namespace MakeYourTrip_API.Repositories.AuthRepo
{
    public interface IRepoLogin
    {
        Task<LoginResponse> EmployeeLogin(LoginRequest loginData);
        Task<LoginResponse> UserLogin(LoginRequest loginData);
        Task<LoginResponse> Logout(string sessionId);
    }
}
