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

        private int count;
        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public ICommand SetSettingsCommand { get; }

        public SettingsViewModel()
        {
            SetSettingsCommand = new SetSettingsCommand(this);
        }
    }
}
