﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BadmintonManager.DAL;
using BadmintonManager.DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;



namespace BadmintonManager.BLL
{
    /// <summary>
    /// Business Logic Layer for Product Management
    /// </summary>
    public class HangHoaBLL
    {
        private HangHoaDAL _hanghoaDAL;

        public HangHoaBLL()
        {
            _hanghoaDAL = new HangHoaDAL();
        }

        // Phương thức lấy danh sách hàng hóa từ DAL và chuyển đổi thành danh sách đối tượng HangHoa
        public List<HangHoa> HangHoaList(string sortCriteria = null)
        {
            // Lấy danh sách BsonDocument từ DAL
            List<BsonDocument> hhListBson = _hanghoaDAL.ListHangHoa();

            // Chuyển đổi BsonDocument thành đối tượng HangHoa
            List<HangHoa> hhList = new List<HangHoa>();
            foreach (var item in hhListBson)
            {
                HangHoa hh = new HangHoa
                {
                    Id = item["_id"].ToString(),
                    TenHH = item["tenHH"].ToString(),
                    MoTa = item["moTa"].ToString(),
                    DonViTinhLon = item["donViTinhLon"].ToString(),
                    DonViTinhNho = item["donViTinhNho"].ToString(),
                    HeSoQuyDoi = item["heSoQuyDoi"].ToInt32(),
                    GiaNhapLon = item["giaNhapLon"].ToDecimal(),
                    GiaNhapNho = item["giaNhapNho"].ToDecimal(),
                    GiaBanLon = item["giaBanLon"].ToDecimal(),
                    GiaBanNho = item["giaBanNho"].ToDecimal(),
                    SoLuongTonLon = item["soLuongTonLon"].ToInt32(),
                    SoLuongTonNho = item["soLuongTonNho"].ToInt32(),
                    MaLoaiHH = item["maLoaiHH"].ToString(),
                    MaHH = item["maHH"].ToInt32()
                };

                // Thêm vào danh sách hàng hóa
                hhList.Add(hh);
            }

            return hhList;
        }

        public HangHoa LayHangHoaByID(int maHH)
        {
            if (maHH <= 0)
            {
                throw new ArgumentException("Invalid MaHH. It must be a positive integer.");
            }

            try
            {
                // Call the DAL method to retrieve the HangHoa by its MaHH
                return _hanghoaDAL.LayHangHoaByID(maHH);
            }
            catch (Exception ex)
            {
                // Handle the exception or rethrow as needed
                throw new Exception($"Error while retrieving HangHoa: {ex.Message}");
            }
        }


        public void ThemHH(HangHoa hh)
        {
            // Tạo BsonDocument từ đối tượng HangHoa
            var newhh = new BsonDocument
                {
                    { "tenHH", hh.TenHH },
                    { "moTa", hh.MoTa },
                    { "donViTinhLon", hh.DonViTinhLon },
                    { "donViTinhNho", hh.DonViTinhNho },
                    { "heSoQuyDoi", hh.HeSoQuyDoi },
                    { "giaNhapLon", hh.GiaNhapLon },
                    { "giaNhapNho", hh.GiaNhapNho },
                    { "giaBanLon", hh.GiaBanLon },
                    { "giaBanNho", hh.GiaBanNho },
                    { "soLuongTonLon", hh.SoLuongTonLon },
                    { "soLuongTonNho", hh.SoLuongTonNho },
                    { "maLoaiHH", hh.MaLoaiHH },
                };
            _hanghoaDAL.ThemHH(newhh);
        } 
      
        public void SuaHH(HangHoa updatedhh)
        {
            _hanghoaDAL.SuaHH(updatedhh);
        }

        public void XoaHH(int maHH)
        {
            if (maHH <= 0)
            {
                throw new ArgumentException("Invalid MaHH for deletion.");
            }

            _hanghoaDAL.XoaHH(maHH); // Call the DAL method
        }

    }
}
