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
    public partial class Form7 : Form
    {
        public Form7()
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
            Form6 form = new Form6();
            this.Hide();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(CString);

            con.Open();

            if (e.ColumnIndex == dataGridView1.Columns["del"].Index)
            {
                    int row = e.RowIndex;
                    int sel = Convert.ToInt32(dataGridView1.Rows[row].Cells["Id"].Value);
                    SqlCommand exe = new SqlCommand("DELETE FROM Rubric WHERE Id = '" + sel + "'", con);
                    exe.ExecuteNonQuery();
                    MessageBox.Show("Deleted!");
                    this.Hide();
                    Form7 form = new Form7();
                    form.Show();
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CString);
            con.Open();

            SqlCommand exe = new SqlCommand("SELECT * FROM Rubric", con);
            SqlDataAdapter data = new SqlDataAdapter(exe);
            DataTable grid = new DataTable(exe.ToString());

            data.Fill(grid);
            dataGridView1.DataSource = grid;
        }
    }
}
