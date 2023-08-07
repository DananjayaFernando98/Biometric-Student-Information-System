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
    public partial class choosing : Form
    {
        public choosing()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Welcom we = new Welcom();
            we.Show();
            this.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            LectueLogin lo = new LectueLogin();
            lo.Show();
            this.Hide();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            StudentLogin st = new StudentLogin();
            st.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void choosing_Load(object sender, EventArgs e)
        {

        }
    }
}
