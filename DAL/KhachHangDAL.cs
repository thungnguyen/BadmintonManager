using System;
using System.Data.SqlClient;
using QuanLySan.DTO;

namespace QuanLySan.DAL
{
    public class KhachHangDAL
    {
        private string connectionString = "Data Source=your_server;Initial Catalog=QuanLySan;Integrated Security=True";

        public int ThemKhachHang(KhachHangDTO khachHang)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO KhachHang (TenKH, SDT) OUTPUT INSERTED.MaKH VALUES (@TenKH, @SDT)";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@TenKH", khachHang.TenKH);
                    cmd.Parameters.AddWithValue("@SDT", khachHang.SDT);

                    // Thực thi câu lệnh và trả về MaKH mới
                    int maKH = (int)cmd.ExecuteScalar();
                    return maKH;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return -1; // Trả về mã lỗi
                }
            }
        }
    }
}
