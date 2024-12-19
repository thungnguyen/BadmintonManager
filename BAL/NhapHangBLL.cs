using BadmintonManager.DAL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;

namespace BadmintonManager.BAL
{
    public class NhapHangBLL
    {
        private NhapHangDAL _nhapHangDAL;

        public NhapHangBLL()
        {
            _nhapHangDAL = new NhapHangDAL();
        }

        // Phương thức thêm mới NhapHang
        public void AddNhapHang(NhapHangDTO nhapHang)
        {
            try
            {
                // Thêm vào bảng NhapHang
                _nhapHangDAL.InsertNhapHang(nhapHang);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Đã xảy ra lỗi khi thêm nhập hàng.", ex);
            }
        }

        public List<NhapHangDTO> GetNhapHang()
        {
            try
            {
                return _nhapHangDAL.GetNhapHang();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Đã xảy ra lỗi khi lấy dữ liệu nhập hàng.", ex);
            }
        }

        public NhapHangDTO GetById(int id)
        {
            return _nhapHangDAL.GetById(id);
        }


    }
}
