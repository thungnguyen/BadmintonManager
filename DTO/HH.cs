using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    internal class HH
    {
        public HH(int maHH, string tenHH, int maLoaiHH, decimal giaBanLon, decimal giaBanNho, string donViTinhNho, string donViTinhLon)
        {
            this.MaHH = maHH;
            this.TenHH = tenHH;
            this.MaLoaiHH = maLoaiHH;
            this.GiaBanLon = giaBanLon;
            this.GiaBanNho = giaBanNho;
            this.DonViTinhNho = donViTinhNho;
            this.DonViTinhLon = donViTinhLon;
        }
        public HH(DataRow row)
        {
            this.MaHH = row["maHH"] != DBNull.Value ? Convert.ToInt32(row["maHH"]) : 0;
            this.TenHH = row["tenHH"] != DBNull.Value ? row["tenHH"].ToString() : string.Empty;
            this.MaLoaiHH = row["maLoaiHH"] != DBNull.Value ? Convert.ToInt32(row["maLoaiHH"]) : 0;
            this.GiaBanLon = row["giaBanLon"] != DBNull.Value ? Convert.ToDecimal(row["giaBanLon"]) : 0;
            this.GiaBanNho = row["giaBanNho"] != DBNull.Value ? Convert.ToDecimal(row["giaBanNho"]) : 0;
            this.DonViTinhLon = row["donViTinhLon"] != DBNull.Value ? row["donViTinhLon"].ToString() : string.Empty;
            this.DonViTinhNho = row["donViTinhNho"] != DBNull.Value ? row["donViTinhNho"].ToString() : string.Empty;
        }
        private int maHH;
        public int MaHH
        {
            get { return maHH; }
            set { maHH = value; }
        }
        private string tenHH;
        public string TenHH
        {
            get { return tenHH; }
            set { tenHH = value; }
        }
        private int maLoaiHH;
        public int MaLoaiHH
        {
            get { return maLoaiHH; }
            set { maLoaiHH = value; }
        }
        private decimal giaBanLon;
        public decimal GiaBanLon
        {
            get { return giaBanLon; }
            set { giaBanLon = value; }
        }
        private decimal giaBanNho;
        public decimal GiaBanNho
        {
            get { return giaBanNho; }
            set { giaBanNho = value; }
        }
        private string donViTinhLon;
        public string DonViTinhLon
        {
            get { return donViTinhLon; }
            set { donViTinhLon = value; }
        }
        private string donViTinhNho;
        public string DonViTinhNho
        {
            get { return donViTinhNho; }
            set { donViTinhNho = value; }
        }
        
    }
}
