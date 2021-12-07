using DLL.Models;
using DLL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class EmployeeRepository : IRepositoryAdd<Employee>, IRepositoryGet<Employee>
    {
        public void Add(Employee item)
        {
            throw new NotImplementedException();
        }

        public void AddAll(List<Employee> itemList)
        {
            throw new NotImplementedException();
        }

        public Employee Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
