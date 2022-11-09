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
        public fThueNha(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void fThueNha_Load(object sender, EventArgs e)
        {
            con = new ConnectSQL();
            txtMaNha.Text = id.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text.Trim().Length > 0)
            {
                string tenKT = txtTim.Text.Trim();
                string query = $"select makhach, TenKhach, GioiTinh, SoDienThoai, SoCMND, DiaChiThuongTru from KhachThue where TenKhach like N'{tenKT}%'";
                SqlDataReader read = con.ExecuteRead(query);
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = read["MaKhach"].ToString();
                    item.SubItems.Add(read["TenKhach"].ToString());
                    item.SubItems.Add(read["GioiTinh"].ToString());
                    item.SubItems.Add(read["SoDienThoai"].ToString());
                    item.SubItems.Add(read["SoCMND"].ToString());
                    item.SubItems.Add(read["DiaChiThuongTru"].ToString());
                    listView.Items.Add(item);
                }
            } else
            {
                MessageBox.Show("Vui lòng nhập thông tin để tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            if (listView.SelectedItems.Count > 0)
            {
                item = listView.SelectedItems[0];
                txtMaKhach.Text = item.Text;
            }
        }
    }
}
