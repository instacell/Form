using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost; Initial Catalog=StudentDB; Integrated Security=True;";


            string sql = "SELECT * FROM Students";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet ds = new DataSet();

            try
            {
                sqlConnection.Open();

                adapter.Fill(ds);
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
