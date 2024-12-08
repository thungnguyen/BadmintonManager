using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    public class Bill
    {
        public Bill(int maDatSan, int maHD, DateTime? ngayLap, decimal tongTien)
        {
            this.MaHD = maHD;
            this.NgayLap = ngayLap;
            this.TongTien = tongTien;
            this.MaDatSan = maDatSan;
            //this.MaSan = maSan;
        }
        public Bill(DataRow row)
        {
            this.MaHD = (int)row["maHD"];
            this.NgayLap = (DateTime?)row["ngayLap"];

            var NgayLapTemp = row["ngayLap"];
            if (NgayLapTemp.ToString() != "")
            {
                this.ngayLap = (DateTime?)NgayLapTemp;
            }
            this.TongTien = (decimal)row["tongTien"];

            //
            // Gán giá trị cho MaDatSan
            if (row["maDatSan"] != DBNull.Value)
                this.MaDatSan = (int)row["maDatSan"];
            else
                this.MaDatSan = null;
        }
        //private int maSan;
        //public int MaSan { get => maSan; set => maSan = value; }
        private int? maDatSan;
        public int? MaDatSan { get => maDatSan; set => maDatSan = value; }
        private int maHD;
        public int MaHD { get => maHD; set => maHD = value; }
        private DateTime? ngayLap;
        public DateTime? NgayLap { get => ngayLap; set => ngayLap = value; }
        private decimal tongTien;
        public decimal TongTien { get => tongTien; set => tongTien = value; }
    }
}
