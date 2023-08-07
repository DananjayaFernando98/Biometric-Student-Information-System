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
    public partial class StudentScheduleICA : Form
    {
        OleDbConnection connection = new OleDbConnection();
        private store str;
        public StudentScheduleICA()
        {
            InitializeComponent();
        }
        public StudentScheduleICA(store stro)
        {
            InitializeComponent();
            str = stro;
        }

        private void StudentScheduleICA_Load(object sender, EventArgs e)
        {
            shoo();
        }
        public void shoo()
        {

            lblYESNO1.Text = "No";
            lblYESNO2.Text = "No";
            lblYESNO3.Text = "No";
            lblDate1.Text = "No";
            lblDate2.Text = "No";
            lblDate3.Text = "No";
        }


        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            shoo();
            string dd = comCourse.Text;
            // lblFirst.Text = dd;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select ICANo,Date from Scheduled_ICA where CourseCode=@cc";

            com.Parameters.AddWithValue("@cc", dd);
            OleDbDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {

                /*  if(rd.GetValue(0).ToString()!=null)
                  {
                      lblFirst.Text = "YES";
                  }
                  else
                  {
                      lblFirst.Text = "NO";
                  }*/
                /* lblRegNo.Text = rd.GetValue(1).ToString();
                 lblAcademicYear.Text = rd.GetValue(2).ToString();*/
                string v = rd.GetValue(0).ToString();
                switch (v)
                {
                    case "1":

                        lblYESNO1.Text = "YES";
                        lblDate1.Text = rd.GetValue(1).ToString();

                        break;


                    case "2":

                        lblYESNO2.Text = "YES";
                        lblDate2.Text = rd.GetValue(1).ToString();
                        break;


                    case "3":

                        lblYESNO3.Text = "YES";
                        lblDate3.Text = rd.GetValue(1).ToString();
                        break;

                    default:
                        lblYESNO1.Text = "NO";
                        // lblDate1.Text = rd.GetValue(1).ToString();
                        break;
                }
            }
            //StudentScheduel_Load(object sender, EventArgs e);
            // shoo();
            connection.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StudentProfile stup = new StudentProfile(str);
            stup.Show();
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
    }
}
