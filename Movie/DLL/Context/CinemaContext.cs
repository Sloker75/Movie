using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Context
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> employee { get; set; }
        public DbSet<LoginData> loginData { get; set; }
        public DbSet<Booking> booking { get; set; }
        public DbSet<Session> session { get; set; }
        public DbSet<Film> film { get; set; }
        public DbSet<CinemaHall> cinemaHall { get; set; }
        public DbSet<Place> place { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasOne(x => x.Login).WithOne(x => x.Employee).HasForeignKey<Employee>(x => x.LoginDataId);
            modelBuilder.Entity<Booking>().HasOne(x => x.Employee);
            modelBuilder.Entity<Booking>().HasOne(x => x.Session);
            modelBuilder.Entity<Booking>().HasOne(x => x.Place).WithMany(x => x.Booking).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Session>().HasOne(x => x.Film);
            modelBuilder.Entity<CinemaHall>().HasMany(x => x.Place).WithOne(x => x.Hall);
            modelBuilder.Entity<CinemaHall>().HasMany(x => x.Sessions).WithOne(x => x.Hall);
        }


    }
}
