using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using BadmintonManager.DTO;

namespace BadmintonManager.DAL
{
    public class BangGiaSanDAL
    {
        private string connectionString;

        public BangGiaSanDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;
        }

        public List<BangGiaSanDTO> LayBangGia(string loaiKhach)
        {
            List<BangGiaSanDTO> bangGiaSanList = new List<BangGiaSanDTO>();
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
                        BangGiaSanDTO bangGiaSan = new BangGiaSanDTO
                        {
                            GioBatDau = reader.GetTimeSpan(0),
                            GioKetThuc = reader.GetTimeSpan(1),
                            Gia = reader.GetDecimal(2)
                        };
                        bangGiaSanList.Add(bangGiaSan);
                    }
                }
            }
            return bangGiaSanList;
        }
    }
}
