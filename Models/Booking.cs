﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ccse_cw1.Models
{
    public class Booking
    {

        public int BookingID { get; set; }
        public string UserID { get; set; }
        public int? HotelID { get; set; }
        public int? TourID { get; set; }
        public float Cost { get; set; }
        public int Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CheckIn { get; set;}
        public DateTime CheckOut { get; set;}

        public int RoomId { get; set; }
        
        public virtual Room Room { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Tour Tour { get; set; }

        public ApplicationUser? User { get; set; }


    }
}
