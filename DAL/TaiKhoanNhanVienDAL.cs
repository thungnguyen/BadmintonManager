using MongoDB.Driver;
using MongoDB.Bson;
using BadmintonManager.DTO;

namespace BadmintonManager.DAL
{
    public class TaiKhoanNhanVienDAL
    {
        private readonly IMongoCollection<TaiKhoanNhanVienDTO> _taiKhoanNhanVienCollection;

        public TaiKhoanNhanVienDAL()
        {
            var dbConnection = new MongoDBConnection();
            var database = dbConnection.Connect();
            _taiKhoanNhanVienCollection = database.GetCollection<TaiKhoanNhanVienDTO>("TaiKhoanNhanVien");
        }

        public TaiKhoanNhanVienDTO DangNhap(string tenDangNhap, string matKhau)
        {
            return _taiKhoanNhanVienCollection
                .Find(tk => tk.TenDangNhap == tenDangNhap && tk.MatKhau == matKhau)
                .FirstOrDefault();
        }
    }

}
