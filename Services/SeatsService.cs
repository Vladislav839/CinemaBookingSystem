using CinemaBookingSystem.Data;
using CinemaBookingSystem.Data.Models;
using CinemaBookingSystem.ViewModels.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Services
{
    public class SeatsService
    {
        private readonly BookingSystemDbContext _context;

        public SeatsService(BookingSystemDbContext context)
        {
            _context = context;
        }

        public List<Seat> getAllReservedSeats(int movieShowId)
        {
            return _context.Seats.Where(s => s.MovieShowId == movieShowId).ToList();
        }

        public void AddSeat(int movieId, BookPlaceViewModel viewModel)
        {
            Seat seat = new Seat { MovieShowId = movieId, Row = viewModel.Row, Place = viewModel.Place };
            _context.Seats.Add(seat);
            _context.SaveChanges();
        }
    }
}
