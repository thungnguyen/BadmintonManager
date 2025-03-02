using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BadmintonManager.DTO;
using System.Linq;

namespace BadmintonManager.DAL
{
    public class LichDatSanDAL
    {
        private readonly MongoDBConnection _mongoConnection;
        private readonly IMongoCollection<BsonDocument> _lichDatSanCollection;
        private readonly IMongoCollection<BsonDocument> _chiTietCollection;

        public LichDatSanDAL()
        {
            _mongoConnection = new MongoDBConnection();
            _lichDatSanCollection = _mongoConnection.GetCollection<BsonDocument>("LichDatSan");
            _chiTietCollection = _mongoConnection.GetCollection<BsonDocument>("ChiTietLichDatSan");
        }

        public ObjectId GetMaSan(string tenSan)
        {
            var sanCollection = _mongoConnection.GetCollection<BsonDocument>("San");
            var filter = Builders<BsonDocument>.Filter.Eq("TenSan", tenSan);
            var san = sanCollection.Find(filter).FirstOrDefault();
            return san != null ? san["_id"].AsObjectId : ObjectId.Empty;
        }

        public ObjectId GetMaKH(string tenKH)
        {
            var khachHangCollection = _mongoConnection.GetCollection<BsonDocument>("KhachHang");
            var filter = Builders<BsonDocument>.Filter.Eq("TenKH", tenKH);
            var khachHang = khachHangCollection.Find(filter).FirstOrDefault();
            return khachHang != null ? khachHang["_id"].AsObjectId : ObjectId.Empty;
        }


        public int LayMaGia(string loaiKhach, TimeSpan gioBatDau)
        {
            var bangGiaCollection = _mongoConnection.GetCollection<BsonDocument>("BangGiaSan");
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("LoaiKH", loaiKhach),
                Builders<BsonDocument>.Filter.Lte("GioBatDau", gioBatDau),
                Builders<BsonDocument>.Filter.Gt("GioKetThuc", gioBatDau)
            );
            var bangGia = bangGiaCollection.Find(filter)
                                         .SortBy(x => x["GioBatDau"])
                                         .FirstOrDefault();
            return bangGia != null ? bangGia["MaGia"].AsInt32 : 0;
        }

