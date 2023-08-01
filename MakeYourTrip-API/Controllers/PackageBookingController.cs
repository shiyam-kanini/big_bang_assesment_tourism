using MakeYourTrip_API.ModelsDTO.PackageModels;
using MakeYourTrip_API.ModelsResponse.PackageResponses;
using MakeYourTrip_API.Repositories.PackageRepo;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class PackageBookingController : ControllerBase
    {
        private readonly IRepoPackageBooking _repoPackageBooking;
        public PackageBookingController(IRepoPackageBooking repoPackageBooking)
        {
            _repoPackageBooking = repoPackageBooking;
        }
        [HttpPost]
        [Route("initiatesession")]
        public async Task<PackageBookingResponse> InitiateSession(InitiateBooking initiateBooking)
        {
            return await _repoPackageBooking.InitiateBookingSession(initiateBooking);
        }
        [HttpPut]
        [Route("addpackage")]
        public async Task<PackageBookingResponse> AddPackage(string packageId, string bookId)
        {
            return await _repoPackageBooking.AddPackage(packageId, bookId);
        }
        [HttpPut]
        [Route("addbookplaces")]
        public async Task<PackageBookingResponse> AddBookPlace(BookPlaceRequest bookPlaceData)
        {
            return await _repoPackageBooking.AddPlaces(bookPlaceData);
        }
        [HttpPut]
        [Route("pickdate")]
        public async Task<PackageBookingResponse> PickDate(PickDateRequest pickDateRequest)
        {
            return await _repoPackageBooking.PickDate(pickDateRequest);
        }
    }
}
