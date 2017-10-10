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
using System.Data.OleDb; // Required when using databaseconnection


namespace RUregistered
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        // connecting to the OLEDATABASE (Which is the Access database)
        //OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Mbube\Downloads\RUregistered\RUregistered.accdb");
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RUregistered.accdb"); //@https://stackoverflow.com/questions/1833640/connection-string-with-relative-path-to-the-database-file
        public MainWindow()
        {
            InitializeComponent();
            textBox.Focus();
            //Display();
           

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // button to enter new data
            clearTextBoxes();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Insert data to database 
            string j = textBox2.Text;
            int b = j.Length;
            try
            {

                if (textBox.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && b==8 && comboBox.Text != "" && textBox4.Text != "")
                {


                    //openning the database connection
                    connection.Open();

                    //A Query made in the database
                    OleDbCommand command = new OleDbCommand(@"INSERT INTO RUTable
                         ([First Name], [Last Name], [Student Number], Email, Course, [Password])
                    VALUES('" + textBox.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox.Text + "','"+textBox4.Text+"')", connection);

                    command.ExecuteNonQuery();

                    //clossing the connection
                    connection.Close();

                    MessageBox.Show("Successsfully Saved...! \n Click new to insert another record ");
                    //Display();

                    this.Hide();
                    Revision X = new Revision();
                    X.ShowDialog();
                }
                if (textBox.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox.Text == "" || textBox4.Text == "")
                {
                    textBox.BorderBrush = Brushes.Red;
                    textBox1.BorderBrush = Brushes.Red;
                    textBox2.BorderBrush = Brushes.Red;
                    textBox3.BorderBrush = Brushes.Red;
                    textBox4.BorderBrush = Brushes.Red;
                    comboBox.BorderBrush = Brushes.Red;

                    MessageBox.Show("Fill all fields");
                    textBox.BorderBrush = Brushes.Gray;
                    textBox1.BorderBrush = Brushes.Gray;
                    textBox2.BorderBrush = Brushes.Gray;
                    textBox3.BorderBrush = Brushes.Gray;
                    textBox4.BorderBrush = Brushes.Gray;
                    comboBox.BorderBrush = Brushes.Gray;
                }
                if(b != 8) { MessageBox.Show("Student Number must be a length of 8. \n it should start with a g/G "); textBox2.BorderBrush = Brushes.Red; }
                
            }
            catch (OleDbException)
            {
                //Checking if the Student Number exists or not hence its a primary key

                MessageBox.Show("You are already in the system. You are now entering a duplicate of yourself.");
                connection.Close();
            }
   
            
        }

        void clearTextBoxes()
        {
            textBox.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
            comboBox.SelectedIndex = -1;
            textBox.Focus(); // bringing the forcus to the textBox with the name textBox
        }

        void Display()
        {
            // to view data on the dataGrid with the name dataGrid1
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

                    Display();
                    clearTextBoxes();
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
            //Update data to database 
            try
            {

                if (textBox.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox.Text != "" && textBox4.Text != "")
                {


                    //openning the database connection
                    connection.Open();

                    //A Query made in the database
                    OleDbCommand command = new OleDbCommand(@"UPDATE       RUTable
 SET                [First Name] ='" + textBox.Text + "', [Last Name] ='" + textBox1.Text + "', [Student Number] ='" + textBox2.Text + "', Email ='" + textBox3.Text + "', Course ='" + comboBox.Text + "', [Password] ='" + textBox4.Text + "' WHERE        (RUTable.[Student Number] = '" + textBox2.Text + "')", connection);

                    command.ExecuteNonQuery();

                    //clossing the connection
                    connection.Close();

                    MessageBox.Show("Updated Successfully...! \n Click new to update another record ");
                    Display();
                    clearTextBoxes();
                }
                if (textBox.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox.Text == "" || textBox4.Text == "")
                {
                    textBox.BorderBrush = Brushes.Red;
                    textBox1.BorderBrush = Brushes.Red;
                    textBox2.Background = Brushes.Red;
                    textBox3.BorderBrush = Brushes.Red;
                    textBox4.BorderBrush = Brushes.Red;
                    comboBox.BorderBrush = Brushes.Red;

                    MessageBox.Show("Fill all fields specifying the Student number you want update its details");
                    textBox.BorderBrush = Brushes.Gray;
                    textBox1.BorderBrush = Brushes.Gray;
                    textBox2.Background = Brushes.White;
                    textBox2.BorderBrush = Brushes.Gray;
                    textBox3.BorderBrush = Brushes.Gray;
                    textBox4.BorderBrush = Brushes.Gray;
                    comboBox.BorderBrush = Brushes.Gray;
                    textBox2.Focus();
                }

            }
            catch (OleDbException)
            {
                //Checking if the Student Number exists or not hence its a primary key

                MessageBox.Show("You are already in the system. You have not updated any details.");
                connection.Close();
            }
        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && textBox.Text != "") { textBox1.Focus(); }
            if (e.Key == Key.Enter && textBox1.Text != "") { textBox2.Focus(); }
            if (e.Key == Key.Enter && textBox2.Text != "") { textBox3.Focus(); }
            if (e.Key == Key.Enter && textBox3.Text != "") { textBox4.Focus(); }
            if (e.Key == Key.Enter && textBox4.Text != "") { comboBox.Focus(); }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {

            if (passwordBox.Password == "0000")
            {
                this.Hide();
                AdministratorUse X = new AdministratorUse();
                X.ShowDialog();
            }
            else
            {
                passwordBox.BorderBrush = Brushes.Red;
                MessageBox.Show("You've entered a wrong password");
                passwordBox.BorderBrush = Brushes.Gray;
            }
        }

        private void intro_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LogIn X = new LogIn();
            X.ShowDialog();
        }

        private void intro_MouseLeave(object sender, MouseEventArgs e)
        {
            intro.Content = "";
        }

        private void intro_MouseMove(object sender, MouseEventArgs e)
        {
            intro.Content = "LogIn";
        }
    }
}