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
using System.Data.OleDb; // Required when using databaseconnection

namespace RUregistered
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RUregistered.accdb");

            try
            {
                connection.Open();
                string Query = @"SELECT[Student Number], [Password]
                        FROM RUTable
                                    WHERE([Student Number] = '" + textBox2.Text + "') AND([Password] = '" + passwordBox.Password + "')";
                OleDbCommand Command = new OleDbCommand(Query, connection);
                Command.ExecuteNonQuery();

                OleDbDataReader ODR = Command.ExecuteReader();
                int i = 0;
                while (ODR.Read())      //@https://www.youtube.com/watch?v=6WWaFRBxNBU
                {
                    i++;

                }
                if (i == 1)
                {
                    this.Hide();
                    Revision X = new Revision();
                    X.ShowDialog();
                }
                if (i < 1)
                {
                    MessageBox.Show("Student Number and password is incorrect");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow X = new MainWindow();
            X.ShowDialog();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Enter all your details again and provide a new password the press update button");
            this.Hide();
            MainWindow X = new MainWindow();
            X.ShowDialog();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter && textBox2.Text != "") { passwordBox.Focus(); }
        }
    }
}
