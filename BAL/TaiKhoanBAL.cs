using System.Collections.Generic;
using BadmintonManager.DTO;
using BadmintonManager.DAL;

namespace BadmintonManager.BAL
{
    public class TaiKhoanBAL
    {
        private TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();

        // Phương thức cũ
        public List<TaiKhoanNhanVienDTO> GetAllAccounts()
        {
            return taiKhoanDAL.GetAllAccounts();
        }

        public void UpdateAccount(TaiKhoanNhanVienDTO account)
        {
            taiKhoanDAL.UpdateAccount(account);
        }

        public void DeleteAccount(int maNV)
        {
            taiKhoanDAL.DeleteAccount(maNV);
        }

        public void AddAccount(TaiKhoanNhanVienDTO account)
        {
            taiKhoanDAL.InsertAccount(account);
        }

        // Phương thức mới từ TaiKhoanNhanVienBAL
        public TaiKhoanNhanVienDTO DangNhap(string tenDangNhap, string matKhau)
        {
            return taiKhoanDAL.DangNhap(tenDangNhap, matKhau);
        }

        public int LayMaNV(string tenDangNhap, string matKhau)
        {
            return taiKhoanDAL.LayMaNV(tenDangNhap, matKhau);
        }

        public bool ThemTaiKhoan(TaiKhoanNhanVienDTO taiKhoan)
        {
            return taiKhoanDAL.ThemTaiKhoan(taiKhoan);
        }
    }
}
