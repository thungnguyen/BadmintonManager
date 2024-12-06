using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlycaulong.Database
{
    public class LichSan
    {
        public int MaLich { get; set; }
        public int MaSan { get; set; }
        public DateTime Ngay { get; set; }
        public TimeSpan ThoiGianBatDau { get; set; }
        public TimeSpan ThoiGianKetThuc { get; set; }
        public string TrangThai { get; set; }
    }

}
