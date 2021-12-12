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

        EmployeeRepository employeeRepository;
        CinemaHallRepository cinemaHallRepository;
        public AdminService(EmployeeRepository employeeRepository, CinemaHallRepository cinemaHallRepository)
        {
            this.employeeRepository = employeeRepository;
            this.cinemaHallRepository = cinemaHallRepository;
        }


        public async void AddEmployee(Employee Employee)
        {
            await employeeRepository.CreateAsync(Employee);
        }

        public async Task<IReadOnlyCollection<Employee>> GetAll()
        {
            return await employeeRepository.GetAllPeopleAsync();
        }

        public async Task<IReadOnlyCollection<Employee>> GetAllWithLogin()
        {
            return await employeeRepository.GetAllAsync();
        }

        public async Task<IReadOnlyCollection<Employee>> GetEmployee(string name, string surname)
        {
            return (await employeeRepository.FindByConditionAsync(x => x.Name == name && x.Surname == surname))?.ToList();
        }

        public async void AddHall(CinemaHall cinemaHall)
        {
            await cinemaHallRepository.CreateAsync(cinemaHall);
        }


    }
}
