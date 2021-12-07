using DLL.Context;
using DLL.Models;
using DLL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DLLTests
{
    public class RepositoryTests
    {
        private CinemaContext context;
        [Fact]
        public async Task TestReadAndSaveFilmAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CinemaContext>();
            var options = optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cinema2Test;Integrated Security=True;Connect Timeout=30;").Options;

            context = new CinemaContext(options);

            FilmRepository filmRepository = new(context);

            await filmRepository.CreateAsync(new Film() { MovieTitle = "Terminator", Genre = "Comedy", MovieDuration = new System.DateTime(1, 1, 1, 1, 54, 34) });
            context.SaveChanges();
            var film = await filmRepository.GetAllAsync();
            var film1 = await filmRepository.FindByConditionAsync(x => x.MovieTitle == "Terminator");
        }

    }
}
