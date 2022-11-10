using QuanLyChoThueNha.SQLConn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            txtMaNha.Clear();
            cbMDSD.SelectedIndex = -1;
            cbHTTT.SelectedIndex = -1;
            dtpNgayBD.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now;
            txtTienCoc.Clear();
        }

        private void LoadThueNha()
        {
            string query = "select * from ThueNha";
            dgvThueNha.DataSource = con.SelectData(query);
        }

        #endregion


        private void fThueNha_Load(object sender, EventArgs e)
        {
            con = new ConnectSQL();
            txtMaNha.Text = Id.ToString();

            cbMDSD.Items.Add("Làm việc");
            cbMDSD.Items.Add("Ở");
            cbMDSD.Items.Add("Bán hàng");

            cbHTTT.Items.Add("Chuyển khoản");
            cbHTTT.Items.Add("Tiền mặt");

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
                    
            } else
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
            if (CheckInput())
            {
                if(MessageBox.Show("Xác nhận cho thuê nhà?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string strMaKhach = txtMaKhach.Text.Trim();
                    string strTenMDSD = "";
                    switch (cbMDSD.SelectedIndex)
                    {
                        case 0: 
                            strMaKhach = "Làm việc";
                            break;
                        case 1: 
                            strTenMDSD = "Ở";
                            break;
                        case 2:
                            strTenMDSD = "Bán hàng";
                            break;
                    }
                    string strMaMDSD = (string)con.ExecuteScalar($"select MaMucDichSD from MucDichSuDung where TenMucDichSD = N'{strTenMDSD}'");
                    string strHTTT = "";
                    switch (cbHTTT.SelectedIndex)
                    {
                        case 0:
                            strHTTT = "Chuyển khoản";
                            break;
                        case 1:
                            strHTTT = "Tiền mặt";
                            break;
                    }
                    string ngaydb = dtpNgayBD.Value.ToString("yyyy-MM-dd");
                    string ngaykt = dtpNgayKT.Value.ToString("yyyy-MM-dd");
                    string strTienCoc = txtTienCoc.Text.Trim();
                    string query = $"insert into ThueNha(MaKhach, MaNha, MaMucDichSD, HinhThucTT, NgayBD, NgayKT, TienDatCoc) values " +
                        $"({strMaKhach}, {id}, '{strMaMDSD}', N'{strHTTT}', '{ngaydb}', '{ngaykt}', {strTienCoc})";
                    try
                    {
                        con.ExecuteIUDQuery(query);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex.ToString());
                    }
                    LoadThueNha();
                    ClearInput();
                }
            }
        }

        
    }
}
