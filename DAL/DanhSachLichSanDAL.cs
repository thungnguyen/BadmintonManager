using System;
using System.Data;
using System.Data.SqlClient;

namespace BadmintonManager.DAL
{
    public class DanhSachLichSanDAL
    {
        private string connectionString = "Data Source=LAPTOP-JDM8N7NE;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False";

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
    }

    public class DanhSachPhieuChiDAL
    {
        private string connectionString = "Data Source=LAPTOP-JDM8N7NE;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False";

        public bool HuyPhieuChi(int maPhieuChi)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Đảm bảo kết nối mở
                    string query = "DELETE FROM PhieuChi WHERE MaPhieuChi = @MaPhieuChi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPhieuChi", maPhieuChi);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                // Xử lý lỗi SQL
                Console.WriteLine("Lỗi SQL khi hủy phiếu chi: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                // Bắt lỗi chung
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
    }
}
