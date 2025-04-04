using Project.Commands;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project.ViewModel
{
    class MainViewModel
    {
        public string TextToGenerate { get; set; }
        public string GeneratedText { get; set; }

        public ICommand GenerateTextCommand { get; set; }
        public ICommand ShowSettingsWindowCommand { get; set; }

        public MainViewModel()
        {
            ShowSettingsWindowCommand = new RelayCommand(ShowSettingsWindow, CanShowSettingsWindow);
        }

        private bool CanShowSettingsWindow(object obj)
        {
            return true;
        }

        private void ShowSettingsWindow(object obj)
        {
            var mainWindow = obj as Window;

            var settingsWindow = new SettingsWindow();
            settingsWindow.Owner = mainWindow;
            settingsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            // Case where user changed setting
            if (settingsWindow.ShowDialog() == true)
            {
                MessageBox.Show("Settings changed");
            }
        }
    }
}
