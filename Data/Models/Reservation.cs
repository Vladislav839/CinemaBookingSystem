using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public int MovieShowId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("MovieShowId")]
        public MovieShow MovieShow { get; set; }
    }

}
