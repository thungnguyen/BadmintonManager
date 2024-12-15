using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using MongoDB.Bson;

namespace BadmintonManager.DTO
{
    public class BangGiaSanDTO
    {
        public int MaGia { get; set; }
        public string LoaiKH { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }
        public decimal Gia { get; set; }

        public BangGiaSanDTO() { }

        // Constructor nhận vào BsonDocument từ MongoDB
        public BangGiaSanDTO(BsonDocument doc)
        {
            MaGia = doc["maGia"].AsInt32;  // Lấy giá trị maGia từ BsonDocument
            LoaiKH = doc["loaiKH"].AsString;  // Lấy giá trị loaiKH từ BsonDocument

            // Chuyển đổi chuỗi thời gian từ MongoDB thành TimeSpan
            GioBatDau = TimeSpan.Parse(doc["gioBatDau"].AsString);  // Chuyển đổi từ chuỗi thành TimeSpan
            GioKetThuc = TimeSpan.Parse(doc["gioKetThuc"].AsString);  // Chuyển đổi từ chuỗi thành TimeSpan

            Gia = doc["gia"].AsDecimal;  // Lấy giá trị gia từ BsonDocument
        }
    }
}


