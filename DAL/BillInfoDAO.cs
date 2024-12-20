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

            // Sau khi thêm hoặc cập nhật chi tiết hóa đơn, gọi UpdateTongTien để tính lại tổng tiền của hóa đơn.
            UpdateTongTien(maHD);
        }


        // Cập nhật tổng tiền cho hóa đơn
        private void UpdateTongTien(ObjectId maHD)
        {
            // Lọc hóa đơn theo mã hóa đơn
            var filter = Builders<BsonDocument>.Filter.Eq("maHD", maHD);

            // Lấy tất cả các sản phẩm trong hóa đơn từ collection HDSP (chi tiết hóa đơn)
            var billItems = MongoDataProvider.Instance.ExecuteQuery(collectionName, filter);

            // Tính tổng thành tiền từ các chi tiết hóa đơn
            decimal newTotalAmount = billItems.Sum(item =>
            {
                // Kiểm tra xem tài liệu có trường "thanhTien" không và lấy giá trị của nó
                if (item.Contains("thanhTien"))
                {
                    return item["thanhTien"].ToDecimal(); // Đảm bảo rằng "thanhTien" là kiểu decimal
                }
                return 0;
            });

            // Lấy tài liệu hóa đơn hiện tại từ collection "HoaDon"
            var invoiceDoc = MongoDataProvider.Instance.GetDocument(collectionName2, filter);
            decimal currentTotalAmount = 0;

            // Kiểm tra nếu đã có tổng tiền hiện tại trong hóa đơn
            if (invoiceDoc != null && invoiceDoc.Contains("tongTien"))
            {
                currentTotalAmount = invoiceDoc["tongTien"].ToDecimal();
            }

            // Cộng dồn tổng tiền mới vào tổng tiền hiện tại
            decimal updatedTotalAmount = currentTotalAmount + newTotalAmount;

            // Cập nhật tổng tiền cho hóa đơn tại vị trí mã hóa đơn đã truyền vào
            var update = Builders<BsonDocument>.Update.Set("tongTien", updatedTotalAmount);

            // Thực hiện cập nhật vào MongoDB cho đúng hóa đơn có maHD
            MongoDataProvider.Instance.UpdateDocument(collectionName2, filter, update);
        }

    }
}
