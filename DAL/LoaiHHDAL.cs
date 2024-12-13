using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BadmintonManager.DAL
{
    internal class LoaiHHDAL
    {
        /// <summary>
        /// Retrieves all product categories from the database
        /// </summary>
        public List<LoaiHH> GetAllCategories()
        {
            List<LoaiHH> categories = new List<LoaiHH>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM LoaiHH";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new LoaiHH
                            {
                                MaLoaiHH = Convert.ToInt32(reader["MaLoaiHH"]),
                                TenLoaiHH = reader["TenLoaiHH"].ToString()
                            });
                        }
                    }
                }
            }

            return categories;
        }

        public void InsertCategory(LoaiHH category)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO LoaiHH (MaLoaiHH, TenLoaiHH) VALUES (@MaLoaiHH, @TenLoaiHH)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaLoaiHH", category.MaLoaiHH);
                    command.Parameters.AddWithValue("@TenLoaiHH", category.TenLoaiHH);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
