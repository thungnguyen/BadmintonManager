using MongoDB.Bson;

namespace BadmintonManager.DTO
{
    public class HH
    {
        public ObjectId Id { get; set; }
        public string TenHH { get; set; }
        public ObjectId MaLoaiHH { get; set; }
        public decimal SoLuong { get; set; }
        public string DonViTinhLon { get; set; }
        public string DonViTinhNho { get; set; }
        public string MoTa { get; set; }
        public decimal GiaBanLon { get; set; } // Thêm vào giá bán lớn
        public decimal GiaBanNho { get; set; } // Thêm vào giá bán nhỏ
        public int SoLuongTonLon { get; set; } // Số lượng tồn lớn
        public int SoLuongTonNho { get; set; } // Số lượng tồn nhỏ

        // Constructor để tạo từ BsonDocument
        public HH(BsonDocument document)
        {
            Id = document["_id"].AsObjectId;
            TenHH = document["tenHH"].AsString;
            MaLoaiHH = document["maLoaiHH"].AsObjectId;
            DonViTinhLon = document["donViTinhLon"].AsString;
            DonViTinhNho = document["donViTinhNho"].AsString;
            MoTa = document.Contains("moTa") ? document["moTa"].AsString : string.Empty;
            GiaBanLon = document["giaBanLon"].ToDecimal(); // Lấy giá bán lớn
            GiaBanNho = document["giaBanNho"].ToDecimal(); // Lấy giá bán nhỏ
            SoLuongTonLon = document["soLuongTonLon"].AsInt32; // Lấy số lượng tồn lớn
            SoLuongTonNho = document["soLuongTonNho"].AsInt32; // Lấy số lượng tồn nhỏ
        }

        // Constructor khác nếu cần
        public HH(ObjectId id, string tenHH, ObjectId maLoaiHH, decimal soLuong, string donViTinhLon, string donViTinhNho, string moTa, decimal giaBanLon, decimal giaBanNho, int soLuongTonLon, int soLuongTonNho)
        {
            Id = id;
            TenHH = tenHH;
            MaLoaiHH = maLoaiHH;
            SoLuong = soLuong;
            DonViTinhLon = donViTinhLon;
            DonViTinhNho = donViTinhNho;
            MoTa = moTa;
            GiaBanLon = giaBanLon;
            GiaBanNho = giaBanNho;
            SoLuongTonLon = soLuongTonLon;
            SoLuongTonNho = soLuongTonNho;
        }
    }
}
