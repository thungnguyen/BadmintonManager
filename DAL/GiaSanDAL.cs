using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using BadmintonManager.DTO;

namespace BadmintonManager.DAL
{
    public class GiaSanDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

        public List<GiaSanDTO> GetGiaSanByLoaiKhach(string loaiKhach)
        {
            List<GiaSanDTO> danhSachGiaSan = new List<GiaSanDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT GioBatDau, GioKetThuc, Gia 
                FROM BangGiaSan 
                WHERE LoaiKH = @LoaiKhach 
                ORDER BY GioBatDau";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LoaiKhach", loaiKhach);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        GiaSanDTO giaSan = new GiaSanDTO
                        {
                            GioBatDau = reader.GetTimeSpan(0),
                            GioKetThuc = reader.GetTimeSpan(1),
                            GiaTruoc17 = reader.GetDecimal(2),
                            GiaSau17 = reader.GetDecimal(2), // Giả sử giá cho cả trước và sau 17 giờ giống nhau, có thể điều chỉnh tùy theo yêu cầu
                            LoaiKhach = loaiKhach
                        };
                        danhSachGiaSan.Add(giaSan);
                    }
                }
            }

            return danhSachGiaSan;
        }
    }
}
