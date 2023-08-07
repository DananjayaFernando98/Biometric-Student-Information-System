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
    public partial class Update : Form
    {
        private store1 str;
        private store1 ss1;
        public Update()
        {
            InitializeComponent();
        }
        public Update(store1 st)
        {
            InitializeComponent();
            str = st;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Welcom we = new Welcom();
            we.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            choosing ch = new choosing();
            ch.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lectreProfile lp = new lectreProfile(str);
            lp.Show();
            this.Hide();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            sshows();
            suhows();
            lshows();
        }
        public void sshows()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select * from Student ";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            st.DataSource = dt;
            connection.Close();
        }
        public void suhows()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select * from Subject ";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sut.DataSource = dt;
            connection.Close();
        }
        public void lshows()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select * from Lectur ";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lt.DataSource = dt;
            connection.Close();
        }

        private void btnsadd_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "insert into Student values(@RegNo,@Name,@AcademicYear,@pin)";
            // com.Parameters.AddWithValue("@cose", txboxcosecode.Text);
            //string pp = txboxRegNo.Text;
            /* OleDbCommand x = new OleDbCommand();
             x.Connection = connection;
             x.CommandText = "select Pin from Student where RegNo=@RegNo";
             x.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
             OleDbDataReader rd1 = x.ExecuteReader();
             while (rd1.Read())
             {
                 // txboxRegNo.Text = rd1.GetValue(0).ToString();
                 com.Parameters.AddWithValue("@Pin", rd1.GetValue(0).ToString());
             }*/

            com.Parameters.AddWithValue("@RegNo", txboxRegNos.Text);
            com.Parameters.AddWithValue("@Name", txboxNames.Text);
            com.Parameters.AddWithValue("@AcademicYear", comYears.Text);
            com.Parameters.AddWithValue("@pin", txboxSpins.Text);
            com.ExecuteNonQuery();
            /*  OleDbDataAdapter da = new OleDbDataAdapter(com);
              DataTable dt = new DataTable();
              da.Fill(dt);
              st.DataSource = dt;*/
            connection.Close();
            sshows();
        }

        private void btnsremove_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "delete * from Student where Pin=@pin ";
            // string pp = txboxRegNo.Text;
            com.Parameters.AddWithValue("@pin", txboxSpins.Text);
            /*  com.Parameters.AddWithValue("@year", comYear.Text);
              com.Parameters.AddWithValue("@sem", comSem.Text);*/
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            st.DataSource = dt;
            connection.Close();
            sshows();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "insert into Lectur values(@LecturId,@Name,@CourseCode,@Lpin)";

            com.Parameters.AddWithValue("@LecturId", txboxlectureId.Text);
            com.Parameters.AddWithValue("@Name", txboxLname.Text);
            com.Parameters.AddWithValue("@CourseCode", comCourseCodeLe.Text);
            com.Parameters.AddWithValue("@Lpin", txboxPINl.Text);
            com.ExecuteNonQuery();
            // com.Parameters.AddWithValue("@photo", "");

            /* OleDbDataAdapter da = new OleDbDataAdapter(com);
             DataTable dt = new DataTable();
             da.Fill(dt);
             sut.DataSource = dt;*/
            connection.Close();
            lshows();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();

            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "delete * from Lectur where LPin=@pin ";
            // string pp = txboxRegNo.Text;
            com.Parameters.AddWithValue("@pin", txboxPINl.Text);
            /*  com.Parameters.AddWithValue("@year", comYear.Text);
              com.Parameters.AddWithValue("@sem", comSem.Text);*/
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lt.DataSource = dt;
            connection.Close();
            lshows();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "insert into Subject values(@CourseCode,@SubjectName,@Days)";

            com.Parameters.AddWithValue("@CourseCode", comboBoxsubCourseCode.Text);
            com.Parameters.AddWithValue("@SubjectName", txboxSubName.Text);
            com.Parameters.AddWithValue("@Days", txBoxDays.Text);
            // com.Parameters.AddWithValue("@pin", spin.Text);
            com.ExecuteNonQuery();
            /* OleDbDataAdapter da = new OleDbDataAdapter(com);
             DataTable dt = new DataTable();
             da.Fill(dt);
             sut.DataSource = dt;*/
            connection.Close();
            suhows();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "delete * from Subject where CourseCode=@CourseCode ";
            // string pp = txboxRegNo.Text;
            com.Parameters.AddWithValue("@CourseCode", comboBoxsubCourseCode.Text);
            /*  com.Parameters.AddWithValue("@year", comYear.Text);
              com.Parameters.AddWithValue("@sem", comSem.Text);*/
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sut.DataSource = dt;
            connection.Close();
            suhows();
        }
    }
}
