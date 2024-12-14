using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DAO
{
    internal class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillInfoDAO();
                }
                return instance;
            }
            private set => instance = value;
        }
        private BillInfoDAO() { }
        public List<BillInfo> GetListBillInfo(int maHD)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.HDSP WHERE MaHD = " + maHD);
            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }
        public void InsertBillInfo(int maHD, int maHH, int soLuong, decimal donGia, string donViTinh)
        {
            // Gọi stored procedure với đầy đủ tham số
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBillInfo @maHD , @maHH , @soLuong , @donGia , @donViTinh",
                new object[] { maHD, maHH, soLuong, donGia, donViTinh });
        }
    }
}
