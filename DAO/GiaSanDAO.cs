using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DAO
{
    internal class GiaSanDAO
    {
        private static GiaSanDAO instance;
        public static GiaSanDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new GiaSanDAO();
                return instance;
            }
            private set => instance = value;
        }
        // Fetch all price data
        public List<BangGiaSanDTO> GetGiaSanData()
        {
            List<BangGiaSanDTO> giaSanList = new List<BangGiaSanDTO>();
            string query = "SELECT MaGia, LoaiKH, GioBatDau, GioKetThuc, Gia FROM BangGiaSan";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                BangGiaSanDTO giaSan = new BangGiaSanDTO(row); // Map data to DTO
                giaSanList.Add(giaSan);
            }

            return giaSanList;
        }

        // Add new price data
        public void AddGiaSan(string loaiKH, TimeSpan gioBatDau, TimeSpan gioKetThuc, decimal gia)
        {
            string query = "INSERT INTO BangGiaSan (LoaiKH, GioBatDau, GioKetThuc, Gia) VALUES (@LoaiKH, @GioBatDau, @GioKetThuc, @Gia)";
            object[] parameters = new object[] { loaiKH, gioBatDau, gioKetThuc, gia };
            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }

        // Update existing price data
        public void UpdateGiaSan(int maGia, string loaiKH, TimeSpan gioBatDau, TimeSpan gioKetThuc, decimal gia)
        {
            string query = "UPDATE BangGiaSan SET LoaiKH = @LoaiKH, GioBatDau = @GioBatDau, GioKetThuc = @GioKetThuc, Gia = @Gia WHERE MaGia = @MaGia";
            object[] parameters = new object[] { maGia, loaiKH, gioBatDau, gioKetThuc, gia };
            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }

        // Delete price data
        public void DeleteGiaSan(int maGia)
        {
            string query = "DELETE FROM BangGiaSan WHERE MaGia = @MaGia";
            object[] parameters = new object[] { maGia };
            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }
    }
}
