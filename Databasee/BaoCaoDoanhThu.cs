using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlycaulong.Database
{
    public class BaoCaoDoanhThu
    {
        public int MaBC { get; set; }
        public int MaLoaiBC { get; set; }
        public int MaHD { get; set; }
        public int MaCTHD { get; set; }
        public int MaDatSan { get; set; }
        public DateTime TgianBD { get; set; }
        public DateTime TgianKT { get; set; }
        public decimal TongDoanhThuSan { get; set; }
        public decimal TongDoanhThuSP { get; set; }
        public decimal TongDoanhThu { get; set; }
    }

}
