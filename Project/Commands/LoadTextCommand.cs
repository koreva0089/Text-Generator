using Microsoft.Win32;
using Project.ViewModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;

namespace Project.Commands
{
    public class LoadTextCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            var mainViewModel = parameter as MainViewModel;
            if (mainViewModel == null)
            {
#if DEBUG
                string errorMessage = "LoadTextCommand -> mainViewModel is null";
                Debug.WriteLine(errorMessage);
                MessageBox.Show(errorMessage, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
#endif
                return;
            }

            OpenFileDialog dialog = new();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";

            if (dialog.ShowDialog() == true)
            {
                mainViewModel.TextToGenerate = string.Empty;
#if DEBUG
                MessageBox.Show(dialog.FileName);
#endif
                using (var fileStream = new FileStream(dialog.FileName, FileMode.Open))
                {
                    StringBuilder str = new();

                    byte[] buf = new byte[1024];
                    var temp = new UTF8Encoding(true);
                    int readLen;

                    while ((readLen = fileStream.Read(buf, 0, buf.Length)) > 0)
                    {
                        str.Append(temp.GetString(buf, 0, readLen));
                    }
                    mainViewModel.TextToGenerate = str.ToString();
                }

            }
        }
    }
}
