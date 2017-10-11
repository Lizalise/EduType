using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.Integration;
using System.Data.OleDb; // Required when using databaseconnection

namespace RUregistered
{
    public partial class Edutype : Form
    {
        Revision revision;
        private string[] panagrams;
        private int pCounter = 0;
       // private int CurrentL = 0;
        private int[] Errors;
        public Edutype()
        {
            revision = new Revision();
            InitializeComponent();
            input.ReadOnly = true;
            panagrams = new String[3];
            Errors = new int[panagrams.Count()];
          
            //button1.Visible = false;
            //textBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "") throw new Exception("Please select a course");
                string s = textBox1.Text;
                FileStream read = File.OpenRead(s);
                var reader = new StreamReader(read);
                int counter = 0;
                while (!reader.EndOfStream)
                {
                    panagrams[counter] = reader.ReadLine();
                    counter++;
                }
                typeBox.Focus();
                Typing();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Typing()
        {
            typeBox.Clear();
            if (pCounter < panagrams.Count())
            {
                input.Text = panagrams[pCounter];
            }
            else
            {
                MessageBox.Show("End of the paragraph");
                ResetForm();
                Stats();
            }
        }

        private void Stats()
        {
            resultsBox.AppendText("Your Results: " + "\n" + "\n");
            for (int i = 0; i < Errors.Count(); i++)
            {
                resultsBox.AppendText("in sentence # " + (i + 1) + " you made " + Errors[i] + " mistakes" + "\n" + "\n");
            }
        }
        private void Accuracy()
        {
            Errors[pCounter] = Math.Abs(input.TextLength - typeBox.TextLength);
            int loopCounter = input.TextLength > typeBox.TextLength ? typeBox.TextLength : input.TextLength;
            for (int i = 0; i < loopCounter; i++)
            {
                if (input.Text.Substring(i, 1) != typeBox.Text.Substring(i, 1))
                {
                    Errors[pCounter] += 1;
                }
            }
        }
        private void ResetForm()
        {
            pCounter = 0;
            input.Clear();
            typeBox.Clear();
            input.Enabled = false;
            typeBox.Enabled = false;
        }


        private void highlightKey(string key)
        {
            ChangeBack();
            foreach (var c in this.Controls)
            {
                if (c is Label)
                {
                    Label label = (Label)c;
                    if (label.Tag != null && label.Tag.ToString().ToUpper() == key.ToUpper())
                    {
                        label.BackColor = Color.Red;
                        return;
                    }
                }
            }
            invalidKey.BackColor = Color.Red;

        }
        private void ChangeBack()
        {
            foreach (var c in this.Controls)
            {
                if (c is Label)
                {
                    Label label = (Label)c;
                    label.BackColor = Color.Empty;
                }
            }
        }


        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Revision x = new Revision();
            x.Show();
        }

        private void typeBox_Click_1(object sender, EventArgs e)
        {
            typeBox.SelectionStart = typeBox.TextLength;
        }

        private void typeBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode != Keys.Enter)
                highlightKey(e.KeyCode.ToString());
            else
            {
                Accuracy();
                typeBox.Clear();
                pCounter++;
                Typing();
            }
        }

        private void typeBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edutype X = new Edutype();
            X.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow X = new MainWindow();
            X.ShowDialog();
        }
    }
}
