using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DAO
{
    internal class SanDAO
    {
        private static SanDAO instance;

        public static SanDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SanDAO();
                }
                return instance;
            }
            private set => instance = value;
        }
        public static int SanWidth = 50;
        public static int SanHeight = 50;
        private SanDAO() { }
        public List<San> LoadSanList()
        {
            List<San> sanList = new List<San>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetSanList");
            foreach (DataRow item in data.Rows)
            {
                San san = new San(item);
                sanList.Add(san);
            }
            return sanList;
        }
        public void InsertSan (string tenSan)
            {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertSan @tenSan", new object[] { tenSan });
            }
        public void UpdateSan(int maSan, string tenSan)
        {
            {
                DataProvider.Instance.ExecuteNonQuery("EXEC [dbo].[UpdateSan] @maSan , @tenSan", new object[] { maSan, tenSan });
            }
        }
        public void DeleteSan(int maSan)
        {
            string query = "DELETE FROM dbo.San WHERE MaSan = " + maSan;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        internal void UpdateSoBuoiDaDat(int maSan, int v)
        {
            throw new NotImplementedException();
        }
    }
}
