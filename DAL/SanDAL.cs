using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using BadmintonManager.DTO;
using System.Linq;
using System;

namespace BadmintonManager.DAL
{
    public class SanDAL
    {
        private readonly IMongoCollection<SanDTO> _sanCollection;

        public SanDAL()
        {
            var database = new MongoDBConnection().Connect();
            _sanCollection = database.GetCollection<SanDTO>("San");
        }

        // Lấy danh sách sân
        public List<SanDTO> GetSanList()
        {
            try
            {
                return _sanCollection.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất dữ liệu từ MongoDB: " + ex.Message);
            }
        }

        // Thêm sân mới
        public bool AddSan(SanDTO san)
        {
            try
            {
                _sanCollection.InsertOne(san);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sân mới: " + ex.Message);
            }
        }
        // Cập nhật thông tin sân
        public bool UpdateSan(SanDTO san)
        {
            try
            {
                var filter = Builders<SanDTO>.Filter.Eq(s => s.MaSan, san.MaSan);
                var update = Builders<SanDTO>.Update
                    .Set(s => s.TenSan, san.TenSan);

                var result = _sanCollection.UpdateOne(filter, update);
                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật thông tin sân: " + ex.Message);
            }
        }
        // Xóa sân
        public bool DeleteSan(int maSan)
        {
            try
            {
                var filter = Builders<SanDTO>.Filter.Eq(s => s.MaSan, maSan);
                var result = _sanCollection.DeleteOne(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa sân: " + ex.Message);
            }
        }
    }
}