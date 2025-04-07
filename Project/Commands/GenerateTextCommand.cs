using Project.ViewModel;
using System.ComponentModel;

namespace Project.Commands
{
    public class GenerateTextCommand : BaseCommand
    {
        private readonly MainViewModel _mainViewModel;

        public GenerateTextCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            _mainViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_mainViewModel.TextToGenerate))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(_mainViewModel.TextToGenerate) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _mainViewModel.GeneratedText = _mainViewModel.TextToGenerate;
        }
    }
}
