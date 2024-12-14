using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BadmintonManager.DAL
{
    public class LichSuNhapHangDAL
    {
        private string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

        public void AddLichSuNhapHang(LichSuNhapHangDTO lichSu)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO LichSuNhapHang (MaPhieu, NgayThucHien, MaNhanVien, GhiChu) " +
                               "VALUES (@MaPhieu, @NgayThucHien, @MaNhanVien, @GhiChu)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieu", lichSu.MaPhieu);
                cmd.Parameters.AddWithValue("@NgayThucHien", lichSu.NgayThucHien);
                cmd.Parameters.AddWithValue("@MaNhanVien", lichSu.MaNhanVien);
                cmd.Parameters.AddWithValue("@GhiChu", lichSu.GhiChu);
                cmd.ExecuteNonQuery();
            }
        }


        public List<LichSuNhapHangDTO> GetAllLichSuNhapHangs()
        {
            List<LichSuNhapHangDTO> lichSuList = new List<LichSuNhapHangDTO>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM LichSuNhapHang";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LichSuNhapHangDTO lichSu = new LichSuNhapHangDTO
                    {
                        MaLichSu = (int)reader["MaLichSu"],
                        MaPhieu = (int)reader["MaPhieu"],
                        NgayThucHien = (DateTime)reader["NgayThucHien"],
                        MaNhanVien = reader["MaNhanVien"].ToString(),
                        GhiChu = reader["GhiChu"].ToString()
                    };
                    lichSuList.Add(lichSu);
                }
            }

            return lichSuList;
        }

        // Method to get LichSuNhapHang by its ID
        public LichSuNhapHangDTO GetLichSuNhapHangById(int maLichSu)
        {
            LichSuNhapHangDTO lichSu = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM LichSuNhapHang WHERE MaLichSu = @MaLichSu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLichSu", maLichSu);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lichSu = new LichSuNhapHangDTO
                    {
                        MaLichSu = (int)reader["MaLichSu"],
                        MaPhieu = (int)reader["MaPhieu"],
                        NgayThucHien = (DateTime)reader["NgayThucHien"],
                        MaNhanVien = reader["MaNhanVien"].ToString(),
                        GhiChu = reader["GhiChu"].ToString()
                    };
                }
            }

            return lichSu;
        }

        // Method to update an existing LichSuNhapHang record
        public void UpdateLichSuNhapHang(LichSuNhapHangDTO lichSu)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "UPDATE LichSuNhapHang SET MaPhieu = @MaPhieu, NgayThucHien = @NgayThucHien, " +
                               "MaNhanVien = @MaNhanVien, GhiChu = @GhiChu WHERE MaLichSu = @MaLichSu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLichSu", lichSu.MaLichSu);
                cmd.Parameters.AddWithValue("@MaPhieu", lichSu.MaPhieu);
                cmd.Parameters.AddWithValue("@NgayThucHien", lichSu.NgayThucHien);
                cmd.Parameters.AddWithValue("@MaNhanVien", lichSu.MaNhanVien);
                cmd.Parameters.AddWithValue("@GhiChu", lichSu.GhiChu);
                cmd.ExecuteNonQuery();
            }
        }

        // Method to delete a LichSuNhapHang record by its ID
        public void DeleteLichSuNhapHang(int maLichSu)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "DELETE FROM LichSuNhapHang WHERE MaLichSu = @MaLichSu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLichSu", maLichSu);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
