using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private BillDAO() { }
    //thanh cong:MaHD
    //that bai:-1

    public int GetUnCheckBillIDByMaSan(int maSan)
    {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.HoaDon WHERE MaSan =" + maSan +" AND status = 0");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.MaHD;
            }
            return -1;
    }
        public void Checkout(int maHD, decimal giaSan)
        {
            // Gọi thủ tục thanh toán và truyền giá sân vào
            string query = "EXEC USP_ThanhToan @maHD = " + maHD + ", @giaGioChoi = " + giaSan;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void InsertBill(int maSan, decimal giaGioChoi)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBill @maSan , @giaGioChoi", new object[] { maSan, giaGioChoi });
        }

        public int GetMaxMaHD()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(MaHD) FROM dbo.HoaDon");
            }
            catch
            {
                return 1;
            }
        }
    }
}
