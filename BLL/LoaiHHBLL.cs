using System.Collections.Generic;
using BadmintonManager.DAL;
using BadmintonManager.DTO;

namespace BadmintonManager.BLL
{

    public class LoaiHHBLL
    {
        private readonly LoaiHHDAL _loaiHHDAL;

        public LoaiHHBLL()
        {
            _loaiHHDAL = new LoaiHHDAL();
        }

        // Lấy danh sách tất cả loại hàng hóa
        public List<LoaiHHDTO> GetLoaiHHList()
        {
            return _loaiHHDAL.ListLoaiHH();
        }

        // Thêm loại hàng hóa mới
        public void AddLoaiHH(LoaiHHDTO newLoaiHH)
        {
            _loaiHHDAL.ThemLoaiHH(newLoaiHH);
        }

        // Sửa loại hàng hóa
        public void UpdateLoaiHH(LoaiHHDTO updatedLoaiHH)
        {
            _loaiHHDAL.SuaLoaiHH(updatedLoaiHH);
        }

        // Xóa loại hàng hóa
        public void DeleteLoaiHH(string id)
        {
            _loaiHHDAL.XoaLoaiHH(id);
        }

        // Tìm loại hàng hóa theo ID
        public LoaiHHDTO GetLoaiHHById(string id)
        {
            return _loaiHHDAL.TimLoaiHHTheoId(id);
        }
    }
}
