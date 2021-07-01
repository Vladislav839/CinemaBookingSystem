using CinemaBookingSystem.Data;
using CinemaBookingSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaBookingSystem.ViewModels.Admin;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingSystem.Services
{
    public class MovieShowsService
    {
        private readonly BookingSystemDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MovieShowsService(BookingSystemDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _env = appEnvironment;
        }

        public void AddMovieShow(MovieShowViewModel model)
        {
            MovieShow movieShow = Mapper.MapMovieShowViewModelToModel(model);
            string path = "/img/posters/" + model.Poster.FileName;
            using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
            {
                model.Poster.CopyTo(fileStream);
            }
            movieShow.PosterPath = path;
            _context.MovieShows.Add(movieShow);
            _context.SaveChanges();
        }
        public List<MovieShow> GetAllMovieShows()
        {
            return _context.MovieShows.Include(m => m.Reservations)
                .Include(m => m.ReservedSeats).ToList();
        }

        public MovieShow GetMovieShowById(int id)
        {
            return _context.MovieShows.Include(m => m.Reservations)
                .Include(m => m.ReservedSeats).FirstOrDefault(m => m.Id == id);
        }
        public void DeleteMovieShow(int id)
        {
            MovieShow movieShow = GetMovieShowById(id);
            if(movieShow != null)
            {
                _context.MovieShows.Remove(movieShow);
                _context.SaveChanges();
            }
        }
        public string GetPosterPath(int id)
        {
            MovieShow movieShow = GetMovieShowById(id);
            return movieShow.PosterPath;
        }
        public void UpdateMovieShow(int id, MovieShowViewModel viewModel)
        {
            var model = GetMovieShowById(id);
            if(model != null)
            {
                if(viewModel.Poster != null)
                {
                    FileInfo fileInfo = new FileInfo(_env.WebRootPath + model.PosterPath);
                    if(fileInfo.Exists)
                    {
                        fileInfo.Delete();
                    }
                    string path = @"\img\posters\" + viewModel.Poster.FileName;
                    using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                    {
                        viewModel.Poster.CopyTo(fileStream);
                    }
                    model.PosterPath = path;
                }
                model.MovieName = viewModel.MovieName;
                model.Year = viewModel.Year;
                model.Country = viewModel.Country;
                model.Genre = viewModel.Genre;
                model.Price = Converter.ConvertStringToDouble(viewModel.Price);
                model.DescriptionLink = viewModel.DescriptionLink;
                model.SessionStart = viewModel.SessionStart;
                _context.SaveChanges();
            }
        }

        public List<MovieShow> GetMovieShowsByName(string name)
        {
            return _context.MovieShows.Include(m => m.Reservations)
                .Include(m => m.ReservedSeats).Where(m => m.MovieName == name)
                .ToList();
        }
    }
}
