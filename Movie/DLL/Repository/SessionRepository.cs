using DLL.Models;
using DLL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class SessionRepository : IRepositoryAdd<Session>, IRepositoryGet<Session>
    {
        public void Add(Session item)
        {
            throw new NotImplementedException();
        }

        public void AddAll(List<Session> itemList)
        {
            throw new NotImplementedException();
        }

        public Session Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Session> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
