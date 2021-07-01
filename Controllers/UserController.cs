using CinemaBookingSystem.Data.Models;
using CinemaBookingSystem.Services;
using CinemaBookingSystem.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly UsersService _usersService;
        private readonly MovieShowsService _movieShowsService;
        private readonly ReservationService _reservationService;

        public UserController(MovieShowsService movieShowsService,
           UsersService usersService,
           ReservationService reservationService)
        {
            _usersService = usersService;
            _movieShowsService = movieShowsService;
            _reservationService = reservationService;
        }

        public IActionResult Reservations()
        {
            User user = _usersService.FindUserByIdentiryName(User.Identity.Name);
            int userId = user.Id;
            List<Reservation> reservations = _reservationService.GetReservationsPerPerson(userId);
            var reservationsViewModel = new List<MovieShowReservationViewModel>();
            reservations.ForEach(r =>
            {
                var reservation = new MovieShowReservationViewModel { Row = r.Row, Seat = r.Place };
                MovieShow movie = _movieShowsService.GetMovieShowById(r.MovieShowId);
                reservation.MovieName = movie.MovieName;
                reservation.SessionStart = movie.SessionStart;
                reservationsViewModel.Add(reservation);
            });
            return View("UserReservations", reservationsViewModel);
        }
    }
}
