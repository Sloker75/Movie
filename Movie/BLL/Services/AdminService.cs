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
        FilmRepository filmRepository;
        public AdminService(EmployeeRepository employeeRepository, CinemaHallRepository cinemaHallRepository)
        {
            this.employeeRepository = employeeRepository;
            this.cinemaHallRepository = cinemaHallRepository;
        }


        public async void AddEmployeeAsync(Employee Employee)
        {
            await employeeRepository.CreateAsync(Employee);
        }
        public async void AddFilmAsync(Film film)
        {
            await filmRepository.CreateAsync(film);
        }
        public async void AddHallAsync(CinemaHall cinemaHall)
        {
            await cinemaHallRepository.CreateAsync(cinemaHall);
        }


        public async Task<IReadOnlyCollection<Employee>> GetAllAsync()
        {
            return await employeeRepository.GetAllPeopleAsync();
        }

        public async Task<IReadOnlyCollection<Employee>> GetAllWithLoginAsync()
        {
            return await employeeRepository.GetAllAsync();
        }

        public async Task<IReadOnlyCollection<Employee>> GetEmployeeAsync(string name, string surname)
        {
            return (await employeeRepository.FindByConditionAsync(x => x.Name == name && x.Surname == surname))?.ToList();
        }

        

        


    }
}
