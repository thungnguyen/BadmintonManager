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
        //Lấy hàng hoá ra từ maHH
        public HangHoa LayHangHoaByID(int maHH)
        {
            if (maHH <= 0)
            {
                throw new ArgumentException("Invalid MaHH. It must be a positive integer.");
            }

            // Fetch the MongoDB collection
            var collection = _connection.GetCollection<BsonDocument>("HangHoa");

            // Create a filter for the document to retrieve
            var filter = Builders<BsonDocument>.Filter.Eq("maHH", maHH);

            // Retrieve the document
            var document = collection.Find(filter).FirstOrDefault();

            if (document == null)
            {
                throw new Exception($"No HangHoa found with MaHH = {maHH}.");
            }

            // Map the BsonDocument to the HangHoa object
            HangHoa hangHoa = new HangHoa
            {
                Id = document["_id"].ToString(),
                MaHH = document["maHH"].ToInt32(),
                TenHH = document["tenHH"].ToString(),
                MoTa = document["moTa"].ToString(),
                DonViTinhLon = document["donViTinhLon"].ToString(),
                DonViTinhNho = document["donViTinhNho"].ToString(),
                HeSoQuyDoi = document["heSoQuyDoi"].ToInt32(),
                GiaNhapLon = document["giaNhapLon"].ToDecimal(),
                GiaNhapNho = document["giaNhapNho"].ToDecimal(),
                GiaBanLon = document["giaBanLon"].ToDecimal(),
                GiaBanNho = document["giaBanNho"].ToDecimal(),
                SoLuongTonLon = document["soLuongTonLon"].ToInt32(),
                SoLuongTonNho = document["soLuongTonNho"].ToInt32(),
                MaLoaiHH = document["maLoaiHH"].ToString()
            };

            return hangHoa;
        }

        public int GetNextMaHH()
        {
            var collection = _connection.GetCollection<BsonDocument>("Counters");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", "maHH");
            var update = Builders<BsonDocument>.Update.Inc("sequence_value", 1);

            // Tìm và cập nhật bộ đếm, đồng thời lấy giá trị mới
            var result = collection.FindOneAndUpdate(filter, update, new FindOneAndUpdateOptions<BsonDocument>
            {
                ReturnDocument = ReturnDocument.After // Lấy giá trị sau khi cập nhật
            });

            if (result == null || !result.Contains("sequence_value"))
            {
                throw new Exception("Failed to retrieve or update the sequence value for MaHH.");
            }

            // Return the sequence_value as an integer
            return result["sequence_value"].AsInt32;
        }



        // Thêm hàng hóa
        public void ThemHH(BsonDocument newhh)
        {
            int nextMaHH = GetNextMaHH();
            newhh["maHH"] = Convert.ToInt32(nextMaHH);

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
        public void XoaHH(int maHH)
        {
            if (maHH <= 0) // Validate for invalid integer values
            {
                throw new ArgumentException("Invalid MaHH for deletion. It must be a positive integer.");
            }

            // Fetch the MongoDB collection
            var collection = _connection.GetCollection<BsonDocument>("HangHoa");

            // Create a filter for the document to delete
            var filter = Builders<BsonDocument>.Filter.Eq("maHH", maHH);

            try
            {
                // Attempt to delete the document
                var result = collection.DeleteOne(filter);

                if (result.DeletedCount == 0)
                {
                    throw new Exception($"No document found with MaHH = {maHH}.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting HangHoa: {ex.Message}");
            }
        }

    }
}
