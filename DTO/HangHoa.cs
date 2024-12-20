using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BadmintonManager.DTO
{
    public class HangHoa
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("tenHH")]
        public string TenHH { get; set; }

        [BsonElement("moTa")]
        public string MoTa { get; set; }

        [BsonElement("donViTinhLon")]
        public string DonViTinhLon { get; set; }

        [BsonElement("donViTinhNho")]
        public string DonViTinhNho { get; set; }

        [BsonElement("heSoQuyDoi")]
        public int HeSoQuyDoi { get; set; }

        [BsonElement("giaNhapLon")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal GiaNhapLon { get; set; }

        [BsonElement("giaNhapNho")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal GiaNhapNho { get; set; }

        [BsonElement("giaBanLon")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal GiaBanLon { get; set; }

        [BsonElement("giaBanNho")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal GiaBanNho { get; set; }

        [BsonElement("soLuongTonLon")]
        public int SoLuongTonLon { get; set; }

        [BsonElement("soLuongTonNho")]
        public int SoLuongTonNho { get; set; }

        [BsonElement("maLoaiHH")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MaLoaiHH { get; set; }

        [BsonElement("maHH")]
        public int MaHH { get; set; }
    }
}
