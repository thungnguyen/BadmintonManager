using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BadmintonManager.DAL
{
    public class NhapHangDAL
    {
        // Thêm phiếu nhập hàng
        public int InsertNhapHang(NhapHangDTO nhapHang)
        {
            string query = "INSERT INTO NhapHang (NgayNhap, TongSoLuong, GhiChu) OUTPUT INSERTED.MaNhapHang " +
                           "VALUES (@NgayNhap, @TongSoLuong, @GhiChu)";
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NgayNhap", nhapHang.NgayNhap);
                        command.Parameters.AddWithValue("@TongSoLuong", nhapHang.TongSoLuong ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@GhiChu", nhapHang.GhiChu ?? (object)DBNull.Value);

                        // Trả về MaNhapHang vừa thêm
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm phiếu nhập hàng: " + ex.Message);
            }
        }

        // Lấy danh sách tất cả phiếu nhập hàng
        public List<NhapHangDTO> GetNhapHang()
        {
            List<NhapHangDTO> nhapHangs = new List<NhapHangDTO>();
            string query = "SELECT * FROM NhapHang";
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            NhapHangDTO nhapHang = new NhapHangDTO
                            {
                                MaNhapHang = reader.GetInt32(0),
                                NgayNhap = reader.GetDateTime(1),
                                TongSoLuong = reader["TongSoLuong"] != DBNull.Value ? (int?)reader.GetInt32(2) : null,
                                GhiChu = reader["GhiChu"]?.ToString()
                            };
                            nhapHangs.Add(nhapHang);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách phiếu nhập hàng: " + ex.Message);
            }
            return nhapHangs;
        }

        // Lấy phiếu nhập hàng theo ID
        public NhapHangDTO GetById(int id)
        {
            string query = "SELECT * FROM NhapHang WHERE MaNhapHang = @MaNhapHang";
            try
            {
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaNhapHang", id);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            return new NhapHangDTO
                            {
                                MaNhapHang = Convert.ToInt32(reader["MaNhapHang"]),
                                NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                                TongSoLuong = reader["TongSoLuong"] != DBNull.Value ? Convert.ToInt32(reader["TongSoLuong"]) : (int?)null,
                                GhiChu = reader["GhiChu"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy phiếu nhập hàng theo ID: " + ex.Message);
            }
            return null; // Không tìm thấy phiếu nhập hàng
        }
    }
}
