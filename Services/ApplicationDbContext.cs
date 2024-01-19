using ccse_cw1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        }

        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Tours> Tours { get; set; }

    
}
    }
