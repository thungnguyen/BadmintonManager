using BadmintonManager.DAL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;

namespace BadmintonManager.BAL
{
    public class PhieuNhapHangBLL
    {
        private PhieuNhapHangDAL _phieuNhapHangDAL;

        public PhieuNhapHangBLL()
        {
            _phieuNhapHangDAL = new PhieuNhapHangDAL();
        }


        public void AddPhieuNhapHang(PhieuNhapHangDTO phieu)
        {

            _phieuNhapHangDAL.AddPhieuNhapHang(phieu);
        }


        public List<PhieuNhapHangDTO> GetAllPhieuNhapHangs()
        {
            return _phieuNhapHangDAL.GetAllPhieuNhapHangs();
        }


        public PhieuNhapHangDTO GetPhieuNhapHangById(int maPhieu)
        {
            return _phieuNhapHangDAL.GetPhieuNhapHangById(maPhieu);
        }


        public void UpdatePhieuNhapHang(PhieuNhapHangDTO phieu)
        {
            _phieuNhapHangDAL.UpdatePhieuNhapHang(phieu);
        }


        public void DeletePhieuNhapHang(int maPhieu)
        {
            _phieuNhapHangDAL.DeletePhieuNhapHang(maPhieu);
        }
    }
}
