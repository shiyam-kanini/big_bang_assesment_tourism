using MakeYourTrip_API.ModelsDTO.AdminModels;
using MakeYourTrip_API.ModelsResponse;
using MakeYourTrip_API.Repositories.AdminRepo;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class AdminController : ControllerBase
    {
        private readonly IRepoAdmin _repoAdmin;
        public AdminController(IRepoAdmin repoAdmin)
        {
            _repoAdmin = repoAdmin;
        }
        [HttpPut]
        [Route("enableemployee")]
        public async Task<CommonResponse> EnableEmployee(EnableEmployeeRequest enableData)
        {
            return await _repoAdmin.EnableEmployee(enableData);
        }
    }
}
