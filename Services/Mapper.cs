using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using CinemaBookingSystem.Data.Models;
using CinemaBookingSystem.ViewModels.Admin;

namespace CinemaBookingSystem.Services
{
    public static class Mapper
    {
        public static MovieShow MapMovieShowViewModelToModel(MovieShowViewModel model)
        {
            return new MovieShow
            {
                Country = model.Country,
                MovieName = model.MovieName,
                Year = model.Year,
                Genre = model.Genre,
                DescriptionLink = model.DescriptionLink,
                SessionStart = model.SessionStart,
                PosterPath = null,
                Price = Converter.ConvertStringToDouble(model.Price)
            };
        }
        public static MovieShowViewModel MapMovieShowModelToViewModel(MovieShow model)
        {
            return new MovieShowViewModel
            {
                MovieName = model.MovieName,
                Year = model.Year,
                Country = model.Country,
                Genre = model.Genre,
                Poster = null,
                DescriptionLink = model.DescriptionLink,
                SessionStart = model.SessionStart,
                Price = model.Price.ToString()
            };
        }
    }
}
