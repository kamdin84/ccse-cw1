using ccse_cw1.Models;
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
    }
    }
