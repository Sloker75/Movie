using DLL.Context;
using DLL.Models;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SessionService
    {
        SessionRepository sessionRepository;
        CinemaHallRepository cinemaHallRepository;
        FilmRepository filmRepository;
        public SessionService(SessionRepository sessionRepository, CinemaHallRepository cinemaHallRepository, FilmRepository filmRepository)
        {
            this.sessionRepository = sessionRepository;
            this.cinemaHallRepository = cinemaHallRepository;
            this.filmRepository = filmRepository;
        }

        public async void AddSessionAsync(Session session)
        {
            await sessionRepository.CreateAsync(session);
        }

        public async Task<IReadOnlyCollection<Session>> GetAllSessionAsync()
        {
            return await sessionRepository.GetAllAsync();
        }

        public async Task<IEnumerable<CinemaHall>> GetAllCinemaHallAsync()
        {
            return await cinemaHallRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Film>> GetAllFilmAsync()
        {
            return await filmRepository.GetAllAsync();
        }

    }
}
