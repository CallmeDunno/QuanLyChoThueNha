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
        private bool hp;

        public fMain()
        {
            InitializeComponent();
        }

        #region Hover

        private void btnDMN_MouseMove(object sender, MouseEventArgs e)
        {
            btnDMN.BackColor = Color.Red;
        }

        private void btnDMN_MouseLeave(object sender, EventArgs e)
        {
            btnDMN.BackColor = Color.Cyan;
        }

        #endregion

        #region Event
        public void OpenChildForm(Form child)
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
            lbTimer.Text = btnDMN.Text;
            OpenChildForm(new fDanhMucNha());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lbTimer.Text = "Nhóm 2";
            if (currForm != null)
            {
                currForm.Close();
            }
        }

        private void btnKhachThueNha_Click(object sender, EventArgs e)
        {
            lbTimer.Text = btnKhachThueNha.Text;
            OpenChildForm(new fKhachThue());
        }

        private void btnTraNha_Click(object sender, EventArgs e)
        {
            lbTimer.Text = btnTraNha.Text;
            OpenChildForm(new fTraNha());
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lbTimer.Text = btnTimKiem.Text;
            OpenChildForm(new fTimKiem());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            lbTimer.Text = btnThongKe.Text;
            OpenChildForm(new fThongKe());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hp)
            {
                if ((lbTimer.Left + lbTimer.Width) < panel3.Width)
                    lbTimer.Left = lbTimer.Left + 5;
                else
                    hp = false;
            }
            else
            {
                if (lbTimer.Left > 0)
                    lbTimer.Left = lbTimer.Left - 5;
                else
                    hp = true;
            }
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            hp = true;
            timer1.Enabled = true;
            timer1.Start();
        }

        #endregion

        private void lbAboutUs_Click(object sender, EventArgs e)
        {
            lbTimer.Text = "About us";
            new fAboutUs().ShowDialog();
        }
    }
}
