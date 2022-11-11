using QuanLyChoThueNha.SQLConn;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyChoThueNha
{
    public partial class fThueNha : Form
    {
        private ConnectSQL con;
        private int id;

        public int Id { get => id; set => id = value; }

        public fThueNha(int id)
        {
            this.Id = id;
            InitializeComponent();
        }

        #region Function
        private bool CheckInput()
        {
            if (txtMaKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Không được để trống mã khách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbHTTT.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn hình thức thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbMDSD.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn mục đích sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtpNgayBD.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày bắt đầu phải là ngày hôm nay.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            TimeSpan diff = dtpNgayKT.Value.Subtract(dtpNgayBD.Value);
            if (diff.TotalDays < 30)
            {
                MessageBox.Show("Thời gian thuê tối thiểu là 1 tháng (30 ngày).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtTienCoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Không được để trống ô tiền đặt cọc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInput()
        {
            txtMaKhach.Clear();
            cbMDSD.SelectedIndex = -1;
            cbHTTT.SelectedIndex = -1;
            dtpNgayBD.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now;
            txtTienCoc.Clear();
        }

        private void LoadThueNha()
        {
            string query = "Select * from DuaRaThongTinThueNha";
            dgvThueNha.DataSource = con.SelectData(query);
        }

        private void StateButton(bool b)
        {
            btnSua.Enabled = b;
            btnHopDong.Enabled = b;
            btnXoa.Enabled = b;
        }

        #endregion

        #region Event
        private void fThueNha_Load(object sender, EventArgs e)
        {
            con = new ConnectSQL();
            txtMaNha.Text = Id.ToString();

            DataTable dataTable = con.SelectData("select TenMucDichSD from MucDichSuDung");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cbMDSD.Items.Add(dataTable.Rows[i]["TenMucDichSD"].ToString());
            }

            cbHTTT.Items.Add("Chuyển khoản");
            cbHTTT.Items.Add("Tiền mặt");

            StateButton(false);
            LoadThueNha();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            listViewKhach.Items.Clear();
            if (txtTim.Text.Trim().Length > 0)
            {
                string tenKT = txtTim.Text.Trim();
                string query = $"select makhach, TenKhach, GioiTinh, SoDienThoai, SoCMND, DiaChiThuongTru from KhachThue where TenKhach like N'{tenKT}%'";
                using (SqlDataReader read = con.ExecuteRead(query))
                {
                    if (read != null)
                    {
                        while (read.Read())
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = read["MaKhach"].ToString();
                            item.SubItems.Add(read["TenKhach"].ToString());
                            item.SubItems.Add(read["GioiTinh"].ToString());
                            item.SubItems.Add(read["SoDienThoai"].ToString());
                            item.SubItems.Add(read["SoCMND"].ToString());
                            item.SubItems.Add(read["DiaChiThuongTru"].ToString());
                            listViewKhach.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin khách thuê nhà.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    read.Close();
                }

            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin để tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void listViewKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            if (listViewKhach.SelectedItems.Count > 0)
            {
                item = listViewKhach.SelectedItems[0];
                txtMaKhach.Text = item.Text;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!btnHopDong.Enabled && !btnXoa.Enabled && !btnSua.Enabled)
            {
                if (CheckInput())
                {
                    if (MessageBox.Show("Xác nhận cho thuê nhà?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string strMaKhach = txtMaKhach.Text.Trim();
                        string strTenMDSD = cbMDSD.Text;
                        string strMaMDSD = (string)con.ExecuteScalar($"select MaMucDichSD from MucDichSuDung where TenMucDichSD = N'{strTenMDSD}'");
                        string strHTTT = cbHTTT.Text;
                        string ngaydb = dtpNgayBD.Value.ToString("yyyy-MM-dd");
                        string ngaykt = dtpNgayKT.Value.ToString("yyyy-MM-dd");
                        string strTienCoc = txtTienCoc.Text.Trim();
                        string query = $"insert into ThueNha(MaKhach, MaNha, MaMucDichSD, HinhThucTT, NgayBD, NgayKT, TienDatCoc) values " +
                            $"({strMaKhach}, {id}, '{strMaMDSD}', N'{strHTTT}', '{ngaydb}', '{ngaykt}', {strTienCoc})";
                        con.ExecuteIUDQuery(query);
                        LoadThueNha();
                        ClearInput();
                    }
                }
            }
            if (btnSua.Enabled)
            {
                if (CheckInput())
                {
                    if (MessageBox.Show("Xác nhận sửa thông tin cho thuê nhà?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int masothue = int.Parse(lbMaSoThue.Text);
                        string strMaNha = txtMaNha.Text;
                        string strMaKhach = txtMaKhach.Text.Trim();
                        string strTenMDSD = cbMDSD.Text;
                        string strMaMDSD = (string)con.ExecuteScalar($"select MaMucDichSD from MucDichSuDung where TenMucDichSD = N'{strTenMDSD}'");
                        string strHTTT = cbHTTT.Text;
                        string ngaydb = dtpNgayBD.Value.ToString("yyyy-MM-dd");
                        string ngaykt = dtpNgayKT.Value.ToString("yyyy-MM-dd");
                        string strTienCoc = txtTienCoc.Text.Trim();
                        string query = $"update ThueNha set MaKhach = {strMaKhach}, MaNha = {strMaNha}, MaMucDichSD = '{strMaMDSD}', " +
                            $"HinhThucTT = N'{strHTTT}', NgayBD = '{ngaydb}', NgayKT = '{ngaykt}', TienDatCoc = {strTienCoc}" +
                            $"where masothue = {masothue}";
                        con.ExecuteIUDQuery(query);
                        LoadThueNha();
                        ClearInput();
                    }
                }
            }
            if (btnXoa.Enabled)
            {
                int masothue = int.Parse(lbMaSoThue.Text);
                if (MessageBox.Show("Xác nhận xóa thông tin cho thuê nhà "+ masothue +"?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string query1 = $"delete from TraNha_MatTaiSan where MaSothue = '{masothue}'";
                    con.ExecuteIUDQuery(query1);
                    string queryDeleteThuTien = $"delete from ThuTien where masothue = {masothue}";
                    con.ExecuteIUDQuery(queryDeleteThuTien);
                    string query = $"delete from ThueNha where masothue = {masothue}";
                    con.ExecuteIUDQuery(query);
                    LoadThueNha();
                    ClearInput();
                }
            }

        }

        private void dgvThueNha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StateButton(true);
            btnXacNhan.Enabled = false;

            lbMaSoThue.Text = dgvThueNha.SelectedRows[0].Cells[0].Value.ToString();

            txtMaKhach.Text = dgvThueNha.SelectedRows[0].Cells[1].Value.ToString();
            txtMaNha.Text = dgvThueNha.SelectedRows[0].Cells[2].Value.ToString();
            cbMDSD.Text = dgvThueNha.SelectedRows[0].Cells[3].Value.ToString();
            cbHTTT.Text = dgvThueNha.SelectedRows[0].Cells[4].Value.ToString();
            dtpNgayBD.Value = DateTime.Parse(dgvThueNha.SelectedRows[0].Cells[5].Value.ToString());
            dtpNgayKT.Value = DateTime.Parse(dgvThueNha.SelectedRows[0].Cells[6].Value.ToString());
            txtTienCoc.Text = dgvThueNha.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            StateButton(false);
            btnSua.Enabled = true;
            btnXacNhan.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            StateButton(false);
            btnXoa.Enabled = true;
            btnXacNhan.Enabled = true;
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            new fHopDong(int.Parse(lbMaSoThue.Text)).ShowDialog();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            StateButton(false);
            btnXacNhan.Enabled = true;
        }
        #endregion
    }
}
