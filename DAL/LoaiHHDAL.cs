using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using BadmintonManager.DTO;

namespace BadmintonManager.DAL
{
    /// <summary>
    /// Data Access Layer for LoaiHH (Category) operations using MongoDB
    /// </summary>
    public class LoaiHHDAL
    {
        private readonly MongoDBConnection _connection;

        public LoaiHHDAL()
        {
            _connection = new MongoDBConnection();
        }

        // Get a list of all categories
        public List<BsonDocument> ListLoaiHH(string sortCriteria = null)
        {
            var collection = _connection.GetCollection<BsonDocument>("LoaiHH");
            return collection.Find(FilterDefinition<BsonDocument>.Empty).ToList();
        }

        // Add a new category
        public void ThemLoaiHH(LoaiHH newLoaiHH)
        {
            var collection = _connection.GetCollection<LoaiHH>("LoaiHH");
            collection.InsertOne(newLoaiHH);
        }

        // Update an existing category
        public void SuaLoaiHH(LoaiHH updatedLoaiHH)
        {
            var collection = _connection.GetCollection<LoaiHH>("LoaiHH");
            var filter = Builders<LoaiHH>.Filter.Eq(loaihh => loaihh.MaLoaiHH, updatedLoaiHH.MaLoaiHH);
            var update = Builders<LoaiHH>.Update
                .Set(loaihh => loaihh.MaLoaiHH, updatedLoaiHH.MaLoaiHH)
                .Set(loaihh => loaihh.TenLoaiHH, updatedLoaiHH.TenLoaiHH);
            collection.UpdateOne(filter, update);
        }

        // Delete a category
        public void XoaLoaiHH(string maloaihh)
        {
            if (string.IsNullOrEmpty(maloaihh))
            {
                throw new ArgumentException("Mã Loại Hàng Hoá không hợp lệ.");
            }

            var collection = _connection.GetCollection<BsonDocument>("LoaiHH"); // Fetch the collection
            var filter = Builders<BsonDocument>.Filter.Eq("MaLoaiHH", maloaihh);

            try
            {
                var result = collection.DeleteOne(filter);
                if (result.DeletedCount == 0)
                {
                    throw new Exception("No document found with the specified MaHH.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting HangHoa: {ex.Message}");
            }
        }
    }
}
