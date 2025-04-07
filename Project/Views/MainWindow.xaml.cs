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

    private void ClipboardCut_Click(object sender, RoutedEventArgs e)
    {
        Clipboard.SetText(txtGenerated.Text);
        txtGenerated.Clear();
        MessageBox.Show("Text had been cut");
    }
}