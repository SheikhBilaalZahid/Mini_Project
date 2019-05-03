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
    public partial class Form12 : Form
    {
        public Form12()
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
            Form11 form = new Form11();
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
                SqlCommand exe = new SqlCommand("DELETE FROM Assessment WHERE Id = '" + sel + "'", con);
                exe.ExecuteNonQuery();
                MessageBox.Show("Deleted!");
                this.Hide();
                Form11 form = new Form11();
                form.Show();
            }
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CString);
            con.Open();

            SqlCommand exe = new SqlCommand("SELECT * FROM Assessment", con);
            SqlDataAdapter data = new SqlDataAdapter(exe);
            DataTable grid = new DataTable(exe.ToString());

            data.Fill(grid);
            dataGridView1.DataSource = grid;
        }
    }
}
