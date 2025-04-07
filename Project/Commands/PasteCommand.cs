using Project.ViewModel;
using System.Windows;

namespace Project.Commands
{
    public class PasteCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;

        public PasteCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
            mainViewModel.TextToGenerate = Clipboard.GetText();
        }
    }
}
