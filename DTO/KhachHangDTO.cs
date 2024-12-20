using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BadmintonManager.DTO
{
    public class KhachHangDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("maKH")]
        public int MaKH { get; set; }

        [BsonElement("tenKH")]
        public string TenKH { get; set; }

        [BsonElement("sdt")]
        public string SDT { get; set; }
    }
}
