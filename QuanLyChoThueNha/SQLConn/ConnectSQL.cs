using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyChoThueNha.SQLConn
{
    internal class ConnectSQL
    {
        private string LinkConnectDB = "Data Source=DUNNO\\SQLEXPRESS;Initial Catalog=QLChoThueNha;Integrated Security=True";

        private SqlConnection connect;

        public ConnectSQL()
        {
            connect = new SqlConnection(LinkConnectDB);
        }

        private void OpenDB()
        {
            if (connect.State != System.Data.ConnectionState.Open)
            {
                connect = new SqlConnection(LinkConnectDB);
                connect.Open();
            }
        }

        private void CloseDB()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
            {
                connect.Close();
            }
        }

        public DataTable SelectData(string query) //thuc thi lenh select
        {
            OpenDB();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connect);
            sqlDataAdapter.Fill(dt);
            CloseDB();
            dt.Dispose();
            return dt;
        }

        public void ExecuteIUDQuery(string query) //Thuc thi cac lenh insert, update, delete
        {
            OpenDB();
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.ExecuteNonQuery();
            CloseDB();
        }

        //Khi muốn trả về 1 giá trị duy nhất
        //Ví dụ như: select TienNha from DanhMucNha where MaNha = '1' 
        //Chưa test, ai làm cái phần này nhớ test cho kỹ rồi mới được up lên github
        public object ExecuteScalar(string query) 
        {
            OpenDB();
            SqlCommand cmd = new SqlCommand(query, connect);
            object obj = (object)cmd.ExecuteScalar();
            return obj;
            CloseDB();
        }

        //ExcuteReader, chắc là dùng khi lấy tên khách các thứ ra để làm hợp đồng
        public SqlDataReader ExecuteRead(string query)
        {
            OpenDB();
            SqlCommand cmd = new SqlCommand(query, connect);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
            CloseDB();
        }
    }
}
