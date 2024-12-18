﻿using System;
using System.Data;
using BadmintonManager.DAL;
using BadmintonManager.DTO;

namespace  BadmintonManager.BAL
{
    public class DanhSachLichSanBAL
    {
        private DanhSachLichSanDAL lichSanDAL;

        public DanhSachLichSanBAL()
        {
            lichSanDAL = new DanhSachLichSanDAL();
        }

        public DataTable LayTatCaLichSan()
        {
            return lichSanDAL.LayDanhSachLichSan();
        }

        public bool HuyLichSan(int maDatSan)
        {
            return lichSanDAL.XoaLichSan(maDatSan);
        }

        public DataTable TimLichSan(DateTime tuNgay, DateTime denNgay)
        {
            return lichSanDAL.TimKiemLichSan(tuNgay, denNgay);
        }


    }
}
