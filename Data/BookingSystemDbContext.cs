using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaBookingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingSystem.Data
{
    public class BookingSystemDbContext : DbContext
    {
        public BookingSystemDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, UserName = "admin", Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<MovieShow>().ToTable("MovieShows");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Seat>().ToTable("Seats");
            modelBuilder.Entity<Reservation>().ToTable("Reservations");

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<MovieShow> MovieShows { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
