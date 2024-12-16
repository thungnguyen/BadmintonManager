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
            var filter = Builders<BsonDocument>.Filter.And(
            Builders<BsonDocument>.Filter.Lt("gioBatDau", gioKetThuc.ToString(@"hh\:mm\:ss")),
            Builders<BsonDocument>.Filter.Gt("gioKetThuc", gioBatDau.ToString(@"hh\:mm\:ss"))
        );
            var frameCount = MongoDataProvider.Instance.ExecuteQuery("BangGiaSan", filter).Count;
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

            // Kiểm tra nếu số giờ chơi không hợp lệ
            if (soGioChoi <= 0)
            {
                return 0;
            }

            decimal gia1 = 0, gia2 = 0;
            int soGio1 = 0, soGio2 = 0;

            // Lọc theo loại khách hàng và thời gian
            var filter1 = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("loaiKH", loaiKH),
                Builders<BsonDocument>.Filter.Lte("gioBatDau", gioKetThuc.ToString(@"hh\:mm\:ss")),
                Builders<BsonDocument>.Filter.Gte("gioKetThuc", gioBatDau.ToString(@"hh\:mm\:ss"))
            );

            // Truy vấn từ MongoDB cho phần đầu
            var documents1 = MongoDataProvider.Instance.ExecuteQuery("BangGiaSan", filter1)
                .Select(doc => new BangGiaSanDTO(doc)) // Chuyển đổi thành BangGiaSanDTO
                .ToList();

            if (documents1.Any())
            {
                gia1 = documents1.FirstOrDefault().Gia;
                soGio1 = (int)(gioKetThuc - gioBatDau).TotalHours;
            }

            // Lọc và truy vấn từ MongoDB cho phần thứ hai
            var filter2 = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("loaiKH", loaiKH),
                Builders<BsonDocument>.Filter.Lte("gioBatDau", gioKetThuc.ToString(@"hh\:mm\:ss")),
                Builders<BsonDocument>.Filter.Gte("gioKetThuc", gioBatDau.ToString(@"hh\:mm\:ss"))
            );

            var documents2 = MongoDataProvider.Instance.ExecuteQuery("BangGiaSan", filter2)
                .Select(doc => new BangGiaSanDTO(doc))
                .ToList();

            if (documents2.Any())
            {
                gia2 = documents2.FirstOrDefault().Gia;
                soGio2 = (int)(gioKetThuc - gioBatDau).TotalHours;
            }

            // Tính giá cho từng phần
            if (gia1 > 0 && gia2 > 0)
            {
                giaGioChoi = (gia1 * soGio1) + (gia2 * soGio2);
            }
            else if (gia1 > 0)
            {
                giaGioChoi = gia1 * soGio1;
            }
            else if (gia2 > 0)
            {
                giaGioChoi = gia2 * soGio2;
            }

            return giaGioChoi;
        }

    }
}
