namespace ccse_cw1.Models
{
    public class Booking
    {

        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int HotelID { get; set; }
        public int TourID { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
