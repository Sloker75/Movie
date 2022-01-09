using BLL.Services;
using DLL.Models;
using Movie.Infrastructure;
using Movie.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Movie.ViewModel
{
    public class EmployeeViewModel :BaseViewModel
    {
        private readonly AdminService _adminService;
        private readonly EmployeeService _employeeService;
        private Employee employee;

        public EmployeeViewModel(AdminService adminService, EmployeeService _employeeService)
        {
            this._adminService = adminService;
            this._employeeService = _employeeService;
        }

        public Employee CurrentEmployee
        {
            get
            {
                if (employee != null) return employee;
                {
                    employee = new Employee();
                    employee.Login = new LoginData();
                    return employee;
                }
            }
            set
            {
                employee = value;
                OnPropertyChange("CurrentEmployee");
            }
        }

        private ObservableCollection<Employee> _employee;

        public  ObservableCollection<Employee> Worker
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

        private async void LoadEmployeeAsync() => _employee = new ObservableCollection<Employee>(await _employeeService.GetAllAsync());


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
            if (String.IsNullOrEmpty(CurrentEmployee.Name) || String.IsNullOrEmpty(CurrentEmployee.Surname))
            {
                return false;
            }
            else if (CurrentEmployee.Name.Length > 25 || CurrentEmployee.Surname.Length > 25)
            {
                return false;
            }
            else if (CurrentEmployee.salary <= 0)
            {
                return false;
            }
            else if (CurrentEmployee.Role.ToLower() != "admin" && CurrentEmployee.Role.ToLower() != "employee")
            {
                return false;
            }
            //else if (!Regex.IsMatch(CurrentEmployee.PhoneNumber, @"\d{3}-\d{3}-\d{4}", RegexOptions.IgnoreCase))
            //{
            //    return false;
            //}
            //else if (!Regex.IsMatch(Convert.ToString(CurrentEmployee.BirthDay), @"\d{4}.\d{2}.\d{2}", RegexOptions.IgnoreCase))
            //{
            //    return false;
            //}
            //else if (CurrentEmployee.BirthDay > new DateTime(2006,12,31))
            //{
            //    return false;
            //}
            return true;
        }

        private void ExecuteAddEmployee(object obj)
        {
            _adminService.AddEmployeeAsync(CurrentEmployee);
        }
    }
}
