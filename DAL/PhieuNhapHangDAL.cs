using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BadmintonManager.DAL
{
    public class PhieuNhapHangDAL
    {
        private string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;


        public void AddPhieuNhapHang(PhieuNhapHangDTO phieu)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO PhieuNhapHang (NgayNhap, MaNhaCungCap, MaNhanVien, TongTien, GhiChu) " +
                               "VALUES (@NgayNhap, @MaNhaCungCap, @MaNhanVien, @TongTien, @GhiChu)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NgayNhap", phieu.NgayNhap);
                cmd.Parameters.AddWithValue("@MaNhaCungCap", phieu.MaNhaCungCap);
                cmd.Parameters.AddWithValue("@MaNhanVien", phieu.MaNhanVien);
                cmd.Parameters.AddWithValue("@TongTien", phieu.TongTien);
                cmd.Parameters.AddWithValue("@GhiChu", phieu.GhiChu);
                cmd.ExecuteNonQuery();
            }
        }


        public List<PhieuNhapHangDTO> GetAllPhieuNhapHangs()
        {
            List<PhieuNhapHangDTO> phieuList = new List<PhieuNhapHangDTO>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM PhieuNhapHang";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PhieuNhapHangDTO phieu = new PhieuNhapHangDTO
                    {
                        MaPhieu = (int)reader["MaPhieu"],
                        NgayNhap = (DateTime)reader["NgayNhap"],
                        MaNhaCungCap = (int)reader["MaNhaCungCap"],
                        MaNhanVien = reader["MaNhanVien"].ToString(),
                        TongTien = (decimal)reader["TongTien"],
                        GhiChu = reader["GhiChu"].ToString()
                    };
                    phieuList.Add(phieu);
                }
            }

            return phieuList;
        }

        // Method to get a PhieuNhapHang by its ID
        public PhieuNhapHangDTO GetPhieuNhapHangById(int maPhieu)
        {
            PhieuNhapHangDTO phieu = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM PhieuNhapHang WHERE MaPhieu = @MaPhieu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    phieu = new PhieuNhapHangDTO
                    {
                        MaPhieu = (int)reader["MaPhieu"],
                        NgayNhap = (DateTime)reader["NgayNhap"],
                        MaNhaCungCap = (int)reader["MaNhaCungCap"],
                        MaNhanVien = reader["MaNhanVien"].ToString(),
                        TongTien = (decimal)reader["TongTien"],
                        GhiChu = reader["GhiChu"].ToString()
                    };
                }
            }

            return phieu;
        }

        // Method to update an existing PhieuNhapHang
        public void UpdatePhieuNhapHang(PhieuNhapHangDTO phieu)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "UPDATE PhieuNhapHang SET NgayNhap = @NgayNhap, MaNhaCungCap = @MaNhaCungCap, " +
                               "MaNhanVien = @MaNhanVien, TongTien = @TongTien, GhiChu = @GhiChu WHERE MaPhieu = @MaPhieu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieu", phieu.MaPhieu);
                cmd.Parameters.AddWithValue("@NgayNhap", phieu.NgayNhap);
                cmd.Parameters.AddWithValue("@MaNhaCungCap", phieu.MaNhaCungCap);
                cmd.Parameters.AddWithValue("@MaNhanVien", phieu.MaNhanVien);
                cmd.Parameters.AddWithValue("@TongTien", phieu.TongTien);
                cmd.Parameters.AddWithValue("@GhiChu", phieu.GhiChu);
                cmd.ExecuteNonQuery();
            }
        }

        // Method to delete a PhieuNhapHang by its ID
        public void DeletePhieuNhapHang(int maPhieu)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "DELETE FROM PhieuNhapHang WHERE MaPhieu = @MaPhieu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
