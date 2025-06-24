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
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        private SqlConnection connection;

        public Form2()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost; Initial Catalog=DBproject1; Trusted_connection=True;";
            connection = new SqlConnection(connectionString);

            adapter = new SqlDataAdapter("SELECT * FROM DOCTOR", connection);

            dataTable = new DataTable();
            adapter.Fill(dataTable);

            bindingSource.DataSource = dataTable;
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();

            textBox1.DataBindings.Add("Text", bindingSource, "DoctorID");
            textBox2.DataBindings.Add("Text", bindingSource, "Name");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource.MoveFirst();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindingSource.MoveLast();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindingSource.MovePrevious();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bindingSource.MoveNext();
        }
    }
}
