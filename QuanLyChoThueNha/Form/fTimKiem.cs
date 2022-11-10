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
    public partial class fTimKiem : Form
    {
        private ConnectSQL conn;
        public fTimKiem()
        {
            InitializeComponent();
            conn = new ConnectSQL();
        }
        #region Function
        private void AddDataComboBox1()
        {
            cbTim1.Items.Add("Loại nhà");
            cbTim1.Items.Add("Loại đối tượng sử dụng");
            cbTim1.Items.Add("Địa chỉ");
        }

        private void AddDataComboBox2()
        {
            cbTim2.Items.Add("Tên khách");
            cbTim2.Items.Add("Địa chỉ thường trú");
            cbTim2.Items.Add("Nghề nghiệp");
        }

        private bool CheckTimNha()
        {
            if(cbTim1.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn phương thức tìm kiếm!!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            if(cbTim1_1.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn phương thức tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;    
        }

        private bool CheckTimKhach()
        {
            if (cbTim2.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn phương thức tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtTim2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thông tin tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

        #region Event
        private void btnTimNha_Click(object sender, EventArgs e)
        {
            if (CheckTimNha())
            {
                string timnha = cbTim1_1.Text;
                switch (cbTim1.SelectedIndex)
                {
                    case 0:
                        DataTable loainha = conn.SelectData($"select * from TimKiemNhaTheoLoaiNha(N'{timnha}')");
                        if(loainha.Rows.Count > 0)
                        {
                            dgvTimNha.DataSource = loainha;
                        }
                        else
                        {
                            MessageBox.Show("Không có thông tin bạn muốn tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }                       
                        break;
                    case 1:
                        DataTable dtsd = conn.SelectData($"select * from TimKiemNhaTheoDTSD(N'{timnha}')");
                        if (dtsd.Rows.Count > 0)
                        {
                            dgvTimNha.DataSource = dtsd;
                        }
                        else
                        {
                            MessageBox.Show("Không có thông tin bạn muốn tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    case 2:
                        DataTable dcnha = conn.SelectData($"select * from TimKiemNhaTheoDiaChi(N'{timnha}')");
                        if (dcnha.Rows.Count > 0)
                        {
                            dgvTimNha.DataSource = dcnha;
                        }
                        else
                        {
                            MessageBox.Show("Không có thông tin bạn muốn tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                }
            }
            
        }

        private void fTimKiem_Load(object sender, EventArgs e)
        {
            AddDataComboBox1();
            AddDataComboBox2();
        }

        private void cbTim1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTim1.SelectedIndex)
            {
                case 0:
                    cbTim1_1.Items.Clear();
                    cbTim1_1.Items.Add("Cấp 4");
                    cbTim1_1.Items.Add("2 tầng");
                    cbTim1_1.Items.Add("3 tầng");
                    cbTim1_1.Items.Add("Phòng trọ");
                    cbTim1_1.Items.Add("Chung cư mini");
                    break;
                case 1:
                    cbTim1_1.Items.Clear();
                    cbTim1_1.Items.Add("Sinh viên");
                    cbTim1_1.Items.Add("Người lao động");
                    cbTim1_1.Items.Add("Hộ gia đình");
                    cbTim1_1.Items.Add("Nhân viên văn phòng");
                    cbTim1_1.Items.Add("Học sinh");
                    break;
                case 2:
                    cbTim1_1.Items.Clear();
                    cbTim1_1.Items.Add("Ba Đình");
                    cbTim1_1.Items.Add("Bắc Từ Liêm");
                    cbTim1_1.Items.Add("Cầu Giấy");
                    cbTim1_1.Items.Add("Đống Đa");
                    cbTim1_1.Items.Add("Hà Đông");
                    cbTim1_1.Items.Add("Thanh Xuân");
                    cbTim1_1.Items.Add("Hai Bà Trưng");
                    cbTim1_1.Items.Add("Hoàn Kiếm");
                    cbTim1_1.Items.Add("Nam Từ Liêm");
                    cbTim1_1.Items.Add("Hoàng Mai");
                    cbTim1_1.Items.Add("Long Biên");
                    cbTim1_1.Items.Add("");
                    cbTim1_1.Items.Add("");
                    cbTim1_1.Items.Add("");
                    cbTim1_1.Items.Add("");
                    cbTim1_1.Items.Add("");
                    cbTim1_1.Items.Add("");
                    cbTim1_1.Items.Add("");
                    cbTim1_1.Items.Add("");
                    cbTim1_1.Items.Add("");
                    cbTim1_1.Items.Add("");
                    cbTim1_1.Items.Add("");
                    cbTim1_1.Items.Add("");
                    break;
            }
        }

        private void btnTimKhach_Click(object sender, EventArgs e)
        {
            if (CheckTimKhach())
            {
                string timkhach = txtTim2.Text.Trim();
                switch (cbTim2.SelectedIndex)
                {
                    case 0:
                        DataTable ten = conn.SelectData($"select * from TimKiemKhachHangTheoTen(N'{timkhach}%')");
                        if (ten.Rows.Count > 0)
                        {
                            dgvTimKhach.DataSource = ten;
                            
                        }
                        else
                        {
                            MessageBox.Show("Không có thông tin bạn muốn tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        txtTim2.Clear();
                        break;
                    case 1:
                        DataTable dckhach = conn.SelectData($"select * from TimKiemKhachHangTheoDiaChi(N'{timkhach}')");
                        if (dckhach.Rows.Count > 0)
                        {
                            dgvTimKhach.DataSource = dckhach;
                            
                        }
                        else
                        {
                            MessageBox.Show("Không có thông tin bạn muốn tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        txtTim2.Clear();
                        break;
                    case 2:
                        DataTable nghe = conn.SelectData($"select * from TimKiemKhachHangTheoNgheNghiep(N'{timkhach}')");
                        if (nghe.Rows.Count > 0)
                        {
                            dgvTimKhach.DataSource = nghe;                            
                        }
                        else
                        {
                            MessageBox.Show("Không có thông tin bạn muốn tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        txtTim2.Clear();
                        break;
                }
            }

        }

        #endregion

    }
}
