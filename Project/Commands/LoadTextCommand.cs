using Microsoft.Win32;
using Project.ViewModel;
using System.IO;
using System.Text;
using System.Windows;

namespace Project.Commands
{
    public class LoadTextCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;

        public LoadTextCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public override void Execute(object? parameter)
        {
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
