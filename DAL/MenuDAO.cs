using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DAO
{
    internal class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new MenuDAO();
                return MenuDAO.instance;
            }
            private set
            {
                MenuDAO.instance = value;
            }
        }
    private MenuDAO() { }
    public List<Menu> GetListMenuBySan(int masan)
        {
            List<Menu> listMenu = new List<Menu>();
            string query = "SELECT \r\n    p.TenHH, \r\n    bi.DonViTinh, \r\n    bi.SoLuong, \r\n    CASE \r\n        WHEN bi.DonViTinh = p.DonViTinhLon THEN p.GiaBanLon\r\n        WHEN bi.DonViTinh = p.DonViTinhNho THEN p.GiaBanNho\r\n    END AS DonGia,\r\n    bi.SoLuong * \r\n    CASE \r\n        WHEN bi.DonViTinh = p.DonViTinhLon THEN p.GiaBanLon\r\n        WHEN bi.DonViTinh = p.DonViTinhNho THEN p.GiaBanNho\r\n    END AS ThanhTien\r\nFROM dbo.HDSP AS bi\r\nJOIN dbo.HoaDon AS b ON bi.MaHD = b.MaHD\r\nJOIN dbo.HangHoa AS p ON bi.MaHH = p.MaHH\r\nWHERE (bi.DonViTinh = p.DonViTinhLon OR bi.DonViTinh = p.DonViTinhNho) AND b.status = 0 AND b.MaSan = " + masan ;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }



    }

}
