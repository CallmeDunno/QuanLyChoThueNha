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
        private int id; //Mã nhà
        public fDanhMucNha_TaiSan(int id)
        {
            this.Id = id;
            InitializeComponent();
        }

        public int Id { get => id; set => id = value; }


    }
}
