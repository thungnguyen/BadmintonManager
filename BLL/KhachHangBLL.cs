using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

public class KhachHangBLL
{
    private string connectionString = ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

    // Phương thức lấy tên khách hàng từ MaKH
    public string GetTenKhachHangById(int maKH)
    {
        string tenKH = string.Empty;

        string query = "SELECT TenKH FROM KhachHang WHERE MaKH = @MaKH";

        try
        {
            // Sử dụng SqlConnection để kết nối đến cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Mở kết nối đến cơ sở dữ liệu

                // Sử dụng SqlCommand để thực thi câu lệnh truy vấn
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Thêm tham số MaKH vào câu lệnh truy vấn
                    cmd.Parameters.AddWithValue("@MaKH", maKH);

                    // Thực thi truy vấn và lấy kết quả
                    using (SqlDataReader reader = cmd.ExecuteReader())  // Đảm bảo SqlDataReader được sử dụng đúng cách
                    {
                        if (reader.Read())  // Kiểm tra xem có dữ liệu trả về không
                        {
                            tenKH = reader["TenKH"].ToString();  // Lấy giá trị tên khách hàng
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Xử lý lỗi khi có sự cố kết nối hoặc truy vấn
            MessageBox.Show("Lỗi khi truy vấn dữ liệu khách hàng: " + ex.Message);
        }

        return tenKH;  // Trả về tên khách hàng, nếu không tìm thấy sẽ trả về chuỗi rỗng
    }
}
