using System.ComponentModel.DataAnnotations;

namespace MakeYourTrip_API.Models
{
    public class Role
    {
        [Key]
        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public ICollection<Employee>? Employees { get; set;}
    }
}
