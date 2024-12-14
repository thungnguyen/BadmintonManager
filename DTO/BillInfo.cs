using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    internal class BillInfo
    {   
        public BillInfo(string donViTinh, int maHDSP, int maHD, int maHH, int soLuong, decimal donGia, decimal thanhTien)
        { 
            this.MaHDSP = maHDSP;
            this.MaHD = maHD;
            this.MaHH = maHH;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.ThanhTien = thanhTien;
            this.DonViTinh = donViTinh;

        }

        public BillInfo(DataRow row)
        {
            this.maHDSP = (int)row["maHDSP"];
            this.maHD = (int)row["maHD"];
            this.MaHH = (int)row["MaHH"];
            this.SoLuong = (int)row["SoLuong"];
            this.DonGia = (decimal)row["DonGia"];
            this.ThanhTien = (decimal)row["ThanhTien"];
            this.DonViTinh = row["DonViTinh"].ToString();
        }
        private decimal thanhTien;
        public decimal ThanhTien { get => thanhTien; set => thanhTien = value; }
        private decimal donGia;
        public decimal DonGia { get => donGia; set => donGia = value; }
        private int soLuong;
        public int SoLuong { get => soLuong; set => soLuong = value; }
        private int maHH;
        public int MaHH { get => maHH; set => maHH = value; }
        private int maHD;
        public int MaHD { get => maHD; set => maHD = value; }
        private int maHDSP;
        public int MaHDSP { get => maHDSP; set => maHDSP = value; }
        private string donViTinh;
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }

    }
}
