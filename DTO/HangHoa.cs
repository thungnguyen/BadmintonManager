namespace BadmintonManager.DTO
{
    public class HangHoa
    {
        public int MaHH { get; set; }
        public string TenHH { get; set; }
        public string MoTa { get; set; }
        public string DonViTinhLon { get; set; }
        public string DonViTinhNho { get; set; }
        public decimal HeSoQuyDoi { get; set; }
        public decimal GiaNhapLon { get; set; }
        public decimal GiaNhapNho { get; set; }
        public decimal GiaBanLon { get; set; }
        public decimal GiaBanNho { get; set; }
        public int SoLuongTonLon { get; set; }
        public int SoLuongTonNho { get; set; }
        public int MaLoaiHH { get; set; }

        // Navigation property
        public LoaiHH LoaiHH { get; set; }

    }
}
