using MakeYourTrip_API.ModelDTO.AuthModels;
using MakeYourTrip_API.Models;
using MakeYourTrip_API.ModelsDTO.AuthModels;
using MakeYourTrip_API.ModelsResponse.AuthResponse;
using MakeYourTrip_API.Repositories.ProfileRepo;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class ProfileController : ControllerBase
    {
        private readonly IRepoProfile _repoProfile;
        public ProfileController(IRepoProfile repoProfile)
        {
            _repoProfile = repoProfile;
        }
        [HttpGet]
        [Route("getemployeeprofile")]
        public async Task<Employee> GetEmployeeProfile(string id)
        {
            return await _repoProfile.GetEmployeeProfile(id);
        }
        [HttpGet]
        [Route("getuserprofile")]
        public async Task<User> GetUserProfile(string id)
        {
            return await _repoProfile.GetUserProfile(id);
        }
        [HttpPut]
        [Route("updateemployeeprofile")]
        public async Task<EmployeeRegisterResponse> UpdateEmployeeProfile(EmployeeRequest updateData, string id)
        {
            return await _repoProfile.UpdateEmployeeProfile(updateData, id);
        }
        [HttpPut]
        [Route("updateuserprofile")]
        public async Task<UserRegisterResponse> UpdateUserProfile(UserRequest updateData, string id)
        {
            return await _repoProfile.UpdateUserProfile(updateData, id);
        }
    }
}
