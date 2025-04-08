using Project.Models;
using Project.ViewModel;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace Project.Commands
{
    public class GenerateTextCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;

        public GenerateTextCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;

            this.mainViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(mainViewModel.TextToGenerate))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(mainViewModel.TextToGenerate) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            //mainViewModel.GeneratedText = mainViewModel.TextToGenerate;
            Dictionary<string, Node> database = new();
            string[] data = mainViewModel.TextToGenerate.Split(' ', StringSplitOptions.None);

            StringBuilder str = new();
            for(int i = 0; i < data.Length; i++)
            {
                str.AppendLine($"{i}. {data[i]}");
            }
            MessageBox.Show(str.ToString());
        }
    }
}
