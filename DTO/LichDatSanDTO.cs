using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    public class LichDatSanDTO
    {
        public int MaSan { get; set; }
        public int MaKH { get; set; }
        public int MaGia { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public TimeSpan TuGio { get; set; }
        public TimeSpan DenGio { get; set; }
        public string LoaiKH { get; set; }
        public int SoBuoi { get; set; }
        public decimal LayGia { get; set; }
        public decimal CanThanhToan { get; set; }
        public decimal DaTra { get; set; }
        public decimal ConLai { get; set; }
        public TimeSpan ThoiGian { get; set; }
        public List<DateTime> NgayDat { get; set; }
    }
}
