using MakeYourTrip_API.Models;
using MakeYourTrip_API.ModelsDTO.PackageModels;
using MakeYourTrip_API.ModelsResponse;
using MakeYourTrip_API.ModelsResponse.PackageResponses;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Net;

namespace MakeYourTrip_API.Repositories.PackageRepo
{
    public class RepoPackageBooking : IRepoPackageBooking
    {
        private readonly AppDbContext _context;
        private readonly Random _random = new();
        public RepoPackageBooking(AppDbContext context)
        {
            _context = context;
        }
        PackageBooking? package = new();
        PackageBookingResponse response = new();
        public async Task<PackageBookingResponse> InitiateBookingSession(InitiateBooking initiateData)
        {
            try
            {
                User? isUser = await _context.Users.FindAsync(initiateData.User_Id);
                if (isUser == null)
                {
                    AddResponse(false, $"No user found for Id : {initiateData.User_Id}");return response;
                }
                package.PackageUserId = $"PKGBOOKID{_random.Next(10000, 99999)}";
                package.User_Id = isUser; 
                package.isBooking = initiateData.isBooking;
                await _context.PackageBookings.AddAsync(package);
                await _context.SaveChangesAsync();
                AddResponse(true, $"Booking session created under Id : {package.PackageUserId}");
                return response;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message );return response;
            }
        }
        public async Task<PackageBookingResponse> AddPackage(string packageId, string bookId)
        {
            try
            {
                Package? isPackage = await _context.Packages.FindAsync(packageId);
                if (isPackage == null)
                {
                    AddResponse(false, $"No package found for Id : {packageId}");return response;
                }
                package = await _context.PackageBookings.FindAsync(bookId);
                if(package == null || !package.isBooking)
                {
                    AddResponse(false, $"Booking session({bookId}) has been expired or closed"); return response;
                }
                _context.Entry(package).State = EntityState.Detached;
                package.Package_Id = isPackage;
                _context.Entry(package).State = EntityState.Modified;
                _context.PackageBookings.Update(package);
                await _context.SaveChangesAsync();
                AddResponse(true, $"Package ({isPackage.PackageName}) has been chosen, Pick {isPackage.PlaceCount} Places to add");
                return response;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message); return response;
            }
        }
        public async Task<PackageBookingResponse> AddPlaces(BookPlaceRequest bookPlaceData)
        {
            try
            {
                package = await _context.PackageBookings.Include(x => x.Package_Id).Where(y => y.PackageUserId.Equals(bookPlaceData.bookId)).FirstOrDefaultAsync();
                if(package == null || !package.isBooking)
                {
                    AddResponse(false, $"Booking session({bookPlaceData.bookId}) has been expired or closed"); return response;
                }
                if(package.Package_Id.PlaceCount > bookPlaceData.PlaceIds.Count)
                {
                    AddResponse(false, $"Package {package.Package_Id.PackageId}({package.Package_Id.PackageName}) requires {package.Package_Id.PlaceCount - bookPlaceData.PlaceIds.Count} more places to be chosen"); return response;
                }
                foreach (string placeId in bookPlaceData.PlaceIds)
                {
                    Place? newPlace = await _context.Places.FindAsync(placeId);
                    PackageBookingPlace? isPlaceBooked = await _context.PackageBookingsPlaces.Where(x => x.PackageBooking_Id.PackageUserId.Equals(bookPlaceData.bookId) && x.Place_PB_Id.PlaceId.Equals(placeId)).FirstOrDefaultAsync();
                    if(isPlaceBooked != null)
                    {
                        AddResponse(false, $"Place {newPlace.PlaceId}({newPlace.PlaceName}) has been already chosen"); return response;
                    }
                    if (newPlace == null)
                    {
                        AddResponse(false, "Place Not found"); return response;
                    }
                    PackageBookingPlace? newPBP = new()
                    {
                        PBPId = $"PBPID{_random.Next(100000, 999999)}",
                        PackageBooking_Id = package,
                        Place_PB_Id = newPlace
                    };
                    await _context.PackageBookingsPlaces.AddAsync(newPBP);
                    await _context.SaveChangesAsync();
                }
                _context.Entry(package).State = EntityState.Detached;
                package.isPlace = true;
                _context.Entry(package).State = EntityState.Modified;
                _context.PackageBookings.Update(package);
                await _context.SaveChangesAsync();
                AddResponse(true, $"The List of places has been successfully added");
                return response;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message); return response;
            }
        }
        public void AddResponse(bool status, string message)
        {
            response = new()
            {
                Status= status,
                Message= message,
                PackageBooking = package
            };
        }

        public  async Task<PackageBookingResponse> PickDate(PickDateRequest pickDateRequest)
        {
            try
            {
                package = await _context.PackageBookings.FindAsync(pickDateRequest.BookId);
                if(package == null || !package.isBooking)
                {
                    AddResponse(false, $"Booking session({pickDateRequest.BookId}) has been expired or closed"); return response;
                }
                _context.Entry(package).State = EntityState.Detached;
                package.JourneyDate = pickDateRequest.Date;
                package.BookingDate = DateTime.UtcNow.ToString();
                _context.Entry(package).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                AddResponse(true, $"{pickDateRequest.Date} date has been booked");
                return response;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message); return response;
            }
        }
        public async Task<PackageBookingResponse> ChooseHotel(ChooseHotelRequest chooseHotelData)
        {
            try
            {
                package = await _context.PackageBookings.Include(x => x.);

            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message); return response;
            }
        }
    }
}
