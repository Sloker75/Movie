using DLL.Models;
using DLL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class FilmRepository : IRepositoryAdd<Film>, IRepositoryGet<CinemaHall>
    {
        public void Add(Film item)
        {
            throw new NotImplementedException();
        }

        public void AddAll(List<Film> itemList)
        {
            throw new NotImplementedException();
        }

        public CinemaHall Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CinemaHall> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
