//using BadmintonManager.DAO;
//using BadmintonManager.DTO;
//using System;
//using System.Collections.Generic;

//namespace BadmintonManager.BLL
//{
//    internal class GiaSanBLL
//    {
//        private GiaSanBLL giaSanBL;

//        public GiaSanBLL()
//        {
//            giaSanBL = new GiaSanBLL();
//        }

//        // Đảm bảo các phương thức dưới đây sử dụng từ GiaSanBusinessLogic

//        public List<BangGiaSanDTO> GetGiaSanData()
//        {
//            return giaSanBL.GetCourtPricingData();
//        }

//        public void AddGiaSan(string loaiKH, TimeSpan gioBatDau, TimeSpan gioKetThuc, decimal gia)
//        {
//            giaSanBL.AddCourtPricing(loaiKH, gioBatDau, gioKetThuc, gia);
//        }

//        public void UpdateGiaSan(int maGia, string loaiKH, TimeSpan gioBatDau, TimeSpan gioKetThuc, decimal gia)
//        {
//            giaSanBL.UpdateCourtPricing(maGia, loaiKH, gioBatDau, gioKetThuc, gia);
//        }

//        public void DeleteGiaSan(int maGia)
//        {
//            giaSanBL.DeleteCourtPricing(maGia);
//        }
//    }
//}
