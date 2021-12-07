using DLL.Models;
using DLL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class CinemaHallRepository : IRepositoryAdd<CinemaHall>, IRepositoryGet<CinemaHall>
    {
        public void Add(CinemaHall item)
        {
            throw new NotImplementedException();
        }

        public void AddAll(List<CinemaHall> itemList)
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
