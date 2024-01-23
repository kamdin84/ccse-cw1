using ccse_cw1.Models;
using ccse_cw1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ccse_cw1.Pages
{
    [Authorize(Roles = "client")]
    public class UserBookingsModel : PageModel
    {
        public List<Booking> Bookings { get; set; }

        public readonly UserManager<ApplicationUser> UserManager;
        private readonly BookingRepository BookingRepository;
        public UserBookingsModel(BookingRepository bookingRepository, UserManager<ApplicationUser> userManager)
        {
            BookingRepository = bookingRepository;
            UserManager = userManager;
        }
        public async void OnGet()
        {
            var task = UserManager.GetUserAsync(User);
            task.Wait();
            var user = task.Result;

            if (user != null)
            {
                Bookings = BookingRepository.GetBookingsUser(user);
            }

        }
    }
}
