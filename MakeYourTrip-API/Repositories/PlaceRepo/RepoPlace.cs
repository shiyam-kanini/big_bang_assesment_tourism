using MakeYourTrip_API.Models;
using MakeYourTrip_API.ModelsResponse;
using MakeYourTrip_API.ModelsResponse.PlaceResponse;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MakeYourTrip_API.Repositories.PlaceRepo
{
    public class RepoPlace : IRepoPlace
    {
        private readonly AppDbContext _context;
        public RepoPlace(AppDbContext context)
        {
            _context = context;
        }
        PlaceGetResponse getResponse = new();
        CommonResponse commonResponse = new();
        List<Place> places = new();
        List<PlaceFestival> festivals = new();
        List<PlaceImage> images = new();
        public async Task<CommonResponse> DeletePlaceFestival(string id)
        {
            try
            {
                PlaceFestival? festival = await _context.PlacesFestivals.FindAsync(id);
                if (festival == null)
                {
                    AddCommonResponse(false, $"No festivals found for id : {id}"); return commonResponse;
                }
                await _context.PlacesFestivals.Where(x => x.PlaceFestivalId.Equals(id)).ExecuteDeleteAsync();
                await _context.SaveChangesAsync();
                AddCommonResponse(true, $"Festival with {id} deleted");return commonResponse;
            }
            catch (Exception ex)
            {
                AddCommonResponse(false, ex.Message);
                return commonResponse;
            }
        }

        public async Task<CommonResponse> DeletePlaceImage(string id)
        {
            try
            {
                PlaceImage? festival = await _context.PlacesImages.FindAsync(id);
                if (festival == null)
                {
                    AddCommonResponse(false, $"No Images found for id : {id}"); return commonResponse;
                }
                await _context.PlacesImages.Where(x => x.PlaceImageId.Equals(id)).ExecuteDeleteAsync();
                await _context.SaveChangesAsync();
                AddCommonResponse(true, $"Image with {id} deleted"); return commonResponse;
            }
            catch (Exception ex)
            {
                AddCommonResponse(false, ex.Message);
                return commonResponse;
            }
        }

        public async Task<CommonResponse> DeletePlace(string id)
        {
            try
            {
                Place? isPlace = await _context.Places.FindAsync(id);
                if (isPlace == null)
                {
                    AddCommonResponse(false, $"Place Not found");
                    return commonResponse;
                }
                PlaceImage[] placeImgArr = await _context.PlacesImages.Where(x => x.Place_Id_I.PlaceId.Equals(id)).ToArrayAsync();
                _context.PlacesImages.RemoveRange(placeImgArr);
                PlaceFestival[] placeFesArr = await _context.PlacesFestivals.Where(x => x.Place.PlaceId.Equals(id)).ToArrayAsync();
                _context.PlacesFestivals.RemoveRange(placeFesArr);
                _context.Places.Remove(isPlace);
                await _context.SaveChangesAsync();
                AddCommonResponse(true, $"{isPlace.PlaceId} ({isPlace.PlaceName}) has been deleted");
                return commonResponse;
            }
            catch (Exception ex)
            {
                AddCommonResponse(false, ex.Message);
                return commonResponse;
            }
        }


        public async Task<PlaceGetResponse> GetAllPlace()
        {
            try
            {
                places = await _context.Places.ToListAsync();
                images = await _context.PlacesImages.ToListAsync();
                festivals = await _context.PlacesFestivals.ToListAsync();
                if(places.Count <= 0) 
                {
                    AddGetCommonResponse(false, $"No places found");
                    return getResponse;
                }
                AddGetCommonResponse(true, $"{places.Count} places found");
                return getResponse;
            }
            catch(Exception ex)
            {
                AddGetCommonResponse(false, ex.StackTrace);
                return getResponse;
            }
        }

        public void AddGetCommonResponse(bool status, string message)
        {
            getResponse = new()
            {
                Status = status,
                Message = message,
                Places= places,
                PlaceImages= images,
                Festival= festivals
            };
        }
        public void AddCommonResponse(bool status, string message)
        {
            commonResponse = new()
            {
                Status = status,
                Message = message,
            };
        }
    }
}
