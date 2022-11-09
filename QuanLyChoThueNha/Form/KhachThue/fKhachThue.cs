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
    public partial class fKhachThue : Form
    {
        private ConnectSQL conn;
        public fKhachThue()
        {
            InitializeComponent();
        }

        #region Function

        private void StateGroupBoxChiTiet(bool type)
        {
            gbChitiet.Enabled = type;
        }

        private void StateButtonThemSuaXoa(bool type)
        {
            btnThem.Enabled = type;
            btnSua.Enabled = type;
            btnXoa.Enabled = type;
        }

        private bool isCheck()
        {
            if (txtTenK.Text.Trim() == "")
            {
                MessageBox.Show("Tên khách thuê không được để trống!", "Thông báo");
                return false;
            }

            if (dtNgaysinh.Value >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không được nhỏ lớn ngày hiện tại!", "Thông báo");
                return false;
            }

            if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Thông báo");
                return false;
            }

            if (cbGioitinh.Text == "")
            {
                MessageBox.Show("Giới tính không được để trống!", "Thông báo");
                return false;
            }

            if (txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("Số CMND không được để trống!", "Thông báo");
                return false;
            }

            if (txtDiachi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được để trống!", "Thông báo");
                return false;
            }

            if (txtTennghe.Text.Trim() == "")
            {
                MessageBox.Show("Tên nghề không được để trống!", "Thông báo");
                return false;
            }

            return true;
        }

        private KhachThue khachThue()
        {
            string tenKhach = txtTenK.Text.Trim();
            string ngaySinh = dtNgaysinh.Value.ToString("yyyy-MM-dd");
            string sdt = txtSDT.Text.Trim();
            string gioiTinh = cbGioitinh.Text.Trim();
            string soCMND = txtCMND.Text.Trim();
            string diaChi = txtDiachi.Text.Trim();
            string tenNghe = txtTennghe.Text.Trim();

            return new KhachThue(tenKhach, ngaySinh, sdt, gioiTinh, soCMND, diaChi, tenNghe);
        }

        private void ResetValue()
        {
            txtTenK.Text = "";
            dtNgaysinh.Value = DateTime.Today;
            cbGioitinh.SelectedIndex = 0;
            txtCMND.Text = "";
            txtDiachi.Text = "";
            txtTennghe.Text = "";
        }

        #endregion

        #region Event
        private void fKhachThue_Load(object sender, EventArgs e)
        {
            conn = new ConnectSQL();
            dgvKhach.DataSource = conn.SelectData("select * from KhachThue");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            StateGroupBoxChiTiet(true);
            StateButtonThemSuaXoa(false);
            btnThem.Enabled = true;
            txtTenK.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            StateGroupBoxChiTiet(true);
            StateButtonThemSuaXoa(false);
            btnSua.Enabled = true;
            txtTenK.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            StateGroupBoxChiTiet(true);
            StateButtonThemSuaXoa(false);
            btnXoa.Enabled = true;
            if (MessageBox.Show("Ban có muốn xóa khách thuê không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                KhachThue kt = khachThue();
                string deleteQuery = $"delete from KhachThue where TenKhach = N'{kt.TenKhach}'";
                try
                {
                    conn.ExecuteIUDQuery(deleteQuery);
                    MessageBox.Show("Đã xóa thành công", "Thông báo");
                    fKhachThue_Load(sender, e);
                    ResetValue();
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled && isCheck())
            {
                KhachThue kt = khachThue();
                string query = $"Insert into KhachThue values" +
                    $"(N'{kt.TenKhach}','{kt.NgaySinh}','{kt.SDT}',N'{kt.GioiTinh}','{kt.SoCMND}',N'{kt.DiaChi}',N'{kt.TenNghe}')";
                if (MessageBox.Show("Bạn có muốn thêm khách thuê không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) ;
                {
                    try
                    {
                        conn.ExecuteIUDQuery(query);
                        MessageBox.Show("Thêm khách thuê thành công");
                        fKhachThue_Load(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }

                }
            }

            if (btnSua.Enabled && isCheck())
            {
                if (MessageBox.Show("Bạn có muốn sửa khách thuê không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    KhachThue kt = khachThue();
                    string updateQuery = $"update KhachThue set " +
                        $"NgaySinh = '{kt.NgaySinh}', SoDienThoai = N'{kt.SDT}'," +
                        $"GioiTinh = '{kt.GioiTinh}', SoCMND = N'{kt.SoCMND}', Diachithuongtru = '{kt.DiaChi}', NgheNghiep = N'{kt.TenNghe}' " +
                        $"where TenKhach = N'{kt.TenKhach}'";
                    try
                    {
                        conn.ExecuteIUDQuery(updateQuery);
                        MessageBox.Show("Đã sửa thành công", "Thông báo");
                        fKhachThue_Load(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.ToString());
                    }
                }
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            ResetValue();
            StateGroupBoxChiTiet(false);
            StateButtonThemSuaXoa(true);
        }

        private void dgvKhach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenK.Text = dgvKhach.CurrentRow.Cells[1].Value.ToString();
            dtNgaysinh.Value = DateTime.Parse(dgvKhach.CurrentRow.Cells[2].Value.ToString());
            txtSDT.Text = dgvKhach.CurrentRow.Cells[3].Value.ToString();
            cbGioitinh.Text = dgvKhach.CurrentRow.Cells[4].Value.ToString();
            txtCMND.Text = dgvKhach.CurrentRow.Cells[5].Value.ToString();
            txtDiachi.Text = dgvKhach.CurrentRow.Cells[6].Value.ToString();
            txtTennghe.Text = dgvKhach.CurrentRow.Cells[7].Value.ToString();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}
