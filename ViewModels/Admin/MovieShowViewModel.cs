using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.ViewModels.Admin
{
    public class MovieShowViewModel
    {
        [Required(ErrorMessage = "Не указано имя фильма")]
        public string MovieName { get; set; }
        [Required(ErrorMessage = "Не указан год")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Не указан страна")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Не указан жанр")]
        public string Genre { get; set; }
        public IFormFile Poster { get; set; }
        [Required(ErrorMessage = "Не указана ссылка на описание")]
        public string DescriptionLink { get; set; }
        [Required(ErrorMessage = "Не указано время начала")]
        public DateTime SessionStart { get; set; }
        [Required(ErrorMessage = "Не указана цена")]
        public string Price { get; set; }
    }
}
