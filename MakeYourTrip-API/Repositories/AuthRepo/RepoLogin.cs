using MakeYourTrip_API.ModelsDTO.AuthModels;
using MakeYourTrip_API.ModelsResponse.AuthResponse;

namespace MakeYourTrip_API.Repositories.AuthRepo
{
    public class RepoLogin : IRepoLogin
    {
        public Task<LoginResponse> EmployeeLogin(LoginRequest loginData)
        {
            throw new NotImplementedException();
        }
        public Task<LoginResponse> UserLogin(LoginRequest loginData)
        {
            throw new NotImplementedException();
        }
    }
}
