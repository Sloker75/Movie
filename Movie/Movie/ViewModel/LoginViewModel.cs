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
        AuthorizationService authorizationService;
        private LoginData loginData;
        public LoginViewModel(AuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        public LoginData CurrentLogin
        {
            get
            {
                if (loginData != null) return loginData;
                {
                    loginData = new LoginData();
                    return loginData;
                }
            }
            set
            {
                loginData = value;
                OnPropertyChange("CurrentLogin");
            }
        }

        RelayCommand _addLoginDataCommand;

        public ICommand AddLoginCommand
        {
            get
            {
                if (_addLoginDataCommand == null)
                {
                    _addLoginDataCommand = new RelayCommand(ExecuteAddEmployee, CanExecuteAddEmployee);
                }
                return _addLoginDataCommand;
            }
        }

        private bool CanExecuteAddEmployee(object obj)
        {
            if(String.IsNullOrEmpty(CurrentLogin.Login) || String.IsNullOrEmpty(CurrentLogin.Password))
            {
                return false;
            }
            //else if (!Regex.IsMatch(CurrentLogin.Password, @"\d{6}"))
            //{

            //}
            return true;
        }

        private void ExecuteAddEmployee(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
