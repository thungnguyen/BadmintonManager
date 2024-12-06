

namespace BadmintonManager.Models
{
    public class HangHoa
    {
        public int MaHH { get; set; }
        public int? MaLoaiHH { get; set; }
        public string TenHH { get; set; }
        public string DonViTinhNhap { get; set; }
        public int? QuyDoi { get; set; }
        public decimal? GiaNhap { get; set; }
        public decimal? GiaBan { get; set; }
        public int? SoLuong { get; set; }

        // Hàm dựng mặc định
        public HangHoa() { }

        // Hàm dựng có tham số (nếu cần)
        public HangHoa(int maHH, int? maLoaiHH, string tenHH, string donViTinh, int? quyDoi, decimal? giaNhap, decimal? giaBan, int? soLuong)
        {
            MaHH = maHH;
            MaLoaiHH = maLoaiHH;
            TenHH = tenHH;
            DonViTinhNhap = donViTinh;
            QuyDoi = quyDoi;
            GiaNhap = giaNhap;
            GiaBan = giaBan;
            SoLuong = soLuong;
        }
    }
}
