using BadmintonManager.DAL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;

namespace BadmintonManager.BAL
{
    public class ChiTietNhapHangBLL
    {
        private ChiTietNhapHangDAL _chiTietNhapHangDAL;

        public ChiTietNhapHangBLL()
        {
            _chiTietNhapHangDAL = new ChiTietNhapHangDAL();
        }

        // Phương thức thêm mới ChiTietNhapHang
        public void AddChiTietNhapHang(ChiTietNhapHangDTO chiTietNhapHang)
        {
            try
            {
                // Thêm vào bảng ChiTietNhapHang
                _chiTietNhapHangDAL.InsertChiTietNhapHang(chiTietNhapHang);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Đã xảy ra lỗi khi thêm chi tiết nhập hàng.", ex);
            }
        }

        public List<ChiTietNhapHangDTO> GetChiTietNhapHang()
        {
            try
            {
                return _chiTietNhapHangDAL.GetChiTietNhapHang();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Đã xảy ra lỗi khi lấy dữ liệu chi tiết nhập hàng.", ex);
            }
        }

        public ChiTietNhapHangDTO GetById(int id)
        {
            return _chiTietNhapHangDAL.GetById(id);
        }
    }
}
