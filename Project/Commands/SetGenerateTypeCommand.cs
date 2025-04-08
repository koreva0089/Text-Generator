using Project.Models;
using Project.ViewModel;
using System.ComponentModel;

namespace Project.Commands
{
    public class SetGenerateTypeCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;

        public SetGenerateTypeCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;

            this.mainViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(GenerateType))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object? parameter)
        {
            var type = parameter as string;

            if (type != null)
            {
                switch (type)
                {
                    case "words":
                        mainViewModel.GenerateType = mainViewModel.Settings.GenerateType = Models.GenerateType.Words;
                        break;

                    case "letters":
                        mainViewModel.GenerateType = mainViewModel.Settings.GenerateType = Models.GenerateType.Letters;
                        break;
                }
            }
        }

        public override bool CanExecute(object? parameter)
        {
            var type = parameter as string;

            return !(type == "words" && mainViewModel.GenerateType == GenerateType.Words)
                && !(type == "letters" && mainViewModel.GenerateType == GenerateType.Letters)
                && base.CanExecute(parameter);
        }
    }
}
