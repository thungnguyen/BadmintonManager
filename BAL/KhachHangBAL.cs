// SanBAL.cs
using System.Collections.Generic;
using BadmintonManager.DAL;
using BadmintonManager.DTO;


namespace BadmintonManager.BAL
{
    public class KhachHangBAL
    {
        private KhachHangDAL khachHangDAL;

        public KhachHangBAL()
        {
            khachHangDAL = new KhachHangDAL();
        }

        public List<KhachHang> GetAllKhachHangs()
        {
            return khachHangDAL.GetKhachHangList();
        }
    }
}