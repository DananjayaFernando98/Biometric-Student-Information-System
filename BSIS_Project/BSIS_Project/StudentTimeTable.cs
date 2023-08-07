using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSIS_Project
{
    public partial class StudentTimeTable : Form
    {
        private store str;
        public StudentTimeTable()
        {
            InitializeComponent();
        }
        public StudentTimeTable(store st)
        {
            InitializeComponent();
            str = st;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            StudentProfile st = new StudentProfile(str);
            st.Show();
            this.Hide();
        }
    }
}
