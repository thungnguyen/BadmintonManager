using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;


namespace qlycaulong.Database
{

    public class DatabaseHelper
    {
        private string connectionString = "Data Source=LAPTOP-G5HQJSJ2\\SQLEXPRESS;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False";

        public List<KhachHang> GetKhachHangList()
        {
            List<KhachHang> khachHangs = new List<KhachHang>();
            string query = "SELECT MaKH, TenKH, SDT FROM KhachHang";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        KhachHang khachHang = new KhachHang
                        {
                            MaKH = Convert.ToInt32(reader["MaKH"]),
                            TenKH = reader["TenKH"].ToString(),
                            SDT = reader["SDT"].ToString()
                        };
                        khachHangs.Add(khachHang);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }

            return khachHangs;
        }
    }


    public class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
    }

}
