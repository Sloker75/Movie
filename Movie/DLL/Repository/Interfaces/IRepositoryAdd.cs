using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository.Interfaces
{
    public interface IRepositoryAdd<T>
    {
        public void Add(T item);
        public void AddAll(List<T> itemList);



    }
}
