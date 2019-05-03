﻿using System;
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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        public string CString = "Data Source=DESKTOP-0BEBLQ6;Initial Catalog=ProjectB;Integrated Security=True";


        private void Form9_Load(object sender, EventArgs e)
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
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Details";
            comboBox1.DataSource = Table;
            comboBox1.Text = "Select";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CString);
            con.Open();

            SqlCommand exe = new SqlCommand("INSERT INTO RubricLevel(RubricId,Details,MeasurementLevel) values('" + Convert.ToInt32(comboBox1.SelectedValue)  + "','" + Details.Text + "','"+ Convert.ToInt32(comboBox2.SelectedItem) +"')", con);
            exe.ExecuteNonQuery();
            MessageBox.Show("Added!");
            this.Hide();
            Form10 frm = new Form10();
            frm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form10 form = new Form10();
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
