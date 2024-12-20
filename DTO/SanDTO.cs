using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BadmintonManager.DTO
{
    public class SanDTO
    {
        [BsonId] // Ánh xạ với _id trong MongoDB
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("maSan")] // Ánh xạ với trường maSan trong MongoDB
        public int MaSan { get; set; }

        [BsonElement("tenSan")] // Ánh xạ với trường tenSan trong MongoDB
        public string TenSan { get; set; }

        [BsonElement("status")] // Ánh xạ với trường status trong MongoDB
        public string Status { get; set; }
    }
}
