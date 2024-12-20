using System.Collections.Generic;
using BadmintonManager.DAL;
using BadmintonManager.DTO;

namespace BadmintonManager.BLL
{
    /// <summary>
    /// Business Logic Layer for Product Management
    /// </summary>
    public class HangHoaBLL
    {
        private readonly HangHoaDAL _hanghoaDAL;

        public HangHoaBLL()
        {
            _hanghoaDAL = new HangHoaDAL();
        }

        // Lấy danh sách hàng hóa
        public List<HangHoa> HangHoaList(string sortCriteria = null)
        {
            return _hanghoaDAL.ListHangHoa(sortCriteria);
        }

        // Thêm hàng hóa
        public void ThemHH(HangHoa hh)
        {
            _hanghoaDAL.ThemHH(hh);
        }

        // Sửa hàng hóa
        public void SuaHH(HangHoa updatedHH)
        {
            _hanghoaDAL.SuaHH(updatedHH);
        }

        // Xóa hàng hóa
        public void XoaHH(string Id)
        {
            _hanghoaDAL.XoaHH(Id);
        }
    }
}
