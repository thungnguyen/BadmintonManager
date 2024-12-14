using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    internal class BangGiaSanDTO
    {
        public int MaGia { get; set; }
        public string LoaiKH { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }
        public decimal Gia { get; set; }

        public BangGiaSanDTO() { }

        // Constructor for mapping DataRow from database
        public BangGiaSanDTO(DataRow row)
        {
            MaGia = (int)row["MaGia"];
            LoaiKH = row["LoaiKH"].ToString();
            GioBatDau = (TimeSpan)row["GioBatDau"];
            GioKetThuc = (TimeSpan)row["GioKetThuc"];
            Gia = (decimal)row["Gia"];
        }
    }
}
