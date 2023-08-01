using MakeYourTrip_API.ModelsDTO.PlaceModels;
using MakeYourTrip_API.ModelsResponse;
using MakeYourTrip_API.ModelsResponse.PlaceResponse;

namespace MakeYourTrip_API.Repositories.PlaceRepo
{
    public interface IRepoAddPlace
    {
        Task<CommonResponse> InsertPlace(PlaceRequest placeData);
        Task<CommonResponse> InsertPlaceImages(PlaceImgRequest placeImageGallery);
        Task<CommonResponse> InsertPlaceFestivals(PlaceFestivalRequest placeFestivalData);
        
    }
}
