using Project.ViewModel;
using Project.Views;
using System.ComponentModel;

namespace Project.Commands
{
    public class SetSettingsCommand : BaseCommand
    {
        private readonly SettingsViewModel settingsViewModel;

        public SetSettingsCommand(SettingsViewModel settingsViewModel)
        {
            this.settingsViewModel = settingsViewModel;

            this.settingsViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }

        public override void Execute(object? parameter)
        {
            var window = parameter as SettingsWindow;

            if (window != null)
            {
                window.DialogResult = true;
            }
        }

        public override bool CanExecute(object? parameter)
        {
            var window = parameter as SettingsWindow;

            if (window != null)
            {
                return window.IsValidated() && base.CanExecute(parameter);
            }

            return false;
        }
    }
}
