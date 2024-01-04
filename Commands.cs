using System;
using System.Windows.Input;

namespace HW18_arbg_editor
{
    internal class Commands : ICommand
    {
        Action<object> _execute;
        Predicate<object> _canExecute;

        public Commands(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object obj)
        {
            if (_canExecute != null)
            {
                return _canExecute(obj);
            }
            return true;
        }

        public void Execute(object obj)
        {
            _execute(obj);
        }

        public event EventHandler CanExecuteChanged
        {
            add 
            { 
                CommandManager.RequerySuggested += value; 
            }
            remove 
            { 
                CommandManager.RequerySuggested -= value; 
            }
        }
    }
}
