// SanDAL.cs
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BadmintonManager.DTO;
using System.Configuration;


namespace BadmintonManager.DAL
{
    public class SanDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

        public List<San> GetSanList()
        {
            List<San> sans = new List<San>();
            string query = "SELECT MaSan, TenSan FROM San";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        San san = new San
                        {
                            MaSan = Convert.ToInt32(reader["MaSan"]),
                            TenSan = reader["TenSan"].ToString()
                        };
                        sans.Add(san);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi truy xuất dữ liệu: " + ex.Message);
                }
            }

            return sans;
        }
    }
}