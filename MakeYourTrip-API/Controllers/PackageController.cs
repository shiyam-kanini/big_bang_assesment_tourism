using MakeYourTrip_API.ModelsDTO.PackageModels;
using MakeYourTrip_API.ModelsResponse.PackageResponses;
using MakeYourTrip_API.Repositories.PackageRepo;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class PackageController : ControllerBase
    {
        private readonly IRepoPackage _repoPackage;
        public PackageController(IRepoPackage repoPackage)
        {
            _repoPackage = repoPackage;
        }
        [HttpGet]
        [Route("getallpackages")]
        public async Task<PackageResponse> GetAllPackages()
        {
            return await _repoPackage.GetAllPackages();
        }
        [HttpPost]
        [Route("insertpackage")]
        public async Task<PackageResponse> InsertPackage(BookPackageRequest packageData)
        {
            return await _repoPackage.PostPackage(packageData);
        }
        [HttpPut]
        [Route("updatepackage")]
        public async Task<PackageResponse> UpdatePackage(BookPackageRequest packageData, string id)
        {
            return await _repoPackage.PutPackage(packageData, id);
        }
        [HttpDelete]
        [Route("deletepackage")]
        public async Task<PackageResponse> DeletePackage(string id)
        {
            return await _repoPackage.DeletePackage(id);
        }
    }
}
