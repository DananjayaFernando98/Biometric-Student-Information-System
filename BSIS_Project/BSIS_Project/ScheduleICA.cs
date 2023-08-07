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
    public partial class ScheduleICA : Form
    {
        private store1 str;
        private store1 ss1;
        public ScheduleICA()
        {
            InitializeComponent();
           
        }
        public ScheduleICA(store1 st)
        {
            InitializeComponent();
            str = st;
        }

        private void ScheduleICA_Load(object sender, EventArgs e)
        {
            shoo();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            lectreProfile lp = new lectreProfile(str);
            lp.Show();
            this.Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "insert into Scheduled_ICA values(@CourseCode,@ICANo,@Date)";

            com.Parameters.AddWithValue("@CourseCode", comboCouse.Text);
            com.Parameters.AddWithValue("@ICA_No", comboBoxICAno.Text);
            com.Parameters.AddWithValue("@Date", Date.Text);
            com.ExecuteNonQuery();
            connection.Close();
            shoo();
        }
        public void shoo()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select * from Scheduled_ICA ";
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
            com.CommandText = "delete * from Scheduled_ICA where CourseCode=@pin AND ICANo=@ICANO";


            com.Parameters.AddWithValue("@pin", comboCouse.Text);
            com.Parameters.AddWithValue("@ICANO", comboBoxICAno.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
            shoo();

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
    }
}
