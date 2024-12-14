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
        public decimal GetDonGiaByMaHHAndDVT(int maHH, string donViTinh)
        {
            // Truy vấn cơ sở dữ liệu với tham số mã hàng hóa và đơn vị tính
            string query = "USP_GetDonGiaByMaHHAndDonViTinh @MaHH , @DonViTinh";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maHH, donViTinh });

            // Nếu kết quả trả về không null, chuyển đổi thành kiểu decimal
            if (result != null && result != DBNull.Value)
            {
                return Convert.ToDecimal(result);
            }

            // Trường hợp không tìm thấy đơn giá, trả về 0 (hoặc giá trị mặc định khác)
            return 0;
        }





    }
}
