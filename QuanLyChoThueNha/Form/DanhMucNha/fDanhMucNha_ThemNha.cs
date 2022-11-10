using Microsoft.VisualBasic;
using QuanLyChoThueNha.Properties;
using QuanLyChoThueNha.SQLConn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChoThueNha
{
    public partial class fDanhMucNha_ThemNha : Form
    {
        private ConnectSQL con; 

        public fDanhMucNha_ThemNha()
        {
            InitializeComponent();
        }

        #region Function

        private int LoadSauKhiNhapID()
        {
            try
            {
                int id = int.Parse(Interaction.InputBox("Nhập mã nhà mà bạn muốn sửa:\n(Mã nhà là số tự nhiên bắt đầu từ 1)", "Nhập mã nhà").Trim());
                string query = $"select * from DuaRaThongTinNha('{id}')";
                DataTable dt = con.SelectData(query);
                if (dt.Rows.Count > 0)
                {
                    ThongTinNha thongTinNha = new ThongTinNha(dt.Rows[0]);
                    txtTenChuNha.Text = thongTinNha.TenChuNha;
                    txtSDT.Text = thongTinNha.SoDienThoai;
                    txtDiaChi.Text = thongTinNha.DiaChi;
                    txtGiaPhong.Text = thongTinNha.GiaPhong;
                    txtTienDien.Text = thongTinNha.TienDien;
                    txtTienNuoc.Text = thongTinNha.TienNuoc;
                    cbTT.Text = thongTinNha.TinhTrangThue;
                    cbLoaiNha.Text = thongTinNha.TenLoai;
                    cbDTSD.Text = thongTinNha.DTSD;
                    pic.Image = Image.FromFile(thongTinNha.AnhMinhHoa);
                    lbURL.Text = thongTinNha.AnhMinhHoa.ToString();
                    return id;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhà mà bạn muốn. Vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Bạn đã để trống hoặc nhập sai định dạng mã nhà. Vui lòng thử lại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return -1;
        }

        private void StateButton(bool b)
        {
            btnThem.Enabled = b;
            btnXoa.Enabled = b;
            btnSua.Enabled = b;
            btnLuu.Enabled = !b;
            btnHuy.Enabled = !b;
        }

        private void StateInput(bool b)
        {
            txtTenChuNha.Enabled = b;
            txtSDT.Enabled = b;
            txtDiaChi.Enabled = b;
            txtGiaPhong.Enabled = b;
            txtTienDien.Enabled = b;
            txtTienNuoc.Enabled = b;
            cbTT.Enabled = b;
            cbLoaiNha.Enabled = b;
            cbDTSD.Enabled = b;
            pic.Enabled = b;
        }

        private bool CheckInput()
        {
            if (txtTenChuNha.Text.Trim().Length == 0)
            {
                return false;
            }
            if (!Regex.IsMatch(txtSDT.Text.Trim(), "[0-9]{10}"))
            {
                return false;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                return false;
            }
            if (txtGiaPhong.Text.Trim().Length == 0)
            {
                return false;
            }
            if (txtTienDien.Text.Trim().Length == 0)
            {
                return false;
            }
            if (txtTienNuoc.Text.Trim().Length == 0)
            {
                return false;
            }
            if (cbTT.SelectedIndex == -1)
            {
                return false;
            }
            if (cbLoaiNha.SelectedIndex == -1)
            {
                return false;
            }
            if (cbDTSD.SelectedIndex == -1)
            {
                return false;
            }
            if (lbURL.Text.Trim().Length == 0)
            {
                return false;
            }
            return true;
        }

        private void ClearInput()
        {
            txtTenChuNha.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtGiaPhong.Clear();
            txtTienDien.Clear();
            txtTienNuoc.Clear();
            cbTT.SelectedIndex = -1;
            cbDTSD.SelectedIndex = -1;
            cbLoaiNha.SelectedIndex = -1;
            lbURL.Text = null;
            txtTenChuNha.Focus();
            pic.Image = Resources.C_;
        }

        #endregion

        #region Event

        private void btnThem_Click(object sender, EventArgs e)
        {
            StateButton(false);
            StateInput(true);
            btnThem.Enabled = true;
        }

        private void fDanhMucNha_ThemNha_Load(object sender, EventArgs e)
        {
            con = new ConnectSQL();
            StateButton(true);
            StateInput(false);
            cbTT.Items.Add("Đã thuê");
            cbTT.Items.Add("Chưa thuê");

            cbLoaiNha.Items.Add("Cấp 4");
            cbLoaiNha.Items.Add("2 tầng");
            cbLoaiNha.Items.Add("3 tầng");
            cbLoaiNha.Items.Add("Phòng trọ");
            cbLoaiNha.Items.Add("Chung cư mini");

            cbDTSD.Items.Add("Sinh viên");
            cbDTSD.Items.Add("Người lao động");
            cbDTSD.Items.Add("Văn phòng");
        }

        private void pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PNG (*.png)|*.png|JPG (*.jpg)|*.jpg";
            openFile.Title = "Select image";
            openFile.FilterIndex = 2;
            openFile.InitialDirectory = "D:\\";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                lbURL.Text = openFile.FileName.ToString();
                pic.Image = Image.FromFile(openFile.FileName);
            }
        }

        private void txtGiaPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTienDien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTienNuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            StateInput(true);
            int id = LoadSauKhiNhapID();
            StateButton(false);
            btnSua.Enabled = true;
            if (id > 0)
            {
                btnLuu.Enabled = true;
                btnSua.Tag = id;
            } else
            {
                btnLuu.Enabled = false;
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            StateInput(false);
            int id = LoadSauKhiNhapID();
            StateButton(false);
            btnXoa.Enabled = true;
            if (id > 0)
            {
                btnLuu.Enabled = true;
                btnXoa.Tag = id;
            }
            else
            {
                btnLuu.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled)
            {
                if (CheckInput())
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn thêm nhà không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string strTenChuNha = txtTenChuNha.Text;
                        string strSDT = txtSDT.Text;
                        string strDC = txtDiaChi.Text;
                        string strGiaPhong = txtGiaPhong.Text;
                        string strTienDien = txtTienDien.Text;
                        string strTienNuoc = txtTienNuoc.Text;
                        string strTTT = cbTT.Text;
                        string strLoaiNha = cbLoaiNha.Text;
                        string strMaLN = (string)con.ExecuteScalar($"select maloai from loainha where tenloai = N'{strLoaiNha}'");
                        string strDTSD = cbDTSD.Text;
                        string strMaDTSD = (string)con.ExecuteScalar($"select madtsd from doituongsudung where tendtsd = N'{strDTSD}'");
                        string strURL = lbURL.Text.ToString();

                        string query = $"insert into DanhMucNha(TenChuNha, SoDienThoai, DiaChi, GiaPhong, TienDien," +
                            $" TienNuoc, TinhTrangThue, AnhMinhHoa, MaLoai, MaDTSD) values " +
                            $"(N'{strTenChuNha}', '{strSDT}', N'{strDC}', {strGiaPhong}, {strTienDien}, {strTienNuoc}," +
                            $" N'{strTTT}', '{strURL}', '{strMaLN}', '{strMaDTSD}')";
                        try
                        {
                            con.ExecuteIUDQuery(query);
                        } catch
                        {
                            MessageBox.Show("Error");
                        }
                        
                        MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInput();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn đã nhập thiếu thông tin hoặc sai định" +
                        " dạng thông tin hoặc chưa chọn ảnh, vui lòng nhập lại!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (btnXoa.Enabled)
            {
                int id = (int)btnXoa.Tag;
                if (MessageBox.Show("Bạn có thực sự muốn xóa thông tin nhà số "+id+" không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    

                    string query = $"delete from Danhmucnha where manha = {id}";

                    try
                    {
                        con.ExecuteIUDQuery(query);
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    }
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                }
            }
            if (btnSua.Enabled)
            {
                if(MessageBox.Show("Bạn có thực sự muốn sửa thông tin nhà không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strTenChuNha = txtTenChuNha.Text;
                    string strSDT = txtSDT.Text;
                    string strDC = txtDiaChi.Text;
                    string strGiaPhong = txtGiaPhong.Text;
                    string strTienDien = txtTienDien.Text;
                    string strTienNuoc = txtTienNuoc.Text;
                    string strTTT = cbTT.Text;
                    string strLoaiNha = cbLoaiNha.Text;
                    string strDTSD = cbDTSD.Text;
                    string strURL = lbURL.Text.ToString();

                    int id = (int)btnSua.Tag;

                    string maloai = (string)con.ExecuteScalar($"select MaLoai from LoaiNha where TenLoai = N'{strLoaiNha}'");
                    string madtsd = (string)con.ExecuteScalar($"select MaDTSD from DoiTuongSuDung where TenDTSD = N'{strDTSD}'");

                    string query = $"update DanhMucNha set TenChuNha = N'{strTenChuNha}', SoDienThoai = '{strSDT}', DiaChi = N'{strDC}'," +
                        $"GiaPhong = {strGiaPhong}, TienDien = {strTienDien}, TienNuoc = {strTienNuoc}, TinhTrangThue = N'{strTTT}'," +
                        $" AnhMinhHoa = '{strURL}', MaLoai = N'{maloai}', MaDTSD = N'{madtsd}'" +
                        $"where MaNha = {id}";
                    try
                    {
                        con.ExecuteIUDQuery(query);
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    }
                    MessageBox.Show("Sửa thông tin phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearInput();
            StateButton(true);
            StateInput(false);
        }

        #endregion


    }


}
