using ccse_cw1.Models;
using ccse_cw1.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace ccse_cw1.Repositories
{
    public class BookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Hotel> GetHotels()
        {
            var hotels = _context.Hotels.ToList();

            return hotels;
        }

        public List<Tour> GetTours()
        { 
            var tours = _context.Tours.ToList();
            
            return tours;
        }

        public List<Booking> GetBookings()
        {
            var bookings = _context.Booking.ToList();

            return bookings;
        }

        public List<Booking> GetBookingsUser(ApplicationUser user)
        {
            var bookings = _context.Booking.Where(booking => booking.UserID == user.Id).ToList();

            return bookings;
        }



        public async Task<Booking> GetBookingAsync(int bookingId)
        {
            var booking = await _context.Booking.FirstOrDefaultAsync(b => b.BookingID == bookingId);

            return booking;
        }

        public async Task<Booking> CreateBookingAsync(string userid, DateTime checkin, DateTime checkout,  int hotelid = 0, string roomtype ="", int tourid = 0)
        {
            var cost = 0;
            var discount = 0;

            var tour = _context.Tours.FirstOrDefault(h => h.TourID == tourid);
            var hotel = _context.Hotels.FirstOrDefault(h => h.HotelID == hotelid);
            var availablecount = 0;

            
                
            if (hotel != null)
                {
                    if (roomtype == "single")
                    {
                        discount = 10;
                        cost += hotel.SinglePrice;
                        availablecount = hotel.AvailableSingle;
                        hotel.AvailableSingle -= 1;
                    }
                    else if (roomtype == "double")
                    {
                        discount = 20;
                        cost += hotel.DoublePrice;
                        availablecount = hotel.AvailableDouble;
                        hotel.AvailableDouble -= 1;
                    
                }
                    else if (roomtype == "family")
                    {
                    availablecount = hotel.AvailableFamily;
                    discount = 40;
                    hotel.FamilyPrice -= 1;
                    cost += hotel.FamilyPrice;
                }
                }
                
                if (availablecount <= 0)
            {
                return new Booking
                {
                    CreatedAt = DateTime.MinValue
                };
            }

                if (hotelid != 0 & tourid != 0)
                {
                    if (tour != null)
                    {
                        cost += tour.TourPrice;

                        cost -= cost * (discount / 100);

                        var booking = new Booking
                        {
                            HotelID = hotelid,
                            UserID = userid,
                            RoomNumber = availablecount,
                            CheckIn = checkin,
                            CheckOut = checkout,
                            CreatedAt = DateTime.Now,
                            TourID = tourid,
                            Discount = discount,
                            Cost = cost,
                        };



                        await _context.Booking.AddAsync(booking);
                        await _context.SaveChangesAsync();

                        return booking;
                    }
                }
                else if (hotelid != 0)
                {
                    var booking = new Booking
                    {
                        HotelID = hotelid,
                        UserID = userid,
                        RoomNumber = availablecount,
                        CheckIn = checkin,
                        CheckOut = checkout,
                        CreatedAt = DateTime.Now,
                        TourID = tourid,
                        Discount = 0,
                        Cost = cost,
                    };

                    await _context.Booking.AddAsync(booking);
                    await _context.SaveChangesAsync();

                    return booking;
                }
                else if (tourid != 0)
                {
                    cost += tour.TourPrice;

                    var booking = new Booking
                    {
                        HotelID = hotelid,
                        UserID = userid,
                        CheckIn = checkin,
                        CheckOut = checkin.AddDays(tour.Duration),
                        CreatedAt = DateTime.Now,
                        TourID = tourid,
                        Discount = 0,
                        Cost = cost,
                    };

                    await _context.Booking.AddAsync(booking);
                    await _context.SaveChangesAsync();

                    return booking;
                }
            

                return new Booking
                {
                    CreatedAt = DateTime.MinValue
                };
            }

    }
}
