using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    public class San
    {

        public San(int maSan, string tenSan, string status)
        {
            this.MaSan = maSan;
            this.TenSan = tenSan;
            this.Status = status;
        }
        public San (DataRow row)
        {
            this.MaSan = (int)row["maSan"];
            this.TenSan = row["tenSan"].ToString();
            this.Status = row["status"].ToString();
        }
        private int maSan;
        public int MaSan
        {
            get { return maSan; }
            set { maSan = value; }
        }
        private string tenSan;
        public string TenSan
        {
            get { return tenSan; }
            set { tenSan = value; }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
