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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        public string CString = "Data Source=DESKTOP-0BEBLQ6;Initial Catalog=ProjectB;Integrated Security=True";
        public int ID;
        public Form8(int id)
        {
            ID = id;
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 frm = new Form3();
            this.Hide();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CString);
            con.Open();


            int s = 0;
            if (comboBox1.Text == "Inactive")
            {
                s = 6;
            }
            else if (comboBox1.Text == "Active")
            {
                s = 5;
            }


            SqlCommand exe = new SqlCommand("UPDATE Student set FirstName = '" + First.Text + "', LastName = '" + Last.Text + "',Contact = '" + Contact.Text + "',Email = '" + Email.Text + "',RegistrationNumber='" + Reg.Text + "',Status = '" + s + "' where Id = '"+ID+"'", con);
            exe.ExecuteNonQuery();

            MessageBox.Show("Edit Successfully!");
            this.Hide();
            Form3 frm = new Form3();
            frm.Show();
        }
    }
}
