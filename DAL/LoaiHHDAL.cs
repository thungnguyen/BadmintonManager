using System.Collections.Generic;
using MongoDB.Driver;
using BadmintonManager.DTO;

namespace BadmintonManager.DAL
{
    /// <summary>
    /// Data Access Layer for LoaiHH (Product Category) operations using MongoDB
    /// </summary>
    public class LoaiHHDAL
    {
        private readonly IMongoCollection<LoaiHHDTO> _collection;

        public LoaiHHDAL()
        {
            var connection = new MongoDBConnection();
            _collection = connection.GetCollection<LoaiHHDTO>("LoaiHH");
        }

        // Lấy danh sách tất cả loại hàng hóa
        public List<LoaiHHDTO> ListLoaiHH()
        {
            return _collection.Find(FilterDefinition<LoaiHHDTO>.Empty).ToList();
        }

        // Thêm loại hàng hóa mới
        public void ThemLoaiHH(LoaiHHDTO newLoaiHH)
        {
            _collection.InsertOne(newLoaiHH);
        }

        // Sửa thông tin loại hàng hóa
        public void SuaLoaiHH(LoaiHHDTO updatedLoaiHH)
        {
            var filter = Builders<LoaiHHDTO>.Filter.Eq(lh => lh._id, updatedLoaiHH._id);
            var update = Builders<LoaiHHDTO>.Update.Set(lh => lh.TenLoaiHH, updatedLoaiHH.TenLoaiHH);
            _collection.UpdateOne(filter, update);
        }

        // Xóa loại hàng hóa
        public void XoaLoaiHH(string id)
        {
            var filter = Builders<LoaiHHDTO>.Filter.Eq(lh => lh._id, id);
            _collection.DeleteOne(filter);
        }

        // Tìm loại hàng hóa theo ID
        public LoaiHHDTO TimLoaiHHTheoId(string id)
        {
            var filter = Builders<LoaiHHDTO>.Filter.Eq(lh => lh._id, id);
            return _collection.Find(filter).FirstOrDefault();
        }
    }
}
