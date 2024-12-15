using MongoDB.Bson;  // Thêm dòng này
using MongoDB.Driver;  // Thêm dòng này nếu cần
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

        public San(int maSan, string tenSan, string status, decimal giaSan)
        {
            this.MaSan = maSan;
            this.TenSan = tenSan;
            this.Status = status;
            this.GiaSan = giaSan;
        }
        public San(BsonDocument doc)
        {
        MaSan = doc["maSan"].AsInt32;
        TenSan = doc["tenSan"].AsString;
        Status = doc.Contains("status") ? doc["status"].AsString : string.Empty;
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
        private decimal giaSan;
        public decimal GiaSan
        {
            get { return giaSan; }
            set { giaSan = value; }
        }
    }
}
