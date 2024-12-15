using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BadmintonManager.DTO
{
    public class HangHoa
    {
        /// <summary>
        /// Unique identifier for the document
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Mã hàng hóa
        /// </summary>
        [BsonElement("maHH")]
        public int MaHH { get; set; }

        /// <summary>
        /// Tên hàng hóa
        /// </summary>
        [BsonElement("tenHH")]
        public string TenHH { get; set; }

        /// <summary>
        /// Mô tả hàng hóa
        /// </summary>
        [BsonElement("moTa")]
        public string MoTa { get; set; }

        /// <summary>
        /// Đơn vị tính lớn (e.g., Thùng)
        /// </summary>
        [BsonElement("donViTinhLon")]
        public string DonViTinhLon { get; set; }

        /// <summary>
        /// Đơn vị tính nhỏ (e.g., Chai)
        /// </summary>
        [BsonElement("donViTinhNho")]
        public string DonViTinhNho { get; set; }

        /// <summary>
        /// Hệ số quy đổi từ đơn vị lớn sang nhỏ
        /// </summary>
        [BsonElement("heSoQuyDoi")]
        public int HeSoQuyDoi { get; set; }

        /// <summary>
        /// Giá nhập hàng hóa (đơn vị lớn)
        /// </summary>
        [BsonElement("giaNhapLon")]
        public decimal GiaNhapLon { get; set; }

        /// <summary>
        /// Giá nhập hàng hóa (đơn vị nhỏ)
        /// </summary>
        [BsonElement("giaNhapNho")]
        public decimal GiaNhapNho { get; set; }

        /// <summary>
        /// Giá bán hàng hóa (đơn vị lớn)
        /// </summary>
        [BsonElement("giaBanLon")]
        public decimal GiaBanLon { get; set; }

        /// <summary>
        /// Giá bán hàng hóa (đơn vị nhỏ)
        /// </summary>
        [BsonElement("giaBanNho")]
        public decimal GiaBanNho { get; set; }

        /// <summary>
        /// Số lượng tồn kho (đơn vị lớn)
        /// </summary>
        [BsonElement("soLuongTonLon")]
        public int SoLuongTonLon { get; set; }

        /// <summary>
        /// Số lượng tồn kho (đơn vị nhỏ)
        /// </summary>
        [BsonElement("soLuongTonNho")]
        public int SoLuongTonNho { get; set; }

        /// <summary>
        /// Mã loại hàng hóa
        /// </summary>
        [BsonElement("maLoaiHH")]
        public int MaLoaiHH { get; set; }
    }
}
