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

        // Phương thức cũ
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

        public void InsertAccount(TaiKhoanNhanVienDTO account)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO TaiKhoanNhanVien (TenNV, TenDangNhap, MatKhau, VaiTro, SDT) 
                                 VALUES (@TenNV, @TenDangNhap, @MatKhau, @VaiTro, @SDT)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
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

        // Phương thức mới từ TaiKhoanNhanVienDAL
        public TaiKhoanNhanVienDTO DangNhap(string tenDangNhap, string matKhau)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT * FROM TaiKhoanNhanVien WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", matKhau);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new TaiKhoanNhanVienDTO
                        {
                            MaNV = Convert.ToInt32(reader["MaNV"]),
                            TenNV = reader["TenNV"].ToString(),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            VaiTro = reader["VaiTro"].ToString(),
                            SDT = reader["SDT"].ToString(),
                        };
                    }
                }
            }
            return null;
        }

        public int LayMaNV(string tenDangNhap, string matKhau)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT MaNV FROM TaiKhoanNhanVien WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", matKhau);

                    object result = command.ExecuteScalar();

                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        public bool ThemTaiKhoan(TaiKhoanNhanVienDTO taiKhoan)
        {
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
                    command.Parameters.AddWithValue("@VaiTro", taiKhoan.VaiTro ?? "1");
                    command.Parameters.AddWithValue("@SDT", taiKhoan.SDT);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
