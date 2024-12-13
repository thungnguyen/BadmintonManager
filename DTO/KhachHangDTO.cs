namespace QuanLySan.DTO
{
    public class KhachHangDTO
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }

        // Constructor
        public KhachHangDTO(int maKH, string tenKH, string sdt)
        {
            MaKH = maKH;
            TenKH = tenKH;
            SDT = sdt;
        }

        // Default constructor
        public KhachHangDTO() { }
    }
}
