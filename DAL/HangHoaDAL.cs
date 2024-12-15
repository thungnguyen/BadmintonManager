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
            var hhList = collection.Find(FilterDefinition<BsonDocument>.Empty).ToList();
            return hhList;
        }

        // Thêm hàng hóa
        public void ThemHH(BsonDocument newhh)
        {
            var collection = _connection.GetCollection<BsonDocument>("HangHoa");
            collection.InsertOne(newhh);
        }

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

        public void XoaHH(HangHoa hh)
        {
            var collection = _connection.GetCollection<HangHoa>("HangHoa");
            var filter = Builders<HangHoa>.Filter.Eq("maHH", hh.MaHH);
            var réult = collection.DeleteOne(filter);
        }

       
    }
}
