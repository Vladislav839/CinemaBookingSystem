using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.ViewModels.Admin
{
    public class MovieShowReservationViewModel
    {
        public string MovieName { get; set; }
        public DateTime SessionStart { get; set; }
        public string UserName { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
    }
}
