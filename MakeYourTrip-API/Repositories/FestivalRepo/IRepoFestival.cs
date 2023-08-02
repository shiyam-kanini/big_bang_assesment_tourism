using MakeYourTrip_API.ModelsDTO;
using MakeYourTrip_API.ModelsResponse;

namespace MakeYourTrip_API.Repositories.FestivalRepo
{
    public interface IRepoFestival
    {
        Task<FestivalResponse> GetAllFestivals();
        Task<FestivalResponse> GetFestivalById(string id);
        Task<FestivalResponse> PostFestival(FestivalRequest festivalData);
        Task<FestivalResponse> PutFestival(FestivalRequest festivalData, string id);
        Task<FestivalResponse> DeleteFestival(string id);
    }
}
