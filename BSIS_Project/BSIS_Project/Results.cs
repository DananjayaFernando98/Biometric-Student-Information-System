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
    public partial class Results : Form
    {
        OleDbConnection connection = new OleDbConnection();
        private store str;
        string p;
        public string re;
        public Results()
        {
            InitializeComponent();
        }
        public Results(store stro)
        {
            InitializeComponent();
            str = stro;

            lblkkk.Text = str.pin;
            p = lblkkk.Text;
        }

        private void Results_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string va = ComCoursecode.Text;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select Result from Result where CourseCode=@cc AND Pin=@pin";

            com.Parameters.AddWithValue("@cc", va);
            lblGrade.Text = "No";
            com.Parameters.AddWithValue("@pin", p);
            OleDbDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                //showresult.Text = rd.GetValue(0).ToString();
                if (rd.GetValue(0).ToString() != null)
                {
                    lblGrade.Text = rd.GetValue(0).ToString();
                    break;
                }
                else
                {
                    lblGrade.Text = "No";
                    break;
                }
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
