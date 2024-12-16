using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace BadmintonManager.DTO
{
    public class Bill
    {
        [BsonId]
        public ObjectId Id { get; set; }  // Khóa chính của hóa đơn

        [BsonElement("maDatSan")]
        public int? MaDatSan { get; set; } // Mã đặt sân

        [BsonElement("ngayLap")]
        public DateTime? NgayLap { get; set; } // Ngày lập hóa đơn

        [BsonElement("tongTien")]
        public decimal? TongTien { get; set; } // Tổng tiền hóa đơn

        [BsonElement("maSan")]
        public int? MaSan { get; set; } // Mã sân liên quan

        [BsonElement("status")]
        public int Status { get; set; } // Trạng thái hóa đơn

        [BsonIgnore]
        public List<BillInfo> BillDetails { get; set; } // Danh sách chi tiết hóa đơn

        public Bill()
        {
            BillDetails = new List<BillInfo>();
        }

        // Constructor nhận vào BsonDocument
        public Bill(BsonDocument doc)
        {
            Id = doc["_id"].AsObjectId;
            MaDatSan = doc["maDatSan"].IsBsonNull ? (int?)null : doc["maDatSan"].ToInt32();
            NgayLap = doc["ngayLap"].IsBsonNull ? (DateTime?)null : doc["ngayLap"].ToLocalTime();
            TongTien = doc["tongTien"].IsBsonNull ? (decimal?)null : doc["tongTien"].ToDecimal();
            MaSan = doc["maSan"].IsBsonNull ? (int?)null : doc["maSan"].ToInt32();
            Status = doc["status"].ToInt32();

            // Loại bỏ phần xử lý "billDetails"
            BillDetails = new List<BillInfo>();
        }
    }
}
