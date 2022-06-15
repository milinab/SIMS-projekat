using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hospital.View.PatientView.Commands
{
    public class CommandPatient : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #region Constructors
        public CommandPatient(Action<object> execute) : this(execute, null) { }

        public CommandPatient(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region ICommand
        public bool CanExecute(object parameters)
        {
            return _canExecute == null ? true : _canExecute(parameters);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameters)
        {
            _execute.Invoke(parameters);
        }
        #endregion
    }
}
