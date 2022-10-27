using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChoThueNha
{
    public partial class fMain : Form
    {

        private Form currForm;

        public fMain()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form child)
        {
            if(currForm != null)
            {
                currForm.Close();
            }
            currForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            pnContent.Controls.Add(child);
            pnContent.Tag = child;
            child.BringToFront();
            child.Show();
        }

        private void btnDMN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fDanhMucNha());
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fTimKiem());
        }

        private void btnDMN_MouseMove(object sender, MouseEventArgs e)
        {
            btnDMN.BackColor = Color.Red;
        }

        private void btnDMN_MouseLeave(object sender, EventArgs e)
        {
            btnDMN.BackColor = Color.Cyan;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currForm != null)
            {
                currForm.Close();
            }
        }

        private void btnThue_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fTraNha());
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fXuatFile());
        }

        private void btnKhachThueNha_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fKhachThue());
        }
    }
}
