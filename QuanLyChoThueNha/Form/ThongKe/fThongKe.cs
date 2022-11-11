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
    public partial class fThongKe : Form
    {
        private Form currFormTK;
        public fThongKe()
        {
            InitializeComponent();
        }

        private void OpenChildFormTK(Form child)
        {
            if (currFormTK != null)
            {
                currFormTK.Close();
            }
            currFormTK = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            pnContent.Controls.Add(child);
            pnContent.Tag = child;
            child.BringToFront();
            child.Show();
        }

        private void excelTienTungNhaTrongThang_Click(object sender, EventArgs e)
        {
            OpenChildFormTK(new fThongKe_TienNhaTungNhaThangHT());
        }

        private void excelTongTienNhaCacThang_Click(object sender, EventArgs e)
        {
            OpenChildFormTK(new fThongKe_TienNhaTungThang());
        }
    }
}
