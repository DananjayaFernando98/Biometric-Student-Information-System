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
    public partial class LectureProfile : Form
    {
        public LectureProfile()
        {
            InitializeComponent();
        }

        private void LectureProfile_Load(object sender, EventArgs e)
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
