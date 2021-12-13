using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Movie.Infrastructure
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<object> execute) : this(execute, null)
        {

        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("Execute");
            }
            this._execute = execute;
            this._canExecute = canExecute;
        }

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        //public event EventHandler CanExecuteChanged
        //{
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}

        public bool CanExecute(object? parameter)
        {
            return this._canExecute == null ? true : this._canExecute.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
