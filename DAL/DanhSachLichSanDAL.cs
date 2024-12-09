using System;
using System.Data;
using System.Data.SqlClient;
using BadmintonManager.DTO;


namespace BadmintonManager.DAL
{
    public class DanhSachLichSanDAL
    {
        private string connectionString = "Data Source=LAPTOP-13092004\\SQLEXPRESS01;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False";

        public DataTable LayDanhSachLichSan()
        {
            string query = "SELECT * FROM LichDatSan";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public bool XoaLichSan(int maDatSan)
        {
            string query = "DELETE FROM LichDatSan WHERE MaDatSan = @MaDatSan";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDatSan", maDatSan);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable TimKiemLichSan(DateTime tuNgay, DateTime denNgay)
        {
            string query = "SELECT * FROM LichDatSan WHERE TuNgay >= @TuNgay AND TuNgay <= @DenNgay";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@TuNgay", tuNgay);
                adapter.SelectCommand.Parameters.AddWithValue("@DenNgay", denNgay);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}

namespace BadmintonManager.DAL
{
    public class DanhSachPhieuChiDAL
    {
        private string connectionString = "your_connection_string_here";

        public bool HuyPhieuChi(int maPhieuChi)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM PhieuChi WHERE MaPhieuChi = @MaPhieuChi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPhieuChi", maPhieuChi);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
