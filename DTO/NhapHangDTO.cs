using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    public class NhapHangDTO
    {
        public int MaNhapHang { get; set; }  
        public DateTime NgayNhap { get; set; } 
        public int? TongSoLuong { get; set; }  
        public string GhiChu { get; set; } 
    }
}
