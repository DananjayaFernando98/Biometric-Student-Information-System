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
    public partial class ICAMark : Form
    {
        OleDbConnection connection = new OleDbConnection();

        private store str;
        string p;
        public ICAMark()
        {
            InitializeComponent();
        }
        public ICAMark(store stro)
        {
            InitializeComponent();
            str = stro;
            p = str.pin;
        }

        private void ICAMark_Load(object sender, EventArgs e)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            OleDbCommand x = new OleDbCommand();
            x.Connection = connection;
            com.Connection = connection;
            com.CommandText = "select Name from student  where Pin=@pin";
            x.CommandText = "select CourseCode from ICA_Marks where pin=@pin";
            /* com.Parameters.AddWithValue("@cc", va);
             showresult.Text = "No";*/
            com.Parameters.AddWithValue("@pin", p);
            x.Parameters.AddWithValue("@pin", p);
            OleDbDataReader rd = com.ExecuteReader();
            OleDbDataReader rd1 = x.ExecuteReader();
            while (rd.Read())
            {
                sql.Text = rd.GetValue(0).ToString();

                /*  if (rd.GetValue(0).ToString() != null)
                  {
                      showresult.Text = rd.GetValue(0).ToString();
                      break;
                  }
                  else
                  {
                      showresult.Text = "No";
                      break;
                  }*/
            }
            while (rd1.Read())
            {
                // lblother.Text = rd1.GetValue(0).ToString();
            }
            connection.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string s = ComCoursecode.Text;
            string n = comICAno.Text;

           /* lblMark.Text = s;
            lblno.Text = n;
            lblpin.Text = p;*/
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select Mark from ICA_Marks  where CourseCode=@code AND ICA_No=@no AND Pin=@pin";
            com.Parameters.AddWithValue("@code", s);
            com.Parameters.AddWithValue("@no", n);
            com.Parameters.AddWithValue("@pin", p);
            lblGrade.Text = "--";
            OleDbDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                lblGrade.Text = rd.GetValue(0).ToString();
            }

            OleDbCommand com1 = new OleDbCommand();
            com1.Connection = connection;
            com1.CommandText = "select SubjectName from Subject  where CourseCode=@code";
            com1.Parameters.AddWithValue("@code", ComCoursecode.Text);
           
            lblSubjectName.Text = "--";
            OleDbDataReader rd1 = com1.ExecuteReader();
            while (rd1.Read())
            {
                lblSubjectName.Text = rd1.GetValue(0).ToString();
            }

            connection.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StudentProfile sp = new StudentProfile(str);
            sp.Show();
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
