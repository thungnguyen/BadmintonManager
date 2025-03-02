using BadmintonManager.DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BadmintonManager.DAL
{
    public class NhapHangDAL
    {
        private readonly IMongoCollection<NhapHang> _nhapHangCollection;

        public NhapHangDAL()
        {
            var client = new MongoClient("mongodb+srv://khoa:3112@clusterkhoa.1b5ey.mongodb.net/"); // Kết nối MongoDB
            var database = client.GetDatabase("QuanLySan"); // Tên database
            _nhapHangCollection = database.GetCollection<NhapHang>("NhapHang"); // Tên collection
        }

        // Thêm phiếu nhập
        public void ThemPhieuNhap(NhapHang phieuNhap)
        {
            _nhapHangCollection.InsertOne(phieuNhap);
        }

        // Lấy danh sách phiếu nhập
        public List<NhapHang> LayDanhSachPhieuNhap()
        {
            return _nhapHangCollection.Find(new BsonDocument()).ToList();
        }

        // Tìm phiếu nhập theo mã nhập hàng
        public NhapHang TimPhieuNhapTheoMa(string maNhapHang)
        {
            return _nhapHangCollection.Find(p => p.MaNhapHang == maNhapHang).FirstOrDefault();
        }

        // Cập nhật phiếu nhập
        public bool CapNhatPhieuNhap(string maNhapHang, NhapHang phieuNhapMoi)
        {
            var filter = Builders<NhapHang>.Filter.Eq(p => p.MaNhapHang, maNhapHang);
            var result = _nhapHangCollection.ReplaceOne(filter, phieuNhapMoi);
            return result.ModifiedCount > 0;
        }

        // Xóa phiếu nhập
        public bool XoaPhieuNhap(string maNhapHang)
        {
            var filter = Builders<NhapHang>.Filter.Eq(p => p.MaNhapHang, maNhapHang);
            var result = _nhapHangCollection.DeleteOne(filter);
            return result.DeletedCount > 0;
        }

        // Tìm phiếu nhập theo ObjectId
        public NhapHang TimPhieuNhapTheoId(ObjectId id)
        {
            return _nhapHangCollection.Find(p => p.Id == id).FirstOrDefault();
        }
    }
}
