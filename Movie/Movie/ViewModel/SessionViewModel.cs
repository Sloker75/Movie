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
                    return session;
                }
            }
            set
            {
                session = value;
                OnPropertyChange("CurrentEmployee");
            }
        }

        private ObservableCollection<Session> _employee;

        public ObservableCollection<Session> Worker
        {
            get
            {
                if (_employee != null) return _employee;
                else
                {
                    LoadEmployeeAsync();
                    return _employee;
                }
            }
        }

        private async void LoadEmployeeAsync() => _employee = new ObservableCollection<Session>(await _sessionService.GetAllSessionAsync());

        RelayCommand _addEmployeeCommand;
        public ICommand AddEmployeeCommand
        {
            get
            {
                if (_addEmployeeCommand == null)
                {
                    _addEmployeeCommand = new RelayCommand(ExecuteAddEmployee, CanExecuteAddEmployee);
                }
                return _addEmployeeCommand;
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
