using DLL.Models;
using DLL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class BookingRepository : IRepositoryAdd<LoginData>, IRepositoryGet<LoginData>
    {
        public void Add(LoginData item)
        {
            throw new NotImplementedException();
        }

        public void AddAll(List<LoginData> itemList)
        {
            throw new NotImplementedException();
        }

        public LoginData Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoginData> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
