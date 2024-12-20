using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BadmintonManager.DTO
{
    public class TaiKhoanNhanVienDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("MaNV")]
        public int MaNV { get; set; }

        [BsonElement("TenNV")]
        public string TenNV { get; set; }

        [BsonElement("TenDangNhap")]
        public string TenDangNhap { get; set; }

        [BsonElement("MatKhau")]
        public string MatKhau { get; set; }

        [BsonElement("VaiTro")]
        public string VaiTro { get; set; }

        [BsonElement("SDT")]
        public string SDT { get; set; }
    }
}
