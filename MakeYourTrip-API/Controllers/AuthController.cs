using MakeYourTrip_API.ModelDTO.AuthModels;
using MakeYourTrip_API.ModelsDTO.AuthModels;
using MakeYourTrip_API.ModelsResponse.AuthResponse;
using MakeYourTrip_API.Repositories.AuthRepo;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class AuthController : ControllerBase
    {
        private readonly IRepoRegister repocontext;
        public AuthController(IRepoRegister repocontext)
        {
            this.repocontext = repocontext;
        }
        [HttpPost]
        [Route("register/employee")]
        public  async Task<EmployeeRegisterResponse> RegisterEmployee(EmployeeRequest registerData)
        {
            return await repocontext.RegisterEmployee(registerData);
        }
        [HttpPost]
        [Route("register/user")]
        public async Task<UserRegisterResponse> RegisterUser(UserRequest registerData)
        {
            return await repocontext.RegisterUser(registerData);
        }
    }
}
