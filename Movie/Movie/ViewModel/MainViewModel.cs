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

        public MainViewModel(EmployeeViewModel employeeViewModel)
        {
            this.employeeViewModel = employeeViewModel;
        }

        RelayCommand _DoubleClickEmployeeCommand;

        public ICommand DoubleClickEmployee
        {
            get
            {
                _DoubleClickEmployeeCommand = new RelayCommand(ExecuteDoubleclickEmployee);
                return _DoubleClickEmployeeCommand;
            }
        }

        private void ExecuteDoubleclickEmployee(object obj)
        {
            var frame = (Frame)obj;
            frame.Content = new EmployeePage(employeeViewModel);

        }

        RelayCommand _DoubleClickCinemaHallCommand;

        public ICommand DoubleClickCinemaHall
        {
            get
            {
                _DoubleClickCinemaHallCommand = new RelayCommand(ExecuteDoubleclickCinemaHall);
                return _DoubleClickCinemaHallCommand;
            }
        }

        private void ExecuteDoubleclickCinemaHall(object obj)
        {
            var frame = (Frame)obj;
            frame.Content = new CinemaHallPage();

        }

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
            frame.Content = new SessionPage();

        }

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

        RelayCommand _DoubleClickFilmCommand;

        public ICommand DoubleClickFilm
        {
            get
            {
                _DoubleClickFilmCommand = new RelayCommand(ExecuteDoubleClickFilm);
                return _DoubleClickFilmCommand;
            }
        }

        private void ExecuteDoubleClickFilm(object obj)
        {
            var frame = (Frame)obj;
            frame.Content = new FilmPage();

        }

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
    }
}
