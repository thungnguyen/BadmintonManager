using BadmintonManager.DAL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;

namespace BadmintonManager.BAL
{
    public class LichSuNhapHangBLL
    {
        private LichSuNhapHangDAL _lichSuNhapHangDAL;

        public LichSuNhapHangBLL()
        {
            _lichSuNhapHangDAL = new LichSuNhapHangDAL();
        }

        // Method to add a new LichSuNhapHang record
        public void AddLichSuNhapHang(LichSuNhapHangDTO lichSu)
        {
            // You can implement business rules here if needed
            _lichSuNhapHangDAL.AddLichSuNhapHang(lichSu);
        }

        // Method to retrieve all LichSuNhapHang records
        public List<LichSuNhapHangDTO> GetAllLichSuNhapHangs()
        {
            return _lichSuNhapHangDAL.GetAllLichSuNhapHangs();
        }

        // Method to get LichSuNhapHang by its ID
        public LichSuNhapHangDTO GetLichSuNhapHangById(int maLichSu)
        {
            return _lichSuNhapHangDAL.GetLichSuNhapHangById(maLichSu);
        }

        // Method to update an existing LichSuNhapHang record
        public void UpdateLichSuNhapHang(LichSuNhapHangDTO lichSu)
        {
            _lichSuNhapHangDAL.UpdateLichSuNhapHang(lichSu);
        }

        // Method to delete a LichSuNhapHang record by its ID
        public void DeleteLichSuNhapHang(int maLichSu)
        {
            _lichSuNhapHangDAL.DeleteLichSuNhapHang(maLichSu);
        }
    }
}
