using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DAO
{
    internal class HHDAO
    {
        private static HHDAO instance;
        public static HHDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HHDAO();
                return HHDAO.instance;
            }
            private set
            {
                HHDAO.instance = value;
            }
        }
        private HHDAO() { }
        public List<HH> GetListByLoaiHH(int maLoaiHH)
        {
            List<HH> list = new List<HH>();
            string query = "SELECT * FROM dbo.HangHoa WHERE MaLoaiHH ="  + maLoaiHH;
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                HH hanghoa = new HH(item);
                list.Add(hanghoa);
            }
            return list;

        }
        public List<HH> GetItemByMaHH(int maHH)
        {
            List<HH> list = new List<HH>();
            string query = "SELECT * FROM dbo.HangHoa WHERE MaHH = " + maHH;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                HH hanghoa = new HH(item);
                list.Add(hanghoa);
            }
            return list;
        }
        public List<HH> GetDonGiaByMaHHAnDVT(int maHH, string donViTinh)
        {
            List <HH> list = new List<HH>();
            
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetDonGiaByMaHHAndDonViTinh @MaHH, @DonViTinh ", new object[] { maHH, donViTinh });
            foreach (DataRow item in data.Rows)
            {
                HH hangHoa = new HH(item);
                list.Add(hangHoa);
            }
            return list;
        }



    }
}
