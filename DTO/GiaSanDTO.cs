using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    public class GiaSanDTO
    {
        public decimal GiaTruoc17 { get; set; }
        public decimal GiaSau17 { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }
        public string LoaiKhach { get; set; }
    }
}
