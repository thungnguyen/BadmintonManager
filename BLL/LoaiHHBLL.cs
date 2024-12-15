using System;
using System.Collections.Generic;
using BadmintonManager.DAL;
using BadmintonManager.DTO;
using MongoDB.Bson;

namespace BadmintonManager.BLL
{
    /// <summary>
    /// Business Logic Layer for Category Management
    /// </summary>
    public class LoaiHHBLL
    {
        private readonly LoaiHHDAL _loaiHHDAL;

        public LoaiHHBLL()
        {
            _loaiHHDAL = new LoaiHHDAL();
        }

        // Get a list of all categories
        public List<LoaiHH> GetLoaiHHList()
        {
            // Lấy danh sách BsonDocument từ DAL
            List<BsonDocument> loaihhListBson = _loaiHHDAL.ListLoaiHH();

            // Chuyển đổi BsonDocument thành đối tượng HangHoa
            List<LoaiHH> loaihhList = new List<LoaiHH>();
            foreach (var item in loaihhListBson)
            {
                LoaiHH loaihh = new LoaiHH
                {
                    Id = item["_id"].ToString(),
                    MaLoaiHH = item["tenLoaiHH"].ToString(),
                    TenLoaiHH = item["tenLoaiHH"].ToString(),
                };

                // Thêm vào danh sách hàng hóa
                loaihhList.Add(loaihh);
            }

            return loaihhList;
        }

        // Add a new category
        public void AddLoaiHH(LoaiHH newLoaiHH)
        {
            if (newLoaiHH == null || string.IsNullOrEmpty(newLoaiHH.TenLoaiHH))
            {
                throw new ArgumentException("Category information is invalid.");
            }
            _loaiHHDAL.ThemLoaiHH(newLoaiHH);
        }

        // Update an existing category
        public void UpdateLoaiHH(LoaiHH updatedLoaiHH)
        {
            _loaiHHDAL.SuaLoaiHH(updatedLoaiHH);
        }

        // Delete a category by MaLoaiHH
        public void DeleteLoaiHH(LoaiHH loaihh)
        {
            if (loaihh == null || string.IsNullOrEmpty(loaihh.MaLoaiHH))
            {
                throw new ArgumentException("Invalid HangHoa object for deletion.");
            }

            _loaiHHDAL.XoaLoaiHH(loaihh.MaLoaiHH);
        }
    }
}
