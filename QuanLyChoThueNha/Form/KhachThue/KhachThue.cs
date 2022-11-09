using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueNha
{
    internal class KhachThue
    {
        private string tenKhach;
        private string ngaySinh;
        private string sdt;
        private string gioiTinh;
        private string soCMND;
        private string diaChi;
        private string tenNghe;

        public KhachThue(string tenKhach, string ngaySinh, string sdt, string gioiTinh, string soCMND, string diaChi, string tenNghe)
        {
            this.tenKhach = tenKhach;
            this.ngaySinh = ngaySinh;
            this.sdt = sdt;
            this.gioiTinh = gioiTinh;
            this.soCMND = soCMND;
            this.diaChi = diaChi;
            this.tenNghe = tenNghe;
        }

        public string TenKhach { get => tenKhach; set => tenKhach = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string SDT { get => sdt; set => sdt = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string SoCMND { get => soCMND; set => soCMND = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string TenNghe { get => tenNghe; set => tenNghe = value; }
    }
}
