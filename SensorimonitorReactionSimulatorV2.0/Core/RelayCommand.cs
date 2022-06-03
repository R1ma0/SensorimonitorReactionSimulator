using System;
using System.Windows.Input;

namespace SensorimonitorReactionSimulatorV2._0.Core
{
    class RelayCommand : ICommand
    {

        #region Fields
        private Action<object> _execute;
        private Func<object, bool> _canExecute;
        #endregion

        #region Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

        #region Constructors
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
        public void Execute(object parameter) => _execute(parameter);
        #endregion
    }
}
