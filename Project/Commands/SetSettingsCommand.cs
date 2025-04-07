using Project.Views;

namespace Project.Commands
{
    public class SetSettingsCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            var window = parameter as SettingsWindow;

            if (window != null)
            {
                window.DialogResult = true;
            }
        }
    }
}
