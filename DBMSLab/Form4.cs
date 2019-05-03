using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBMSLab
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public string CString = "Data Source=DESKTOP-0BEBLQ6;Initial Catalog=ProjectB;Integrated Security=True";

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 form = new Form5();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CString);
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into dbo.Clo(Name,DateCreated,DateUpdated) values('" + First.Text + "','" +Convert.ToDateTime(dateTimePicker1.Text) + "','" + Convert.ToDateTime(dateTimePicker1.Text) + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added!");
            this.Hide();
            Form5 frm = new Form5();
            frm.Show();
        }
    }
}
