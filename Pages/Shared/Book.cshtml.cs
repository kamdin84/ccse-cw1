using ccse_cw1.Models;
using ccse_cw1.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using System;
using System.Web;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ccse_cw1.Pages.Shared
{
    [Authorize]
    public class BookModel : PageModel
    {
        public readonly UserManager<ApplicationUser> UserManager;
       
        public ApplicationUser? appUser;

        private readonly BookingRepository _bookingRepository;
        public List<Hotel> Hotels { get; set; }
        public List<Tour> Tours { get; set; }
        public BookModel(UserManager<ApplicationUser> userManager, BookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
            UserManager = userManager;
            Hotels = _bookingRepository.GetHotels();
            Tours = _bookingRepository.GetTours();
        }

        public void OnGet()
        {

        }

        /*
        [BindProperty]
        public SearchModel Search { get; set;  }

        public class SearchModel
        {
            public required DateTime CheckIn { get; set; } = DateTime.MinValue;
            public required DateTime CheckOut { get; set; }
            public required string RoomType { get; set; }
        }
        */




            [BindProperty]
        public InputModel Input { get; set; }
        
        public class InputModel 
        {

            [Display(Name = "Hotel")]
            public int HotelID { get; set; }

            [Display(Name = "Tour")]
            public int TourId { get; set; }


            public string? RoomType { get; set; }

            [Required(ErrorMessage = "Please select a check-in date")]
            [DataType(DataType.DateTime)]
            [Display(Name = "Check in date")]
            public DateTime CheckIn { get; set; }

            [Required(ErrorMessage = "Please select a check-out date")]
            [DataType(DataType.DateTime)]
            [Display(Name = "Check out date")]
            public DateTime CheckOut { get; set; }


        }

        public async Task<IActionResult> OnPostAsync()
        {

            var IsHotel = !(Input.HotelID == 0);
            var IsTour = !(Input.TourId == 0);


            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await UserManager.GetUserAsync(User);

            Booking booking = new();

            if (IsHotel & IsTour)
            {

                booking = await _bookingRepository.CreateBookingAsync(user.Id, Input.CheckIn, Input.CheckOut, Input.HotelID, Input.RoomType, Input.TourId);
            }
            else if (IsHotel)
            {
                booking = await _bookingRepository.CreateBookingAsync(user.Id, Input.CheckIn, Input.CheckOut, Input.HotelID, Input.RoomType);
            }
            else if (IsTour)
            {
                booking = await _bookingRepository.CreateBookingAsync(user.Id, Input.CheckIn, Input.CheckOut, tourid: Input.TourId);
            }

            if (booking != null || booking.CreatedAt == DateTime.MinValue)
            {
                return RedirectToPage("./BookSuccess");
            }
            

            return Page();

        }

    }

}

    