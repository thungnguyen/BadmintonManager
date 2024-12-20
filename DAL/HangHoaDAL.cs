using System.Collections.Generic;
using MongoDB.Driver;
using BadmintonManager.DTO;

namespace BadmintonManager.DAL
{
    /// <summary>
    /// Data Access Layer for HangHoa (Product) operations using MongoDB
    /// </summary>
    public class HangHoaDAL
    {
        private readonly IMongoCollection<HangHoa> _collection;

        public HangHoaDAL()
        {
            var connection = new MongoDBConnection();
            _collection = connection.GetCollection<HangHoa>("HangHoa");
        }

        // Lấy danh sách hàng hóa
        public List<HangHoa> ListHangHoa(string sortCriteria = null)
        {
            var filter = FilterDefinition<HangHoa>.Empty;
            var sort = string.IsNullOrEmpty(sortCriteria)
                ? null
                : Builders<HangHoa>.Sort.Ascending(sortCriteria);

            return sort != null
                ? _collection.Find(filter).Sort(sort).ToList()
                : _collection.Find(filter).ToList();
        }

        // Thêm hàng hóa
        public void ThemHH(HangHoa newHH)
        {
            _collection.InsertOne(newHH);
        }

        // Sửa hàng hóa
        public void SuaHH(HangHoa updatedHH)
        {
            var filter = Builders<HangHoa>.Filter.Eq(hh => hh.MaHH, updatedHH.MaHH);
            var update = Builders<HangHoa>.Update
                                          .Set(hh => hh.TenHH, updatedHH.TenHH)
                                          .Set(hh => hh.MoTa, updatedHH.MoTa)
                                          .Set(hh => hh.DonViTinhLon, updatedHH.DonViTinhLon)
                                          .Set(hh => hh.DonViTinhNho, updatedHH.DonViTinhNho)
                                          .Set(hh => hh.HeSoQuyDoi, updatedHH.HeSoQuyDoi)
                                          .Set(hh => hh.GiaNhapLon, updatedHH.GiaNhapLon)
                                          .Set(hh => hh.GiaNhapNho, updatedHH.GiaNhapNho)
                                          .Set(hh => hh.GiaBanLon, updatedHH.GiaBanLon)
                                          .Set(hh => hh.GiaBanNho, updatedHH.GiaBanNho)
                                          .Set(hh => hh.SoLuongTonLon, updatedHH.SoLuongTonLon)
                                          .Set(hh => hh.SoLuongTonNho, updatedHH.SoLuongTonNho)
                                          .Set(hh => hh.MaLoaiHH, updatedHH.MaLoaiHH);
            _collection.UpdateOne(filter, update);
        }

        // Xóa hàng hóa
        public void XoaHH(string Id)
        {
            var filter = Builders<HangHoa>.Filter.Eq(hh => hh._id, Id);
            _collection.DeleteOne(filter);
        }
    }
}
