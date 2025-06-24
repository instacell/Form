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
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        string connectionString = "Data Source=localhost; Initial Catalog=StudentDB;Integrated Security=True;";
        private SqlConnection conn;
        private SqlDataAdapter adapter;

        public Form3()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            conn = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter("SELECT * FROM Students", conn);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "INSERT INTO Students (IndexNo, Name, Age, City) VALUES (@IndexNo, @Name, @Age, @City)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@IndexNo", txtIndexNo.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
            cmd.Parameters.AddWithValue("@City", txtCity.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            String sql = "DELETE FROM Students WHERE IndexNo=@IndexNo";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@IndexNo", txtIndexNo.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "UPDATE Students SET Name=@Name, Age=@Age, City=@City WHERE IndexNo=@IndexNo";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@IndexNo", txtIndexNo.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
            cmd.Parameters.AddWithValue("@City", txtCity.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtIndexNo.Text = dataGridView1.Rows[e.RowIndex].Cells["IndexNo"].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtAge.Text = dataGridView1.Rows[e.RowIndex].Cells["Age"].Value.ToString();
                txtCity.Text = dataGridView1.Rows[e.RowIndex].Cells["City"].Value.ToString();
            }
        }
    }
}
