using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BadmintonManager.DTO
{
    internal class KhachHang
    {
        // Các thuộc tính cần ánh xạ với các trường trong MongoDB
        [BsonId]
        public ObjectId Id { get; set; } // Trường _id của MongoDB

        [BsonElement("maKH")]
        public int MaKH { get; set; }

        [BsonElement("tenKH")]
        public string TenKH { get; set; }

        [BsonElement("sdt")]
        public string SDT { get; set; }

        // Constructor để khởi tạo đối tượng từ MongoDB BsonDocument
        public KhachHang(BsonDocument doc)
        {
            this.MaKH = doc["maKH"].ToInt32();
            this.TenKH = doc["tenKH"].ToString();
            this.SDT = doc["sdt"].ToString();
        }

        // Constructor để khởi tạo đối tượng khi có thông tin đầy đủ
        public KhachHang(int maKH, string tenKH, string sdt)
        {
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.SDT = sdt;
        }
    }
}
