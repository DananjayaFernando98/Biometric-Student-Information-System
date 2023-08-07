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
    public partial class LectueLogin : Form
    {
        public string stuPIN;
        public LectueLogin()
        {
            InitializeComponent();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\BSIS\ProjectBSIS.accdb";
            connection.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = connection;
            store1 str = new store1();
            str.pinL = txboxLecturePin.Text;
            //  stuPIN = txbxStudentPin.Text;



            com.CommandText = "select * from Lectur where Lpin='" + txboxLecturePin.Text + "' ";





            OleDbDataReader reader = com.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            if (count == 1)
            {
                lectreProfile lpr = new lectreProfile(str);
                lpr.Show();
                this.Hide();
            }
            else if (count > 1)
            {
                MessageBox.Show("Duplicate PIN", "Wiarning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Not Currect Your PIN ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            txboxLecturePin.Text = null;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Welcom we = new Welcom();
            we.Show();
            this.Hide();
        }

        private void LectueLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
