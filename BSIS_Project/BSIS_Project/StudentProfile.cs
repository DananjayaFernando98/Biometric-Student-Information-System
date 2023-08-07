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
    public partial class StudentProfile : Form
    {
        OleDbConnection connection = new OleDbConnection();
        private store str;
        string p;
        public StudentProfile()
        {
            InitializeComponent();
        }
        public StudentProfile(store stro)
        {
            InitializeComponent();
            str = stro;
            p = str.pin;
            kkk.Text = p;
        }
        private void StudentProfile_Load(object sender, EventArgs e)
        {
            //lblName.Text = str.pin;

            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select Name,RegNo,AcademicYear,Pin from Student where Pin=@pin";

            com.Parameters.AddWithValue("@pin", str.pin);

            OleDbDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                lblName.Text = rd.GetValue(0).ToString();
                str.name = lblName.Text;
                lblRegNo.Text = rd.GetValue(1).ToString();
                str.regno = lblRegNo.Text;
                lblAcademiicYear.Text = rd.GetValue(2).ToString();
                str.accdmicyear = lblAcademiicYear.Text;
                kkk.Text = rd.GetValue(3).ToString();

            }


            /*   OpenFileDialog dlg = new OpenFileDialog();
               dlg.Filter = "JPG Files(*.jpg)|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
               if(dlg.ShowDialog()==DialogResult.OK)
               {
                   string picLoc = dlg.FileName.ToString();
                   pictureBox1.ImageLocation = picLoc;

               }*/



            /* connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\MMM\BSIS.accdb";
             connection.Open();*/
            OleDbCommand com1 = new OleDbCommand();
            com1.Connection = connection;
            com1.CommandText = "select Name,RegNo,AcademicYear,Pin from Student where RegNo=@pin";

            com1.Parameters.AddWithValue("@pin", kkk.Text);

            OleDbDataReader rd1 = com1.ExecuteReader();
            while (rd1.Read())
            {
                lblName.Text = rd1.GetValue(0).ToString();
                // str.name = lblName.Text;
                lblRegNo.Text = rd1.GetValue(1).ToString();
                // str.regno = lblRegNo.Text;
                lblAcademiicYear.Text = rd1.GetValue(2).ToString();
                // str.acdmicyear = lblAcademicYear.Text;
                kkk.Text = rd1.GetValue(3).ToString();
            }




            /*  OleDbDataAdapter da = new OleDbDataAdapter(com);
              DataTable dt = new DataTable();
              da.Fill(dt);
              CashiarDataView.DataSource = dt;*/
            connection.Close();
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            store st = new store();
            st.pin = lblRegNo.Text;
            StudentAttendance at = new StudentAttendance(st);
            at.Show();
            this.Hide();
        }

        private void btnGPA_Click(object sender, EventArgs e)
        {
            store st = new store();
            st.pin = kkk.Text;
            GPA g = new GPA(st);
            g.Show();
            this.Hide();
        }

        private void btnScheduledICA_Click(object sender, EventArgs e)
        {
            store st = new store();
            st.pin = kkk.Text;
            StudentScheduleICA stus = new StudentScheduleICA(st);
            stus.Show();
            this.Hide();
        }

        private void btnICAMarks_Click(object sender, EventArgs e)
        {
            store st = new store();
            st.pin = kkk.Text;
            ICAMark im = new ICAMark(st);
            im.Show();
            this.Hide();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            store st = new store();
            st.pin = kkk.Text;
            Results re = new Results(st);
            re.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Welcom we = new Welcom();
            we.Show();
            this.Hide();
        }

        private void btnTimeTable_Click(object sender, EventArgs e)
        {
            store st = new store();
            st.pin = kkk.Text;
            StudentTimeTable stu = new StudentTimeTable(st);
            stu.Show();
            this.Hide();
        }
    }
}
