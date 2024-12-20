    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;
    using System.Collections.Generic;
    using System;


    namespace BadmintonManager.DTO
    {
        public class LichDatSanDTO
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            [BsonElement("maDatSan")]
            public int MaDatSan { get; set; }

            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string MaSan { get; set; }

            [BsonElement("maKH")]
            public string MaKH { get; set; }


            [BsonElement("tuNgay")]
            public DateTime TuNgay { get; set; }

            [BsonElement("denNgay")]
            public DateTime DenNgay { get; set; }

            [BsonElement("tuGio")]
            public TimeSpan TuGio { get; set; }

            [BsonElement("denGio")]
            public TimeSpan DenGio { get; set; }

            [BsonElement("loaiKH")]
            public string LoaiKH { get; set; }

            [BsonElement("soBuoi")]
            public int SoBuoi { get; set; }

            [BsonElement("layGia")]
            public decimal LayGia { get; set; }

            [BsonElement("canThanhToan")]
            public decimal CanThanhToan { get; set; }

            [BsonElement("daTra")]
            public decimal DaTra { get; set; }

            [BsonElement("conLai")]
            public decimal ConLai { get; set; }

            [BsonElement("thoiGian")]
            public TimeSpan ThoiGian { get; set; }

            [BsonIgnore]
            public List<DateTime> NgayDat { get; set; }
        }

        public class ChiTietLichDatSanDTO
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            [BsonElement("maChiTiet")]
            public int MaChiTiet { get; set; }

            [BsonElement("maDatSan")]
            public string MaDatSan { get; set; }

            [BsonElement("ngay")]
            public DateTime Ngay { get; set; }

            [BsonElement("tuGio")]
            public string TuGio { get; set; }

            [BsonElement("denGio")]
            public string DenGio { get; set; }
        }
    }