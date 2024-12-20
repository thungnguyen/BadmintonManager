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


        public TaiKhoanNhanVienDTO DangNhap(string tenDangNhap, string matKhau)
        {
            return _taiKhoanCollection
                .Find(tk => tk.TenDangNhap == tenDangNhap && tk.MatKhau == matKhau)
                .FirstOrDefault();
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
                // Đảm bảo chúng ta đang cập nhật đúng document dựa trên Id và MaNV
                var filter = Builders<TaiKhoanNhanVienDTO>.Filter.And(
                    Builders<TaiKhoanNhanVienDTO>.Filter.Eq(x => x.MaNV, taiKhoan.MaNV)
                );

                var update = Builders<TaiKhoanNhanVienDTO>.Update
                    .Set(x => x.TenNV, taiKhoan.TenNV)
                    .Set(x => x.TenDangNhap, taiKhoan.TenDangNhap)
                    .Set(x => x.MatKhau, taiKhoan.MatKhau)
                    .Set(x => x.SDT, taiKhoan.SDT)
                    .Set(x => x.VaiTro, taiKhoan.VaiTro);

                var options = new UpdateOptions { IsUpsert = false }; // Đảm bảo không tạo mới nếu không tìm thấy

                var result = _taiKhoanCollection.UpdateOne(filter, update, options);
                return result.ModifiedCount > 0;
            }
            catch
            {
                return false;
            }
        }

        // Trong TaiKhoanDAL
        public bool IsTenDangNhapExists(string tenDangNhap, int excludeMaNV)
        {
            try
            {
                var filter = Builders<TaiKhoanNhanVienDTO>.Filter.And(
                    Builders<TaiKhoanNhanVienDTO>.Filter.Eq("TenDangNhap", tenDangNhap),
                    Builders<TaiKhoanNhanVienDTO>.Filter.Ne("MaNV", excludeMaNV)
                );
                return _taiKhoanCollection.Find(filter).Any();
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
