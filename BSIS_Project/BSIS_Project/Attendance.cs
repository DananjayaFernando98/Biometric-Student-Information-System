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
    public partial class Attendance : Form
    {
        OleDbConnection connection = new OleDbConnection();

        private store1 str;
        string p, c, d;
        public Attendance()
        {
            InitializeComponent();
        }
        public Attendance(store1 stro)
        {
            InitializeComponent();
            str = stro;
            c = str.coursecode;
            // code.Text = c;
            lblSub.Text = c;
            d = str.date1;
            p = str.pinL;

           // lll.Text = p;
        }
        private void lblSub_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Welcom we = new Welcom();
            we.Show();
            this.Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

            Welcom we = new Welcom();
            we.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lll.Text = str.pinL;
            str.pinL = lll.Text;
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

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            store1 str = new store1();
            str.date1 = Date.Text;
            str.atten = "Yes";
            str.coursecode = c;
            MarkAttendence mr = new MarkAttendence(str);
            mr.Show();
            this.Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            store1 stt = new store1();
            stt.coursecode = lblToday.Text;

            CheckStudentAttendance ck = new CheckStudentAttendance(str);
            ck.Show();
            this.Hide();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            double allStu, todaystu, avg;
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "SELECT COUNT(*)FROM Student";
            OleDbDataReader rd1 = com.ExecuteReader();
            while (rd1.Read())
            {
                lblTotal.Text = rd1.GetValue(0).ToString();
                //  allStu = Convert.ToDouble(lblTotalbatch.Text);
            }
            allStu = Convert.ToDouble(lblTotal.Text);


            OleDbCommand com1 = new OleDbCommand();
            com1.Connection = connection;
            com1.CommandText = "SELECT COUNT(RegNo)FROM Attendance where Date=@date ";
            com1.Parameters.AddWithValue("@date", Date.Text);
           // com1.Parameters.AddWithValue("@code", lblSub.Text);
            OleDbDataReader rd2 = com1.ExecuteReader();
            while (rd2.Read())
            {
                lblToday.Text = rd2.GetValue(0).ToString();

            }
            todaystu = Convert.ToDouble(lblToday.Text);
            avg = (todaystu / allStu) * 100;
            avg = Math.Round(avg, 2);
            lblAvg.Text = avg.ToString() + "%";

            connection.Close();
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            shoo();
        }
        public void shoo()
        {
            
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select * from Attendance";
            //com.Parameters.AddWithValue("@cose",str.coursecode);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
    }
}
