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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        public string CString = "Data Source=DESKTOP-0BEBLQ6;Initial Catalog=ProjectB;Integrated Security=True";

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form12 form = new Form12();
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

            SqlCommand exe = new SqlCommand("INSERT INTO Assessment(Title,DateCreated,TotalMarks,TotalWeightage) values('" + title.Text + "','" + DateTime.Now + "','" + Convert.ToInt32(Totalmarks.Text) + "','"+ Convert.ToInt32(weight.Text)+"')", con);
            exe.ExecuteNonQuery();
            MessageBox.Show("Added!");
            this.Hide();
            Form12 frm = new Form12();
            frm.Show();
        }
    }
}
