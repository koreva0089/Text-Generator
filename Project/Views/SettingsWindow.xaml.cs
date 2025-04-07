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
        }

        public Settings GetResult()
        {
            return new Settings(settingsViewModel.GenerateType);
        }
    }
}
