using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DAO
{
    internal class MenuHHDAO
    {
        private static MenuHHDAO instance;
        public static MenuHHDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new MenuHHDAO();
                return MenuHHDAO.instance;
            }
            private set
            {
                MenuHHDAO.instance = value;
            }
        }
        private MenuHHDAO() { }
        public List<MenuHH> GetListMenuByLoaiHH(int loaiHH)
        {
            List<MenuHH> list = new List<MenuHH>();
            string query = "SELECT TenHH FROM dbo.HangHoa WHERE LoaiHH =" + loaiHH;
            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (System.Data.DataRow item in data.Rows)
            {
                MenuHH menuHH = new MenuHH(item);
                list.Add(menuHH);
            }
            return list;

        }
    }
}
