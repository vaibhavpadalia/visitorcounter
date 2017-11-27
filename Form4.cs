using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;   
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visitor_Counter
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new OpenFileDialog();
                dialog.ShowDialog();
                string result = dialog.FileName;
                string src = "C:/Users/samsung pc/Documents/Visitor.accdb";
                System.IO.File.Copy(src, result, true);
                MessageBox.Show("Backup Completed !", "Success");
            }
            catch 
            {
                MessageBox.Show("Please select a file !!" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OleDbConnection conn1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Vaibhav Jonas/Documents/Visitor.accdb");
            conn1.Open();
            try
            {
                OleDbCommand cm = new OleDbCommand("SELECT ID FROM vis WHERE sno=' " + textBox1.Text + " ' ", conn1);
                textBox2.Text = cm.ExecuteScalar().ToString();
                OleDbCommand cmd = new OleDbCommand("SELECT name FROM vis WHERE sno=' " + textBox1.Text + " ' ", conn1);
                textBox3.Text = cmd.ExecuteScalar().ToString();
                OleDbCommand cmd1 = new OleDbCommand("SELECT status FROM vis WHERE sno =' " + textBox1.Text + " ' ", conn1);
                textBox4.Text = cmd1.ExecuteScalar().ToString();
                OleDbCommand cmd2 = new OleDbCommand("SELECT checkin FROM vis WHERE sno =' " + textBox1.Text + " ' ", conn1);
                textBox5.Text = cmd2.ExecuteScalar().ToString();
                OleDbCommand cmd3 = new OleDbCommand("UPDATE vis SET checkout=' " + DateTime.Now + " ' WHERE sno =' " + textBox1.Text + " ' ", conn1);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Checked Out Successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Entry Not Found ! Please check again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            conn1.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            for (int p = 0; p < textBox1.Text.Length; p++)
            {
                if (Char.IsLetter(textBox1.Text, p))
                {
                    MessageBox.Show("You Can't Enter A Character !! \n Please Enter a number !");
                    textBox1.Focus();
                    textBox1.Text = "";
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            button3.Hide();
            button2.Hide();
            button4.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/samsung pc/Documents/Visitor.accdb");
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("UPDATE vis SET ID=' " + textBox2.Text + " ' WHERE sno =' " + textBox1.Text + " ' ", conn);
            cmd.ExecuteNonQuery();
            OleDbCommand cmd1 = new OleDbCommand("UPDATE vis SET name=' " + textBox3.Text + " ' WHERE sno =' " + textBox1.Text + " ' ", conn);
            cmd1.ExecuteNonQuery();
            OleDbCommand cmd2 = new OleDbCommand("UPDATE vis SET status=' " + textBox4.Text + " ' WHERE sno =' " + textBox1.Text + " ' ", conn);
            cmd2.ExecuteNonQuery();
            OleDbCommand cmd3 = new OleDbCommand("UPDATE vis SET checkin=' " + textBox5.Text + " ' WHERE sno =' " + textBox1.Text + " ' ", conn);
            cmd3.ExecuteNonQuery();
            MessageBox.Show("Job Completed !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            button1.Show();
            button2.Hide();
            button3.Hide();
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            conn.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4.Hide();
            button1.Hide();
            button2.Show();
            button3.Show();
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Show();
            button4.Show();
            button3.Hide();
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/samsung pc/Documents/Visitor.accdb");
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("DELETE TABLE FROM vis WHERE sno=' " + textBox1.Text + " ' ", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Entry Deleted !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button1.Show();
            button2.Hide();
            button4.Hide();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conn1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/samsung pc/Documents/Visitor.accdb");
            conn1.Open();
            try
            {
                OleDbCommand cm = new OleDbCommand("SELECT ID FROM vis WHERE sno=' " + textBox1.Text + " ' ", conn1);
                textBox2.Text = cm.ExecuteScalar().ToString();
                OleDbCommand cmd = new OleDbCommand("SELECT name FROM vis WHERE sno=' " + textBox1.Text + " ' ", conn1);
                textBox3.Text = cmd.ExecuteScalar().ToString();
                OleDbCommand cmd1 = new OleDbCommand("SELECT status FROM vis WHERE sno =' " + textBox1.Text + " ' ", conn1);
                textBox4.Text = cmd1.ExecuteScalar().ToString();
                OleDbCommand cmd2 = new OleDbCommand("SELECT checkin FROM vis WHERE sno =' " + textBox1.Text + " ' ", conn1);
                textBox5.Text = cmd2.ExecuteScalar().ToString();
            }
            catch
            {
                MessageBox.Show("Entry Not Found ! Please check again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn1.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            for (int p = 0; p < textBox1.Text.Length; p++)
            {
                if (Char.IsLetter(textBox1.Text, p))
                {
                    MessageBox.Show("You Can't Enter A Character !! \nPlease Enter a number !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    textBox1.Focus();
                    textBox1.Text = "";
                }
            }
        } 
    }
}
