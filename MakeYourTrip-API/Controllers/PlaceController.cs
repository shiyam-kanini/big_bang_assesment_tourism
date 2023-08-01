using MakeYourTrip_API.ModelsDTO.PlaceModels;
using MakeYourTrip_API.ModelsResponse;
using MakeYourTrip_API.ModelsResponse.PlaceResponse;
using MakeYourTrip_API.Repositories.PlaceRepo;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class PlaceController : ControllerBase
    {
        private readonly IRepoAddPlace _repoAddPlace;
        private readonly IRepoPlace _repoPlace;
        public PlaceController(IRepoAddPlace repoAddPlace, IRepoPlace repoPlace)
        {
            _repoAddPlace = repoAddPlace;
            _repoPlace = repoPlace;
        }
        [HttpPost]
        [Route("addplace")]
        public async Task<CommonResponse> AddPlace(PlaceRequest placeData)
        {
            return await _repoAddPlace.InsertPlace(placeData);
        }
        [HttpPost]
        [Route("addplaceimages")]
        public async Task<CommonResponse> AddPlaceImages(PlaceImgRequest placeData)
        {
            return await _repoAddPlace.InsertPlaceImages(placeData);
        }
        [HttpPost]
        [Route("addplacefestivals")]
        public async Task<CommonResponse> AddPlaceFestival(PlaceFestivalRequest placeData)
        {
            return await _repoAddPlace.InsertPlaceFestivals(placeData);
        }
        [HttpDelete]
        [Route("deleteplace")]
        public async Task<CommonResponse> RemovePlace(string placeId)
        {
            return await _repoPlace.DeletePlace(placeId);
        }
        [HttpDelete]
        [Route("deleteplacefestival")]
        public async Task<CommonResponse> RemovePlaceFestival(string id)
        {
            return await _repoPlace.DeletePlaceFestival(id);
        }
        [HttpDelete]
        [Route("deleteplaceimage")]
        public async Task<CommonResponse> RemovePlaceImage(string id)
        {
            return await _repoPlace.DeletePlaceImage(id);
        }
        [HttpGet]
        [Route("getallplaces")]
        public async Task<PlaceGetResponse> GetAllPlaces()
        {
            return await _repoPlace.GetAllPlace();
        }

    }
}
