using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using Project.ViewModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }

    private void MenuExit_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void MenuOpen_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog dialog = new();
        dialog.DefaultExt = ".txt";
        dialog.Filter = "Text documents (.txt)|*.txt";

        if (dialog.ShowDialog() == true)
        {
            txtToGenerate.Text = string.Empty;

            MessageBox.Show(dialog.FileName);
            using (var fileStream=new FileStream(dialog.FileName, FileMode.Open))
            {
                byte[] buf = new byte[1024];
                var temp = new UTF8Encoding(true);
                int readLen;
                while ((readLen = fileStream.Read(buf, 0, buf.Length)) > 0)
                {
                    txtToGenerate.Text += temp.GetString(buf, 0, readLen);
                }
            }
        }
    }

    private void ClipboardCopy_Click(object sender, RoutedEventArgs e)
    {
        Clipboard.SetText(txtGenerated.Text);
        MessageBox.Show("Text had been copied");
    }

    private void ClipboardPaste_Click(object sender, RoutedEventArgs e)
    {
        txtToGenerate.Text = Clipboard.GetText();
    }

    private void GenerateText_Click(object sender, RoutedEventArgs e)
    {
        txtGenerated.Text = txtToGenerate.Text;
    }

    private void ClipboardCut_Click(object sender, RoutedEventArgs e)
    {
        Clipboard.SetText(txtGenerated.Text);
        txtGenerated.Clear();
        MessageBox.Show("Text had been cut");
    }
}