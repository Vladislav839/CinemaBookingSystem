using CinemaBookingSystem.Data.Models;
using CinemaBookingSystem.Services;
using CinemaBookingSystem.ViewModels.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly MovieShowsService _movieShowsService;
        private readonly SeatsService _seatsService;
        private readonly ReservationService _reservationService;
        private readonly UsersService _usersService;

        public BookingController(MovieShowsService movieShowsService, UsersService usersService,
            SeatsService seatsService, ReservationService reservationService)
        {
            _movieShowsService = movieShowsService;
            _seatsService = seatsService;
            _reservationService = reservationService;
            _usersService = usersService;
        }
        public IActionResult BookPlace(int id)
        {
            MovieShow show = _movieShowsService.GetMovieShowById(id);
            ViewBag.FilmId = id;
            ViewBag.reservedSeats = _seatsService.getAllReservedSeats(id);
            ViewBag.filmName = show.MovieName;
            ViewBag.Sessionstart = show.SessionStart;
            ViewBag.Price = show.Price;
            ViewBag.Rows = 5;
            ViewBag.Cols = 10;
            return View();
        }
        [HttpPost]
        public IActionResult BookPlace(int id, BookPlaceViewModel viewModel)
        {
            _seatsService.AddSeat(id, viewModel);
            _reservationService.AddReservation(id, viewModel, User.Identity.Name);
            return RedirectToAction("BookPlace");
        }
    }
}
