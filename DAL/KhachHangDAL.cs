using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using BadmintonManager.DTO;

namespace BadmintonManager.DAL
{
    public class KhachHangDAL
    {
        private readonly IMongoCollection<KhachHangDTO> _khachHangCollection;

        public KhachHangDAL()
        {
            var database = new MongoDBConnection().Connect();
            _khachHangCollection = database.GetCollection<KhachHangDTO>("KhachHang");
        }

        public bool AddKhachHang(KhachHangDTO khachHang)
        {
            try
            {
                // Lấy mã khách hàng mới
                var sort = Builders<KhachHangDTO>.Sort.Descending(x => x.MaKH);
                var lastCustomer = _khachHangCollection.Find(new BsonDocument()).Sort(sort).FirstOrDefault();

                khachHang.MaKH = (lastCustomer?.MaKH ?? 0) + 1;

                _khachHangCollection.InsertOne(khachHang);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<KhachHangDTO> GetKhachHangList()
        {
            try
            {
                return _khachHangCollection.Find(Builders<KhachHangDTO>.Filter.Empty).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ MongoDB: " + ex.Message);
                return new List<KhachHangDTO>();
            }
        }
    }
}