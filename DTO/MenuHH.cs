using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    internal class MenuHH
    {
        public MenuHH(int maHH, string tenHH)
        {
            this.TenHH = tenHH;
            this.MaHH = maHH;
        }
        public MenuHH(DataRow row)
        {
           this.MaHH = (int)row["maHH"];
            this.TenHH = row["tenHH"].ToString();

        }
        private string tenHH;
        public string TenHH
        {
            get { return tenHH; }
            set { tenHH = value; }
        }
        private int maHH;
        public int MaHH
        {
            get { return maHH; }
            set { maHH = value; }
        }
    }
}
