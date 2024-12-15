using BadmintonManager.DAL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadmintonManager.BAL
{
    public class LichDatSanBAL
    {
        private LichDatSanDAL _dal = new LichDatSanDAL();
        private LichDatSanDAL lichDatSanDAL = new LichDatSanDAL();

        public bool SaveLichDatSan(LichDatSanDTO dto)
        {
            try
            {
                // Insert LichDatSan
                int maDatSan = _dal.InsertLichDatSan(dto);
                if (maDatSan == 0)
                {
                    MessageBox.Show("Không thể lấy mã đặt sân.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Insert ChiTietLichDatSan
                _dal.InsertChiTietLichDatSan(maDatSan, dto.NgayDat, dto.TuGio, dto.DenGio);

                MessageBox.Show("Đã lưu lịch đặt sân thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Method to get MaGia
        public int LayMaGia(bool loaiKhachChecked, DateTime tuGio)
        {
            string loaiKhach = loaiKhachChecked ? "Co dinh" : "Vang lai";
            TimeSpan gioBatDau = tuGio.TimeOfDay;

            return _dal.LayMaGia(loaiKhach, gioBatDau); // Calls the DAL method
        }

        public int GetMaSan(string tenSan)
        {
            return _dal.GetMaSan(tenSan);
        }

        public int GetMaKH(string tenKH)
        {
            return _dal.GetMaKH(tenKH);
        }

        // Phương thức kiểm tra trùng lịch và thực hiện các hành động khác
        public bool CheckTrungLich(LichDatSanDTO lichDatSan)
        {
            return lichDatSanDAL.CheckTrungLich(lichDatSan);
        }

        public bool KiemTraTrungLich(string maSan, List<DateTime> cacNgayDat, TimeSpan tuGio, TimeSpan denGio)
        {
            var lichDatSanList = lichDatSanDAL.GetLichDatSanByMaSan(maSan, cacNgayDat);

            foreach (var lichDatSan in lichDatSanList)
            {
                foreach (var ngayDat in lichDatSan.NgayDat)
                {
                    // Kiểm tra trùng lịch
                    if ((tuGio >= lichDatSan.TuGio && tuGio < lichDatSan.DenGio) ||
                        (denGio > lichDatSan.TuGio && denGio <= lichDatSan.DenGio))
                    {
                        return true; // Trùng lịch
                    }
                }
            }

            return false; // Không trùng lịch
        }

    }

}
