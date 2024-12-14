using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    public class PhieuNhapHangDTO
    {
        public int MaPhieu { get; set; }        
        public DateTime NgayNhap { get; set; }   
        public int MaNhaCungCap { get; set; }     
        public string MaNhanVien { get; set; }    
        public decimal TongTien { get; set; }    
        public string GhiChu { get; set; }       
    }
}