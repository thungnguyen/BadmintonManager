using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BadmintonManager.DTO
{
    public class KhachHangDTO
    {
        [BsonId] // Đánh dấu là trường _id
        [BsonRepresentation(BsonType.ObjectId)] // Xử lý kiểu ObjectId của MongoDB
        public string Id { get; set; }

        [BsonElement("maKH")] // Ánh xạ với trường maKH trong MongoDB
        public int MaKH { get; set; }

        [BsonElement("tenKH")] // Ánh xạ với trường tenKH trong MongoDB
        public string TenKH { get; set; }

        [BsonElement("sdt")] // Ánh xạ với trường sdt trong MongoDB
        public string SDT { get; set; }
    }
}
