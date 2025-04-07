using Project.Commands;
using System.Windows.Input;

namespace Project.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string textToGenerate = string.Empty;
        public string TextToGenerate
        {
            get => textToGenerate;
            set
            {
                textToGenerate = value;
                OnPropertyChanged(nameof(TextToGenerate));
            }
        }

        private string generatedText = string.Empty;
        public string GeneratedText
        {
            get => generatedText;
            set
            {
                generatedText = value;
                OnPropertyChanged(nameof(GeneratedText));
            }
        }


        public ICommand GenerateTextCommand { get; }
        public ICommand ShowSettingsWindowCommand { get; }
        public ICommand CloseWindowCommand { get; }
        public ICommand LoadTextCommand { get; }

        public MainViewModel()
        {
            GenerateTextCommand = new GenerateTextCommand(this);
            ShowSettingsWindowCommand = new ShowSettingsWindowCommand();
            CloseWindowCommand = new CloseWindowCommand();
            LoadTextCommand = new LoadTextCommand();
        }
    }
}
