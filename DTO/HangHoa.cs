using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BadmintonManager.DTO
{
    public class HangHoa
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string MaHH { get; set; }
        public string TenHH { get; set; }
        public string MoTa { get; set; }
        public string DonViTinhLon { get; set; }
        public string DonViTinhNho { get; set; }
        public int HeSoQuyDoi { get; set; }
        public decimal GiaNhapLon { get; set; }
        public decimal GiaNhapNho { get; set; }
        public decimal GiaBanLon { get; set; }
        public decimal GiaBanNho { get; set; }
        public int SoLuongTonLon { get; set; }
        public int SoLuongTonNho { get; set; }
        public string MaLoaiHH { get; set; }
    } 
}