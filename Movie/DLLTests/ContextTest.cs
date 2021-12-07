using DLL.Context;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DLLTests
{
    public class ContextTest
    {
        private CinemaContext context;
        [Fact]
        public void createDb()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CinemaContext>();
            var options = optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CinemaDbTest;Integrated Security=True;Connect Timeout=30;").Options;
            try
            {
                context = new CinemaContext(options);
                Assert.NotNull(context);
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }

        [Fact]
        public void TestReadAndSaveFilm()
        {
            createDb();
            context.film.Add(new Film() { MovieTitle = "Detpoll", Genre = "Comedy", MovieDuration = new System.DateTime(1,1,1,1,54,34)});
            context.SaveChanges();
            var Film = context.film.Where(x => x.MovieTitle == "Detpoll").ToList();
        }


        public void TestReadSaveHall()
        {
            createDb();
            context.cinemaHall.Add(new CinemaHall() {HallRoom = 5, NumberOfRows = 10, NumberOfSeatsInRow = 15 });
            context.SaveChanges();
            var Hall = context.cinemaHall.Where(x => x.HallRoom == 5).ToList();
        }

        public void TestReadAndSaveSession()
        {
            createDb();
            var Film = context.film.First(x => x.MovieTitle == "Detpoll");
            var Hall = context.cinemaHall.First(x => x.HallRoom == 5);
            context.session.Add(new Session() { Film = Film, Hall = Hall, endOfTheSession = new System.DateTime(2021, 11, 5, 15, 25, 15), startOfTheSession = new System.DateTime(2021, 11, 5, 13, 10, 2) });
            context.SaveChanges();
            var Session = context.session.First();
        }

        public void TestReadSavePlace()
        {
            createDb();
            var Hall = context.cinemaHall.First(x => x.HallRoom == 5);
            context.place.Add(new Place() { Hall = Hall, Cost = 100, Row = 4, RowNumber = 5, });
            context.SaveChanges();
            var Place = context.place.Where(x => x.Cost == 100);
        }

        public void TestsaveBooking()
        {
            var Place = context.place.First(x => x.Cost == 100);
            var Session = context.session.First();
            var Employee = context.employee.First(x => x.Name == "vlad");
            createDb();
            context.booking.Add(new Booking()
            {
                PhoneNumber = 0965471545,
                IsPaid = true,
                Place = Place,
                Session = Session,
                Employee = Employee
            });
        }


        public void TestsaveLoginData()
        {
            createDb();
            context.loginData.Add(new LoginData() { Login = "vlad", Password = "154" });
            context.SaveChanges();
            var Login = context.loginData.Where(x => x.Login == "Vlad").ToList();
        }

        public void TestsaveEmployee()
        {
            createDb();
            var Login = context.loginData.First(x => x.Login == "Vlad");
            context.employee.Add(new Employee()
            {
                Name = "Vlad",
                Surname = "Burylo",
                salary = 15000,
                BirthDay = new System.DateTime(2004, 10, 6, 21, 5, 14),
                LoginDataId = 1,
                PhoneNumber = 0964786515,
                Role = "admin",
                Login = Login
            });
            context.SaveChanges();
            var Employee = context.employee.Where(x => x.Name == "vlad").ToList();
        }
    }
}
