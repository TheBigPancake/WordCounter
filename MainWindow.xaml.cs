using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WordCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void UpdateStatusBar(double num)
        {
            if (num >= 0)
            {
                progress.Value = num;
                progress_text.Content = ((int)num) + "%";
            }
            else
                throw new Exception("The status bar cannot be below zero");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select text file";
            dialog.Filter = "Text files(*.txt)|*.txt";
            dialog.ShowDialog();
            
            file_path.Text = dialog.FileName;
            cancel_button.IsEnabled = false;
            start_button.IsEnabled = false;
            grid.ItemsSource = null;
            UpdateStatusBar(0);

            if (dialog.FileName is "") return;
            start_button.IsEnabled = true;
        }
    }
}
