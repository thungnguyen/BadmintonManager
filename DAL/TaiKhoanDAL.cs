using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BadmintonManager.DTO;

namespace BadmintonManager.DAL
{
    public class TaiKhoanDAL
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

        public List<TaiKhoanNhanVienDTO> GetAllAccounts()
        {
            List<TaiKhoanNhanVienDTO> accounts = new List<TaiKhoanNhanVienDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM TaiKhoanNhanVien";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TaiKhoanNhanVienDTO account = new TaiKhoanNhanVienDTO
                    {
                        MaNV = Convert.ToInt32(reader["MaNV"]),
                        TenNV = reader["TenNV"].ToString(),
                        TenDangNhap = reader["TenDangNhap"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        VaiTro = reader["VaiTro"].ToString(),
                        SDT = reader["SDT"].ToString()
                    };
                    accounts.Add(account);
                }
            }
            return accounts;
        }

        public void UpdateAccount(TaiKhoanNhanVienDTO account)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE TaiKhoanNhanVien SET 
                                 TenNV = @TenNV, TenDangNhap = @TenDangNhap, 
                                 MatKhau = @MatKhau, VaiTro = @VaiTro, SDT = @SDT
                                 WHERE MaNV = @MaNV";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaNV", account.MaNV);
                    command.Parameters.AddWithValue("@TenNV", account.TenNV);
                    command.Parameters.AddWithValue("@TenDangNhap", account.TenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", account.MatKhau);
                    command.Parameters.AddWithValue("@VaiTro", account.VaiTro);
                    command.Parameters.AddWithValue("@SDT", account.SDT);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAccount(int maNV)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM TaiKhoanNhanVien WHERE MaNV = @MaNV";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaNV", maNV);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
