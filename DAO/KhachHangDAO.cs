using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DAO
{
    internal class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KhachHangDAO();
                }
                return instance;
            }
            private set => instance = value;
        }
        private KhachHangDAO() { }
        public List<KhachHang> GetListKhachHang()
        {
            List<KhachHang> listKhachHang = new List<KhachHang>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KhachHang");
            foreach (DataRow item in data.Rows)
            {
                KhachHang kh = new KhachHang(item);
                listKhachHang.Add(kh);
            }
            return listKhachHang;
        }
       
    }
}
