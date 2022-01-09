using BLL.Services;
using DLL.Models;
using Movie.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Movie.ViewModel
{
    public class SessionViewModel : BaseViewModel
    {
        private readonly SessionService _sessionService;
        private Session session;
        public SessionViewModel(SessionService sessionService)
        {
            this._sessionService = sessionService;
        }

        public Session CurrentSession
        {
            get
            {
                if (session != null) return session;
                {
                    session = new Session();
                    session.Film = new Film();
                    session.Hall = new CinemaHall();
                    return session;
                }
            }
            set
            {
                session = value;
                OnPropertyChange("CurrentEmployee");
            }
        }


        private ObservableCollection<Film> _film;

        public ObservableCollection<Film> Film
        {
            get
            {
                if (_film != null) return _film;
                else
                {
                    LoadFilmAsync();
                    return _film;
                }
            }
        }

        private async Task<ObservableCollection<Film>> LoadFilmAsync() => _film = new ObservableCollection<Film>(await _sessionService.GetAllFilmAsync());


        //private ObservableCollection<CinemaHall> _hall;

        //public ObservableCollection<CinemaHall> CinemaHall
        //{
        //    get
        //    {
        //        if (_hall != null) return _hall;
        //        else
        //        {
        //            LoadHallAsync();
        //            return _hall;
        //        }
        //    }
        //}


        //private async void LoadHallAsync() => _hall = new ObservableCollection<CinemaHall>(await _sessionService.GetAllCinemaHallAsync());



        private ObservableCollection<Session> _session;

        public ObservableCollection<Session> Sessions
        {
            get
            {
                if (_session != null) return _session;
                else
                {
                    LoadSessionAsync();
                    return _session;
                }
            }
        }

        private async void LoadSessionAsync()
        {
            try
            {
                _session = new ObservableCollection<Session>(await _sessionService.GetAllSessionAsync());
            }
            catch (Exception)
            {
                LoadSessionAsync();
            }
        } 

        RelayCommand _addSessionCommand;
        public ICommand AddSessionCommand
        {
            get
            {
                if (_addSessionCommand == null)
                {
                    _addSessionCommand = new RelayCommand(ExecuteAddEmployee, CanExecuteAddEmployee);
                }
                return _addSessionCommand;
            }
        }

        private bool CanExecuteAddEmployee(object obj)
        {

            return true;
        }

        private void ExecuteAddEmployee(object obj)
        {
            _sessionService.AddSessionAsync(CurrentSession);
        }

    }
}
