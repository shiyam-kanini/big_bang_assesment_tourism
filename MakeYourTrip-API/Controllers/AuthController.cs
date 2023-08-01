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
        private readonly IRepoRegister _registerContext;
        private readonly IRepoLogin _loginContext;
        public AuthController(IRepoRegister registerContext, IRepoLogin loginContext)
        {
            this._registerContext = registerContext;
            this._loginContext = loginContext;
        }
        [HttpPost]
        [Route("register/employee")]
        public  async Task<EmployeeRegisterResponse> RegisterEmployee(EmployeeRequest registerData)
        {
            return await _registerContext.RegisterEmployee(registerData);
        }
        [HttpPost]
        [Route("register/user")]
        public async Task<UserRegisterResponse> RegisterUser(UserRequest registerData)
        {
            return await _registerContext.RegisterUser(registerData);
        }
        [HttpPost]
        [Route("login/employee")]
        public async Task<LoginResponse> LoginEmployee(LoginRequest loginData)
        {
            return await _loginContext.EmployeeLogin(loginData);
        }
        [HttpPost]
        [Route("login/user")]
        public async Task<LoginResponse> LoginUser(LoginRequest loginData)
        {
            return await _loginContext.UserLogin(loginData);
        }
        [HttpPut]
        [Route("logout")]
        public async Task<LoginResponse> Logout(string sessionId)
        {
            return await _loginContext.Logout(sessionId);
        }
    }
}
