using System;

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
