using System.Collections.Generic;
using BadmintonManager.DTO;
using BadmintonManager.DAL;

namespace BadmintonManager.BAL
{
    public class TaiKhoanBAL
    {
        private readonly TaiKhoanDAL _taiKhoanDAL;

        public TaiKhoanBAL()
        {
            _taiKhoanDAL = new TaiKhoanDAL();
        }

        // Thêm tài khoản
        public bool AddTaiKhoan(TaiKhoanNhanVienDTO taiKhoan)
        {
            return _taiKhoanDAL.AddTaiKhoan(taiKhoan);
        }

        // Lấy danh sách tất cả tài khoản
        public List<TaiKhoanNhanVienDTO> GetAllAccounts()
        {
            return _taiKhoanDAL.GetAllAccounts();
        }

        // Cập nhật tài khoản
        public bool UpdateAccount(TaiKhoanNhanVienDTO taiKhoan)
        {
            return _taiKhoanDAL.UpdateAccount(taiKhoan);
        }

        // Xóa tài khoản
        public bool DeleteAccount(int maNV)
        {
            return _taiKhoanDAL.DeleteAccount(maNV);
        }
    }
}


