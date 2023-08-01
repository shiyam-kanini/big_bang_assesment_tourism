using MakeYourTrip_API.ModelsResponse;
using MakeYourTrip_API.ModelsResponse.PlaceResponse;

namespace MakeYourTrip_API.Repositories.PlaceRepo
{
    public interface IRepoPlace
    {
        Task<PlaceGetResponse> GetAllPlace();
        Task<CommonResponse> DeletePlace(string id);
        Task<CommonResponse> DeletePlaceImage(string id);
        Task<CommonResponse>  DeletePlaceFestival(string id);
    }
}
