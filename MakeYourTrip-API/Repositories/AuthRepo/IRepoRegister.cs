using MakeYourTrip_API.ModelDTO.AuthModels;
using MakeYourTrip_API.ModelsDTO.AuthModels;
using MakeYourTrip_API.ModelsResponse.AuthResponse;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip_API.Repositories.AuthRepo
{
    public interface IRepoRegister
    {
        Task<EmployeeRegisterResponse> RegisterEmployee(EmployeeRequest registerData);
        Task<UserRegisterResponse> RegisterUser(UserRequest registerData);
    }
}
