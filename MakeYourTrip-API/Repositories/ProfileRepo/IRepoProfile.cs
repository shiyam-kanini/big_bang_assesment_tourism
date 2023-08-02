using MakeYourTrip_API.ModelDTO.AuthModels;
using MakeYourTrip_API.Models;
using MakeYourTrip_API.ModelsDTO.AuthModels;
using MakeYourTrip_API.ModelsResponse.AuthResponse;

namespace MakeYourTrip_API.Repositories.ProfileRepo
{
    public interface IRepoProfile
    {
        Task<Employee> GetEmployeeProfile(string EmployeeId);
        Task<User> GetUserProfile(string UserId);
        Task<EmployeeRegisterResponse> UpdateEmployeeProfile(EmployeeRequest updateData, string employeeId);

        Task<UserRegisterResponse> UpdateUserProfile(UserRequest updateData, string userId);

    }
}
