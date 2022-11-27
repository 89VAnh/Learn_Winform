using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data.View
{
    public partial class MDIApp : Form
    {

        public MDIApp()
        {
            InitializeComponent();
        }
        private void quảnLýLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClasses f = new frmClasses();
            f.Show();
            f.MdiParent = this;
        }

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudents f = new frmStudents();
            f.Show();
            f.MdiParent = this;
        }

        private void quảnLýSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooks f = new frmBooks();
            f.Show();
            f.MdiParent = this;

        }
    }
}
