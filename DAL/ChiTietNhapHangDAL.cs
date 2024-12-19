using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BadmintonManager.DAL
{
    public class ChiTietNhapHangDAL
    {
        // Phương thức Insert vào bảng ChiTietNhapHang
        public void InsertChiTietNhapHang(ChiTietNhapHangDTO chiTietNhapHang)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO ChiTietNhapHang (MaNhapHang, MaHH, SoLuongNhapLon, SoLuongNhapNho) " +
                               "VALUES (@MaNhapHang, @MaHH, @SoLuongNhapLon, @SoLuongNhapNho)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaNhapHang", chiTietNhapHang.MaNhapHang);
                    command.Parameters.AddWithValue("@MaHH", chiTietNhapHang.MaHH);
                    command.Parameters.AddWithValue("@SoLuongNhapLon", chiTietNhapHang.SoLuongNhapLon);
                    command.Parameters.AddWithValue("@SoLuongNhapNho", chiTietNhapHang.SoLuongNhapNho);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ChiTietNhapHangDTO> GetChiTietNhapHang()
        {
            List<ChiTietNhapHangDTO> chiTietNhapHangs = new List<ChiTietNhapHangDTO>();

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM ChiTietNhapHang";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ChiTietNhapHangDTO chiTietNhapHang = new ChiTietNhapHangDTO
                        {
                            MaNhapHang = reader.GetInt32(0),
                            MaHH = reader.GetInt32(1),
                            SoLuongNhapLon = reader.GetInt32(2),
                            SoLuongNhapNho = reader.GetInt32(3)
                        };
                        chiTietNhapHangs.Add(chiTietNhapHang);
                    }
                }
            }

            return chiTietNhapHangs;
        }


        public ChiTietNhapHangDTO GetById(int id)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM ChiTietNhapHang WHERE MaCTNhapHang = @MaCTNhapHang";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaCTNhapHang", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Chuyển dữ liệu từ reader sang DTO
                        ChiTietNhapHangDTO chiTietNhapHang = new ChiTietNhapHangDTO
                        {
                            MaCTNhapHang = Convert.ToInt32(reader["MaCTNhapHang"]),
                            MaNhapHang = Convert.ToInt32(reader["MaNhapHang"]),
                            MaHH = Convert.ToInt32(reader["MaHH"]),
                            SoLuongNhapLon = Convert.ToInt32(reader["SoLuongNhapLon"]),
                            SoLuongNhapNho = Convert.ToInt32(reader["SoLuongNhapNho"])
                        };
                        return chiTietNhapHang;
                    }
                    return null; // Không tìm thấy chi tiết nhập hàng
                }
            }
        }
    }
}
