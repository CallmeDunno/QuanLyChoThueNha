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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnExitLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();
            //Thuan'note
            if(user.Equals("admin") && pass.Equals("admin"))
            {
                txtUsername.Clear();
                txtPassword.Clear();
                fMain fMain = new fMain();
                this.Hide();
                fMain.ShowDialog();
                this.Show();
            } else
            {
                txtUsername.Clear();
                txtPassword.Clear();
                MessageBox.Show("Đăng nhập không thành công! Vui lòng nhập lại Tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
            }
            
            
            
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals(""))
            {
                lbWarning1.Visible = true;
            } else
            {
                lbWarning1.Visible = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(""))
            {
                lbWarning2.Visible = true;
            }
            else
            {
                lbWarning2.Visible = false;
            }
        }
    }
}
