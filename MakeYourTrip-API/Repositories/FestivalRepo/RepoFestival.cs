using MakeYourTrip_API.Models;
using MakeYourTrip_API.ModelsDTO;
using MakeYourTrip_API.ModelsResponse;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip_API.Repositories.FestivalRepo
{
    public class RepoFestival : IRepoFestival
    {
        private readonly Random random= new Random();
        private readonly AppDbContext _context;
        public RepoFestival(AppDbContext context)
        {
            _context = context;
        }
        Festival newFestival = new Festival();
        FestivalResponse festivalResponse= new FestivalResponse();
        List<Festival> festivals = new List<Festival>();
        public async Task<FestivalResponse> DeleteFestival(string id)
        {
            try
            {
                newFestival = await _context.Festivals.FindAsync(id);
                if (newFestival == null)
                {
                    AddFestivalResponse(false, $"No Festival found with id : {id} ", festivals); return festivalResponse;
                }
                _context.Festivals.Remove(newFestival);
                await _context.SaveChangesAsync();
                AddFestivalResponse(true, $"Festival {newFestival.FestivalId}({newFestival.FestivalName}) has been deleted", festivals); return festivalResponse;
            }
            catch (Exception ex)
            {
                AddFestivalResponse(false, ex.Message, festivals); return festivalResponse;
            }
        }

        public async Task<FestivalResponse> GetAllFestivals()
        {
            try
            {
                festivals = await _context.Festivals.ToListAsync();
                if (festivals.Count <= 0)
                {
                    AddFestivalResponse(false, "No Data Found", festivals); return festivalResponse;
                }
                else
                {
                    AddFestivalResponse(true, $"{festivals.Count} Records found", festivals); return festivalResponse;
                }
            }
            catch(Exception ex)
            {
                AddFestivalResponse(true, ex.Message, festivals); return festivalResponse;
            }

        }

        public async Task<FestivalResponse> GetFestivalById(string id)
        {
            try
            {
                Festival? isFestival = await _context.Festivals.FindAsync(id);
                if (isFestival == null)
                {
                    AddFestivalResponse(false, $"No Festival found with id : {id} ", festivals); return festivalResponse;
                }
                festivals.Add(isFestival);
                AddFestivalResponse(true, $"{festivals.Count} records found for id {id}", festivals); return festivalResponse;
            }
            catch(Exception ex)
            {
                AddFestivalResponse(false, ex.Message, festivals); return festivalResponse;
            }
        }

        public async Task<FestivalResponse> PostFestival(FestivalRequest festivalData)
        {
            try
            {
                Festival? isFestival = await _context.Festivals.Where(x => x.FestivalName.Equals(festivalData.FestivalName)).FirstOrDefaultAsync();
                if(isFestival != null)
                {
                    AddFestivalResponse(false, $"Festival {festivalData.FestivalName} already exists", festivals); return festivalResponse;
                }
                AddFestival($"FESID{random.Next(1000, 9999)}", festivalData);
                await _context.AddAsync(newFestival);
                await _context.SaveChangesAsync();
                AddFestivalResponse(true, $"Festival {festivalData.FestivalName} has been added with id {newFestival.FestivalId}", festivals); return festivalResponse;
            }
            catch (Exception ex)
            {
                AddFestivalResponse(false, ex.Message, festivals); return festivalResponse;
            }
        }

        public async Task<FestivalResponse> PutFestival(FestivalRequest festivalData, string id)
        {
            try
            {
                AddFestival(id, festivalData);
                _context.Festivals.Update(newFestival);
                await _context.SaveChangesAsync();
                AddFestivalResponse(true, $"Festival {festivalData.FestivalName} has been Updated", festivals); return festivalResponse;
            }
            catch (Exception ex)
            {
                AddFestivalResponse(false, ex.Message, festivals); return festivalResponse;
            }
        }
        public void AddFestivalResponse(bool status, string message, List<Festival> festivals) 
        {
            festivalResponse = new()
            {
                Status = status,
                Messsage = message,
                Festival = festivals
            };
        }
        public void AddFestival(string festivalId, FestivalRequest festivalData)
        {
            newFestival = new()
            {
                FestivalId = festivalId,
                FestivalName = festivalData.FestivalName,
                FestivalDescription = festivalData.FestivalDescription,
                FestivalMonth = festivalData.FestivalMonth,
            };
        }
    }
}
