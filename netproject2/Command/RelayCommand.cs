using System;
using System.Windows.Input;

namespace netproject2.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        // Constructor for commands with parameter
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // Constructor for commands without parameter
        public RelayCommand(Action execute, Func<bool> canExecute = null)
            : this(execute != null ? (p => execute()) : throw new ArgumentNullException(nameof(execute)),
                   canExecute != null ? (p => canExecute()) : (Func<object, bool>)null)
        {
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
