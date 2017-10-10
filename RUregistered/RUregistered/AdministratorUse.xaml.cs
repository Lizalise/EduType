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
    /// Interaction logic for AdministratorUse.xaml
    /// </summary>
    public partial class AdministratorUse : Window
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RUregistered.accdb");
        public AdministratorUse()
        {
            InitializeComponent();
        }
        public void display()
        {
            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RUregistered.accdb");

            try
            {
                connection.Open();
                string Query = "select * from RUTable"; // the *  selects everything on the database table
                OleDbCommand Command = new OleDbCommand(Query, connection);
                Command.ExecuteNonQuery();
                //creating an adapter
                OleDbDataAdapter adapter = new OleDbDataAdapter(Command);
                System.Data.DataTable dataTable = new System.Data.DataTable("RUTable");
                //fill the datatable
                adapter.Fill(dataTable);
                dataGrid1.ItemsSource = dataTable.DefaultView; // viewing the table created on the dataGrid1
                adapter.Update(dataTable); //update the table
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            display();
        }

        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RUregistered.accdb");

            try
            {
                connection.Open();
                string Query = "select * from RUTable WHERE (RUTable.[Student Number] like '" + textBox4.Text + "%') or (RUTable.[Last Name] like '" + textBox4.Text + "%')"; // the *  selects everything on the database table
                OleDbCommand Command = new OleDbCommand(Query, connection);
                Command.ExecuteNonQuery();
                //creating an adapter
                OleDbDataAdapter adapter = new OleDbDataAdapter(Command);
                System.Data.DataTable dataTable = new System.Data.DataTable("RUTable");
                //fill the datatable
                adapter.Fill(dataTable);
                
                dataGrid1.ItemsSource = dataTable.DefaultView; // viewing the table  on the dataGrid1
                adapter.Update(dataTable); //update the table
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //delete from Database


            try
            {
                if (textBox2.Text != "" || @"RUTable.[Student Number]" == textBox2.Text)
                {
                    //openning the database connection
                    connection.Open();

                    //A Query made in the database

                    OleDbCommand command = new OleDbCommand(@"DELETE FROM RUTable
                   WHERE      (RUTable.[Student Number]='" + textBox2.Text + "')", connection);

                    command.ExecuteNonQuery();

                    //clossing the connection

                    connection.Close();
                    MessageBox.Show("Deleted Successsfully....!");

                    display();
                   
                }
                else
                {
                    textBox2.Background = Brushes.Red;
                    MessageBox.Show("Enter your Student Number");
                    textBox2.Background = Brushes.White;
                    textBox2.Focus();
                }
            }
            catch (OleDbException)
            {
                //Checking if the Student Number exists or not hence its a primary key

                MessageBox.Show("The record you want to delete is not found.");
                connection.Close();
            }

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow X = new MainWindow();
            X.ShowDialog();
        }
    }
    }

