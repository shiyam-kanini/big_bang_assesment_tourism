using MakeYourTrip_API.Models;
using MakeYourTrip_API.ModelsDTO.PlaceModels;
using MakeYourTrip_API.ModelsResponse;
using MakeYourTrip_API.ModelsResponse.PlaceResponse;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip_API.Repositories.PlaceRepo
{
    public class RepoAddPlace : IRepoAddPlace
    {
        private readonly AppDbContext _context;
        private readonly Random _random = new Random();
        public RepoAddPlace(AppDbContext context)
        {
            _context = context;
        }
        Place? newPlace;
        CommonResponse commonResponse;
        PlaceImage placeImage;
        PlaceFestival? placeFestival;
        public async Task<CommonResponse> InsertPlace(PlaceRequest placeData)
        {
            try
            {
                newPlace = await _context.Places.Where(x => x.PlaceName.Equals(placeData.PlaceName)).FirstOrDefaultAsync();
                if (newPlace != null)
                {
                    AddcommonResponse(false, $"Place {placeData.PlaceName} already exists under id {newPlace.PlaceId}"); return commonResponse;
                }
                AddPlace($"PLACEID{_random.Next(10000, 99999)}", placeData);
                await _context.Places.AddAsync(newPlace ?? new Place());
                await _context.SaveChangesAsync();
                AddcommonResponse(true, $"Place {newPlace?.PlaceId}({newPlace?.PlaceName}) has been added");
                return commonResponse;
            }
            catch(Exception ex)
            {
                AddcommonResponse(false, ex.Message); return commonResponse;
            }
        }
        public async Task<CommonResponse> InsertPlaceImages(PlaceImgRequest imageGalleryData)
        {
            try
            {
                newPlace = await _context.Places.FindAsync(imageGalleryData.PlaceId);
                if(newPlace == null)
                {
                    AddcommonResponse(false, $"No place with id : {imageGalleryData.PlaceId}"); return commonResponse;
                }
                foreach(string imageURL in imageGalleryData.PlaceImgURLs ?? new List<string>())
                {
                    AddPlaceImage($"PIMGID{_random.Next(10000, 99999)}", newPlace, imageURL);
                    await _context.PlacesImages.AddAsync(placeImage);
                    await  _context.SaveChangesAsync();
                }
                AddcommonResponse(true, $"{imageGalleryData?.PlaceImgURLs?.Count} images add for place : {newPlace.PlaceName}");
                return commonResponse;
            }
            catch(Exception ex)
            {
                AddcommonResponse(false, ex.Message); return commonResponse;
            }
        }
        public async Task<CommonResponse> InsertPlaceFestivals(PlaceFestivalRequest placeFestivalData)
        {
            try
            {
                newPlace = await _context.Places.FindAsync(placeFestivalData.PlaceId);
                if (newPlace == null)
                {
                    AddcommonResponse(false, $"No place with id : {placeFestivalData.PlaceId}"); return commonResponse;
                }
                foreach (string festivalId in placeFestivalData.Festival ?? new List<string>())
                {
                    Festival? newFestival = await _context.Festivals.FindAsync(festivalId);
                    AddFestival($"PIMGID{_random.Next(10000, 99999)}", newPlace, newFestival);
                    await _context.PlacesFestivals.AddAsync(placeFestival ?? new PlaceFestival());
                    await _context.SaveChangesAsync();
                }
                AddcommonResponse(true, $"{placeFestivalData?.Festival?.Count} festivals add for place : {newPlace.PlaceName}");
                return commonResponse;
            }
            catch(Exception ex)
            {
                AddcommonResponse(false, ex.Message); return commonResponse;
            }
        }
        public void AddFestival(string placeFestivalId, Place place, Festival festival)
        {
            placeFestival = new PlaceFestival()
            {
                PlaceFestivalId = placeFestivalId,
                Festival = festival,
                Place= place,
            };
        }
        public void AddPlaceImage(string placeImageId, Place place, string imgURL)
        {
            placeImage = new PlaceImage()
            {
                PlaceImageId= placeImageId,
                Place_Id_I = place,
                PlaceImageURL= imgURL
            };
        }
        public void AddPlace(string placeId, PlaceRequest placeData)
        {
            newPlace = new Place()
            {
                PlaceId = placeId,
                PlaceName = placeData.PlaceName,
                PlaceDescription = placeData.PlaceDescription,
                PlaceType = placeData.PlaceType,
                PlaceState= placeData.PlaceState,
                placeCountry = placeData.placeCountry,
                PlaceStatus= placeData.PlaceStatus,
                PlaceUrl = placeData.PlaceUrl,
                AmenityBathroom = placeData.AmenityBathroom,
                AmenityParking = placeData.AmenityParking,
                VisitingDay= placeData.VisitingDay,
                PlacePrice = placeData.Price
            };
        }
        public void AddcommonResponse(bool status, string message)
        {
            commonResponse = new CommonResponse()
            {
                Status= status,
                Message= message
            };
        }
    }
}
