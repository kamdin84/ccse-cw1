using System.ComponentModel.DataAnnotations.Schema;

namespace ccse_cw1.Models
{
    public class Booking
    {

        public int BookingID { get; set; }
        public string UserID { get; set; }
        public int? HotelID { get; set; }
        public int? RoomNumber { get; set; }
        public int? TourID { get; set; }
        public float Cost { get; set; }
        public int Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CheckIn { get; set;}
        public DateTime CheckOut { get; set;}

        public ApplicationUser? User { get; set; }


    }
}
