using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DAO
{
    internal class LoaiHHDAO
    {
        private static LoaiHHDAO instance;
        public static LoaiHHDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiHHDAO();
                return LoaiHHDAO.instance;
            }
            private set
            {
                LoaiHHDAO.instance = value;
            }
        }
        private LoaiHHDAO() { }
        public List<LoaiHH> GetListLoaiHH()
        {
            List<LoaiHH> list = new List<LoaiHH>();
            string query = "SELECT * FROM dbo.LoaiHH";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                LoaiHH loaiHH = new LoaiHH(item);
                list.Add(loaiHH);
            }
            return list;

        }
    }
}
