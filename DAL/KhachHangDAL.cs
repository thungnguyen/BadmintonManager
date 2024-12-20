using System;
using BadmintonManager.DTO;
using System.Windows.Forms;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson;

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
                _khachHangCollection.InsertOne(khachHang);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
                return false;
            }
        }
        public List<KhachHangDTO> GetKhachHangList()
        {
            List<KhachHangDTO> khachHangs = new List<KhachHangDTO>();

            try
            {
                // Lấy danh sách tất cả tài liệu từ collection 'KhachHang'
                khachHangs = _khachHangCollection.Find(Builders<KhachHangDTO>.Filter.Empty).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ MongoDB: " + ex.Message);
            }

            return khachHangs;
        }
    }
}

