using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace BadmintonManager.DTO
{
    public class LichDatSanDTO
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int MaDatSan { get; set; }


        public int MaSan { get; set; }
        public int MaKH { get; set; }
        public int MaGia { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public TimeSpan TuGio { get; set; }
        public TimeSpan DenGio { get; set; }
        public string LoaiKH { get; set; }
        public int SoBuoi { get; set; }
        public decimal LayGia { get; set; }
        public decimal CanThanhToan { get; set; }
        public decimal DaTra { get; set; }
        public decimal ConLai { get; set; }
        public TimeSpan ThoiGian { get; set; }
        public List<DateTime> NgayDat { get; set; }
    }

    public class ChiTietLichDatSan
    {
        public int MaChiTiet { get; set; } // Add this property
        public int MaSan { get; set; }
        public int MaDatSan { get; set; }
        public DateTime Ngay { get; set; }
        public TimeSpan TuGio { get; set; }
        public TimeSpan DenGio { get; set; }
    }
}
