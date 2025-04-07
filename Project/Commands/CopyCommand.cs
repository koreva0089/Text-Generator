using Project.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace Project.Commands
{
    public class CopyCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;

        public CopyCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;

            this.mainViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(mainViewModel.GeneratedText))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object? parameter)
        {
            Clipboard.SetText(mainViewModel.GeneratedText);
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(mainViewModel.GeneratedText) && base.CanExecute(parameter);
        }
    }
}
