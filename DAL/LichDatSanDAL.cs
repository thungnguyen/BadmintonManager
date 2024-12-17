using MongoDB.Driver;
using BadmintonManager.DTO;
using System;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace BadmintonManager.DAL
{
    public class LichDatSanDAL
    {
        private readonly MongoDBConnection _mongoDBConnection;

        public LichDatSanDAL()
        {
            _mongoDBConnection = new MongoDBConnection();
        }

        public int GetMaSan(string tenSan)
        {
            var sanCollection = _mongoDBConnection.GetCollection<SanDTO>("San");
            var san = sanCollection.Find(s => s.TenSan == tenSan).FirstOrDefault();
            return san?.MaSan ?? 0;
        }

        public int GetMaKH(string tenKH)
        {
            var khachHangCollection = _mongoDBConnection.GetCollection<KhachHangDTO>("KhachHang");
            var khachHang = khachHangCollection.Find(k => k.TenKH == tenKH).FirstOrDefault();
            return khachHang?.MaKH ?? 0;
        }

        public int LayMaGia(string loaiKhach, TimeSpan gioBatDau)
        {
            // Lấy collection từ MongoDB
            var bangGiaSanCollection = _mongoDBConnection.GetCollection<BsonDocument>("BangGiaSan");

            // Tìm bản ghi giá sân phù hợp dựa trên loại khách và thời gian bắt đầu
            var gia = bangGiaSanCollection.AsQueryable()
                .FirstOrDefault(b => b["LoaiKH"].AsString == loaiKhach
                                  && b["gioBatDau"].ToUniversalTime().TimeOfDay <= gioBatDau
                                  && b["gioKetThuc"].ToUniversalTime().TimeOfDay > gioBatDau);

            // Trả về mã giá (MaGia), hoặc 0 nếu không tìm thấy
            return gia?["maGia"]?.ToInt32() ?? 0;
        }







        public List<LichDatSanDTO> GetLichDatSanByMaSan(int maSan, List<DateTime> cacNgayDat)
        {
            var lichDatSanCollection = _mongoDBConnection.GetCollection<LichDatSanDTO>("LichDatSan");

            var lichDatSanList = lichDatSanCollection.AsQueryable()
                .Where(lds => lds.MaSan == maSan && cacNgayDat.Select(d => d.Date).Contains(lds.TuNgay.Date))
                .ToList();

            return lichDatSanList;
        }

        public void InsertLichDatSan(LichDatSanDTO dto)
        {
            var lichDatSanCollection = _mongoDBConnection.GetCollection<LichDatSanDTO>("LichDatSan");
            lichDatSanCollection.InsertOne(dto);
        }

        public bool CheckTrungLich(LichDatSanDTO lichDatSan)
        {
            var chiTietLichDatSanCollection = _mongoDBConnection.GetCollection<ChiTietLichDatSan>("ChiTietLichDatSan");

            foreach (var ngay in lichDatSan.NgayDat)
            {
                var conflict = chiTietLichDatSanCollection.AsQueryable()
                    .Any(ct => ct.MaSan == lichDatSan.MaSan && ct.Ngay == ngay &&
                               ((lichDatSan.TuGio >= ct.TuGio && lichDatSan.TuGio < ct.DenGio) ||
                                (lichDatSan.DenGio > ct.TuGio && lichDatSan.DenGio <= ct.DenGio)));

                if (conflict) return true;
            }

            return false;
        }

        public void InsertChiTietLichDatSan(int maDatSan, List<DateTime> ngayDat, TimeSpan tuGio, TimeSpan denGio)
        {
            var chiTietLichDatSanCollection = _mongoDBConnection.GetCollection<ChiTietLichDatSan>("ChiTietLichDatSan");

            foreach (var ngay in ngayDat)
            {
                var chiTiet = new ChiTietLichDatSan
                {
                    MaDatSan = maDatSan,
                    Ngay = ngay,
                    TuGio = tuGio,
                    DenGio = denGio
                };
                chiTietLichDatSanCollection.InsertOne(chiTiet);
            }
        }
    }
}