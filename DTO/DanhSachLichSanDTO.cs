using MongoDB.Bson;
using System;

namespace BadmintonManager.DTO
{
    public class DanhSachLichSanDTO
    {
        public ObjectId Id { get; set; }
        public string MaSan { get; set; }
        public string MaKH { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public string TuGio { get; set; }
        public string DenGio { get; set; }
        public string LoaiKH { get; set; }
        public int SoBuoi { get; set; }
        public decimal LayGia { get; set; }
        public decimal CanThanhToan { get; set; }
        public decimal DaTra { get; set; }
        public decimal ConLai { get; set; }
        public string ThoiGian { get; set; }

        public DanhSachLichSanDTO() { }

        // Constructor nhận vào BsonDocument từ MongoDB
        public DanhSachLichSanDTO(BsonDocument doc)
        {
            Id = doc["_id"].AsObjectId;  // Lấy giá trị _id từ BsonDocument
            MaSan = doc["maSan"].AsString;  // Lấy giá trị maSan từ BsonDocument
            MaKH = doc["maKH"].AsString;  // Lấy giá trị maKH từ BsonDocument
            TuNgay = doc["tuNgay"].ToUniversalTime();  // Lấy giá trị tuNgay và chuyển thành DateTime
            DenNgay = doc["denNgay"].ToUniversalTime();  // Lấy giá trị denNgay và chuyển thành DateTime
            TuGio = doc["tuGio"].AsString;  // Lấy giá trị tuGio từ BsonDocument
            DenGio = doc["denGio"].AsString;  // Lấy giá trị denGio từ BsonDocument
            LoaiKH = doc["loaiKH"].AsString;  // Lấy giá trị loaiKH từ BsonDocument
            SoBuoi = doc["soBuoi"].AsInt32;  // Lấy giá trị soBuoi từ BsonDocument
            LayGia = doc["layGia"].ToDecimal();  // Lấy giá trị layGia từ BsonDocument
            CanThanhToan = doc["canThanhToan"].ToDecimal();  // Lấy giá trị canThanhToan từ BsonDocument
            DaTra = doc["daTra"].ToDecimal();  // Lấy giá trị daTra từ BsonDocument
            ConLai = doc["conLai"].ToDecimal();  // Lấy giá trị conLai từ BsonDocument
            ThoiGian = doc["thoiGian"].AsString;  // Lấy giá trị thoiGian từ BsonDocument
        }
    }
}
