using CinemaBookingSystem.Data;
using CinemaBookingSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Services
{
    public class UsersService
    {
        private readonly BookingSystemDbContext _context;

        public UsersService(BookingSystemDbContext context)
        {
            _context = context;
        }

        public User FindUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
        public User FindUserByIdentiryName(string identiryName)
        {
            return _context.Users.FirstOrDefault(u => u.Email == identiryName);
        }
    }
}
