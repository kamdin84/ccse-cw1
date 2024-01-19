using ccse_cw1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace ccse_cw1.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> //Add the namespace on top: using Microsoft.EntityFrameworkCore;
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) //Constructor for the class
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var client = new IdentityRole("client");
            client.NormalizedName = "client";

            var seller = new IdentityRole("seller");
            seller.NormalizedName = "seller";

            builder.Entity<IdentityRole>().HasData(admin, client, seller);

            builder.Entity<ApplicationUser>()
            .HasMany(u => u.Bookings)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserID);

            // lets seed some data :D YAY
            
            var hotels = new List<Hotels> {
                new() { HotelName = "Hilton London Hotel", HotelLocation = "London", AvailableDouble = 20, AvailableFamily = 20, AvailableSingle = 20, SinglePrice = 375, DoublePrice = 775, FamilyPrice = 950 },
                new() { HotelName = "London Marriott Hotel", HotelLocation = "London", AvailableDouble = 20, AvailableFamily = 20, AvailableSingle = 20,  SinglePrice = 300, DoublePrice = 500, FamilyPrice = 900 },
                new() { HotelName = "Travelodge Brighton Seafront", HotelLocation = "Brighton", AvailableDouble = 20, AvailableFamily = 20, AvailableSingle = 20,  SinglePrice = 80, DoublePrice = 120, FamilyPrice = 150 },
                new() { HotelName = "Kings Hotel Brighton", HotelLocation = "Brighton", AvailableDouble = 20, AvailableFamily = 20, AvailableSingle = 20,  SinglePrice = 180, DoublePrice = 400, FamilyPrice = 520},
                new() { HotelName = "Leonardo Hotel Brighton", HotelLocation = "Brighton", AvailableDouble = 20, AvailableFamily = 20, AvailableSingle = 20,  SinglePrice = 180, DoublePrice = 400, FamilyPrice = 520},
                new() { HotelName = "Nevis Bank Inn, Fort William", HotelLocation = "Fort William", AvailableDouble = 20, AvailableFamily = 20, AvailableSingle = 20, SinglePrice = 90, DoublePrice = 100, FamilyPrice = 155 },
            };

            var id = 0;
            foreach (var hotel in hotels)
            {
                id += 1;
                hotel.HotelID = id;
                builder.Entity<Hotels>().HasData(hotel);
            }
        }

        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Tours> Tours { get; set; }


    
}
    }
