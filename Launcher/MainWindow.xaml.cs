using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics; 

namespace Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show(SaveManager.getSolPath());
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void wotlButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo WotL = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + @"\Isaac_WotL.exe");
            this.Hide();
            Process.Start(WotL).WaitForExit(); //We wait for exit to track Steam time
            this.Close();

        }

        private void vanillaButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo vanilla = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + @"\Isaac_Vanilla.exe");
            this.Hide();
            Process.Start(vanilla).WaitForExit(); //We wait for exit to track Steam time
            this.Close();
        }




    }
}
