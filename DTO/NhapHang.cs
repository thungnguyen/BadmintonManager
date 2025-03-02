using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace BadmintonManager.DTO
{
    public class NhapHang
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("maNhapHang")]
        public string MaNhapHang { get; set; }

        [BsonElement("ngayNhap")]
        public DateTime NgayNhap { get; set; }

        [BsonElement("tongTien")]
        public decimal TongTien { get; set; }

        [BsonElement("chiTietNhap")]
        public List<ChiTietNhap> ChiTietNhap { get; set; }
    }

    public class ChiTietNhap
    {
        [BsonElement("maHH")]
        public ObjectId MaHH { get; set; } // Sử dụng ObjectId để liên kết với bảng HangHoa

        [BsonElement("soLuongLon")]
        public int SoLuongLon { get; set; }

        [BsonElement("soLuongNho")]
        public int SoLuongNho { get; set; }

        [BsonElement("giaNhapLon")]
        public decimal GiaNhapLon { get; set; }

        [BsonElement("giaNhapNho")]
        public decimal GiaNhapNho { get; set; }

        [BsonElement("thanhTien")]
        public decimal ThanhTien { get; set; }
    }
}
