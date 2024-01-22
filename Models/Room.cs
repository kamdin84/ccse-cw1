namespace ccse_cw1.Models
{
    public class Room
    {
        public int HotelID { get; set; }
        public int RoomID { get; set; }
        public string RoomType { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual Hotel? Hotel { get; set; }
     }
}
