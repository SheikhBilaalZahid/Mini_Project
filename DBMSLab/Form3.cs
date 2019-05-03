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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string CString = "Data Source=DESKTOP-0BEBLQ6;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CString);
            con.Open();
            
            SqlCommand exe = new SqlCommand("select * from Student where Status = '" + 5 + "'", con);
            SqlDataAdapter data = new SqlDataAdapter(exe);
            DataTable grid = new DataTable(exe.ToString());

            data.Fill(grid);
            dataGridView1.DataSource = grid;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(CString);
            con.Open();

            if (e.ColumnIndex == dataGridView1.Columns["del"].Index)
            {
                
                    int rownum = e.RowIndex;
                    int sel = Convert.ToInt32(dataGridView1.Rows[rownum].Cells["Id"].Value);
                    SqlCommand exe = new SqlCommand("DELETE FROM Student WHERE Id = '" + sel + "'", con);
                    exe.ExecuteNonQuery();
                    MessageBox.Show("Deleted");
                    this.Hide();
                    Form3 form = new Form3();
                    form.Show();

            }
            if (e.ColumnIndex == dataGridView1.Columns["edit"].Index)
            {

                int rownum = e.RowIndex;
                int sel = Convert.ToInt32(dataGridView1.Rows[rownum].Cells["Id"].Value);
                
                this.Hide();
                Form8 form = new Form8(sel);
                form.Show();

            }

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
