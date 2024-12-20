using System;

namespace BadmintonManager.DTO
{
    public class GiaSanDTO
    {
        public int MaGia { get; set; }          // Mã giá (khóa định danh)
        public decimal GiaTruoc17 { get; set; } // Giá trước 17:00
        public decimal GiaSau17 { get; set; }   // Giá sau 17:00
        public TimeSpan GioBatDau { get; set; } // Thời gian bắt đầu
        public TimeSpan GioKetThuc { get; set; } // Thời gian kết thúc
        public string LoaiKhach { get; set; }   // Loại khách (Cố định/Vãng lai)
    }
}
