using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueNha
{
    internal class ThongTinNha
    {
        private int maNha;
        private string tenChuNha;
        private string soDienThoai;
        private string diaChi;
        private string giaPhong;
        private string tienDien;
        private string tienNuoc;
        private string tinhTrangThue;
        private string tenLoai;
        private string dTSD;
        private string anhMinhHoa;

        public ThongTinNha(DataRow row)
        {
            this.MaNha = (int)row["MaNha"];
            this.TenChuNha = row["TenChuNha"].ToString();
            this.SoDienThoai = row["SoDienThoai"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.GiaPhong = row["GiaPhong"].ToString();
            this.TienDien = row["TienDien"].ToString();
            this.TienNuoc = row["TienNuoc"].ToString();
            this.TinhTrangThue = row["TinhTrangThue"].ToString();
            this.TenLoai = row["TenLoai"].ToString();
            this.DTSD = row["TenDTSD"].ToString();
            this.AnhMinhHoa = row["AnhMinhHoa"].ToString();
        }

        public ThongTinNha(int maNha, string tenChuNha, string soDienThoai, string diaChi, string giaPhong, string tienDien, string tienNuoc, string tinhTrangThue, string tenLoai, string dTSD, string anhMinhHoa)
        {
            this.MaNha = maNha;
            this.TenChuNha = tenChuNha;
            this.SoDienThoai = soDienThoai;
            this.DiaChi = diaChi;
            this.GiaPhong = giaPhong;
            this.TienDien = tienDien;
            this.TienNuoc = tienNuoc;
            this.TinhTrangThue = tinhTrangThue;
            this.TenLoai = tenLoai;
            this.DTSD = dTSD;
            this.AnhMinhHoa = anhMinhHoa;
        }

        public int MaNha { get => maNha; set => maNha = value; }
        public string TenChuNha { get => tenChuNha; set => tenChuNha = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string GiaPhong { get => giaPhong; set => giaPhong = value; }
        public string TienDien { get => tienDien; set => tienDien = value; }
        public string TienNuoc { get => tienNuoc; set => tienNuoc = value; }
        public string TinhTrangThue { get => tinhTrangThue; set => tinhTrangThue = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
        public string DTSD { get => dTSD; set => dTSD = value; }
        public string AnhMinhHoa { get => anhMinhHoa; set => anhMinhHoa = value; }
    }
}
