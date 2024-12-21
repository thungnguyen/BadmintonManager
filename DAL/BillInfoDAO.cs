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
        private string collectionName2 = "HoaDon";

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

            var existingDoc = MongoDataProvider.Instance.GetDocument("HDSP", filter);

            if (existingDoc != null)
            {
                // Lấy giá đơn giá cũ (nếu tồn tại)
                var currentDonGia = existingDoc.Contains("donGia") ? existingDoc["donGia"].ToDecimal() : donGia;

                // Cập nhật số lượng và giá đơn giá mới (nếu khác)
                var newQuantity = existingDoc["soLuong"].ToInt32() + soLuong;
                if (newQuantity > 0)
                {
                    var updatedDonGia = donGia > 0 ? donGia : currentDonGia; // Nếu `donGia` mới không hợp lệ, giữ giá cũ
                    var update = Builders<BsonDocument>.Update
                        .Set("soLuong", newQuantity)
                        .Set("donGia", updatedDonGia)
                        .Set("thanhTien", newQuantity * updatedDonGia);
                    MongoDataProvider.Instance.UpdateDocument("HDSP", filter, update);
                }
                else
                {
                    // Xóa tài liệu nếu số lượng mới <= 0
                    MongoDataProvider.Instance.DeleteDocument("HDSP", filter);
                }
            }
            else
            {
                // Thêm sản phẩm mới vào HDSP
                var newDoc = new BsonDocument
        {
            { "maHD", maHD },
            { "maHH", maHH },
            { "soLuong", soLuong },
            { "donGia", donGia },
            { "donViTinh", donViTinh },
            { "thanhTien", soLuong * donGia }
        };
                MongoDataProvider.Instance.InsertDocument("HDSP", newDoc);
            }

            // Sau khi thêm hoặc cập nhật chi tiết hóa đơn, gọi UpdateTongTien để tính lại tổng tiền của hóa đơn.
            UpdateTongTien(maHD);
        }


        // Cập nhật tổng tiền cho hóa đơn
        private void UpdateTongTien(ObjectId maHD)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maHD", maHD);

            var billItems = MongoDataProvider.Instance.ExecuteQuery("HDSP", filter);
            decimal totalItemsAmount = billItems.Sum(item =>
            {
                return item.Contains("thanhTien") ? item["thanhTien"].ToDecimal() : 0;
            });
            var invoiceFilter = Builders<BsonDocument>.Filter.Eq("_id", maHD);
            var invoiceDoc = MongoDataProvider.Instance.GetDocument("HoaDon", invoiceFilter);
            decimal tienSan = 0;
            if (invoiceDoc != null && invoiceDoc.Contains("tongTien"))
            {
                tienSan = invoiceDoc["tongTien"].ToDecimal();
            }
            decimal updatedTotalAmount = tienSan + totalItemsAmount;
            var update = Builders<BsonDocument>.Update.Set("tongTien", updatedTotalAmount);
            MongoDataProvider.Instance.UpdateDocument("HoaDon", invoiceFilter, update);
        }
    }

}
