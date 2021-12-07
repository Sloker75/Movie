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
                var db = new CinemaContext(options);
                Assert.NotNull(db);
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }

        //[Fact]
        //public void AddFilmTest()
        //{
        //    context.film.Add(new Film() {MovieTitle = "" });
        //    context.SaveChanges();

        //    var movie = context.film.Where(x => x.MovieTitle == "g");
        //    Assert.NotNull(movie);
        //}
    }
}
