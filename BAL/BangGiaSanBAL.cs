using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadmintonManager.DAL;
using BadmintonManager.DTO;



namespace BadmintonManager.BAL
{
    public class BangGiaSanBAL
    {
        private BangGiaSanDAL bangGiaSanDAL;

        public BangGiaSanBAL()
        {
            bangGiaSanDAL = new BangGiaSanDAL();
        }

        public static decimal TinhGia(string loaiKhach, TimeSpan gioBatDau, TimeSpan gioKetThuc, BangGiaSanDAL bangGiaSanDAL)
        {
            List<BangGiaSanDTO> bangGiaList = bangGiaSanDAL.LayBangGia(loaiKhach);

            decimal totalGia = 0;
            decimal giaTruoc17 = 0, giaSau17 = 0;
            TimeSpan gio17h = new TimeSpan(17, 0, 0);

            foreach (var bangGia in bangGiaList)
            {
                if (bangGia.GioKetThuc <= gio17h)
                {
                    giaTruoc17 = bangGia.Gia;
                }
                else if (bangGia.GioBatDau >= gio17h)
                {
                    giaSau17 = bangGia.Gia;
                }
            }

            if (gioBatDau < gio17h && gioKetThuc > gio17h)
            {
                decimal soGioTruoc17 = (decimal)(gio17h - gioBatDau).TotalHours;
                decimal soGioSau17 = (decimal)(gioKetThuc - gio17h).TotalHours;
                totalGia = giaTruoc17 * soGioTruoc17 + giaSau17 * soGioSau17;
            }
            else if (gioKetThuc <= gio17h)
            {
                decimal soGioTruoc17 = (decimal)(gioKetThuc - gioBatDau).TotalHours;
                totalGia = giaTruoc17 * soGioTruoc17;
            }
            else if (gioBatDau >= gio17h)
            {
                decimal soGioSau17 = (decimal)(gioKetThuc - gioBatDau).TotalHours;
                totalGia = giaSau17 * soGioSau17;
            }

            return totalGia;
        }

        internal decimal TinhGia(string loaiKhach, TimeSpan gioBatDau, TimeSpan gioKetThuc)
        {
            throw new NotImplementedException();
        }
    }
}
