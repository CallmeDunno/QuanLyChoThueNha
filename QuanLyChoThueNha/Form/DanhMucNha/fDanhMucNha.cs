using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChoThueNha
{
    public partial class fDanhMucNha : Form
    {

        private Form currFormDMN;
        public fDanhMucNha()
        {
            InitializeComponent();
        }

        private void OpenChildFormDMN(Form child)
        {
            if (currFormDMN != null)
            {
                currFormDMN.Close();
            }
            currFormDMN = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            pnContentDMN.Controls.Add(child);
            pnContentDMN.Tag = child;
            child.BringToFront();
            child.Show();
        }

        private void menustripNha_Click(object sender, EventArgs e)
        {
            OpenChildFormDMN(new fDanhMucNha_Nha());
        }

        private void menustripThemNha_Click(object sender, EventArgs e)
        {
            OpenChildFormDMN(new fDanhMucNha_ThemNha());
        }

    }
}
