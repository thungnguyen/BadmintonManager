using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BadmintonManager.Database
{
    public class TaiKhoanNhanVien
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayBatDau { get; set; }

        // Chuỗi kết nối đến cơ sở dữ liệu
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

        // Phương thức kiểm tra thông tin đăng nhập
        public TaiKhoanNhanVien DangNhap(string tenDangNhap, string matKhau)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT * FROM TaiKhoanNhanVien 
                                 WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", matKhau);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Tạo đối tượng TaiKhoanNhanVien từ dữ liệu truy vấn
                        TaiKhoanNhanVien taiKhoan = new TaiKhoanNhanVien
                        {
                            MaNV = Convert.ToInt32(reader["MaNV"]),
                            TenNV = reader["TenNV"].ToString(),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            VaiTro = reader["VaiTro"].ToString(),
                            SDT = reader["SDT"].ToString(),
                            Email = reader["Email"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            NgayBatDau = Convert.ToDateTime(reader["NgayBatDau"])
                        };

                        return taiKhoan; // Trả về đối tượng nếu thông tin đúng
                    }
                }
            }

            return null; // Trả về null nếu thông tin đăng nhập không đúng
        }

        public int LayMaNV(string tenDangNhap, string matKhau)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT MaNV FROM TaiKhoanNhanVien 
                         WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", matKhau);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result); // Trả về MaNV nếu có dữ liệu
                    }
                }
            }

            return -1; // Trả về -1 nếu không tìm thấy tài khoản
        }
    }
}
