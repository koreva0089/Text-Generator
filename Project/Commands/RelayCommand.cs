using System.Windows.Input;

namespace Project.Commands
{
    class RelayCommand : ICommand
    {
        private Action<object> _Execute { get; set; }
        private Predicate<object> _CanExecute { get; set; }

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<object> excecute, Predicate<object> canExcecute)
        {
            _Execute = excecute;
            _CanExecute = canExcecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _CanExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _Execute(parameter);
        }
    }
}
