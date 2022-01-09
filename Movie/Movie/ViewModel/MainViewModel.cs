using DLL.Models;
using Movie.Infrastructure;
using Movie.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Movie.ViewModel
{
    public class MainViewModel
    {
        private EmployeeViewModel employeeViewModel;
        private FilmViewModel filmViewModel;
        private Employee employee;
        private SessionViewModel sessionViewModel;
        private CinemaHallViewModel cinemaHallViewModel;

        public MainViewModel(EmployeeViewModel employeeViewModel, FilmViewModel filmViewModel, Employee employee, SessionViewModel sessionViewModel, CinemaHallViewModel cinemaHallViewModel)
        {
            this.employeeViewModel = employeeViewModel;
            this.filmViewModel = filmViewModel;
            this.employee = employee;
            this.sessionViewModel = sessionViewModel;
            this.cinemaHallViewModel = cinemaHallViewModel;
        }

        #region EmployeeDoubleClick



        RelayCommand _DoubleClickEmployeeCommand;

        public ICommand DoubleClickEmployee
        {
            get
            {
                
                _DoubleClickEmployeeCommand = new RelayCommand(ExecuteDoubleclickEmployee, CanExecuteDoubleClickEmployee);
                return _DoubleClickEmployeeCommand;
            }
        }

        private bool CanExecuteDoubleClickEmployee(object obj)
        {
            return !(employee.Role == "employee");
        }

        private void ExecuteDoubleclickEmployee(object obj)
        {
            var frame = (Frame)obj;
            frame.Content = new EmployeePage(employeeViewModel);

        }

        #endregion

        #region CinemaHallDoubleClick

        

        RelayCommand _DoubleClickCinemaHallCommand;

        public ICommand DoubleClickCinemaHall
        {
            get
            {
                _DoubleClickCinemaHallCommand = new RelayCommand(ExecuteDoubleclickCinemaHall, CanExecuteDoubleClickCinemaHall);
                return _DoubleClickCinemaHallCommand;
            }
        }

        private bool CanExecuteDoubleClickCinemaHall(object obj)
        {
            return !(employee.Role == "employee");
        }

        private void ExecuteDoubleclickCinemaHall(object obj)
        {
            var frame = (Frame)obj;
            frame.Content = new CinemaHallPage(cinemaHallViewModel);

        }
        #endregion

        #region SessionDoubleClick

        

        RelayCommand _DoubleClickSessionCommand;

        public ICommand DoubleClickSession
        {
            get
            {
                _DoubleClickSessionCommand = new RelayCommand(ExecuteDoubleClickSession);
                return _DoubleClickSessionCommand;
            }
        }

        private void ExecuteDoubleClickSession(object obj)
        {
            var frame = (Frame)obj;
            frame.Content = new SessionPage(sessionViewModel);

        }

        #endregion

        #region TicketDoubleClick

        

        RelayCommand _DoubleClickTicketCommand;

        public ICommand DoubleClickTicket
        {
            get
            {
                _DoubleClickTicketCommand = new RelayCommand(ExecuteDoubleClickTicket);
                return _DoubleClickTicketCommand;
            }
        }

        private void ExecuteDoubleClickTicket(object obj)
        {
            var frame = (Frame)obj;
            frame.Content = new TicketPage();

        }

        #endregion

        #region FilmDoubleClick

       

        RelayCommand _DoubleClickFilmCommand;

        public ICommand DoubleClickFilm
        {
            get
            {
                _DoubleClickFilmCommand = new RelayCommand(ExecuteDoubleClickFilm, CanExecuteDoubleClickFilm);
                return _DoubleClickFilmCommand;
            }
        }

        private bool CanExecuteDoubleClickFilm(object obj)
        {
            return !(employee.Role == "employee");
        }

        private void ExecuteDoubleClickFilm(object obj)
        {
            var frame = (Frame)obj;
            frame.Content = new FilmPage(filmViewModel);

        }

        #endregion

        #region CloseClick

        
        RelayCommand _ClickCloseBtnCommand;

        public ICommand ClickCloseBtn
        {
            get
            {
                _ClickCloseBtnCommand = new RelayCommand(ExecuteClickCloseBtn);
                return _ClickCloseBtnCommand;
            }
        }

        private void ExecuteClickCloseBtn(object obj)
        {
            ((MainWindow)App.serviceProvider.GetService(typeof(MainWindow))).Close();
        }
        #endregion
    }
}
