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
    public class FilmViewModel : BaseViewModel
    {
        private readonly AdminService adminService;
        private readonly SessionService sessionService;
        private Film film;

        public FilmViewModel(AdminService adminService, SessionService sessionService)
        {
            this.adminService = adminService;
            this.sessionService = sessionService;
        }

        public Film CurrentFilm
        {
            get
            {
                if (film != null) return film;
                {
                    film = new Film();
                    return film;
                }
            }
            set
            {
                film = value;
                OnPropertyChange("CurrentEmployee");
            }
        }

        private ObservableCollection<Film> _film;

        public ObservableCollection<Film> Worker
        {
            get
            {
                if (_film != null) return _film;
                else
                {
                    LoadEmployeeAsync();
                    return _film;
                }
            }
        }

        private async void LoadEmployeeAsync() => _film = new ObservableCollection<Film>(await sessionService.GetAllFilmAsync());

        RelayCommand _addFilmCommand;
        public ICommand AddEmployeeCommand
        {
            get
            {
                if (_addFilmCommand == null)
                {
                    _addFilmCommand = new RelayCommand(ExecuteAddFilm, CanExecuteAddFilm);
                }
                return _addFilmCommand;
            }
        }

        private bool CanExecuteAddFilm(object obj)
        {
            if (String.IsNullOrEmpty(CurrentFilm.MovieTitle))
            {
                return false;
            }
            else if (CurrentFilm.MovieTitle.Length > 50)
            {
                return false;
            }
            else if (String.IsNullOrEmpty(CurrentFilm.Genre))
            {
                return false;
            }
            else if (CurrentFilm.Genre.Length > 50)
            {
                return false;
            }
            return true;
        }

        private void ExecuteAddFilm(object obj)
        {
           adminService.AddFilmAsync(CurrentFilm);
        }
    }
}
