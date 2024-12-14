// SanDAL.cs
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BadmintonManager.DTO;
using System.Configuration;
using System.Windows.Forms;


namespace BadmintonManager.DAL
{
    public class KhachHangDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

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
        public bool AddKhachHang(KhachHang khachHang)
        {
            string query = "INSERT INTO KhachHang (TenKH, SDT) VALUES (@TenKH, @SDT)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenKH", khachHang.TenKH);
                command.Parameters.AddWithValue("@SDT", khachHang.SDT);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
