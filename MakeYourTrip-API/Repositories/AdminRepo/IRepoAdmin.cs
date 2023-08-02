using MakeYourTrip_API.Models;
using MakeYourTrip_API.ModelsDTO.AdminModels;
using MakeYourTrip_API.ModelsResponse;

namespace MakeYourTrip_API.Repositories.AdminRepo
{
    public interface IRepoAdmin
    {
        Task<CommonResponse> EnableEmployee(EnableEmployeeRequest enableEmployeeRequest);
    }
}
