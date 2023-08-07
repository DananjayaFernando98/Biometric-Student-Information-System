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
    public partial class Welcom : Form
    {
        public Welcom()
        {
            InitializeComponent();
        }

      

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            choosing ch = new choosing();
            ch.Show();
            this.Hide();
        }
    }
}
