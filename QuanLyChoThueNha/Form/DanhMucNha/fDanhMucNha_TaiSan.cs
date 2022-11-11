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
    public partial class fDanhMucNha_TaiSan : Form
    {
        private ConnectSQL connect;
        private int id;
        public fDanhMucNha_TaiSan(int id)
        {
            this.id = id;
            connect = new ConnectSQL();
            InitializeComponent();
        }

        #region Function

        private void state_Button(bool type)
        {
            btnThem.Enabled = type;
            btnSua.Enabled = type;
            btnXoa.Enabled = type;
        }
        private bool checkInput()
        {
            if (txtMaTS.Text == "")
            {
                MessageBox.Show("Không được để trống mã tài sản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTS.Focus();
                return false;
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Không được để trống số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return false;
            }
            if (txtGiaTri.Text == "")
            {
                MessageBox.Show("Không được để trống giá trị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaTri.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region Event

        private void fDanhMucNha_TaiSan_Load(object sender, EventArgs e)
        {
            string query = $"Select Manha as N'Mã nhà', nha_taisan.mataisan as N'Mã tài sản', tentaisan as N'Tên tài sản'" +
                $", soluong as N'Số lượng', giatri as N'Giá trị'" +
                $" from nha_taisan join taisan on nha_taisan.mataisan = taisan.mataisan " +
                $"where manha = '{id}'";
            dgvTaiSan.DataSource = connect.SelectData(query);
            lbMaNha.Text = "Mã nhà: " + id.ToString();
            DataTable dataTable = connect.SelectData("select TenTaiSan from taisan");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cbTenTS.Items.Add(dataTable.Rows[i]["TenTaiSan"].ToString());
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && txtGiaTri.Text.Contains("."))
                e.Handled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                state_Button(false);
                btnThem.Enabled = true;
                btnThem.Focus();
                string message = "Xác nhận thêm tài sản cho nhà có " +
                    "\n Mã nhà: " + id +
                    "\n Mã tài sản: " + txtMaTS.Text.Trim() +
                    "\n Tên tài sản: " + cbTenTS.Text.Trim() +
                    "\n Số lượng: " + txtSoLuong.Text.Trim() +
                    "\n Giá trị: " + txtGiaTri.Text.Trim();
                if (MessageBox.Show(message,"Thông báo",MessageBoxButtons.YesNo,
                    MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    string query = $"insert into nha_taisan values ('{id}','{txtMaTS.Text.Trim()}'," +
                        $"'{txtSoLuong.Text.Trim()}','{txtGiaTri.Text.Trim()}')";
                    try
                    {
                        connect.ExecuteIUDQuery(query);
                        MessageBox.Show("Thêm thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fDanhMucNha_TaiSan_Load(sender,e);
                        btnHuy.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm thông tin thất bại! Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                state_Button(false);
                btnSua.Enabled = true;
                btnSua.Focus();
            }
            string message = "Xác nhận sửa thông tin tài sản" +
                    "\n Mã nhà: " + id +
                    "\n Mã tài sản: " + txtMaTS.Text.Trim() +
                    "\n Tên tài sản: " + cbTenTS.Text.Trim() +
                    "\n Số lượng: " + txtSoLuong.Text.Trim() +
                    "\n Giá trị: " + txtGiaTri.Text.Trim();
            if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                string query = $"update nha_taisan set soluong = '{txtSoLuong.Text.Trim()}', giatri = '{txtGiaTri.Text.Trim()}'" +
                    $" where manha = '{id}' and mataisan = '{txtMaTS.Text.Trim()}'";
                try
                {
                    connect.ExecuteIUDQuery(query);
                    MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fDanhMucNha_TaiSan_Load(sender, e);
                    btnHuy.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sửa thông tin thất bại! Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                state_Button(false);
                btnXoa.Enabled = true;
                btnXoa.Focus();
                string message = "Xác nhận thêm tài sản cho nhà có " +
                    "\n Mã nhà: " + id +
                    "\n Mã tài sản: " + txtMaTS.Text.Trim() +
                    "\n Tên tài sản: " + cbTenTS.Text.Trim() +
                    "\n Số lượng: " + txtSoLuong.Text.Trim() +
                    "\n Giá trị: " + txtGiaTri.Text.Trim();
                if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    string query = $"delete from nha_taisan where manha = '{id}' and mataisan = '{txtMaTS.Text.Trim()}'";
                    try
                    {
                        connect.ExecuteIUDQuery(query);
                        MessageBox.Show("Xóa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fDanhMucNha_TaiSan_Load(sender, e);
                        btnHuy.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thông tin thất bại! Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dgvTaiSan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTS.Text = dgvTaiSan.SelectedRows[0].Cells[1].Value.ToString();
            cbTenTS.Text = dgvTaiSan.SelectedRows[0].Cells[2].Value.ToString();
            txtSoLuong.Text = dgvTaiSan.SelectedRows[0].Cells[3].Value.ToString();
            txtGiaTri.Text = dgvTaiSan.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cbTenTS.SelectedIndex = -1;
            txtSoLuong.Text = "";
            txtGiaTri.Text = "";
            state_Button(true);
        }

        private void cbTenTS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = $"select mataisan from taisan where tentaisan = N'{cbTenTS.Text.Trim()}'";
            DataTable dataTable = connect.SelectData(query);
            try
            {
                txtMaTS.Text = dataTable.Rows[0]["mataisan"].ToString();
            }
            catch
            {
                txtMaTS.Text = "";
            }
        }

        #endregion
    }
}
