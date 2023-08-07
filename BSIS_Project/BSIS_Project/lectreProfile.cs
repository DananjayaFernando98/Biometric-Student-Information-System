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
    public partial class lectreProfile : Form
    {
        OleDbConnection connection = new OleDbConnection();
        private store1 str1;
        public lectreProfile()
        {
            InitializeComponent();
        }
        public lectreProfile(store1 stro)
        {
            InitializeComponent();
            str1 = stro;
            lp.Text = str1.pinL;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Welcom we = new Welcom();
            we.Show();
            this.Hide();
        }

        private void LctureProfile_Load(object sender, EventArgs e)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select Name,Lpin from Lectur where LPin=@pin";

            com.Parameters.AddWithValue("@pin",lp.Text);
            OleDbDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                lblName.Text = rd.GetValue(0).ToString();
                lp.Text = rd.GetValue(1).ToString();
                // lblSubject.Text = rd.GetValue(1).ToString();
                //lpi.Text = rd.GetValue(2).ToString();
            }
        }

        private void btnTimeTable_Click(object sender, EventArgs e)
        {
            store1 ss = new store1();

            ss.pinL = lp.Text;
            LectureTimeTable lt = new LectureTimeTable(ss);
            lt.Show();
            this.Hide();
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            store1 strr = new store1();
            strr.coursecode = comCourseCode.Text;
            strr.pinL = lp.Text;


            Attendance at = new Attendance(strr);
            at.Show();
            this.Hide();
        }

        private void btnGPA_Click(object sender, EventArgs e)
        {
            store1 ss = new store1();

            ss.pinL = lp.Text;
            AddGPA ag = new AddGPA(str1);
            ag.Show();
            this.Hide();

        }

        private void btnScheduledICA_Click(object sender, EventArgs e)
        {
            store1 ss = new store1();

            ss.pinL = lp.Text;
            ScheduleICA si = new ScheduleICA(str1);
            si.Show();
            this.Hide();
        }

        private void btnICAMarks_Click(object sender, EventArgs e)
        {
            store1 ss = new store1();

            ss.pinL = lp.Text;
            AddICA ac = new AddICA(str1);
            ac.Show();
            this.Hide();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            store1 ss = new store1();

            ss.pinL = lp.Text;

            Update u = new Update(str1);
            u.Show();
            this.Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            store1 ss = new store1();

            ss.pinL = lp.Text;
            AddResult ac = new AddResult(str1);
            ac.Show();
            this.Hide();
        }
    }
}
