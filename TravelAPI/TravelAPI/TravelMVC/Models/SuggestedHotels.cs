using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelMVC.Models
{
    public class SuggestedHotels
    {
        [Key]
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Hotellocation { get; set; }

        public string ContactNo { get; set; }
        public int rating { get; set; }
    }
}