using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using BadmintonManager.DTO;

namespace BadmintonManager.DAL
{
    /// <summary>
    /// Data Access Layer for HangHoa (Product) operations using MongoDB
    /// </summary>
    public class HangHoaDAL
    {
        private readonly MongoDBConnection _connection;

        public HangHoaDAL()
        {
            _connection = new MongoDBConnection();
        }

        // Lấy danh sách hàng hóa
        public List<BsonDocument> ListHangHoa(string sortCriteria = null)
        {
            var collection = _connection.GetCollection<BsonDocument>("HangHoa");
            return collection.Find(FilterDefinition<BsonDocument>.Empty).ToList();
        }

        public string GetNextMaHH()
        {
            var collection = _connection.GetCollection<BsonDocument>("Counters");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", "MaHH");
            var update = Builders<BsonDocument>.Update.Inc("sequence_value", 1);

            // Tìm và cập nhật bộ đếm, đồng thời lấy giá trị mới
            var result = collection.FindOneAndUpdate(filter, update, new FindOneAndUpdateOptions<BsonDocument>
            {
                ReturnDocument = ReturnDocument.After
            });

            return result["sequence_value"].ToString();  // Trả về giá trị mới của MaHH
        }

        // Thêm hàng hóa
        public void ThemHH(BsonDocument newhh)
        {
            var nextMaHH = GetNextMaHH();
            newhh["MaHH"] = nextMaHH;

            var collection = _connection.GetCollection<BsonDocument>("HangHoa");
            collection.InsertOne(newhh);
        }

        // Sửa hàng hóa
        public void SuaHH(HangHoa updatedhh)
        {
            var collection = _connection.GetCollection<HangHoa>("HangHoa");
            var filter = Builders<HangHoa>.Filter.Eq(hh => hh.MaHH, updatedhh.MaHH);
            var update = Builders<HangHoa>.Update
                .Set(hh => hh.TenHH, updatedhh.TenHH)
                .Set(hh => hh.MoTa, updatedhh.MoTa)
                .Set(hh => hh.DonViTinhLon, updatedhh.DonViTinhLon)
                .Set(hh => hh.DonViTinhNho, updatedhh.DonViTinhNho)
                .Set(hh => hh.HeSoQuyDoi, updatedhh.HeSoQuyDoi)
                .Set(hh => hh.GiaNhapLon, updatedhh.GiaNhapLon)
                .Set(hh => hh.GiaBanLon, updatedhh.GiaBanLon)
                .Set(hh => hh.GiaBanNho, updatedhh.GiaBanNho)
                .Set(hh => hh.SoLuongTonLon, updatedhh.SoLuongTonLon)
                .Set(hh => hh.SoLuongTonNho, updatedhh.SoLuongTonNho)
                .Set(hh => hh.MaLoaiHH, updatedhh.MaLoaiHH);
            collection.UpdateOne(filter, update);
        }

        // Xoá hàng hóa
        public void XoaHH(string maHH)
        {
            if (string.IsNullOrEmpty(maHH))
            {
                throw new ArgumentException("Invalid MaHH for deletion.");
            }

            var collection = _connection.GetCollection<BsonDocument>("HangHoa"); // Fetch the collection
            var filter = Builders<BsonDocument>.Filter.Eq("maHH", maHH);

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
