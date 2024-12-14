using System;
using System.Data.SqlClient;
using BadmintonManager.DTO;

namespace BadmintonManager.DAL
{
    public class TaiKhoanNhanVienDAL
    {

        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;
        private readonly TaiKhoanNhanVienDTO tknv;
        public TaiKhoanNhanVienDAL() { 
            tknv = new TaiKhoanNhanVienDTO();
        }
        public TaiKhoanNhanVienDTO DangNhap(string tenDangNhap, string matKhau)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT * FROM TaiKhoanNhanVien WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", matKhau);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new TaiKhoanNhanVienDTO
                        {
                            MaNV = Convert.ToInt32(reader["MaNV"]),
                            TenNV = reader["TenNV"].ToString(),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            VaiTro = reader["VaiTro"].ToString(),
                            SDT = reader["SDT"].ToString(),
                        };
                    }
                }
            }

            return null; // Trả về null nếu thông tin đăng nhập không đúng
        }

         public bool ThemTaiKhoan(TaiKhoanNhanVienDTO taiKhoan)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO TaiKhoanNhanVien (TenNV, TenDangNhap, MatKhau, VaiTro, SDT) 
                                 VALUES (@TenNV, @TenDangNhap, @MatKhau, @VaiTro, @SDT)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenNV", taiKhoan.TenNV);
                    command.Parameters.AddWithValue("@TenDangNhap", taiKhoan.TenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);
                    command.Parameters.AddWithValue("@VaiTro", taiKhoan.VaiTro ?? "1");
                    command.Parameters.AddWithValue("@SDT", taiKhoan.SDT);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public int LayMaNV(string tenDangNhap, string matKhau)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT MaNV FROM TaiKhoanNhanVien WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", matKhau);

                    object result = command.ExecuteScalar();

                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }
    }
}
