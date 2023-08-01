using MakeYourTrip_API.Models;
using MakeYourTrip_API.ModelsDTO.PackageModels;
using MakeYourTrip_API.ModelsResponse.PackageResponses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace MakeYourTrip_API.Repositories.PackageRepo
{
    public class RepoPackage : IRepoPackage
    {
        private readonly AppDbContext _context;
        private readonly Random _random = new Random();
        public RepoPackage(AppDbContext context)
        {
            _context = context;
        }
        PackageResponse packageResponse = new();
        Package? newPackage = new();
        List<Package> packages = new();
        public async Task<PackageResponse> DeletePackage(string id)
        {
            newPackage = await _context.Packages.FindAsync(id);
            if(newPackage == null)
            {
                AddPackageResponse(false, $"No Package found with id : {id}");return packageResponse;
            }
            await _context.Packages.Where(x => x.PackageId.Equals(id)).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            AddPackageResponse(true, $"{newPackage.PackageId}({newPackage.PackageName}) has been deleted");
            return packageResponse;
        }

        public async Task<PackageResponse> GetAllPackages()
        {
            packages = await _context.Packages.ToListAsync();
            if(packages.Count <= 0)
            {
                AddPackageResponse(false, $"No Packages found");return packageResponse;
            }
            AddPackageResponse(true, $"{packages.Count} records found");return packageResponse;
        }

        public Task<PackageResponse> GetPackageById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<PackageResponse> PostPackage(BookPackageRequest packageData)
        {
            newPackage = await _context.Packages.Where(x => x.PackageName.Equals(packageData.PackageName)).FirstOrDefaultAsync();
            if(newPackage != null)
            {
                AddPackageResponse(false, $"Package {packageData.PackageName} already found under id {newPackage.PackageId}");return packageResponse;
            }
            AddPackage($"PAKGID{_random.Next(10000, 99999)}", packageData);
            await _context.Packages.AddAsync(newPackage);
            await _context.SaveChangesAsync();
            AddPackageResponse(true, $"package {packageData.PackageName} has been inserted under id : {newPackage.PackageId}");
            return packageResponse;
        }

        public async Task<PackageResponse> PutPackage(BookPackageRequest packageData, string id)
        {
            AddPackage(id, packageData);
            _context.Packages.Update(newPackage);
            await _context.SaveChangesAsync();
            AddPackageResponse(true, $"package {packageData.PackageName} has been updated");
            return packageResponse;
        }
        public void AddPackage(string packageId, BookPackageRequest packageData)
        {
            newPackage = new()
            {
                PackageId = packageId,
                PackageName = packageData.PackageName,
                PackageDescription= packageData.PackageDescription,
                PackagePrice= packageData.PackagePrice,
                PackageType= packageData.PackageType,
                PlaceCount= packageData.PlaceCount,
                PackageImgURL = packageData.PackageImgURL,
            };
        }
        public void AddPackageResponse (bool status, string message)
        {
            packageResponse = new()
            {
                Status= status,
                Message= message,
                Packages= packages
            };
        }
    }
}
