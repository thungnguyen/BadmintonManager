using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    internal class BangGiaSan
    {
        public int MaGia { get; set; }
        public string LoaiKH { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }
        public decimal Gia { get; set; }

        public BangGiaSan() { }

        // Constructor for mapping DataRow from database
        public BangGiaSan(DataRow row)
        {
            MaGia = (int)row["MaGia"];
            LoaiKH = row["LoaiKH"].ToString();
            GioBatDau = (TimeSpan)row["GioBatDau"];
            GioKetThuc = (TimeSpan)row["GioKetThuc"];
            Gia = (decimal)row["Gia"];
        }
    }
}
