using BadmintonManager.DAL;
using BadmintonManager.DTO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BadmintonManager.BAL
{
    public class LichDatSanBAL
    {
        private IMongoDatabase _database;
        private LichDatSanDAL _dal = new LichDatSanDAL();

        // Constructor to initialize the database connection
        public LichDatSanBAL()
        {
            // Create an instance of MongoDBConnection to get the database
            var mongoConnection = new MongoDBConnection();
            _database = mongoConnection.Connect();
        }

        public bool SaveLichDatSan(LichDatSanDTO dto)
        {
            try
            {
                // Lưu lịch đặt sân vào MongoDB
                _dal.InsertLichDatSan(dto);

                // Lưu chi tiết lịch đặt sân
                _dal.InsertChiTietLichDatSan(dto.MaDatSan, dto.NgayDat, dto.TuGio, dto.DenGio);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public bool KiemTraTrungLich(int maSan, List<DateTime> cacNgayDat, TimeSpan tuGio, TimeSpan denGio)
        {
            // Kiểm tra trùng lịch qua DAL
            return _dal.CheckTrungLich(new LichDatSanDTO
            {
                MaSan = maSan,
                NgayDat = cacNgayDat,
                TuGio = tuGio,
                DenGio = denGio
            });
        }

        public void InsertChiTietLichDatSan(int maDatSan, List<DateTime> ngayDat, TimeSpan tuGio, TimeSpan denGio)
        {
            var chiTietLichDatSanCollection = _database.GetCollection<ChiTietLichDatSan>("ChiTietLichDatSan");

            foreach (var ngay in ngayDat)
            {
                var chiTiet = new ChiTietLichDatSan
                {
                    MaDatSan = maDatSan,
                    MaChiTiet = GenerateNewChiTietId(),
                    Ngay = ngay,
                    TuGio = tuGio,
                    DenGio = denGio
                };

                chiTietLichDatSanCollection.InsertOne(chiTiet);
            }
        }

        private int GenerateNewChiTietId()
        {
            var chiTietCollection = _database.GetCollection<ChiTietLichDatSan>("ChiTietLichDatSan");
            var lastChiTiet = chiTietCollection.Find(FilterDefinition<ChiTietLichDatSan>.Empty)
                .SortByDescending(ct => ct.MaChiTiet)
                .FirstOrDefault();

            return lastChiTiet != null ? lastChiTiet.MaChiTiet + 1 : 1;
        }

        public int GetMaSan(string tenSan)
        {
            return _dal.GetMaSan(tenSan);
        }

        public int GetMaKH(string tenKH)
        {
            return _dal.GetMaKH(tenKH);
        }

        public int LayMaGia(string loaiKhach, TimeSpan gioBatDau)
        {
            // Lấy mã giá từ DAL
            int maGia = _dal.LayMaGia(loaiKhach, gioBatDau);  // Gọi từ DAL

            // Trả về mã giá
            return maGia;
        }









        public bool CheckTrungLich(LichDatSanDTO lichDatSan)
        {
            return _dal.CheckTrungLich(lichDatSan);
        }
    }
}
