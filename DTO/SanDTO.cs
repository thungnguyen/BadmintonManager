using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BadmintonManager.DTO
{
    public class SanDTO
    {
        [BsonId] // Ánh xạ với _id trong MongoDB
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int MaSan { get; set; }
        public string TenSan { get; set; }

        public string Status { get; set; }
    }
}
