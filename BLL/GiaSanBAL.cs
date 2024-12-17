using BadmintonManager.DAL;
using System.Collections.Generic;
using System;
using BadmintonManager.DTO;

public class GiaSanBAL
{
    private readonly GiaSanDAL_MongoDB giaSanDAL;

    public GiaSanBAL()
    {
        giaSanDAL = new GiaSanDAL_MongoDB();
    }

    public decimal TinhGia(bool loaiKhachChecked, TimeSpan gioBatDau, TimeSpan gioKetThuc)
    {
        string loaiKhach = loaiKhachChecked ? "Co dinh" : "Vang lai";
        List<GiaSanDTO> danhSachGiaSan = giaSanDAL.GetGiaSanByLoaiKhach(loaiKhach);

        decimal totalGia = 0;
        decimal giaTruoc17 = 0, giaSau17 = 0;

        foreach (var giaSan in danhSachGiaSan)
        {
            // Lấy giá trước 17 giờ
            if (giaSan.GioBatDau < new TimeSpan(17, 0, 0) && giaSan.GioKetThuc <= new TimeSpan(17, 0, 0))
            {
                giaTruoc17 = giaSan.GiaTruoc17;
            }

            // Lấy giá sau 17 giờ
            if (giaSan.GioBatDau >= new TimeSpan(17, 0, 0))
            {
                giaSau17 = giaSan.GiaSau17;
            }
        }

        // Tính tổng giá dựa vào khoảng thời gian
        if (gioBatDau < new TimeSpan(17, 0, 0) && gioKetThuc > new TimeSpan(17, 0, 0))
        {
            decimal soGioTruoc17 = (decimal)(new TimeSpan(17, 0, 0) - gioBatDau).TotalHours;
            decimal soGioSau17 = (decimal)(gioKetThuc - new TimeSpan(17, 0, 0)).TotalHours;
            totalGia = (giaTruoc17 * soGioTruoc17) + (giaSau17 * soGioSau17);
        }
        else if (gioKetThuc <= new TimeSpan(17, 0, 0))
        {
            decimal soGioTruoc17 = (decimal)(gioKetThuc - gioBatDau).TotalHours;
            totalGia = giaTruoc17 * soGioTruoc17;
        }
        else if (gioBatDau >= new TimeSpan(17, 0, 0))
        {
            decimal soGioSau17 = (decimal)(gioKetThuc - gioBatDau).TotalHours;
            totalGia = giaSau17 * soGioSau17;
        }

        return totalGia;
    }
}
