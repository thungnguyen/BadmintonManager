using System;

namespace BadmintonManager.DTO
{
    public class DanhSachLichSanDTO
    {
        public int MaDatSan { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public string KhachHang { get; set; }
        public string San { get; set; }
    }
    public class PhieuChiDTO
        {
            public int MaPhieuChi { get; set; }
            public int MaDatSan{ get; set; }
            public string MaSan { get; set; }
            public string TenKH { get; set; }
            public DateTime TuNgay { get; set; }
            public string DaTra { get; set; }
            public string MaKH { get; set; }
            public DateTime NgayLap { get; set; }
    }
   
}
