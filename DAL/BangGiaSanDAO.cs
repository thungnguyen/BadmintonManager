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
        private string collectionName = "BangGiaSan";
        public List<BangGiaSanDTO> GetListGiaSan()
        {
            List<BangGiaSanDTO> listGiaSan = new List<BangGiaSanDTO>();
            var documents = MongoDataProvider.Instance.ExecuteQuery("BangGiaSan"); 

            foreach (var doc in documents)
            {
                BangGiaSanDTO giasan = new BangGiaSanDTO(doc);
                listGiaSan.Add(giasan);
            }

            return listGiaSan;
        }
            public void InsertGiaSan(int maGia, string loaiKH, TimeSpan gioBatDau, TimeSpan gioKetThuc, decimal gia)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("maGia", maGia);
                var existingDocument = MongoDataProvider.Instance.GetDocument(collectionName, filter);

                if (existingDocument != null)
                {
                    MessageBox.Show("Mã giá này đã tồn tại trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var newDocument = new BsonDocument
                {
                    { "maGia", maGia },                         
                    { "loaiKH", loaiKH },                       
                    { "gia", gia },                            
                    { "gioBatDau", gioBatDau.ToString(@"hh\:mm\:ss") },
                    { "gioKetThuc", gioKetThuc.ToString(@"hh\:mm\:ss") }
                };

                // Chèn tài liệu vào MongoDB
                MongoDataProvider.Instance.InsertDocument(collectionName, newDocument);

                // Thông báo thành công
                MessageBox.Show("Giá sân đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void UpdateGiaSan(int maGia, string loaiKH, TimeSpan gioBatDau, TimeSpan gioKetThuc, decimal gia)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maGia", maGia); 
            var update = Builders<BsonDocument>.Update
                .Set("loaiKH", loaiKH)
                .Set("gioBatDau", gioBatDau.ToString())
                .Set("gioKetThuc", gioKetThuc.ToString())
                .Set("gia", gia);

            MongoDataProvider.Instance.UpdateDocument("BangGiaSan", filter, update);
        }

        public void DeleteGiaSan(int maGia)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maGia", maGia);
            MongoDataProvider.Instance.DeleteDocument("BangGiaSan", filter);
        }
    }
}
