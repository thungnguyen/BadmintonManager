using BadmintonManager.DAL;
using BadmintonManager.DTO;

namespace BadmintonManager.BAL
{
    public class TaiKhoanNhanVienBAL
    {
        private readonly TaiKhoanNhanVienDAL _taiKhoanDAL;

        public TaiKhoanNhanVienBAL()
        {
            _taiKhoanDAL = new TaiKhoanNhanVienDAL();
        }

        public TaiKhoanNhanVienDTO DangNhap(string tenDangNhap, string matKhau)
        {
            return _taiKhoanDAL.DangNhap(tenDangNhap, matKhau);
        }
    }
}
