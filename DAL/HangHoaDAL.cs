using BadmintonManager.DTO;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BadmintonManager.DAL
{
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
                // Log connection status
                MessageBox.Show("Database connection successful");

                string query = @"SELECT MaHH, TenHH, MoTa, GiaBanLon, MaLoaiHH, 
                     DonViTinhLon, DonViTinhNho, HeSoQuyDoi, 
                     GiaNhapLon, GiaNhapNho, SoLuongTonLon, SoLuongTonNho 
                     FROM HangHoa";

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
                                MaLoaiHH = Convert.ToInt32(reader["MaLoaiHH"]),
                                DonViTinhLon = reader["DonViTinhLon"].ToString(),
                                DonViTinhNho = reader["DonViTinhNho"].ToString(),
                                HeSoQuyDoi = Convert.ToDecimal(reader["HeSoQuyDoi"]),
                                GiaNhapLon = Convert.ToDecimal(reader["GiaNhapLon"]),
                                GiaNhapNho = Convert.ToDecimal(reader["GiaNhapNho"]),
                                SoLuongTonLon = Convert.ToInt32(reader["SoLuongTonLon"]),
                                SoLuongTonNho = Convert.ToInt32(reader["SoLuongTonNho"])
                            });
                        }
                    }
                }
                return products;
            }
        }

        public DataTable GetTableProduct()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"
            SELECT h.MaHH, h.TenHH, h.MoTa, h.GiaBanLon, h.MaLoaiHH, 
                   h.DonViTinhLon, h.DonViTinhNho, h.HeSoQuyDoi, 
                   h.GiaNhapLon, h.GiaNhapNho, h.SoLuongTonLon, h.SoLuongTonNho,
                   l.TenLoaiHH 
            FROM HangHoa h
            JOIN LoaiHH l ON h.MaLoaiHH = l.MaLoaiHH";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public DataTable GetProducts(string searchTerm = null)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"
            SELECT h.MaHH, h.TenHH, h.MoTa, h.GiaBanLon, h.MaLoaiHH, 
                   h.DonViTinhLon, h.DonViTinhNho, h.HeSoQuyDoi, 
                   h.GiaNhapLon, h.GiaNhapNho, h.SoLuongTonLon, h.SoLuongTonNho,
                   l.TenLoaiHH
            FROM HangHoa h
            JOIN LoaiHH l ON h.MaLoaiHH = l.MaLoaiHH";

                // Add filtering if a search term is provided
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " WHERE h.TenHH LIKE @SearchTerm";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        /// <summary>
        /// Retrieves product categories
        /// </summary>
        public List<LoaiHHDTO> GetProductCategories()
        {
            var categories = new List<LoaiHHDTO>();
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM LoaiHH", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new LoaiHHDTO
                        {
                            MaLoaiHH = (int)reader["MaLoai"],
                            TenLoaiHH = reader["TenLoai"].ToString()
                        });
                    }
                }
            }
            return categories;
        }

        /// <summary>
        /// Adds a new product to the database
        /// </summary>
        public void AddProduct(HangHoa product)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                using (var command = new SqlCommand(
                    "INSERT INTO HangHoa (TenHH, MaLoaiHH, MoTa, DonViTinhNho, DonViTinhLon, HeSoQuyDoi, GiaNhapLon, GiaNhapNho, GiaBanLon, GiaBanNho, SoLuongTonLon, SoLuongTonNho) " +
                    "VALUES (@TenHH, @MaLoaiHH, @MoTa, @DonViTinhNho, @DonViTinhLon, @HeSoQuyDoi, @GiaNhapLon, @GiaNhapNho, @GiaBanLon, @GiaBanNho, @SoLuongTonLon, @SoLuongTonNho)",
                    connection))
                {
                    command.Parameters.AddWithValue("@TenHH", product.TenHH);
                    command.Parameters.AddWithValue("@MaLoaiHH", product.MaLoaiHH);
                    command.Parameters.AddWithValue("@MoTa", product.MoTa ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DonViTinhNho", product.DonViTinhNho ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DonViTinhLon", product.DonViTinhLon ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@HeSoQuyDoi", product.HeSoQuyDoi);
                    command.Parameters.AddWithValue("@GiaNhapLon", product.GiaNhapLon);
                    command.Parameters.AddWithValue("@GiaNhapNho", product.GiaNhapNho);
                    command.Parameters.AddWithValue("@GiaBanLon", product.GiaBanLon);
                    command.Parameters.AddWithValue("@GiaBanNho", product.GiaBanNho);
                    command.Parameters.AddWithValue("@SoLuongTonLon", product.SoLuongTonLon);
                    command.Parameters.AddWithValue("@SoLuongTonNho", product.SoLuongTonNho);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int maHH)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM HangHoa WHERE MaHH = @MaHH";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaHH", maHH);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("No product found with the specified ID.");
                    }
                }
            }
        }



        public void UpdateProduct(HangHoa product)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {


                string query = @"
                UPDATE HangHoa
                SET 
                    TenHH = @TenHH,
                    MaLoaiHH = @MaLoaiHH,
                    MoTa = @MoTa,
                    DonViTinhNho = @DonViTinhNho,
                    DonViTinhLon = @DonViTinhLon,
                    HeSoQuyDoi = @HeSoQuyDoi,
                    GiaNhapLon = @GiaNhapLon,
                    GiaNhapNho = @GiaNhapNho,
                    GiaBanLon = @GiaBanLon,
                    GiaBanNho = @GiaBanNho
                WHERE MaHH = @MaHH";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaHH", product.MaHH);
                    command.Parameters.AddWithValue("@TenHH", product.TenHH);
                    command.Parameters.AddWithValue("@MaLoaiHH", product.MaLoaiHH);
                    command.Parameters.AddWithValue("@MoTa", product.MoTa ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DonViTinhNho", product.DonViTinhNho);
                    command.Parameters.AddWithValue("@DonViTinhLon", product.DonViTinhLon);
                    command.Parameters.AddWithValue("@HeSoQuyDoi", product.HeSoQuyDoi);
                    command.Parameters.AddWithValue("@GiaNhapLon", product.GiaNhapLon);
                    command.Parameters.AddWithValue("@GiaNhapNho", product.GiaNhapNho);
                    command.Parameters.AddWithValue("@GiaBanLon", product.GiaBanLon);
                    command.Parameters.AddWithValue("@GiaBanNho", product.GiaBanNho);

                    command.ExecuteNonQuery();
                }
            }
        }

        public HangHoa GetProductById(int productId)
        {
            HangHoa product = null;

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {

                string query = "SELECT * FROM HangHoa WHERE MaHH = @MaHH";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaHH", productId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new HangHoa
                            {
                                MaHH = Convert.ToInt32(reader["MaHH"]),
                                TenHH = reader["TenHH"].ToString(),
                                MaLoaiHH = Convert.ToInt32(reader["MaLoaiHH"]),
                                MoTa = reader["MoTa"] != DBNull.Value ? reader["MoTa"].ToString() : null,
                                DonViTinhNho = reader["DonViTinhNho"].ToString(),
                                DonViTinhLon = reader["DonViTinhLon"].ToString(),
                                HeSoQuyDoi = Convert.ToInt32(reader["HeSoQuyDoi"]),
                                GiaNhapLon = Convert.ToDecimal(reader["GiaNhapLon"]),
                                GiaNhapNho = Convert.ToDecimal(reader["GiaNhapNho"]),
                                GiaBanLon = Convert.ToDecimal(reader["GiaBanLon"]),
                                GiaBanNho = Convert.ToDecimal(reader["GiaBanNho"]),
                                SoLuongTonLon = Convert.ToInt32(reader["SoLuongTonLon"]),
                                SoLuongTonNho = Convert.ToInt32(reader["SoLuongTonNho"])
                            };
                        }

                    }
                }
                }
            return product;
        }

            
        }
    }



