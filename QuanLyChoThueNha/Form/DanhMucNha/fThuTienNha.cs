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
    public partial class fThuTienNha : Form
    {
        private int idNha;
        private ConnectSQL con;
        public fThuTienNha(int idNha)
        {
            InitializeComponent();
            con = new ConnectSQL();
            this.idNha = idNha;
        }

        #region Function

        private bool CheckInput()
        {
            if (dtpNgayThu.Value > DateTime.Now)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtSoDien.Text.Trim().Length == 0)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtSoNuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInput()
        {
            dtpNgayThu.Value = DateTime.Now;
            txtSoDien.Clear();
            txtSoNuoc.Clear();
            txtGhiChu.Clear();
        }

        private void StateButton(bool b)
        {
            btnXacNhan.Enabled = b;
            btnSua.Enabled = !b;
        }

        private void LoadDGV(int masothue)
        {
            dgvThuTien.DataSource = con.SelectData($"select MaSoThu as N'Mã số thu', MaSoThue as N'Mã số thuê', " +
                $"NgayThu as N'Ngày thu', SoDien as N'Số điện', SoNuoc as N'Số nước', TongTien as N'Tổng tiền', " +
                $"GhiChu as N'Ghi chú' from thutien where masothue = {masothue}");
        }

        #endregion

        #region Event
        private void fThuTienNha_Load(object sender, EventArgs e)
        {
            lbThuTienNha.Text += idNha.ToString();
            string query = $"select * from TraVeMaSoThue_ThuTien('{idNha}')";
            int maSoThue = (int)con.ExecuteScalar(query);
            txtMaSoThue.Text = maSoThue.ToString();
            btnSua.Enabled = false;
            LoadDGV(maSoThue);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (MessageBox.Show("Bạn chắc chắn muốn thêm hóa đơn thu tiền nhà?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    int masothue = int.Parse(txtMaSoThue.Text);
                    string strNgayThu = dtpNgayThu.Value.ToString("yyyy-MM-dd");
                    int sodien = int.Parse(txtSoDien.Text);
                    int sonuoc = int.Parse(txtSoNuoc.Text);
                    string strGhichu = txtGhiChu.Text;
                    string query = $"insert into ThuTien(MaSoThue, NgayThu, SoDien, SoNuoc, GhiChu) values ({masothue}, '{strNgayThu}', {sodien}, {sonuoc}, N'{strGhichu}')";
                    con.ExecuteIUDQuery(query);
                    ClearInput();
                    StateButton(false);
                    LoadDGV(int.Parse(txtMaSoThue.Text));
                }
            }
        }

        private void dgvThuTien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StateButton(false);
            lbMaSoThu.Text = dgvThuTien.SelectedRows[0].Cells[0].Value.ToString();
            dtpNgayThu.Value = DateTime.Parse(dgvThuTien.SelectedRows[0].Cells[2].Value.ToString());
            txtSoDien.Text = dgvThuTien.SelectedRows[0].Cells[3].Value.ToString();
            txtSoNuoc.Text = dgvThuTien.SelectedRows[0].Cells[4].Value.ToString();
            txtGhiChu.Text = dgvThuTien.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (MessageBox.Show("Bạn chắc chắn muốn sửa hóa đơn thu tiền nhà?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    int masothu = int.Parse(lbMaSoThu.Text);
                    string strNgayThu = dtpNgayThu.Value.ToString("yyyy-MM-dd");
                    int sodien = int.Parse(txtSoDien.Text);
                    int sonuoc = int.Parse(txtSoNuoc.Text);
                    string strGhichu = txtGhiChu.Text;
                    string query = $"update ThuTien set NgayThu = '{strNgayThu}', SoDien = {sodien}, SoNuoc = {sonuoc}, GhiChu = N'{strGhichu}' where masothu = {masothu}";
                    con.ExecuteIUDQuery(query);
                    ClearInput();
                    StateButton(true);
                    LoadDGV(int.Parse(txtMaSoThue.Text));
                }
            }
        }
        #endregion
    }
}
