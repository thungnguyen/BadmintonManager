using MongoDB.Bson;
using MongoDB.Driver;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BadmintonManager.DAO
{
    internal class BillInfoDAO
    {
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillInfoDAO();
                return instance;
            }
            private set => instance = value;
        }

        private BillInfoDAO() { }

        private string collectionName = "HDSP";

        // Lấy danh sách chi tiết hóa đơn theo mã hóa đơn
        public List<BillInfo> GetListBillInfo(ObjectId maHD)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maHD", maHD);
            var documents = MongoDataProvider.Instance.ExecuteQuery(collectionName, filter);
            return documents.Select(doc => new BillInfo(doc)).ToList();
        }

        // Thêm chi tiết hóa đơn
        public void InsertBillInfo(ObjectId maHD, ObjectId maHH, int soLuong, decimal donGia, string donViTinh)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("maHD", maHD),
                Builders<BsonDocument>.Filter.Eq("maHH", maHH),
                Builders<BsonDocument>.Filter.Eq("donViTinh", donViTinh)
            );
            var existingDoc = MongoDataProvider.Instance.GetDocument(collectionName, filter);

            if (existingDoc != null)
            {
                var newQuantity = existingDoc["soLuong"].ToInt32() + soLuong;
                if (newQuantity > 0)
                {
                    var update = Builders<BsonDocument>.Update
                        .Set("soLuong", newQuantity)
                        .Set("thanhTien", newQuantity * donGia);
                    MongoDataProvider.Instance.UpdateDocument(collectionName, filter, update);
                }
                else
                {
                    MongoDataProvider.Instance.DeleteDocument(collectionName, filter);
                }
            }
            else
            {
                var newDoc = new BsonDocument
                {
                    { "maHD", maHD },
                    { "maHH", maHH },
                    { "soLuong", soLuong },
                    { "donGia", donGia },
                    { "donViTinh", donViTinh },
                    { "thanhTien", soLuong * donGia }
                };
                MongoDataProvider.Instance.InsertDocument(collectionName, newDoc);
            }

            UpdateTongTien(maHD);
        }

        // Cập nhật tổng tiền cho hóa đơn
        private void UpdateTongTien(ObjectId maHD)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maHD", maHD);
            var billItems = MongoDataProvider.Instance.ExecuteQuery(collectionName, filter);
            var totalAmount = billItems.Sum(item => item["thanhTien"].ToDecimal());

            var invoiceFilter = Builders<BsonDocument>.Filter.Eq("maHD", maHD);
            var update = Builders<BsonDocument>.Update.Set("TongTien", totalAmount);
            MongoDataProvider.Instance.UpdateDocument("HoaDon", invoiceFilter, update);
        }
    }
}
