using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DAL
{
    public class LichDatSanDAL
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

        public int GetMaSan(string tenSan)
        {
            // SQL query to get MaSan based on the name of the court
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT MaSan FROM San WHERE TenSan = @TenSan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenSan", tenSan);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int GetMaKH(string tenKH)
        {
            // SQL query to get MaKH based on the name of the customer
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT MaKH FROM KhachHang WHERE TenKH = @TenKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenKH", tenKH);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Method to get MaGia from the database
        public int LayMaGia(string loaiKhach, TimeSpan gioBatDau)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT TOP 1 MaGia 
                FROM BangGiaSan 
                WHERE LoaiKH = @LoaiKhach 
                AND GioBatDau <= @GioBatDau 
                AND GioKetThuc > @GioBatDau
                ORDER BY GioBatDau";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LoaiKhach", loaiKhach);
                        cmd.Parameters.AddWithValue("@GioBatDau", gioBatDau);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            return 0; // Not found
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy mã giá: " + ex.Message);
            }
        }

        // Lấy thông tin lịch đặt sân từ cơ sở dữ liệu
        public List<LichDatSanDTO> GetLichDatSanByMaSan(string maSan, List<DateTime> cacNgayDat)
        {
            List<LichDatSanDTO> lichDatSanList = new List<LichDatSanDTO>();
            string connectionString = ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Xây dựng chuỗi danh sách ngày để sử dụng trong câu truy vấn
                string danhSachNgay = string.Join(",", cacNgayDat.Select(d => $"'{d:yyyy-MM-dd}'"));

                string query = $@"
                    SELECT cts.Ngay, cts.TuGio, cts.DenGio
                    FROM ChiTietLichDatSan cts
                    JOIN LichDatSan lds ON cts.MaDatSan = lds.MaDatSan
                    WHERE lds.MaSan = @MaSan AND cts.Ngay IN ({danhSachNgay})";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaSan", maSan);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LichDatSanDTO lichDatSan = new LichDatSanDTO
                            {
                                NgayDat = new List<DateTime> { reader.GetDateTime(0) },
                                TuGio = reader.GetTimeSpan(1),
                                DenGio = reader.GetTimeSpan(2)
                            };
                            lichDatSanList.Add(lichDatSan);
                        }
                    }
                }
            }

            return lichDatSanList;
        }

        public int InsertLichDatSan(LichDatSanDTO dto)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string insertLichDatSan = @"
                INSERT INTO LichDatSan (MaSan, MaKH, MaGia, TuNgay, DenNgay, TuGio, DenGio, LoaiKH, SoBuoi, LayGia, CanThanhToan, DaTra, ConLai, ThoiGian)
                OUTPUT INSERTED.MaDatSan
                VALUES (@MaSan, @MaKH, @MaGia, @TuNgay, @DenNgay, @TuGio, @DenGio, @LoaiKH, @SoBuoi, @LayGia, @CanThanhToan, @DaTra, @ConLai, @ThoiGian)";
                SqlCommand cmd = new SqlCommand(insertLichDatSan, conn);
                cmd.Parameters.AddWithValue("@MaSan", dto.MaSan);
                cmd.Parameters.AddWithValue("@MaKH", dto.MaKH);
                cmd.Parameters.AddWithValue("@MaGia", dto.MaGia);
                cmd.Parameters.AddWithValue("@TuNgay", dto.TuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", dto.DenNgay);
                cmd.Parameters.AddWithValue("@TuGio", dto.TuGio);
                cmd.Parameters.AddWithValue("@DenGio", dto.DenGio);
                cmd.Parameters.AddWithValue("@LoaiKH", dto.LoaiKH);
                cmd.Parameters.AddWithValue("@SoBuoi", dto.SoBuoi);
                cmd.Parameters.AddWithValue("@LayGia", dto.LayGia);
                cmd.Parameters.AddWithValue("@CanThanhToan", dto.CanThanhToan);
                cmd.Parameters.AddWithValue("@DaTra", dto.DaTra);
                cmd.Parameters.AddWithValue("@ConLai", dto.ConLai);
                cmd.Parameters.AddWithValue("@ThoiGian", dto.ThoiGian);
                return (int)cmd.ExecuteScalar();
            }
        }

        // Phương thức kiểm tra lịch trùng
        public bool CheckTrungLich(LichDatSanDTO lichDatSan)
        {
            bool isTrungLich = false;

            // Kết nối cơ sở dữ liệu
            string connectionString = ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT Ngay, TuGio, DenGio 
                FROM ChiTietLichDatSan 
                WHERE MaSan = @MaSan AND Ngay = @Ngay";

                foreach (DateTime ngay in lichDatSan.NgayDat)
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSan", lichDatSan.MaSan);
                        cmd.Parameters.AddWithValue("@Ngay", ngay);

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            DateTime ngayDb = reader.GetDateTime(0);
                            TimeSpan tuGioDb = reader.GetTimeSpan(1);
                            TimeSpan denGioDb = reader.GetTimeSpan(2);

                            // Kiểm tra trùng lịch
                            if ((lichDatSan.TuGio >= tuGioDb && lichDatSan.TuGio < denGioDb) || (lichDatSan.DenGio > tuGioDb && lichDatSan.DenGio <= denGioDb))
                            {
                                isTrungLich = true;
                                break;
                            }
                        }
                        reader.Close();
                    }

                    if (isTrungLich)
                    {
                        break;
                    }
                }
            }

            return isTrungLich;
        }

        public void InsertChiTietLichDatSan(int maDatSan, List<DateTime> ngayDat, TimeSpan tuGio, TimeSpan denGio)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string insertChiTiet = @"
                INSERT INTO ChiTietLichDatSan (MaDatSan, Ngay, TuGio, DenGio)
                VALUES (@MaDatSan, @Ngay, @TuGio, @DenGio)";
                SqlCommand cmd = new SqlCommand(insertChiTiet, conn);

                foreach (var ngay in ngayDat)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MaDatSan", maDatSan);
                    cmd.Parameters.AddWithValue("@Ngay", ngay);
                    cmd.Parameters.AddWithValue("@TuGio", tuGio);
                    cmd.Parameters.AddWithValue("@DenGio", denGio);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
