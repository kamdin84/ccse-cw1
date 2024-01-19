using ccse_cw1.Models;
using ccse_cw1.Services;
using Microsoft.EntityFrameworkCore;

namespace ccse_cw1.Repositories
{
    public class BookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Booking> GetBookingAsync(int bookingId)
        {
            var booking = await _context.Booking.FirstOrDefaultAsync(b => b.BookingID == bookingId);

            return booking;
        }

        public async Task<Booking> CreateBookingAsync(string userid, float cost, int discount, DateTime checkin, DateTime checkout,  int hotelid = 0, int roomnumber = 0, int tourid = 0)
        {
            var booking = new Booking
            {
                UserID = userid,
                Cost = cost,
                Discount = discount,
                CreatedAt = DateTime.Now,
                CheckIn = checkin,
                CheckOut = checkout,
                HotelID = hotelid,
                RoomNumber = roomnumber,
                TourID = tourid
            };

            await _context.Booking.AddAsync(booking);
            await _context.SaveChangesAsync();

            return booking;
        }
    }
}
