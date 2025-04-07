using Project.Commands;
using Project.Models;
using System.Windows.Input;

namespace Project.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public Settings Settings { get; set; }

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

        public ICommand CopyCommand { get; }
        public ICommand PasteCommand { get; }
        public ICommand CutCommand { get; }

        public MainViewModel()
        {
            Settings = new(GenerateType.Words);

            GenerateTextCommand = new GenerateTextCommand(this);
            ShowSettingsWindowCommand = new ShowSettingsWindowCommand(this);
            CloseWindowCommand = new CloseWindowCommand();
            LoadTextCommand = new LoadTextCommand(this);

            CopyCommand = new CopyCommand(this);
            PasteCommand = new PasteCommand(this);
            CutCommand = new CutCommand(this);
        }
    }
}
