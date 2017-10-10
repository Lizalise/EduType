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
using System.IO;
using Microsoft.Win32;

namespace RUregistered
{
    /// <summary>
    /// Interaction logic for Revision.xaml
    /// </summary>
    interface NameOfThing
    {
        string Name { get; set; }
    }
    class Content
    {
        public string Text { get; protected set; }
        public Content(string r)
        {
            Text = r;
        }

    }
    class Subject : NameOfThing
    {
        public string Name { get; set; }
        public List<Examples> MyExamples;
        public List<Definitions> MyDefs;
        public List<LectureNotes> myLectNotes;
        public Subject(string name)
        {
            Name = name;
            MyExamples = new List<Examples>();
            MyDefs = new List<Definitions>();
            myLectNotes = new List<LectureNotes>();
        }
    }
    class LectureNotes : Content, NameOfThing
    {
        DateTime Date { get; set; }
        public string Name { get; set; }
        public LectureNotes(string name, string content, DateTime date) : base(content)
        {
            Date = date;
            Name = name;
        }
        public override string ToString()
        {
            string text = $"{Name} {Date}\n\n \n  {Text}";
            return text;
        }
    }
    class Examples : Content, NameOfThing
    {
        public string Name { get; set; }
        public Examples(string NameOfExamples, string content) : base(content)
        {
            Name = NameOfExamples;
        }
        public override string ToString()
        {
            string text = $"The concept of {Name}: \n\n \n{Text}";
            return text;
        }
    }
    class Definitions : Content, NameOfThing
    {
        public string Name { get; set; }

        public Definitions(string name, string content) : base(content)
        {
            Name = name;
        }
        public override string ToString()
        {
            string text = $"{Name}: \n \n {Text}";
            return text;
        }
    }
    public class studentNumberFile
    {
        public string Name { get; set; }
        public studentNumberFile(string name)
        {
            Name = name;
        }
    }
    public partial class Revision : Window
    {
        studentNumberFile studentNumber;
        Subject Current;

        public Revision()
        {
            InitializeComponent();
            dataGrid.IsEnabled = false;
            Current = new Subject(textBox5.Text);
        }

