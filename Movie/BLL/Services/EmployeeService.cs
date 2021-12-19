using DLL.Models;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService
    {
        EmployeeRepository employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<IReadOnlyCollection<Employee>> GetAllAsync()
        {
            return await employeeRepository.GetAllPeopleAsync();
        }

        public async Task<IReadOnlyCollection<Employee>> GetAllWithLoginAsync()
        {
            return await employeeRepository.GetAllAsync();
        }
    }
}
