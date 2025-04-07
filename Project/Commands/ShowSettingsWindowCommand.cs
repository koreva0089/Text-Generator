using Project.ViewModel;
using Project.Views;
using System.Windows;

namespace Project.Commands
{
    public class ShowSettingsWindowCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;

        public ShowSettingsWindowCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is MainWindow)
            {
                var mainWindow = parameter as Window;

                var settingsWindow = new SettingsWindow();
                settingsWindow.Owner = mainWindow;
                settingsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                // Case where user changed setting
                if (settingsWindow.ShowDialog() == true)
                {
                    
                }
            }
        }
    }
}
