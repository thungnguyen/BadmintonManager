using System.Collections.Generic;
using BadmintonManager.DTO;
using BadmintonManager.DAL;

namespace BadmintonManager.BAL
{
    public class TaiKhoanBAL
    {
        private TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();

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
    }
}
