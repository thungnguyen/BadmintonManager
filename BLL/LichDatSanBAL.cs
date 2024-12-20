using BadmintonManager.DAL;
using BadmintonManager.DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BadmintonManager.BAL
{
    public class LichDatSanBAL
    {
        private readonly LichDatSanDAL _dal;

        public LichDatSanBAL()
        {
            _dal = new LichDatSanDAL();
        }

        public bool SaveLichDatSan(LichDatSanDTO dto)
        {
            try
            {
                // Insert LichDatSan and get the maDatSan
                int maDatSan = _dal.InsertLichDatSan(dto);
                if (maDatSan == 0)
                {
                    MessageBox.Show("Không thể lấy mã đặt sân.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Insert ChiTietLichDatSan
                _dal.InsertChiTietLichDatSan(maDatSan, dto.NgayDat, dto.TuGio, dto.DenGio);

                MessageBox.Show("Đã lưu lịch đặt sân thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu lịch đặt sân: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public int LayMaGia(bool loaiKhachChecked, DateTime tuGio)
        {
            string loaiKhach = loaiKhachChecked ? "Co dinh" : "Vang lai";
            return _dal.LayMaGia(loaiKhach, tuGio.TimeOfDay);
        }

        //public string GetMaSan(string tenSan)
        //{
        //    return _dal.GetMaSan(tenSan);
        //}

        //public string GetMaKH(string tenKH)
        //{
        //    return _dal.GetMaKH(tenKH);
        //}

        // BAL Layer
        // Trong LichDatSanBAL.cs
        public (bool isTrung, List<DateTime> ngayTrung, List<string> thoiGianTrung) CheckTrungLich(LichDatSanDTO lichDatSan)
        {
            return _dal.CheckTrungLich(lichDatSan);
        }
        public bool KiemTraTrungLich(string maSan, List<DateTime> cacNgayDat, TimeSpan tuGio, TimeSpan denGio)
        {
            var lichDatSanList = _dal.GetLichDatSanByMaSan(maSan, cacNgayDat);

            foreach (var lichDatSan in lichDatSanList)
            {
                foreach (var ngayDat in lichDatSan.NgayDat)
                {
                    if ((tuGio >= lichDatSan.TuGio && tuGio < lichDatSan.DenGio) ||
                        (denGio > lichDatSan.TuGio && denGio <= lichDatSan.DenGio))
                    {
                        return true; // Trùng lịch
                    }
                }
            }

            return false; // Không trùng lịch
        }

        public bool KiemTraTrungLichMongo(LichDatSanDTO lichDatSan)
        {
            bool isTrungLich = false;

            // Kết nối MongoDB
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("BadmintonManager");
            var collection = database.GetCollection<BsonDocument>("ChiTietLichDatSan");

            foreach (DateTime ngay in lichDatSan.NgayDat)
            {
                // Truy vấn MongoDB để kiểm tra trùng lịch
                var filter = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("MaSan", lichDatSan.MaSan),
                    Builders<BsonDocument>.Filter.Eq("Ngay", ngay),
                    Builders<BsonDocument>.Filter.Or(
                        Builders<BsonDocument>.Filter.And(
                            Builders<BsonDocument>.Filter.Lte("TuGio", lichDatSan.TuGio),
                            Builders<BsonDocument>.Filter.Gt("DenGio", lichDatSan.TuGio)
                        ),
                        Builders<BsonDocument>.Filter.And(
                            Builders<BsonDocument>.Filter.Lt("TuGio", lichDatSan.DenGio),
                            Builders<BsonDocument>.Filter.Gte("DenGio", lichDatSan.DenGio)
                        )
                    )
                );

                var result = collection.Find(filter).FirstOrDefault();
                if (result != null)
                {
                    isTrungLich = true;
                    break;
                }
            }

            return isTrungLich;
        }
    }
}