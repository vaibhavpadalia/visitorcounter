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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Vaibhav Jonas/Documents/Visitor.accdb");
            conn.Open();
            OleDbCommand cmd1 = new OleDbCommand("SELECT MAX (sno) FROM vis",conn);
            string a = cmd1.ExecuteScalar().ToString();
            int ans=1;
            if (string.IsNullOrEmpty(a) == true)
            {
                ans = 1;
            }
            else
            {
                ans = int.Parse(a);
                ans++;
            }
            string strno = ans.ToString();
            OleDbCommand cmd = new OleDbCommand(" INSERT INTO vis(sno,ID,name,status,checkin) VALUES (' "+ strno +" ',' "+ textBox1.Text +" ',' " + textBox2.Text + " ',' " + textBox3.Text + " ',' " + DateTime.Now + " ')",conn);
            cmd.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            MessageBox.Show("Entry added successfully !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox4.Hide();
            label4.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
                MessageBox.Show("Please select a file!! \n" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            textBox4.Show();
            label4.Show();
            button3.Show();
            button2.Show();
            button1.Hide();
            button4.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OleDbConnection conn1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/samsung pc/Documents/Visitor.accdb");
            conn1.Open();
            try
            {
                OleDbCommand cm = new OleDbCommand("SELECT ID FROM vis WHERE sno=' " + textBox4.Text + " ' ", conn1);
                textBox1.Text = cm.ExecuteScalar().ToString();
                OleDbCommand cmd = new OleDbCommand("SELECT name FROM vis WHERE sno=' " + textBox4.Text + " ' ", conn1);
                textBox2.Text = cmd.ExecuteScalar().ToString();
                OleDbCommand cmd1 = new OleDbCommand("SELECT status FROM vis WHERE sno =' " + textBox4.Text + " ' ", conn1);
                textBox3.Text = cmd1.ExecuteScalar().ToString();
                conn1.Close();
            }
            catch 
            {
                MessageBox.Show("Entry Not Found ! Please check again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/samsung pc/Documents/Visitor.accdb");
            conn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("UPDATE vis SET ID=' " + textBox1.Text + " ' WHERE sno =' " + textBox4.Text + " ' ", conn);
                cmd.ExecuteNonQuery();
                OleDbCommand cmd1 = new OleDbCommand("UPDATE vis SET name=' " + textBox2.Text + " ' WHERE sno =' " + textBox4.Text + " ' ", conn);
                cmd1.ExecuteNonQuery();
                OleDbCommand cmd2 = new OleDbCommand("UPDATE vis SET status=' " + textBox3.Text + " ' WHERE sno =' " + textBox4.Text + " ' ", conn);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Job Completed !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("Entry Not Found ! Please check again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            label4.Hide();
            textBox4.Hide();
            button1.Show();
            button2.Hide();
            button3.Hide();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/samsung pc/Documents/Visitor.accdb");
            conn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("DELETE TABLE FROM vis WHERE sno=' " + textBox4.Text + " ' ", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Entry Deleted !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Entry Not Found ! Please check again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            label4.Hide();
            button2.Hide();
            textBox4.Hide();
            button1.Show();
            button4.Hide();
            button3.Hide();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            conn.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.Show();
            button4.Show();
            label4.Show();
            textBox4.Show();
            button1.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            for (int p = 0; p < textBox1.Text.Length; p++)
            {
                if (Char.IsLetter(textBox1.Text, p))
                {
                    MessageBox.Show("You Can't Enter A Character !!\nPlease Enter a number !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    textBox1.Focus();
                    textBox1.Text = "";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int p = 0; p < textBox1.Text.Length; p++)
            {
                if (Char.IsLetter(textBox1.Text, p))
                {
                    MessageBox.Show("You Can't Enter A Character !!\nPlease Enter a number !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    textBox1.Text = "";
                }
            }
        }

    }
}


