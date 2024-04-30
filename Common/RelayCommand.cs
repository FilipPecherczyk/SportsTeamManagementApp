using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportsTeamManagementApp.Common
{
    public class RelayCommand : ICommand, IDisposable
    {
        readonly List<EventHandler> _canExecuteSubscribers = new List<EventHandler>();
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                _canExecuteSubscribers.Add(value);
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                CommandManager.InvalidateRequerySuggested();
                _canExecuteSubscribers.Remove(value);

            }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void Dispose()
        {
            var temp = _canExecuteSubscribers;

            foreach (var x in temp)
            {
                CanExecuteChanged -= x;
                break;
            }

            _canExecuteSubscribers.Clear();
        }
    }
}
