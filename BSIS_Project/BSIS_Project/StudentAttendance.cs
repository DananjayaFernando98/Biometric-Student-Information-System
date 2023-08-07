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
    public partial class StudentAttendance : Form
    {
        OleDbConnection connection = new OleDbConnection();
        private store str;
        public StudentAttendance()
        {
            InitializeComponent();
        }
        public StudentAttendance(store stro)
        {
            InitializeComponent();
            str = stro;
            lblRegnoo.Text = str.pin;
            lblRegNo.Text = str.pin;
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

        private void StudentAttendance_Load(object sender, EventArgs e)
        {

        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            lblCourseCode.Text = comCourseCode.Text;
            //   lblRegNo.Text = txboxRegNo.Text;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select Days from Subject where CourseCode=@pin";

            com.Parameters.AddWithValue("@pin", lblCourseCode.Text);

            OleDbDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                lblSchedulDay.Text = rd.GetValue(0).ToString();

            }


            double attstu, avg, allday;


            OleDbCommand com1 = new OleDbCommand();
            com1.Connection = connection;
            com1.CommandText = "SELECT COUNT(RegNo)FROM Attendance where CourseCode=@code AND RegNo=@regno";

            com1.Parameters.AddWithValue("@code", comCourseCode.Text);
            com1.Parameters.AddWithValue("@regno", lblRegnoo.Text);
            allday = Convert.ToDouble(lblSchedulDay.Text);
            OleDbDataReader rd1 = com1.ExecuteReader();
            while (rd1.Read())
            {
                // attstu =Convert.ToDouble( rd1.GetValue(0).ToString());
                lblPresentDay.Text = rd1.GetValue(0).ToString();
                /* avg = attstu / allday;
                 avg = Math.Round(avg, 2);
                 lblAttendance.Text = avg.ToString() + "%";*/

            }
            attstu = Convert.ToDouble(lblPresentDay.Text);
            avg = (attstu / allday) * 100;
            avg = Math.Round(avg, 2);
            lblAttendance.Text = avg.ToString() + "%";


            connection.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            store stt = new store();
            StudentProfile stu = new StudentProfile(str);
            stu.Show();
            this.Hide();
        }
    }
}
