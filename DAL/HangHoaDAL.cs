using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BadmintonManager.DAL;
using BadmintonManager.DTO;

namespace BadmintonManager.DAL
{
    /// <summary>
    /// Data Access Layer for HangHoa (Product) operations
    /// </summary>
    public class HangHoaDAL
    {
        /// <summary>
        /// Retrieves all products from the database
        /// </summary>
        public List<HangHoa> GetAllProducts()
        {
            List<HangHoa> products = new List<HangHoa>();
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM HangHoa";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new HangHoa
                            {
                                MaHH = Convert.ToInt32(reader["MaHH"]),
                                TenHH = reader["TenHH"].ToString(),
                                MoTa = reader["MoTa"].ToString(),
                                GiaBanLon = Convert.ToDecimal(reader["GiaBanLon"]),
                                MaLoaiHH = Convert.ToInt32(reader["MaLoaiHH"])

                            });
                        }
                    }
                }
            }
            return products;
        }

        /// <summary>
        /// Adds a new product to the database
        /// </summary>
        public int AddProduct(HangHoa product)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"INSERT INTO HangHoa 
                    (TenHH, MoTa, GiaBanLon, MaLoaiHH) 
                    VALUES (@TenHH, @MoTa, @GiaBanLon, @MaLoaiHH);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenHH", product.TenHH);
                    command.Parameters.AddWithValue("@MoTa", product.MoTa);
                    command.Parameters.AddWithValue("@GiaBanLon", product.GiaBanLon);
                    command.Parameters.AddWithValue("@MaLoaiHH", product.MaLoaiHH);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Updates an existing product in the database
        /// </summary>
        public bool UpdateProduct(HangHoa product)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"UPDATE HangHoa 
                    SET TenHH = @TenHH, 
                        MoTa = @MoTa, 
                        GiaBanLon = @GiaBanLon, 
                        MaLoaiHH = @MaLoaiHH 
                    WHERE MaHH = @MaHH";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaHH", product.MaHH);
                    command.Parameters.AddWithValue("@TenHH", product.TenHH);
                    command.Parameters.AddWithValue("@MoTa", product.MoTa);
                    command.Parameters.AddWithValue("@GiaBanLon", product.GiaBanLon);
                    command.Parameters.AddWithValue("@MaLoaiHH", product.MaLoaiHH);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Deletes a product from the database
        /// </summary>
        public bool DeleteProduct(int productId)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM HangHoa WHERE MaHH = @MaHH";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaHH", productId);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
