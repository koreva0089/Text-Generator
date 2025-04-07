using System.Windows;

namespace Project.Commands
{
    public class CloseWindowCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            var window = parameter as Window;
            window?.Close();
        }
    }
}
