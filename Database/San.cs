using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlycaulong.Database
{
    public class San
    {
        public int MaSan { get; set; }
        public string TenSan { get; set; }
 
    // Chuỗi kết nối đến cơ sở dữ liệu
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;
    }
}
