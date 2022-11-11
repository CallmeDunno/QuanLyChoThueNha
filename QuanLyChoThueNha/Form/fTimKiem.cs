using QuanLyChoThueNha.SQLConn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
                            dgvTimNha.DataSource = null;
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
                            dgvTimNha.DataSource = null;
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
                            dgvTimNha.DataSource = null;
                            MessageBox.Show("Không có thông tin bạn muốn tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                }
                if (dgvTimNha.Rows.Count > 0)
                {
                    btnExcelNha.Enabled = true;
                } else
                {
                    btnExcelNha.Enabled = false;
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
                    DataTable dataTable = conn.SelectData("select TenLoai from LoaiNha");
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        cbTim1_1.Items.Add(dataTable.Rows[i]["TenLoai"].ToString());
                    }
                    break;
                case 1:
                    cbTim1_1.Items.Clear();
                    DataTable dataTable1 = conn.SelectData("select TenDTSD from DoiTuongSuDung");
                    for (int i = 0; i < dataTable1.Rows.Count; i++)
                    {
                        cbTim1_1.Items.Add(dataTable1.Rows[i]["TenDTSD"].ToString());
                    }
                    break;
                case 2:
                    cbTim1_1.Items.Clear();
                    DataTable dataTable2 = conn.SelectData("select DiaChi from DanhMucNha");
                    for (int i = 0; i < dataTable2.Rows.Count; i++)
                    {
                        cbTim1_1.Items.Add(dataTable2.Rows[i]["DiaChi"].ToString());
                    }
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
                            dgvTimKhach.DataSource = null;
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
                            dgvTimKhach.DataSource = null;
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
                            dgvTimKhach.DataSource = null;
                            MessageBox.Show("Không có thông tin bạn muốn tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        txtTim2.Clear();
                        break;
                }
                if (dgvTimKhach.Rows.Count > 0)
                {
                    btnExcelKH.Enabled = true;
                } else
                {
                    btnExcelKH.Enabled = false;
                }
            }

        }

        private void btnExcelKH_Click(object sender, EventArgs e)
        {
            string titleExcel = "Danh sách " + cbTim2.Text + ": " + txtTim2.Text;
            ExportExcel ee = new ExportExcel();
            ee.ExportFileExcel(dgvTimNha, titleExcel);
        }

        private void btnExcelNha_Click(object sender, EventArgs e)
        {
            string titleExcel = "Danh sách " + cbTim1.Text + ": " + cbTim1_1.Text;
            ExportExcel ee = new ExportExcel();
            ee.ExportFileExcel(dgvTimNha, titleExcel);
        }

        #endregion
    }
}
