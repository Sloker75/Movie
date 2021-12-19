using BLL.Services;
using DLL.Models;
using Movie.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Movie.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly AuthorizationService _authorizationService;
        private Employee employee;
        private LoginData loginData = new LoginData();
  
        public LoginViewModel(AuthorizationService authorizationService, Employee employee)
        {
            this._authorizationService = authorizationService;
            this.employee = employee;
        }

        public LoginData LoginData
        {
            get
            {
                return loginData;
            }
            set
            {
                loginData = value;
                OnPropertyChange(nameof(LoginData)); 
            }
        }

        RelayCommand _addLoginDataCommand;

        public ICommand AddLoginCommand
        {
            get
            {
                if (_addLoginDataCommand == null)
                {
                    _addLoginDataCommand = new RelayCommand(ExecuteAuthorization, CanExecuteAuthorizatio);
                }
                return _addLoginDataCommand;
            }
        }

        private bool CanExecuteAuthorizatio(object obj)
        {
            if(String.IsNullOrEmpty(LoginData.Login) || String.IsNullOrEmpty(LoginData.Password))
            {
                return false;
            }
            else if (!Regex.IsMatch(LoginData.Login, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase))
            {
                return false;
            }
            else if (!(Convert.ToInt32(LoginData.Password) >= 111111))
            {
                return false;
            }
            return true;
        }

        private async void ExecuteAuthorization(object obj)
        {
           var _employee =  await _authorizationService.AuthorizationAsync(LoginData);
            if (_employee != null)
            {
                employee.Name = _employee.Employee.Name;
                employee.Surname = _employee.Employee.Surname;
                employee.salary = _employee.Employee.salary;
                employee.Role = _employee.Employee.Role;
                employee.BirthDay = _employee.Employee.BirthDay;
                employee.PhoneNumber = _employee.Employee.PhoneNumber;
                employee.LoginDataId = _employee.Employee.LoginDataId;
            }
            ((MainWindow)App.serviceProvider.GetService(typeof(MainWindow))).Show();
        }

        RelayCommand _ClickCloseBtnCommand;

        public ICommand ClickCloseBtn
        {
            get
            {
                if (_ClickCloseBtnCommand == null)
                {
                    _ClickCloseBtnCommand = new RelayCommand(ExecuteClickCloseBtn);
                }
                return _ClickCloseBtnCommand;
            }
        }

        private void ExecuteClickCloseBtn(object obj)
        {
            ((AuthorizationWindow)App.serviceProvider.GetService(typeof(AuthorizationWindow))).Close();
        }
    }
}
