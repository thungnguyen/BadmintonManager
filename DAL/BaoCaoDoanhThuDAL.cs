using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class BaoCaoDoanhThuDAL
{
    private string connectionString = "Data Source=LAPTOP-JDM8N7NE;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False";

    public List<BaoCaoDoanhThuDTO> LayDanhSachBaoCao()
    {
        List<BaoCaoDoanhThuDTO> danhSachBaoCao = new List<BaoCaoDoanhThuDTO>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT [MaBC], [MaLoaiBC], [MaHD], [MaHDSP], [MaDatSan], [TgianBD], [TgianKT], [TongDoanhThuSan], [TongDoanhThuSP], [TongDoanhThu] FROM [QuanLySan].[dbo].[BaoCaoDoanhThu]";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                BaoCaoDoanhThuDTO baoCao = new BaoCaoDoanhThuDTO
                {
                    MaBC = reader.GetInt32(0),
                    MaLoaiBC = reader.GetInt32(1),
                    MaHD = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                    MaHDSP = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                    MaDatSan = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                    TgianBD = reader.GetDateTime(5),
                    TgianKT = reader.GetDateTime(6),
                    TongDoanhThuSan = reader.GetDecimal(7),
                    TongDoanhThuSP = reader.GetDecimal(8),
                    TongDoanhThu = reader.GetDecimal(9)
                };
                danhSachBaoCao.Add(baoCao);
            }
        }

        return danhSachBaoCao;
    }
}
