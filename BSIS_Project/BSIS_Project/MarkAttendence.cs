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
    public partial class MarkAttendence : Form
    {
        OleDbConnection connection = new OleDbConnection();
        private store1 str;
        string p, c, d, a;
        string regno, name;
        public MarkAttendence()
        {
            InitializeComponent();
        }
        public MarkAttendence(store1 stro)
        {
            InitializeComponent();
            str = stro;
            c = str.coursecode;

            p = str.pinL;
            d = str.date1;
            a = str.atten;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string pp = txboxPINS.Text;
            // string regno,name;
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            // OleDbConnection connection = new OleDbConnection();



            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            com.CommandText = "insert into Attendance values(@CourseCode,@RegNo,@Name,@Attendance,@Date)";

            // string pp = txboxRegNo.Text;
            OleDbCommand x = new OleDbCommand();
            x.Connection = connection;
            x.CommandText = "select RegNo,Name from Student where Pin=@pin";
            x.Parameters.AddWithValue("@pin", txboxPINS.Text);
            OleDbDataReader rd1 = x.ExecuteReader();
            while (rd1.Read())
            {
                regno = rd1.GetValue(0).ToString();
                // com.Parameters.AddWithValue("@RegNo", regno);

                name = rd1.GetValue(1).ToString();
                //  com.Parameters.AddWithValue("@Name", name);
            }
            // com.Parameters.AddWithValue("@RegNo",regno);
            com.Parameters.AddWithValue("@CourseCode", c);
            com.Parameters.AddWithValue("@RegNo", regno);
            com.Parameters.AddWithValue("@Name", name);
            com.Parameters.AddWithValue("@Attendance", a);
            com.Parameters.AddWithValue("@Date", d);

            com.ExecuteNonQuery();
            connection.Close();
            /*OleDbDataAdapter da = new OleDbDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;*/
            store1 str = new store1();
            str.coursecode = c;
            Attendance at = new Attendance(str);
            at.Show();
            Hide();
        }

        private void MarkAttendence_Load(object sender, EventArgs e)
        {

        }
    }
}
