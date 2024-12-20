using BadmintonManager.DTO;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BadmintonManager.DAO
{
    internal class PricePerHourDAO
    {
        private static PricePerHourDAO instance;

        public static PricePerHourDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PricePerHourDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private PricePerHourDAO() { }

        // Kiểm tra số lượng khung giờ trùng với thời gian bắt đầu và kết thúc
        public int CheckFrameCount(TimeSpan gioBatDau, TimeSpan gioKetThuc)
        {
            // Tạo bộ lọc để kiểm tra các khung giờ bị chồng lấn
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Lt("gioBatDau", gioKetThuc.ToString(@"hh\:mm\:ss")), // @gioKetThuc > GioBatDau
                Builders<BsonDocument>.Filter.Gt("gioKetThuc", gioBatDau.ToString(@"hh\:mm\:ss"))  // @gioBatDau < GioKetThuc
            );
            var documents = MongoDataProvider.Instance.ExecuteQuery("BangGiaSan", filter);

            // Truy vấn từ MongoDB, chỉ lấy các giá trị gioBatDau duy nhất
            var frameCount = documents
                .Select(doc => TimeSpan.Parse(doc["gioBatDau"].ToString())) // Chuyển đổi từ string sang TimeSpan
                .Distinct() // Lọc ra các giá trị duy nhất
                .Count(); // Đếm số lượng giá trị duy nhất

            return frameCount;
        }


        // Lấy giá theo khung giờ cho khách hàng
        public decimal GetPriceForTimeSlot(TimeSpan gioBatDau, TimeSpan gioKetThuc, string loaiKH)
        {
            decimal giaGioChoi = 0;

            // Tính số giờ chơi
            int soGioChoi = (int)(gioKetThuc - gioBatDau).TotalHours;

            // Kiểm tra nếu số giờ chơi không hợp lệ
            if (soGioChoi <= 0)
            {
                return 0;
            }

            // Lọc theo thời gian bắt đầu, kết thúc và loại khách hàng
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("loaiKH", loaiKH),
                Builders<BsonDocument>.Filter.Or(
                    Builders<BsonDocument>.Filter.And(
                        Builders<BsonDocument>.Filter.Lt("gioBatDau", gioKetThuc.ToString(@"hh\:mm\:ss")),
                        Builders<BsonDocument>.Filter.Gt("gioKetThuc", gioBatDau.ToString(@"hh\:mm\:ss"))
                    ),
                    Builders<BsonDocument>.Filter.And(
                        Builders<BsonDocument>.Filter.Lt("gioKetThuc", gioKetThuc.ToString(@"hh\:mm\:ss")),
                        Builders<BsonDocument>.Filter.Gt("gioBatDau", gioBatDau.ToString(@"hh\:mm\:ss"))
                    )
                )
            );

            // Truy vấn từ MongoDB và lấy danh sách các BangGiaSanDTO
            var documents = MongoDataProvider.Instance.ExecuteQuery("BangGiaSan", filter)
                .Select(doc => new BangGiaSanDTO(doc)) // Chuyển đổi thành BangGiaSanDTO
                .ToList();

            // Kiểm tra nếu có kết quả và lấy giá
            if (documents.Any())
            {
                giaGioChoi = documents.FirstOrDefault().Gia * soGioChoi;
            }

            return giaGioChoi;
        }


        // Lấy giá giữa các khung giờ
        public decimal GetPriceBetweenTimeFrames(TimeSpan gioBatDau, TimeSpan gioKetThuc, string loaiKH)
        {
            decimal giaGioChoi = 0;

            // Tính số giờ chơi
            int soGioChoi = (int)(gioKetThuc - gioBatDau).TotalHours;
            if (soGioChoi <= 0)
            {
                return 0;
            }

            // Chuyển đổi TimeSpan sang định dạng chuỗi
            string gioBatDauStr = gioBatDau.ToString(@"hh\:mm\:ss");
            string gioKetThucStr = gioKetThuc.ToString(@"hh\:mm\:ss");

            // Lọc các tài liệu có thời gian giao nhau với khung giờ chơi
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("loaiKH", loaiKH),
                Builders<BsonDocument>.Filter.Lt("gioBatDau", gioKetThucStr),
                Builders<BsonDocument>.Filter.Gt("gioKetThuc", gioBatDauStr)
            );

            var documents = MongoDataProvider.Instance.ExecuteQuery("BangGiaSan", filter)
                .Select(doc => new BangGiaSanDTO(doc))
                .ToList();

            // Tính giá cho từng tài liệu
            foreach (var doc in documents)
            {
                // Tính khoảng thời gian giao nhau
                var start = doc.GioBatDau;
                var end = doc.GioKetThuc;

                var gioBatDauThucTe = gioBatDau > start ? gioBatDau : start;
                var gioKetThucThucTe = gioKetThuc < end ? gioKetThuc : end;

                int soGioThucTe = (int)(gioKetThucThucTe - gioBatDauThucTe).TotalHours;
                giaGioChoi += doc.Gia * soGioThucTe;
            }

            return giaGioChoi;
        }


    }
}
