using BadmintonManager.DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BadmintonManager.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private BillDAO() { }

        private string collectionName = "HoaDon"; // Tên collection trong MongoDB

        // Lấy hóa đơn chưa thanh toán dựa trên mã sân
        public ObjectId GetUnCheckBillIDByMaSan(int maSan)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maSan", maSan) &
                         Builders<BsonDocument>.Filter.Eq("status", 0);
            var document = MongoDataProvider.Instance.GetDocument(collectionName, filter);

            if (document != null)
            {
                return document["_id"].AsObjectId;
            }
            else
            return ObjectId.Empty;
        }

        // Thanh toán hóa đơn
        public void Checkout(ObjectId maHD)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", maHD);
            var update = Builders<BsonDocument>.Update
                .Set("status", 1); // Chỉ thay đổi trạng thái của hóa đơn thành 1 (đã thanh toán)

            MongoDataProvider.Instance.UpdateDocument(collectionName, filter, update);

            // Cập nhật trạng thái sân sau khi hóa đơn thay đổi
            UpdateSanStatusAfterBillChange(maHD);
        }

        // Tạo mới hóa đơn
        public void InsertBill(ObjectId? maDatSan, int maSan, decimal giaGioChoi)
        {
            // Tính tổng tiền, bao gồm giá giờ chơi
            var tongTien = CalculateTotalBill(maSan) + giaGioChoi;

            // Tạo tài liệu hóa đơn mới
            var newBill = new BsonDocument
    {
        { "ngayLap", DateTime.Now },
        { "tongTien", tongTien },
        { "maSan", maSan },
        { "status", 0 }
    };

            // Kiểm tra và thêm trường maDatSan
            if (maDatSan.HasValue)
            {
                newBill.Add("maDatSan", maDatSan.Value);
            }
            else
            {
                newBill.Add("maDatSan", BsonNull.Value);
            }

            // Chèn hóa đơn mới vào cơ sở dữ liệu
            MongoDataProvider.Instance.InsertDocument("HoaDon", newBill);

            // Cập nhật trạng thái sân
            UpdateSanStatus(maSan);
        }

        private void UpdateSanStatus(int maSan)
        {
            var count = MongoDataProvider.Instance.CountDocuments(
                "HoaDon",
                Builders<BsonDocument>.Filter.Eq("maSan", maSan) &
                Builders<BsonDocument>.Filter.Eq("status", 0)
            );

            string newStatus = count > 0 ? "Có người" : "Trống";

            var sanCollection = "San";
            var filter = Builders<BsonDocument>.Filter.Eq("maSan", maSan);
            var update = Builders<BsonDocument>.Update.Set("status", newStatus);

            MongoDataProvider.Instance.UpdateDocument(sanCollection, filter, update);
        }

        // Hàm cập nhật trạng thái sân khi hóa đơn thay đổi
        private void UpdateSanStatusAfterBillChange(ObjectId maHD)
        {
            // Lấy thông tin hóa đơn
            var hoaDonFilter = Builders<BsonDocument>.Filter.Eq("_id", maHD);
            var hoaDon = MongoDataProvider.Instance.GetDocument("HoaDon", hoaDonFilter);

            if (hoaDon != null && hoaDon.Contains("maSan"))
            {
                int maSan = hoaDon["maSan"].AsInt32;

                // Kiểm tra hóa đơn chưa thanh toán cho sân
                var count = MongoDataProvider.Instance.CountDocuments(
                    "HoaDon",
                    Builders<BsonDocument>.Filter.Eq("maSan", maSan) &
                    Builders<BsonDocument>.Filter.Eq("status", 0)
                );

                string newStatus = count > 0 ? "Có người" : "Trống";

                // Cập nhật trạng thái sân
                UpdateSanStatus(maSan);
            }
        }

        public ObjectId GetMaxMaHD()
        {
            var documents = MongoDataProvider.Instance.ExecuteQuery(collectionName);
            if (documents.Count > 0)
            {
                return documents.Max(doc => doc["_id"].AsObjectId);
            }
            return ObjectId.Empty;
        }

        private decimal CalculateTotalBill(int maSan)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maSan", maSan);
            var document = MongoDataProvider.Instance.GetDocument("San", filter);

            if (document != null && document.Contains("giaSan"))
            {
                return document["giaSan"].AsDecimal;
            }

            return 0;
        }
    }
}
