using Project.Commands;
using Project.Models;
using System.Windows.Input;

namespace Project.ViewModel
{
    public class SettingsViewModel : BaseViewModel
    {
        private GenerateType generateType;
        public GenerateType GenerateType
        {
            get => generateType;
            set
            {
                generateType = value;
                OnPropertyChanged(nameof(GenerateType));
            }
        }

        public ICommand SetSettingsCommand { get; }

        public SettingsViewModel()
        {
            SetSettingsCommand = new SetSettingsCommand();
        }
    }
}
