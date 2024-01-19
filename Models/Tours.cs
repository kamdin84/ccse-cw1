using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Models
{
    public class Tours
    {
        [Key]
        public required int TourID { get; set; }
        public required string TourName { get; set; }
        public int TourPrice { get; set;}
        public int TourSpaces { get; set;}
        public DateTime TourStart { get; set;}
        public DateTime TourEnd { get; set;}

    }
}
