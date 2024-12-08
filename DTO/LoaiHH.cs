using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    internal class LoaiHH
    {
        public LoaiHH(int maLoaiHH, string tenLoaiHH)
        { 
            this.MaLoaiHH = maLoaiHH;   
            this.TenLoaiHH = tenLoaiHH;
        }
        public LoaiHH(DataRow row)
        {
            this.maLoaiHH = (int)row["maLoaiHH"];
            this.tenLoaiHH = row["tenLoaiHH"].ToString();
        }
        private int maLoaiHH;
        public int MaLoaiHH
        {
            get { return maLoaiHH; }
            set { maLoaiHH = value; }
        }
        private string tenLoaiHH;
        public string TenLoaiHH
        {
            get { return tenLoaiHH; }
            set { tenLoaiHH = value; }
        }
    }
}
