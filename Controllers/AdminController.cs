using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaBookingSystem.Data;
using CinemaBookingSystem.ViewModels.Admin;
using CinemaBookingSystem.Services;
using CinemaBookingSystem.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace CinemaBookingSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly MovieShowsService _service;
        private readonly UsersService _usersService;
        private readonly ReservationService _reservationService;

        public AdminController(MovieShowsService service, 
            UsersService usersService, 
            ReservationService reservationService)
        {
            _usersService = usersService;
            _service = service;
            _reservationService = reservationService;
        }
        public IActionResult CreateMovieShows()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMovieShows(MovieShowViewModel model)
        {
            if(model.Poster == null)
            {
                ModelState.AddModelError("", "Не выбран постер");
                return View(model);
            }
            if(ModelState.IsValid)
            {
                _service.AddMovieShow(model);
                ViewBag.Success = "true";
            }
            return View(model);
        }
        public IActionResult UpdateMovieShows()
        {
            return View(_service.GetAllMovieShows());
        }
        [HttpPost]
        public IActionResult DeleteMovieShow(int id)
        {
            _service.DeleteMovieShow(id);
            return RedirectToAction("UpdateMovieShows", "Admin");
        }
        [HttpGet]
        public string GetPosterPath(int id)
        {
            return _service.GetPosterPath(id);
        }
        [HttpGet]
        public IActionResult UpdateMovieShow(int id)
        {
            var model = _service.GetMovieShowById(id);
            ViewBag.PosterPath = model.PosterPath;
            ViewBag.Id = id;
            MovieShowViewModel viewModel = Mapper.MapMovieShowModelToViewModel(model);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult UpdateMovieShow(int id, MovieShowViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateMovieShow(id, model);
                ViewBag.Success = "true";
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult SeeAllReservations()
        {
            return View("Reservations", _service.GetAllMovieShows().OrderByDescending(s => s.SessionStart));
        }

        [HttpGet]
        public IActionResult MovieShowReservations(int id)
        {
            var reservations = new List<MovieShowReservationViewModel>();
            MovieShow movieShow = _service.GetMovieShowById(id);
            movieShow.Reservations.ForEach(r =>
            {
                var reservation = new MovieShowReservationViewModel { Row = r.Row, Seat = r.Place };
                reservation.MovieName = movieShow.MovieName;
                reservation.SessionStart = movieShow.SessionStart;
                reservation.UserName = _usersService.FindUserById(r.UserId).Email;
                reservations.Add(reservation);
            });
            return View(reservations);
        }
    }
}
