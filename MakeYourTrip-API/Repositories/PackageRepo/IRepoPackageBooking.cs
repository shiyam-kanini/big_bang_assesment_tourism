using MakeYourTrip_API.ModelsDTO.PackageModels;
using MakeYourTrip_API.ModelsResponse;
using MakeYourTrip_API.ModelsResponse.PackageResponses;

namespace MakeYourTrip_API.Repositories.PackageRepo
{
    public interface IRepoPackageBooking
    {
        Task<PackageBookingResponse> InitiateBookingSession(InitiateBooking initiateData);
        Task<PackageBookingResponse> AddPackage(string packageId, string bookId);
        Task<PackageBookingResponse> AddPlaces(BookPlaceRequest bookPlaceData);
        Task<PackageBookingResponse> PickDate(PickDateRequest pickDateData);
        Task<PackageBookingResponse> ChooseHotel(ChooseHotelRequest chooseHotelData);
        Task<PackageBookingResponse> PickGuide(PickGuideRequest pickGuideData);
        Task<PackageBookingResponse> GenerateBill(string BookId);
        Task<PackageBookingResponse> ApplyCoupon(ApplyCouponRequest applyCouuponData);
    }
}
