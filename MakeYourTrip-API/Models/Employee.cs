using System.ComponentModel.DataAnnotations;

namespace MakeYourTrip_API.Models
{
    public class Employee
    {
        [Key]
        public string? EmployeeId { get; set; }
        public string? EmployeeFirstName { get; set; }
        public string? EmployeeLastName { get; set; }
        public string? EmployeeImageUrl { get; set; }
        public bool IsActive { get; set; }
        public string? EmployeeEmail { get; set; }
        public string? CountryCode { get; set; }
        public string? EmployeePhone { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordKey { get; set; }
        public string? EmployeeState { get; set; }
        public Role? Role { get; set; }
        public string? Specialization { get; set; }
        public ICollection<PackageBooking>? PackageBooking { get; set; } 
    }
}
