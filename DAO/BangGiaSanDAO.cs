using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DAO
{
    internal class BangGiaSanDAO
    {
        private static BangGiaSanDAO instance;

        public static BangGiaSanDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BangGiaSanDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private BangGiaSanDAO() { }
        public List<BangGiaSan> GetListGiaSan()
        {
            List<BangGiaSan> list = new List<BangGiaSan>();
            string query = "SELECT * FROM dbo.BangGiaSan";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                BangGiaSan giaSan = new BangGiaSan(item);
                list.Add(giaSan);
            }
            return list;
        }
        public void InsertGiaSan(string loaiKH, TimeSpan gioBatDau, TimeSpan gioKetThuc, decimal gia)
        {
            string query = "INSERT INTO dbo.BangGiaSan (LoaiKH , GioBatDau , GioKetThuc , Gia) VALUES ( @loaiKH , @gioBatDau , @gioKetThuc , @gia )";
            object[] parameters = new object[] { loaiKH, gioBatDau, gioKetThuc, gia };
            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }
        public void UpdateGiaSan(int maGia, string loaiKH, TimeSpan gioBatDau, TimeSpan gioKetThuc, decimal gia)
        {
            string query = "UPDATE dbo.BangGiaSan SET LoaiKH = @loaiKH , GioBatDau = @gioBatDau , GioKetThuc = @gioKetThuc , Gia = @gia WHERE MaGia = @maGia";
            object[] parameters = new object[] { loaiKH, gioBatDau, gioKetThuc, gia, maGia };
            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }
        public void DeleteGiaSan(int maGia)
        {
            string query = "DELETE FROM dbo.BangGiaSan WHERE MaGia = @maGia";
            object[] parameters = new object[] { maGia };
            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }
    }
}
