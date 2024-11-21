using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlycaulong.Database
{
    public class ThanhToan
    {
        public int MaTT { get; set; }
        public int MaHD { get; set; }
        public int MaHinhThucTT { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public decimal SoTien { get; set; }
        public string TrangThai { get; set; }
    }

}
