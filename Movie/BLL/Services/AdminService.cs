using DLL.Context;
using DLL.Models;
using DLL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminService
    {
        public CinemaContext context { get; set; }

        public AdminService(CinemaContext context)
        {
            this.context = context;
        }


        public async void AddEmployee(Employee Employee)
        {
            EmployeeRepository employeeRepository = new(context);

            await employeeRepository.CreateAsync(Employee);
        }


        public async Task<IReadOnlyCollection<Employee>> GetAll()
        {
            EmployeeRepository employeeRepository = new(context);
            return await employeeRepository.GetAllAsync();
        }


    }
}
