using MakeYourTrip_API.ModelsDTO;
using MakeYourTrip_API.ModelsResponse;
using MakeYourTrip_API.Repositories.FestivalRepo;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class FestivalController : ControllerBase
    {
        private readonly IRepoFestival _festivalContext;
        public FestivalController(IRepoFestival festivalContext)
        {
            _festivalContext = festivalContext;
        }
        [HttpGet]
        [Route("getallfestivals")]
        public async Task<FestivalResponse> GetAllFestivals()
        {
            return await _festivalContext.GetAllFestivals();
        }
        [HttpGet]
        [Route("getallfestivalbyid")]
        public async Task<FestivalResponse> GetFestivalById(string id)
        {
            return await _festivalContext.GetFestivalById(id);
        }
        [HttpPost]
        [Route("postfestival")]
        public async Task<FestivalResponse> InsertFestival(FestivalRequest festivaldata)
        {
            return await _festivalContext.PostFestival(festivaldata);
        }
        [HttpPut]
        [Route("putfestival")]
        public async Task<FestivalResponse> UpdateFestival(FestivalRequest festivaldata, string id)
        {
            return await _festivalContext.PutFestival(festivaldata, id);
        }
        [HttpDelete]
        [Route("deletefestival")]
        public async Task<FestivalResponse> DeleteFestival(string id)
        {
            return await _festivalContext.DeleteFestival(id);
        }
    }
}
