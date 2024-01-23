using ccse_cw1.Models;
using ccse_cw1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ccse_cw1.Pages
{
    public class BookManagementModel : PageModel
    {

        public List<Booking> Bookings { get; set; }

        private readonly BookingRepository BookingRepository;
        public BookManagementModel(BookingRepository bookingRepository)
        {
            BookingRepository = bookingRepository;
            Bookings = BookingRepository.GetBookings();

        }
        public void OnGet()
        {
        }
    }
}
