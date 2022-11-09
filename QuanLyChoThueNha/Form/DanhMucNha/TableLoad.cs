using QuanLyChoThueNha.SQLConn;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueNha
{
    internal class TableLoad
    {
        private ConnectSQL con;

        public TableLoad()
        {
            con = new ConnectSQL();
        }

        public List<ThongTinNha> LoadThongTinNha()
        {
            List<ThongTinNha> list = new List<ThongTinNha>();
            DataTable dataTable = con.SelectData("exec DuaRaTrangThaiNha");

            foreach(DataRow dr in dataTable.Rows)
            {
                ThongTinNha thongTinNha = new ThongTinNha(dr);
                list.Add(thongTinNha);
            }

            return list;
        }
    }
}
