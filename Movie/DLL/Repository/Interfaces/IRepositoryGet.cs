using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository.Interfaces
{
    public interface IRepositoryGet<T>
    {
        public T Get();
        public IEnumerable<T> GetAll();
    }
}
