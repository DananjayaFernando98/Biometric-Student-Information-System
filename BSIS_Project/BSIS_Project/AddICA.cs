using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BSIS_Project
{
    public partial class AddICA : Form
    {
        private store1 str;
        private store1 ss1;
        public AddICA()
        {
            InitializeComponent();
        }
        public AddICA(store1 st)
        {
            InitializeComponent();
            str = st;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lectreProfile lp = new lectreProfile(str);
            lp.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            choosing ch = new choosing();
            ch.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Welcom we = new Welcom();
            we.Show();
            this.Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string npin;
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            // OleDbConnection connection = new OleDbConnection();



            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "insert into ICA_Marks values(@Pin,@CourseCode,@ICA_No,@Mark)";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            string pp = txboxRegNo.Text;
            OleDbCommand x = new OleDbCommand();
            x.Connection = connection;
            x.CommandText = "select Pin from Student where RegNo=@RegNo";
            x.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
            OleDbDataReader rd1 = x.ExecuteReader();
            while (rd1.Read())
            {
                // txboxRegNo.Text = rd1.GetValue(0).ToString();
                com.Parameters.AddWithValue("@Pin", rd1.GetValue(0).ToString());
            }

            //  com.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
            com.Parameters.AddWithValue("@CourseCode", comCoursecode.Text);
            com.Parameters.AddWithValue("@ICA_No", comICANo.Text);
            com.Parameters.AddWithValue("@Mark", textBoxGrade.Text);
            com.ExecuteNonQuery();
            /*OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;*/
            connection.Close();
            shows();
        }
        public void shows()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select * from ICA_Marks ";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            // OleDbConnection connection = new OleDbConnection();



            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "delete * from ICA_Marks where Pin=@pin AND CourseCode=@cc AND ICA_No=@icn ";
            string pp = txboxRegNo.Text;
            OleDbCommand x = new OleDbCommand();
            x.Connection = connection;
            x.CommandText = "select Pin from Student where RegNo=@RegNo";
            x.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
            OleDbDataReader rd1 = x.ExecuteReader();
            while (rd1.Read())
            {
                txboxRegNo.Text = rd1.GetValue(0).ToString();

            }
            com.Parameters.AddWithValue("@pin", txboxRegNo.Text);
            com.Parameters.AddWithValue("@cc", comCoursecode.Text);
            com.Parameters.AddWithValue("@icn", comICANo.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
            shows();
        }

        private void AddICA_Load(object sender, EventArgs e)
        {
            shows();
        }
    }
}
