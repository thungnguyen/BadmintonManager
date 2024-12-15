// SanBAL.cs
using System.Collections.Generic;
using BadmintonManager.DAL;
using BadmintonManager.DTO;

// BAL Layer
namespace BadmintonManager.BAL
{
    public class KhachHangBAL
    {
        private readonly KhachHangDAL _khachHangDAL;

        public KhachHangBAL()
        {
            _khachHangDAL = new KhachHangDAL();
        }

        public bool AddKhachHang(KhachHangDTO khachHang)
        {
            return _khachHangDAL.AddKhachHang(khachHang);
        }
    }
}