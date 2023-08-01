
using Microsoft.Identity.Client;

namespace MakeYourTrip_API.Models
{
    public class User
    {
        public string? UserId { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserImageUrl { get; set; }
        public string? UserType { get; set; }
        public string? IsActive { get; set; }
        public string? UserEmail { get; set;}
        public string? CountryCode { get; set; }
        public string? UserPhone { get; set;}
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordKey { get; set; }
        public string? UserState { get; set; }
        public bool Married { get; set; }
        public ICollection<PackageBooking>? PackageBookings { get; set; }
    }
}
