using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Data.Models
{
    public class MovieShow
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }
        public string PosterPath { get; set; }
        public string DescriptionLink { get; set; }
        public DateTime SessionStart { get; set; }
        public double Price { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<Seat> ReservedSeats { get; set; } = new List<Seat>();
    }
}
