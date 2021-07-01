using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Data.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public int MovieShowId { get; set; }
        [ForeignKey("MovieShowId")]
        [JsonIgnore]
        public MovieShow MovieShow { get; set; }
    }
}
