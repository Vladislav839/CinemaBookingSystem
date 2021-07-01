using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CinemaBookingSystem.ViewModels;
using CinemaBookingSystem.Data;
using CinemaBookingSystem.Services;

namespace CinemaBookingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieShowsService _service;

        public HomeController(MovieShowsService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MovieShows()
        {
            var movieShows = _service.GetAllMovieShows();
            return View(movieShows);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
