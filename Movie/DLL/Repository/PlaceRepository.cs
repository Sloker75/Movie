using DLL.Models;
using DLL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class PlaceRepository : IRepositoryAdd<Place>, IRepositoryGet<Place>
    {
        public void Add(Place item)
        {
            throw new NotImplementedException();
        }

        public void AddAll(List<Place> itemList)
        {
            throw new NotImplementedException();
        }

        public Place Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Place> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
