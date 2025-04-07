using Project.Models;

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
    }
}
