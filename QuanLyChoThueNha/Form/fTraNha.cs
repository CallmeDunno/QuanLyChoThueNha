using QuanLyChoThueNha.SQLConn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChoThueNha
{
    public partial class fTraNha : Form
    {
        private ConnectSQL connect;
        public fTraNha()
        {
            connect = new ConnectSQL();
            InitializeComponent();
        }

        #region Function
        private void state_groupbox(bool type)
        {
            grbTraNha.Enabled = type;
            grbMatTaiSan.Enabled = type;
        }

        private void state_buttonChucNangChinh(bool type)
        {
            btnThem.Enabled = type;
            btnSua.Enabled = type;
            btnXoa.Enabled = type;
        }

        private bool checkTraNha()
        {
            if (txtMaSoThue.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống Mã số thuê!");
                txtMaSoThue.Focus();
                return false;
            }
            if (txtTongTien.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống Tổng tiền!");
                txtTongTien.Focus();
                return false;
            }
            TimeSpan diff = dtpNgayTra.Value.Subtract(DateTime.Now);
            if (diff.TotalDays < 30)
            {
                MessageBox.Show("Ngày trả phải lớn hơn 1 tháng tính từ hiện tại!");
                dtpNgayTra.Focus();
                return false;
            }
            return true;
        }

        private bool checkMatTaiSan()
        {
            if (cmbMST_MatTS.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống Mã số thuê!");
                cmbMST_MatTS.Focus();
                return false;
            }
            if (cmbMaTaiSan.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống Mã tài sản!");
                cmbMaTaiSan.Focus();
                return false;
            }
            if (txtSoLuong.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống Số lượng!");
                txtSoLuong.Focus();
                return false;
            }
            if (txtGiaTri.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống giá trị!");
                txtGiaTri.Focus();
                return false;
            }
            return true;
        }

        private void loadDataComboBox()
        {
            DataTable dataTable = connect.SelectData("select masothue from tranha");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cmbMST_MatTS.Items.Add(dataTable.Rows[i]["MaSoThue"].ToString());
            }
            dataTable.Clear();
            dataTable = connect.SelectData("select mataisan from taisan");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cmbMaTaiSan.Items.Add(dataTable.Rows[i]["MaTaiSan"].ToString());
            }
        }
        #endregion

        #region Event
        private void fTraNha_Load(object sender, EventArgs e)
        {
            dgvDsNhaChuaTra.DataSource = connect.SelectData("Select * from TraNha");
            state_groupbox(false);
            loadDataComboBox();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            state_buttonChucNangChinh(false);
            btnThem.Enabled = true;
            btnThem.Focus();
            state_groupbox(true);
            btnLamLaiMatTaiSan.PerformClick();
            btnLamLaiTraNha.PerformClick();
        }
     
        private void btnSua_Click(object sender, EventArgs e)
        {
            state_buttonChucNangChinh(false);
            btnSua.Enabled = true;
            btnSua.Focus();
            state_groupbox(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            state_buttonChucNangChinh(false);
            btnXoa.Enabled = true;
            btnXoa.Focus();
            state_groupbox(true);
            dtpNgayTra.Enabled = false;
            txtTongTien.Enabled = false;
            txtSoLuong.Enabled = false;
            txtGiaTri.Enabled = false;
            btnLuuMatTaiSan.Text = "Xóa";
            btnLuuTraNha.Text = "Xóa";
            MessageBox.Show("Mời bạn chọn xóa thông tin trả nhà hoặc thông tin mất tài sản");
        }

        private void dgvDsNhaChuaTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string masothue = dgvDsNhaChuaTra.SelectedRows[0].Cells[0].Value.ToString();
            string query = $"Select MaSoThue, TraNha_MatTaiSan.MaTaiSan, " +
                $"TenTaiSan, SoLuong, GiaTri " +
                $"from TraNha_MatTaiSan join TaiSan on TraNha_MatTaiSan.MaTaiSan = TaiSan.MaTaiSan" +
                $" where MaSoThue = '{masothue}'";
            dgvThongTinMatTaiSan.DataSource = connect.SelectData(query);
            txtMaSoThue.Text = masothue;
            dtpNgayTra.Value = DateTime.Parse(dgvDsNhaChuaTra.SelectedRows[0].Cells[1].Value.ToString());
            txtTongTien.Text = dgvDsNhaChuaTra.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void dgvThongTinMatTaiSan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbMST_MatTS.Text = dgvThongTinMatTaiSan.SelectedRows[0].Cells[0].Value.ToString();
            cmbMaTaiSan.Text = dgvThongTinMatTaiSan.SelectedRows[0].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvThongTinMatTaiSan.SelectedRows[0].Cells[3].Value.ToString();
            txtGiaTri.Text = dgvThongTinMatTaiSan.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnLuuTraNha_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == true)
            {
                if (checkTraNha())
                {
                    string query = $"insert into TraNha values ('{txtMaSoThue.Text.Trim()}'," +
                        $"'{dtpNgayTra.Value.ToString("yyyy-MM-dd")}','{txtTongTien.Text.Trim()}')";
                    try
                    {
                        connect.ExecuteIUDQuery(query);
                        MessageBox.Show("Thêm vào bảng trả nhà thành công!");
                        dgvDsNhaChuaTra.DataSource = connect.SelectData("Select * from TraNha");
                        btnLamLaiTraNha.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm vào bảng trả nhà thất bại! Lỗi: "+ex.Message);
                    }
                }
                else
                {
                    return;
                }
            }
            if (btnSua.Enabled == true)
            {
                if (checkTraNha())
                {
                    string query = $"update TraNha set NgayTra = '{dtpNgayTra.Value.ToString("yyyy-MM-dd")}', Tongtien = '{txtTongTien.Text}' where MaSoThue = '{txtMaSoThue.Text.Trim()}'";
                    try
                    {
                        connect.ExecuteIUDQuery(query);
                        MessageBox.Show("Sửa thông tin thành công!");
                        dgvDsNhaChuaTra.DataSource = connect.SelectData("Select * from TraNha");
                        btnLamLaiTraNha.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sửa thông tin thất bại! Lỗi: " + ex.Message);
                    }
                }
                else
                {
                    return;
                }
            }
            if (btnXoa.Enabled == true)
            {
                if (txtMaSoThue.Text.Trim() == "")
                {
                    MessageBox.Show("Không được để trống Mã số thuê!");
                    txtMaSoThue.Focus();
                    return;
                }
                
                string query2 = $"delete from TraNha where MaSothue = '{txtMaSoThue.Text.Trim()}'";
                try
                {
                    connect.ExecuteIUDQuery(query2);
                    MessageBox.Show("Xóa thông tin thành công!");
                    dgvDsNhaChuaTra.DataSource = connect.SelectData("Select * from TraNha");
                    btnLamLaiTraNha.PerformClick();
                    string masothue = dgvDsNhaChuaTra.SelectedRows[0].Cells[0].Value.ToString();
                    string query3 = $"Select MaSoThue, TraNha_MatTaiSan.MaTaiSan, " +
                        $"TenTaiSan, SoLuong, GiaTri " +
                        $"from TraNha_MatTaiSan join TaiSan on TraNha_MatTaiSan.MaTaiSan = TaiSan.MaTaiSan" +
                        $" where MaSoThue = '{masothue}'";
                    dgvThongTinMatTaiSan.DataSource = connect.SelectData(query3);
                    btnLamLaiMatTaiSan.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thông tin thất bại! Lỗi: " + ex.Message);
                }
            }
        }

        private void btnLuuMatTaiSan_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == true)
            {
                if (checkMatTaiSan())
                {
                    try
                    {
                        string query1 = $"insert into TraNha_MatTaiSan values('{cmbMST_MatTS.Text.Trim()}'" +
                            $",'{cmbMaTaiSan.Text.Trim()}','{txtSoLuong.Text.Trim()}','{txtGiaTri.Text.Trim()}')";
                        connect.ExecuteIUDQuery(query1);
                        MessageBox.Show("Thêm thông tin thành công!");
                        string masothue = dgvDsNhaChuaTra.SelectedRows[0].Cells[0].Value.ToString();
                        string query2 = $"Select MaSoThue, TraNha_MatTaiSan.MaTaiSan, " +
                            $"TenTaiSan, SoLuong, GiaTri " +
                            $"from TraNha_MatTaiSan join TaiSan on TraNha_MatTaiSan.MaTaiSan = TaiSan.MaTaiSan" +
                            $" where MaSoThue = '{masothue}'";
                        dgvThongTinMatTaiSan.DataSource = connect.SelectData(query2);
                        btnLamLaiMatTaiSan.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm thông tin thất bại! Lỗi: " + ex.Message);
                    }
                }
                else
                {
                    return;
                }
            }
            if (btnSua.Enabled == true)
            {
                if (checkMatTaiSan())
                {
                    try
                    {
                        string query1 = $"update TraNha_MatTaiSan set" +
                            $" SoLuong = '{txtSoLuong.Text.Trim()}', GiaTri = '{txtGiaTri.Text.Trim()}')" +
                            $"where masothue = '{cmbMST_MatTS.Text.Trim()}' and mataisan = '{cmbMaTaiSan.Text.Trim()}'";
                        connect.ExecuteIUDQuery(query1);
                        MessageBox.Show("Sửa thông tin thành công!");
                        string masothue = dgvDsNhaChuaTra.SelectedRows[0].Cells[0].Value.ToString();
                        string query2 = $"Select MaSoThue, TraNha_MatTaiSan.MaTaiSan, " +
                            $"TenTaiSan, SoLuong, GiaTri " +
                            $"from TraNha_MatTaiSan join TaiSan on TraNha_MatTaiSan.MaTaiSan = TaiSan.MaTaiSan" +
                            $" where MaSoThue = '{masothue}'";
                        dgvThongTinMatTaiSan.DataSource = connect.SelectData(query2);
                        btnLamLaiMatTaiSan.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sửa thông tin thất bại! Lỗi: " + ex.Message);
                    }
                }
                else
                {
                    return;
                }
            }
            if (btnXoa.Enabled == true) 
            {
                if (cmbMST_MatTS.Text.Trim() == "")
                {
                    MessageBox.Show("Không được để trống Mã số thuê!");
                    txtMaSoThue.Focus();
                    return;
                }
                if (cmbMaTaiSan.Text.Trim() == "")
                {
                    MessageBox.Show("Không được để trống Mã tài sản!");
                    cmbMaTaiSan.Focus();
                    return;
                }
                string query = $"delete from TraNha_MatTaiSan where MaSothue = '{cmbMST_MatTS.Text.Trim()}'" +
                    $" and mataisan = '{cmbMaTaiSan.Text.Trim()}'";
                try
                {
                    connect.ExecuteIUDQuery(query);
                    MessageBox.Show("Xóa thông tin thành công!");
                    dgvDsNhaChuaTra.DataSource = connect.SelectData("Select * from TraNha");
                    string masothue = dgvDsNhaChuaTra.SelectedRows[0].Cells[0].Value.ToString();
                    string query2 = $"Select MaSoThue, TraNha_MatTaiSan.MaTaiSan, " +
                        $"TenTaiSan, SoLuong, GiaTri " +
                        $"from TraNha_MatTaiSan join TaiSan on TraNha_MatTaiSan.MaTaiSan = TaiSan.MaTaiSan" +
                        $" where MaSoThue = '{masothue}'";
                    dgvThongTinMatTaiSan.DataSource = connect.SelectData(query2);
                    btnLamLaiMatTaiSan.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thông tin thất bại! Lỗi: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnLamLaiMatTaiSan.PerformClick();
            btnLamLaiTraNha.PerformClick();
            state_groupbox(false);
            state_buttonChucNangChinh(true);
            dtpNgayTra.Enabled = true;
            txtTongTien.Enabled = true;
            txtSoLuong.Enabled = true;
            txtGiaTri.Enabled = true;
            btnLuuMatTaiSan.Text = "Lưu";
            btnLuuTraNha.Text = "Lưu";
        }

        private void btnLamLaiTraNha_Click(object sender, EventArgs e)
        {
            txtMaSoThue.Text = "";
            dtpNgayTra.Text = "";
            txtTongTien.Text = "";
        }

        private void btnLamLaiMatTaiSan_Click(object sender, EventArgs e)
        {
            cmbMST_MatTS.Text = "";
            cmbMaTaiSan.Text = "";
            txtSoLuong.Text = "";
            txtGiaTri.Text = "";
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

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtTongTien.Text.Contains("."))
                e.Handled = true;
        }
        #endregion
    }
}
