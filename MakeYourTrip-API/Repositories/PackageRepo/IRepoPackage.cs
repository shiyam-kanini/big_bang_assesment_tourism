using MakeYourTrip_API.ModelsDTO.PackageModels;
using MakeYourTrip_API.ModelsResponse.PackageResponses;

namespace MakeYourTrip_API.Repositories.PackageRepo
{
    public interface IRepoPackage
    {
        Task<PackageResponse> GetAllPackages();
        Task<PackageResponse> GetPackageById(string id);
        Task<PackageResponse> PostPackage(BookPackageRequest packageData);
        Task<PackageResponse> PutPackage(BookPackageRequest packageData, string id);
        Task<PackageResponse> DeletePackage(string id);
    }
}
