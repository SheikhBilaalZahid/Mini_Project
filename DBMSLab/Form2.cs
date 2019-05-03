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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string CString = "Data Source=DESKTOP-0BEBLQ6;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CString);
            con.Open();
            
            
                int s=0;
                if (comboBox1.Text == "Inactive")
                {
                    s = 6;
                }
                else if(comboBox1.Text == "Active")
                {
                    s = 5;
                }

            
                SqlCommand exe = new SqlCommand("INSERT INTO Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) values('"+First.Text+"','" + Last.Text + "','" + Contact.Text + "','" + Email.Text + "','" + Reg.Text + "','" + s + "')", con);
                exe.ExecuteNonQuery();

                MessageBox.Show("Added Successfully!");
                this.Hide();
                Form3 frm = new Form3();
                frm.Show();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form = new Form3();
            this.Hide();
            form.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }
    }
}
