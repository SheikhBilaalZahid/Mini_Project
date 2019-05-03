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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        public string CString = "Data Source=DESKTOP-0BEBLQ6;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form13_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CString);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT Details,Id FROM Rubric", con);
            SqlDataReader r;

            r = com.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Columns.Add("Details", typeof(string));
            Table.Columns.Add("Id", typeof(string));
            Table.Load(r);
            rubricId.ValueMember = "Id";
            rubricId.DisplayMember = "Details";
            rubricId.DataSource = Table;
            rubricId.Text = "Select";


            r.Close();

            SqlCommand com2 = new SqlCommand("SELECT Title,Id FROM Assessment", con);
            SqlDataReader r2;

            r2 = com.ExecuteReader();
            DataTable Table2 = new DataTable();
            Table2.Columns.Add("Details", typeof(string));
            Table2.Columns.Add("Id", typeof(string));
            Table2.Load(r2);
            assessmentId.ValueMember = "Id";
            assessmentId.DisplayMember = "Details";
            assessmentId.DataSource = Table2;
            rubricId.Text = "Select";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CString);
            con.Open();

            SqlCommand exe = new SqlCommand("INSERT INTO AssessmentComponent(Name,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) values('" + Name.Text + "','" +Convert.ToInt32(rubricId.SelectedValue) + "','" + totalmarks.Text + "','"+DateTime.Now+"','"+DateTime.Now+"','"+ Convert.ToInt32(assessmentId.SelectedValue) + "')", con);
            exe.ExecuteNonQuery();
            MessageBox.Show("Added!");
            this.Hide();
            Form14 frm = new Form14();
            frm.Show();
        }
    }
}
