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
using System.Diagnostics;
using System.IO;

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
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void wotlButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo WotL = new ProcessStartInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wotl", "Isaac_WotL.exe"));
            this.Hide();
            Process.Start(WotL).WaitForExit(); //We wait for exit to track Steam time
            this.Close();

        }

        private void vanillaButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo vanilla = new ProcessStartInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vanilla", "Isaac_Vanilla.exe"));
            this.Hide();
            Process.Start(vanilla).WaitForExit(); //We wait for exit to track Steam time
            this.Close();
        }




    }
}
