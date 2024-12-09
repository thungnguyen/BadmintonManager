using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    internal class KhachHang
    {
        public KhachHang(int maKH, string tenKH, string sdt)
        {
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.SDT = sdt;
        }
        public KhachHang(DataRow row)
        {
            this.MaKH = (int)row["MaKH"];
            this.TenKH = row["TenKH"].ToString();
            this.SDT = row["SDT"].ToString();
        }
        private int maKH;
        public int MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        private string tenKH;
        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }
        private string sdt;
        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }
    }
}
