using BadmintonManager.DAL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace QuanLyNhapHang.BLL
{
    public class NhapHangBLL
    {
        private readonly NhapHangDAL _nhapHangDal;

        public NhapHangBLL()
        {
            _nhapHangDal = new NhapHangDAL();
        }

        // Thêm phiếu nhập mới
        public bool ThemPhieuNhap(NhapHang phieuNhap)
        {
            if (phieuNhap == null || phieuNhap.ChiTietNhap == null || phieuNhap.ChiTietNhap.Count == 0)
            {
                throw new ArgumentException("Phiếu nhập hoặc chi tiết phiếu nhập không hợp lệ.");
            }

            // Tính tổng tiền cho phiếu nhập
            phieuNhap.TongTien = TinhTongTien(phieuNhap.ChiTietNhap);
            phieuNhap.NgayNhap = DateTime.Now; // Gán thời gian hiện tại
            _nhapHangDal.ThemPhieuNhap(phieuNhap);

            return true;
        }

        // Tính tổng tiền từ danh sách chi tiết nhập
        private decimal TinhTongTien(List<ChiTietNhap> chiTietNhap)
        {
            decimal tongTien = 0;

            foreach (var chiTiet in chiTietNhap)
            {
                chiTiet.ThanhTien = (chiTiet.SoLuongLon * chiTiet.GiaNhapLon) +
                                    (chiTiet.SoLuongNho * chiTiet.GiaNhapNho);
                tongTien += chiTiet.ThanhTien;
            }

            return tongTien;
        }

        // Lấy danh sách phiếu nhập
        public List<NhapHang> LayDanhSachPhieuNhap()
        {
            return _nhapHangDal.LayDanhSachPhieuNhap();
        }

        // Tìm phiếu nhập theo mã
        public NhapHang TimPhieuNhapTheoMa(string maNhapHang)
        {
            if (string.IsNullOrEmpty(maNhapHang))
            {
                throw new ArgumentException("Mã nhập hàng không được để trống.");
            }

            return _nhapHangDal.TimPhieuNhapTheoMa(maNhapHang);
        }

        // Tìm phiếu nhập theo ObjectId
        public NhapHang TimPhieuNhapTheoId(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                throw new ArgumentException("ID không hợp lệ.");
            }

            return _nhapHangDal.TimPhieuNhapTheoId(objectId);
        }

        // Cập nhật phiếu nhập
        public bool CapNhatPhieuNhap(string maNhapHang, NhapHang phieuNhapMoi)
        {
            if (string.IsNullOrEmpty(maNhapHang) || phieuNhapMoi == null)
            {
                throw new ArgumentException("Thông tin phiếu nhập không hợp lệ.");
            }

            // Tính lại tổng tiền nếu chi tiết phiếu nhập thay đổi
            if (phieuNhapMoi.ChiTietNhap != null)
            {
                phieuNhapMoi.TongTien = TinhTongTien(phieuNhapMoi.ChiTietNhap);
            }

            return _nhapHangDal.CapNhatPhieuNhap(maNhapHang, phieuNhapMoi);
        }

        // Xóa phiếu nhập
        public bool XoaPhieuNhap(string maNhapHang)
        {
            if (string.IsNullOrEmpty(maNhapHang))
            {
                throw new ArgumentException("Mã nhập hàng không được để trống.");
            }

            return _nhapHangDal.XoaPhieuNhap(maNhapHang);
        }
    }
}
