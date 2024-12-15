using BadmintonManager.DTO;
using BadmintonManager.GUI;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadmintonManager.DAO
{
    internal class BangGiaSanDAO
    {
        private static BangGiaSanDAO instance;

        public static BangGiaSanDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BangGiaSanDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private BangGiaSanDAO() { }
        private string collectionName = "BangGiaSan"; // Tên collection trong MongoDB
        public List<BangGiaSanDTO> GetListGiaSan()
        {
            List<BangGiaSanDTO> listGiaSan = new List<BangGiaSanDTO>();
            var documents = MongoDataProvider.Instance.ExecuteQuery("BangGiaSan"); // 'San' là tên collection MongoDB.

            foreach (var doc in documents)
            {
                BangGiaSanDTO giasan = new BangGiaSanDTO(doc); // Sử dụng constructor nhận BsonDocument.
                listGiaSan.Add(giasan);
            }

            return listGiaSan;
        }
            public void InsertGiaSan(int maGia, string loaiKH, TimeSpan gioBatDau, TimeSpan gioKetThuc, decimal gia)
            {
                // Kiểm tra xem mã sân đã tồn tại trong cơ sở dữ liệu hay chưa
                var filter = Builders<BsonDocument>.Filter.Eq("maGia", maGia);
                var existingDocument = MongoDataProvider.Instance.GetDocument(collectionName, filter);

                if (existingDocument != null)
                {
                    // Nếu mã sân đã tồn tại, thông báo và không thực hiện thêm
                    MessageBox.Show("Mã giá này đã tồn tại trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng lại không thực hiện thêm
                }

                // Nếu mã sân chưa tồn tại, tiếp tục chèn tài liệu mới vào MongoDB
                var newDocument = new BsonDocument
                {
                    { "maGia", maGia },                          // Mã giá
                    { "loaiKH", loaiKH },                        // Loại khách hàng
                    { "gia", gia },                              // Giá
                    { "gioBatDau", gioBatDau.ToString(@"hh\:mm\:ss") },  // Chuyển TimeSpan sang chuỗi với định dạng hh:mm:ss
                    { "gioKetThuc", gioKetThuc.ToString(@"hh\:mm\:ss") }  // Chuyển TimeSpan sang chuỗi với định dạng hh:mm:ss
                };

                // Chèn tài liệu vào MongoDB
                MongoDataProvider.Instance.InsertDocument(collectionName, newDocument);

                // Thông báo thành công
                MessageBox.Show("Giá sân đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public void UpdateGiaSan(int maGia, string loaiKH, TimeSpan gioBatDau, TimeSpan gioKetThuc, decimal gia)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maGia", maGia); // Tìm tài liệu theo maGia
            var update = Builders<BsonDocument>.Update
                .Set("loaiKH", loaiKH)
                .Set("gioBatDau", gioBatDau.ToString()) // Chuyển TimeSpan sang chuỗi
                .Set("gioKetThuc", gioKetThuc.ToString()) // Chuyển TimeSpan sang chuỗi
                .Set("gia", gia);

            MongoDataProvider.Instance.UpdateDocument("BangGiaSan", filter, update);
        }

        public void DeleteGiaSan(int maGia)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maGia", maGia); // Tìm tài liệu theo maGia
            MongoDataProvider.Instance.DeleteDocument("BangGiaSan", filter);
        }
    }
}
