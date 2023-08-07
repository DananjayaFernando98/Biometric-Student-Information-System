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
    public partial class LectureTimeTable : Form
    {
        private store ss;
        private store str;
        string p;
        private store1 ss1;
        public LectureTimeTable()
        {
            InitializeComponent();
        }
        public LectureTimeTable(store1 ss1)
        {
            InitializeComponent();
            this.ss1 = ss1;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            choosing ch = new choosing();
            ch.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lectreProfile lp = new lectreProfile(ss1);
            lp.Show();
            this.Hide();
        }

        private void LectureTimeTable_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Welcom we = new Welcom();
            we.Show();
            this.Hide();
        }
    }
}
