// SanDAL.cs
using System;
using BadmintonManager.DTO;

using System.Windows.Forms;

// DAL Layer
using MongoDB.Driver;

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
    }
}