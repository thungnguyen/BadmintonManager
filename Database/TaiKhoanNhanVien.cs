using System;
using System.Data.SqlClient;


namespace BadmintonManager.Database
{
    // up code
    public class TaiKhoanNhanVien
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public string SDT { get; set; }

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

        // Kiểm tra tài khoản đã tồn tại
        public bool KiemTraTaiKhoanTonTai(string tenDangNhap)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM TaiKhoanNhanVien WHERE TenDangNhap = @TenDangNhap";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0; // Trả về true nếu đã tồn tại
                }
            }
        }

        // Thêm tài khoản mới
        public bool ThemTaiKhoan(TaiKhoanNhanVien taiKhoan)
        {
            if (KiemTraTaiKhoanTonTai(taiKhoan.TenDangNhap))
            {
                throw new Exception("Tên đăng nhập đã tồn tại.");
            }

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
                    command.Parameters.AddWithValue("@VaiTro", taiKhoan.VaiTro ?? "Nhân viên");
                    command.Parameters.AddWithValue("@SDT", taiKhoan.SDT);

                    int result = command.ExecuteNonQuery();
                    return result > 0; // Trả về true nếu thêm thành công
                }
            }
        }

    }
}
