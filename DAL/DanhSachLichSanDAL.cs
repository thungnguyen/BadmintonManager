using BadmintonManager.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BadmintonManager.DAL
{
    public class DanhSachLichSanDAL
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

        public DataTable LayDanhSachLichSan()
        {
            string query = "SELECT * FROM LichDatSan";
            DataTable dataTable = new DataTable();
            try
            {
                // Mở kết nối với SQL Server
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Đảm bảo kết nối được mở

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    // Điền dữ liệu vào DataTable
                    adapter.Fill(dataTable);
                }
            }
            catch (SqlException ex)
            {
                // Bắt lỗi SQL, có thể kết nối bị lỗi hoặc câu lệnh không hợp lệ
                Console.WriteLine("Lỗi SQL: " + ex.Message);
                // Bạn có thể hiển thị thông báo lỗi ở đây nếu cần
            }
            catch (Exception ex)
            {
                // Bắt tất cả các loại lỗi khác
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return dataTable;
        }

        public bool XoaLichSan(int maDatSan)
        {
            string query = "DELETE FROM LichDatSan WHERE MaDatSan = @MaDatSan";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Đảm bảo kết nối mở
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDatSan", maDatSan);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi và hiển thị thông báo
                Console.WriteLine("Lỗi khi xóa lịch: " + ex.Message);
                return false;
            }
        }

        public DataTable TimKiemLichSan(DateTime tuNgay, DateTime denNgay)
        {
            string query = "SELECT * FROM LichDatSan WHERE TuNgay >= @TuNgay AND TuNgay <= @DenNgay";
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Đảm bảo kết nối mở
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    // Thêm tham số vào câu truy vấn
                    adapter.SelectCommand.Parameters.AddWithValue("@TuNgay", tuNgay);
                    adapter.SelectCommand.Parameters.AddWithValue("@DenNgay", denNgay);

                    // Điền dữ liệu vào DataTable
                    adapter.Fill(dataTable);
                }
            }
            catch (SqlException ex)
            {
                // Bắt lỗi SQL
                Console.WriteLine("Lỗi SQL khi tìm kiếm lịch: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Bắt lỗi chung
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return dataTable;
        }
        public DataTable TimLichSanTheoTenKH(string tenKhachHang)
        {
            DataTable dataTable = new DataTable();

            // Truy vấn cơ sở dữ liệu theo tên khách hàng với phép JOIN
            string query = @"
        SELECT LichDatSan.*, KhachHang.TenKH
        FROM LichDatSan
        INNER JOIN KhachHang ON LichDatSan.MaKH = KhachHang.MaKH
        WHERE KhachHang.TenKH LIKE @TenKH";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();  // Đảm bảo kết nối được mở

                    // Khởi tạo câu lệnh SqlCommand
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số tên khách hàng vào câu lệnh
                        cmd.Parameters.AddWithValue("@TenKH", "%" + tenKhachHang + "%");

                        // Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (SqlException ex)
            {
                // Xử lý lỗi SQL
                Console.WriteLine("Lỗi SQL khi tìm kiếm lịch: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Bắt lỗi chung
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return dataTable;
        }


    }
}
