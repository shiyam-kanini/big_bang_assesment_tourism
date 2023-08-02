using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip_API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PlaceFestival> PlacesFestivals { get; set;}
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<PlaceImage> PlacesImages { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<PackageBooking> PackageBookings { get; set; }  
        public DbSet<PackageBookingPlace> PackageBookingsPlaces { get; set; }
        
    }
}