        private void Save(string filename)
        {
            try
            {

                TextWriter filebash = File.AppendText(filename);
                if (Current.MyDefs.Count != 0)
                {
                    string v = "";
                    for (int i = 0; i < Current.MyDefs.Count; i++)
                    {
                        v = string.Format("{0}", Current.MyDefs[i]);
                        filebash.WriteLine(v);
                    }
                }

                if (Current.MyExamples.Count != 0)
                {
                    for (int i = 0; i < Current.MyExamples.Count; i++)
                    {
                        string v = string.Format("{0}", Current.MyExamples[i]);
                        filebash.WriteLine(v);
                    }
                }
                if (Current.myLectNotes.Count != 0)
                {
                    for (int i = 0; i < Current.myLectNotes.Count; i++)
                    {
                        string v = string.Format("{0}", Current.myLectNotes[i]);
                        filebash.WriteLine(v);
                    }
                }
                filebash.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region next, prev methods
        int LectCount = 0;
        int DefCount = 0;
        int ExCount = 0;

        private void Next()
        {

            if (LectCount < Current.myLectNotes.Count)
            {
                Revisiontxt.Text = Convert.ToString(Current.myLectNotes[LectCount]);
                LectCount++;
            }
            else if (DefCount < Current.MyDefs.Count)
            {
                Revisiontxt.Text = Convert.ToString(Current.MyDefs[DefCount]);
                DefCount++;
            }
            else if (ExCount < Current.MyExamples.Count)
            {
                Revisiontxt.Text = Convert.ToString(Current.MyExamples[ExCount]);
                ExCount++;
            }
            else
            {
                LectCount = 0;
                DefCount = 0;
                ExCount = 0;
            }

        }
        private void Prev()
        {
            if (LectCount == 0 && DefCount == 0 && ExCount == 0)
            {
                Revisiontxt.Text = Convert.ToString(Current.myLectNotes[LectCount]);
                LectCount = Current.myLectNotes.Count - 1;
                DefCount = Current.MyDefs.Count - 1;
                ExCount = Current.MyExamples.Count - 1;
            }
            else
            {
                if (LectCount > 0 && LectCount < Current.myLectNotes.Count)
                {

                    LectCount--;
                    Revisiontxt.Text = Convert.ToString(Current.myLectNotes[LectCount]);
                }
                else if (DefCount > 0 && DefCount < Current.MyDefs.Count)
                {
                    DefCount--;
                    Revisiontxt.Text = Convert.ToString(Current.MyDefs[DefCount]);
                }
                else if (ExCount > 0 && ExCount < Current.MyExamples.Count)
                {
                    ExCount--;
                    Revisiontxt.Text = Convert.ToString(Current.MyExamples[ExCount]);
                }
                else
                {
                    LectCount = Current.myLectNotes.Count - 1;
                    DefCount = Current.MyDefs.Count - 1;
                    ExCount = Current.MyExamples.Count - 1;
                }
            }
        }

        #endregion

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ExampleTextBox.Text == ""|| ExampleName.Text=="") throw new Exception("Please enter text on both texboxes!");
                Examples n = new Examples(ExampleName.Text, ExampleTextBox.Text);
                Current.MyExamples.Add(n);
                ExampleName.Text = "";
                ExampleTextBox.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        protected string ReadString(StreamReader r)
        {
            int lines = Convert.ToInt32(r.ReadLine());
            string s = "";
            for (int i = 0; i < lines; i++)
            {
                s += r.ReadLine() + "\n";
            }
            return s;
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow X = new MainWindow();
            X.ShowDialog();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DefName.Text == "" || ExampleTextBox == null) throw new Exception("Please enter text on both texboxes!");
                Current.MyDefs.Add(new Definitions(DefName.Text, Txtdefinition.Text));
                DefName.Text = "";
                Txtdefinition.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try {
                Save(Current.Name);
                MessageBox.Show("successfully saved!!");
                //SaveFileDialog saver = new SaveFileDialog();

                //saver.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill in your student number first");
            }
        }

        private void textBox5_TextChanged(object sender, TextChangedEventArgs e)
        {

            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\RUregistered.accdb");

            {

                try
                {
                    connection.Open();

                    OleDbDataAdapter Query = new OleDbDataAdapter("select [Course] from RUTable WHERE (RUTable.[Student Number] like '" + textBox5.Text + "%') OR (RUTable.[Last Name] like '" + textBox5.Text + "%')", connection); // the *  selects everything on the database table

                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    //fill the datatable
                    Query.Fill(dataTable);

                    dataGrid.ItemsSource = dataTable.DefaultView; // viewing the table  on the dataGrid1
                    Query.Update(dataTable); //update the table
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string j = textBox5.Text;
                int b = j.Length;
                if (e.Key == Key.Enter && b == 8)
                {
                    dataGrid.IsEnabled = true;
                    dataGrid.IsReadOnly = true;
                    Current = new Subject(textBox5.Text);
                    textBox5.IsReadOnly = true;
                    studentNumber = new studentNumberFile(textBox5.Text);
                }
                else
                {
                    if (e.Key == Key.Enter && b != 8)
                    {
                        MessageBox.Show("Invalid student number");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Edutype X = new Edutype();
            X.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DefName.Text == "" || Txtdefinition.Text == "") throw new Exception("Please enter text on both texboxes!");
                Current.MyDefs.Add(new Definitions(DefName.Text, Txtdefinition.Text));
                DefName.Text = "";
                Txtdefinition.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            try {
                if (LecNotes.Text == "") throw new Exception("Please enter text on both texboxes!");
                LectureNotes n = new LectureNotes(textBox5.Text, LecNotes.Text, DateTime.Today);
                Current.myLectNotes.Add(n);
                LecNotes.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void load(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Current.Name))
            {
                StreamReader y = File.OpenText(Current.Name);
                Revisiontxt.Text = ReadString(y);
            }
            else
            {
                Next();
            }
        }

        private void nextbtn_Click(object sender, RoutedEventArgs e)
        {
            Next();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Prev();
        }
    }
}

