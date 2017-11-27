using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visitor_Counter
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

   
        private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/samsung pc/Documents/Visitor.accdb");
            conn.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM vis", conn);
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Show();
            conn.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
