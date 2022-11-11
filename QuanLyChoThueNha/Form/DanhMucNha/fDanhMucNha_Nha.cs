using QuanLyChoThueNha.SQLConn;
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
    public partial class fDanhMucNha_Nha : Form
    {
        public fDanhMucNha_Nha()
        {
            InitializeComponent();
            LoadTable();
        }

        #region Function

        private void LoadTable()
        {
            flpDMN_Nha.Controls.Clear();
            TableLoad tableLoad = new TableLoad();
            List<ThongTinNha> list = tableLoad.LoadThongTinNha();
            foreach (ThongTinNha thongTinNha in list)
            {
                Button button = new Button();
                button.Width = 80;
                button.Height = 80;
                button.Text = "Nhà " + thongTinNha.MaNha;
                if (thongTinNha.TinhTrangThue.Equals("Đã thuê"))
                {
                    button.BackColor = Color.LawnGreen;
                }
                else
                {
                    button.BackColor = Color.Brown;
                }
                button.Click += Button_Click;
                button.Tag = thongTinNha;
                flpDMN_Nha.Controls.Add(button);
            }

        }

        #endregion

        #region Event

        private void Button_Click(object sender, EventArgs e)
        {
            int id = ((sender as Button).Tag as ThongTinNha).MaNha;
            string query = $"select * from DuaRaThongTinNha('{id}')";
            ConnectSQL connect = new ConnectSQL();
            DataTable dt = connect.SelectData(query);
            ThongTinNha thongTinNha = new ThongTinNha(dt.Rows[0]);
            txtMaNha.Text = id.ToString();
            txtTenCN.Text = thongTinNha.TenChuNha;
            txtSDT.Text = thongTinNha.SoDienThoai;
            txtDC.Text = thongTinNha.DiaChi;
            txtGiaPhong.Text = thongTinNha.GiaPhong;
            txtD.Text = thongTinNha.TienDien;
            txtN.Text = thongTinNha.TienNuoc;
            txtTTT.Text = thongTinNha.TinhTrangThue;
            txtLoaiNha.Text = thongTinNha.TenLoai;
            txtDTSD.Text = thongTinNha.DTSD;
            picture.Image = Image.FromFile(thongTinNha.AnhMinhHoa);
            if (txtTTT.Text.Equals("Đã thuê"))
            {
                btnThue.Enabled = false;
                btnThue.Visible = false;

                btnTaiSan.Enabled = true;
                btnTaiSan.Visible = true;
                btnThuTienNha.Enabled = true;
                btnThuTienNha.Visible = true;
            } else
            {
                btnThue.Enabled = true;
                btnThue.Visible = true;

                btnTaiSan.Visible = false;
                btnTaiSan.Enabled = false;
                btnThuTienNha.Enabled = false;
                btnThuTienNha.Visible = false;
            }
        }

        private void btnThue_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMaNha.Text);
            new fThueNha(id).ShowDialog();
            LoadTable();
        }

        private void btnThuTienNha_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMaNha.Text);
            new fThuTienNha(id).ShowDialog();
        }

        private void btnTaiSan_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtMaNha.Text);
            new fDanhMucNha_TaiSan(id).ShowDialog();
        }

        #endregion
    }
}
