using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using BadmintonManager.DTO;

namespace BadmintonManager.DAL
{
    public class TaiKhoanDAL
    {
        private readonly IMongoCollection<TaiKhoanNhanVienDTO> _taiKhoanCollection;

        public TaiKhoanDAL()
        {
            var database = new MongoDBConnection().Connect();
            _taiKhoanCollection = database.GetCollection<TaiKhoanNhanVienDTO>("TaiKhoanNhanVien");
        }

        // Thêm tài khoản
        public bool AddTaiKhoan(TaiKhoanNhanVienDTO taiKhoan)
        {
            try
            {
                _taiKhoanCollection.InsertOne(taiKhoan);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Lấy tất cả tài khoản
        public List<TaiKhoanNhanVienDTO> GetAllAccounts()
        {
            return _taiKhoanCollection.AsQueryable().ToList();
        }

        // Cập nhật tài khoản
        public bool UpdateAccount(TaiKhoanNhanVienDTO taiKhoan)
        {
            try
            {
                var filter = Builders<TaiKhoanNhanVienDTO>.Filter.Eq("MaNV", taiKhoan.MaNV);
                var update = Builders<TaiKhoanNhanVienDTO>.Update
                    .Set("TenNV", taiKhoan.TenNV)
                    .Set("TenDangNhap", taiKhoan.TenDangNhap)
                    .Set("MatKhau", taiKhoan.MatKhau)
                    .Set("SDT", taiKhoan.SDT)
                    .Set("VaiTro", taiKhoan.VaiTro);

                var result = _taiKhoanCollection.UpdateOne(filter, update);
                return result.ModifiedCount > 0;
            }
            catch
            {
                return false;
            }
        }

        // Xóa tài khoản
        public bool DeleteAccount(int maNV)
        {
            try
            {
                var filter = Builders<TaiKhoanNhanVienDTO>.Filter.Eq("MaNV", maNV);
                var result = _taiKhoanCollection.DeleteOne(filter);
                return result.DeletedCount > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
