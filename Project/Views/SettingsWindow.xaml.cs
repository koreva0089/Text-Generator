using Project.Models;
using Project.ViewModel;
using System.Windows;

namespace Project.Views
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private readonly SettingsViewModel settingsViewModel;

        public SettingsWindow(Settings settings)
        {
            InitializeComponent();

            settingsViewModel = Resources["SettingsViewModel"] as SettingsViewModel
                ?? throw new ArgumentException();

            settingsViewModel.GenerateType = settings.GenerateType;
            settingsViewModel.Count = settings.Count;
            settingsViewModel.StepsType = settings.StepsType;
        }

        public bool IsValidated()
        {
            int value;
            bool isConverted = int.TryParse(countTextBox.Text, out value);

            return isConverted && value > 0;
        }

        public Settings GetResult()
        {
            return new Settings()
            {
                GenerateType = settingsViewModel.GenerateType,
                Count = settingsViewModel.Count,
                StepsType = settingsViewModel.StepsType
            };
        }
    }
}
