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
using System.Windows.Shapes;

namespace RUregistered
{
    /// <summary>
    /// Interaction logic for Intro.xaml
    /// </summary>
    public partial class Intro : Window
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void intro_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow X = new MainWindow();
            X.ShowDialog();
        }

        private void intro_MouseLeave(object sender, MouseEventArgs e)
        {
           intro.Content = "";
        }
        private void intro_MouseMove(object sender, MouseEventArgs e)
        {
            intro.Content = "Click here to proceed";
        }
    }
}
