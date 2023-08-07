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
    public partial class GPA : Form
    {
        OleDbConnection connection = new OleDbConnection();
        private store str;
        string p;
        public GPA()
        {
            InitializeComponent();
        }
        public GPA(store stro)
        {
            InitializeComponent();
            str = stro;

            lblgg.Text = str.pin;
            p = lblgg.Text;
        }

        private void GPA_Load(object sender, EventArgs e)
        {
            lblYear.Text = "--";
            lblSem.Text = "--";
            lblGPA.Text = "--";
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string y, s;
            y = comYearT.Text;
            s = ComSemT.Text;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select Year,Semester,GPA from GPA  where Year=@year AND Semester=@sem AND Pin=@pin";
            com.Parameters.AddWithValue("@Year", y);
            com.Parameters.AddWithValue("@sem", s);
            com.Parameters.AddWithValue("@pin", p);
            lblYear.Text = "--";
            lblSem.Text = "--";
            lblGPA.Text = "--";
            OleDbDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                lblYear.Text = rd.GetValue(0).ToString();
                lblSem.Text = rd.GetValue(1).ToString();
                lblGPA.Text = rd.GetValue(2).ToString();
            }
            connection.Close();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            double yearsum;
            double sem1 = 0;
            double sem2 = 0;
            string y, s;
            y = comBYear.Text;
            //  s = comSem.Text;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "select GPA from GPA  where Year=@year AND Semester=@sem AND Pin=@pin";
            com.Parameters.AddWithValue("@Year", y);
            com.Parameters.AddWithValue("@sem", "1");
            com.Parameters.AddWithValue("@pin", p);

            OleDbDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                sem1 = Convert.ToDouble(rd.GetValue(0));
            }
            OleDbCommand co = new OleDbCommand();
            co.Connection = connection;
            co.CommandText = "select GPA from GPA  where Year=@year AND Semester=@sem AND Pin=@pin";
            co.Parameters.AddWithValue("@Year", y);
            co.Parameters.AddWithValue("@sem", "2");
            co.Parameters.AddWithValue("@pin", p);

            OleDbDataReader rd1 = co.ExecuteReader();
            while (rd1.Read())
            {
                sem2 = Convert.ToDouble(rd1.GetValue(0));
            }

            yearsum = (sem1 + sem2) / 2;
            lblYearGPA.Text = yearsum.ToString();

            connection.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StudentProfile stu = new StudentProfile(str);
            stu.Show();
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
