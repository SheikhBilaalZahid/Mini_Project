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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public string CString = "Data Source=DESKTOP-0BEBLQ6;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form6_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CString);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT Name,Id FROM Clo", con);
            SqlDataReader r;

            r = com.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Columns.Add("Name", typeof(string));
            Table.Columns.Add("Id", typeof(string));
            Table.Load(r);
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = Table;
            comboBox1.Text = "Select";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form7 form = new Form7();
            this.Hide();
            form.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CString);
            con.Open();

            SqlCommand exe = new SqlCommand("INSERT INTO Rubric(Details,CloId) values('" + Details.Text + "','" + comboBox1.SelectedValue + "')", con);
            exe.ExecuteNonQuery();
            MessageBox.Show("Added!");
            this.Hide();
            Form7 frm = new Form7();
            frm.Show();
        }
    }
}
