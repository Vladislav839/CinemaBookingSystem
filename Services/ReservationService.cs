using CinemaBookingSystem.Data;
using CinemaBookingSystem.Data.Models;
using CinemaBookingSystem.ViewModels.Booking;
using System.Security.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingSystem.Services
{
    public class ReservationService
    {
        private readonly BookingSystemDbContext _context;
        private readonly UsersService _usersService;

        public ReservationService(BookingSystemDbContext context, UsersService usersService)
        {
            _context = context;
            _usersService = usersService;
        }

        public void AddReservation(int movieId, BookPlaceViewModel viewModel, string currentUserIdentityName)
        {
            User currentUser = _usersService.FindUserByIdentiryName(currentUserIdentityName);
            Reservation reservation = new Reservation
            {
                MovieShowId = movieId,
                UserId = currentUser.Id,
                Row = viewModel.Row,
                Place = viewModel.Place
            };
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _context.Reservations;
        }

        public List<Reservation> GetReservationsPerPerson(int userId)
        {
            return _context.Reservations.Where(r => r.UserId == userId).ToList();
        }
    }
}