        public List<LichDatSanDTO> GetLichDatSanByMaSan(string maSan, List<DateTime> cacNgayDat)
        {
            try
            {
                var result = new List<LichDatSanDTO>();

                if (!int.TryParse(maSan, out int maSanInt))
                {
                    throw new ArgumentException("Mã sân không hợp lệ");
                }

                var lichDatSanFilter = Builders<BsonDocument>.Filter.Eq("maSan", maSanInt);
                var lichDatSanDocs = _lichDatSanCollection.Find(lichDatSanFilter).ToList();
                var maDatSanList = lichDatSanDocs.Select(x => x["maDatSan"].AsInt32).ToList();

                if (maDatSanList.Any())
                {
                    var filter = Builders<BsonDocument>.Filter.And(
                        Builders<BsonDocument>.Filter.In("maDatSan", maDatSanList),
                        Builders<BsonDocument>.Filter.In("ngay", cacNgayDat)
                    );

                    var chiTietLichDat = _chiTietCollection.Find(filter).ToList();

                    foreach (var chiTiet in chiTietLichDat)
                    {
                        try
                        {
                            var dto = new LichDatSanDTO
                            {
                                NgayDat = new List<DateTime> { chiTiet["ngay"].ToUniversalTime() },
                                TuGio = TimeSpan.Parse(chiTiet["tuGio"].AsString),
                                DenGio = TimeSpan.Parse(chiTiet["denGio"].AsString)
                            };
                            result.Add(dto);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Lỗi khi chuyển đổi dữ liệu chi tiết: {ex.Message}");
                            continue; 
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy lịch đặt sân: {ex.Message}");
            }
        }


        public int InsertLichDatSan(LichDatSanDTO dto)
        {
            var maDatSan = GetNextMaDatSan();
            var document = new BsonDocument
        {
            { "maDatSan", maDatSan },
            { "maSan", dto.MaSan },
            { "maKH", dto.MaKH },
            { "tuNgay", dto.TuNgay },
            { "denNgay", dto.DenNgay },
            { "tuGio", dto.TuGio.ToString() },
            { "denGio", dto.DenGio.ToString() },
            { "loaiKH", dto.LoaiKH },
            { "soBuoi", dto.SoBuoi },
            { "layGia", dto.LayGia },
            { "canThanhToan", dto.CanThanhToan },
            { "daTra", dto.DaTra },
            { "conLai", dto.ConLai },
            { "thoiGian", dto.ThoiGian.ToString() }
        };

            _lichDatSanCollection.InsertOne(document);
            return maDatSan;
        }


        private int GetNextMaDatSan()
        {
            var sort = Builders<BsonDocument>.Sort.Descending("maDatSan");
            var lastRecord = _lichDatSanCollection.Find(new BsonDocument())
                                                .Sort(sort)
                                                .Limit(1)
                                                .FirstOrDefault();
            return lastRecord != null ? lastRecord["maDatSan"].AsInt32 + 1 : 1;
        }
        // Trong LichDatSanDAL.cs
        public (bool isTrung, List<DateTime> ngayTrung, List<string> thoiGianTrung) CheckTrungLich(LichDatSanDTO lichDatSan)
        {
            try
            {
                var ngayTrung = new List<DateTime>();
                var thoiGianTrung = new List<string>();

                var lichDatSanFilter = Builders<BsonDocument>.Filter.Eq("maSan", lichDatSan.MaSan);
                var lichDatSanDocs = _lichDatSanCollection.Find(lichDatSanFilter).ToList();

                if (!lichDatSanDocs.Any())
                {
                    return (false, ngayTrung, thoiGianTrung);
                }

                var maDatSanList = lichDatSanDocs.Select(x => x["maDatSan"].AsInt32).ToList();

                foreach (var ngay in lichDatSan.NgayDat)
                {
                    var chiTietFilter = Builders<BsonDocument>.Filter.And(
                        Builders<BsonDocument>.Filter.In("maDatSan", maDatSanList),
                        Builders<BsonDocument>.Filter.Eq("ngay", ngay.Date)
                    );

                    var chiTietList = _chiTietCollection.Find(chiTietFilter).ToList();

                    foreach (var chiTiet in chiTietList)
                    {
                        var tuGioDb = TimeSpan.Parse(chiTiet["tuGio"].AsString);
                        var denGioDb = TimeSpan.Parse(chiTiet["denGio"].AsString);

                        bool isTrungGio = (lichDatSan.TuGio < denGioDb && lichDatSan.DenGio > tuGioDb);

                        if (isTrungGio)
                        {
                            ngayTrung.Add(ngay.Date);
                            thoiGianTrung.Add($"{tuGioDb.ToString(@"hh\:mm")} - {denGioDb.ToString(@"hh\:mm")}");
                            break; // Thoát vòng lặp chiTietList khi đã tìm thấy trùng
                        }
                    }
                }

                return (ngayTrung.Any(), ngayTrung, thoiGianTrung);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi kiểm tra trùng lịch: {ex.Message}");
            }
        }


        public void InsertChiTietLichDatSan(int maDatSan, List<DateTime> ngayDat, TimeSpan tuGio, TimeSpan denGio)
        {
            var documents = new List<BsonDocument>();
            int maChiTiet = GetNextMaChiTiet();

            foreach (var ngay in ngayDat)
            {

                var document = new BsonDocument
            {
                { "maChiTiet", maChiTiet++ },
                { "maDatSan", maDatSan }, // Sử dụng kiểu int thay vì string
                { "ngay", ngay },
                { "tuGio", tuGio.ToString() },
                { "denGio", denGio.ToString() }
            };
                documents.Add(document);
            }

            _chiTietCollection.InsertMany(documents);
        }



        private int GetNextMaChiTiet()
        {
            var sort = Builders<BsonDocument>.Sort.Descending("maChiTiet");
            var lastRecord = _chiTietCollection.Find(new BsonDocument())
                                             .Sort(sort)
                                             .Limit(1)
                                             .FirstOrDefault();
            return lastRecord != null ? lastRecord["maChiTiet"].AsInt32 + 1 : 1;
        }


        public List<LichDatSanDTO> GetLichDatSanDtoByDate(DateTime ngayChon)
        {
            try
            {
                // Lấy tất cả các sân trong hệ thống
                var sanCollection = _mongoConnection.GetCollection<BsonDocument>("San");
                var sanDocs = sanCollection.Find(new BsonDocument()).ToList();

                // Kiểm tra và lấy danh sách tên sân, nếu không có trường "tenSan" sẽ trả về chuỗi rỗng
                var danhSachSan = sanDocs.Select(x =>
                {
                    return x.Contains("tenSan") ? x["tenSan"].AsString : string.Empty;
                }).Where(x => !string.IsNullOrEmpty(x)).ToList();  // Lọc bỏ các tên sân rỗng

                // Danh sách kết quả LichDatSanDTO
                var result = new List<LichDatSanDTO>();

                // Duyệt qua từng sân để lấy lịch đặt sân
                foreach (var tenSan in danhSachSan)
                {
                    // Lấy mã sân tương ứng với tên sân
                    var maSan = GetMaSan(tenSan);
                    if (maSan == ObjectId.Empty)
                    {
                        continue; // Nếu không tìm thấy mã sân thì bỏ qua
                    }

                    // Gọi phương thức GetLichDatSanByMaSan để lấy danh sách lịch đặt cho sân đó
                    var lichDatSanList = GetLichDatSanByMaSan(maSan.ToString(), new List<DateTime> { ngayChon });

                    // Thêm vào kết quả nếu có lịch đặt cho ngày chọn
                    result.AddRange(lichDatSanList);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy lịch đặt sân theo ngày: {ex.Message}");
            }
        }
    }
}