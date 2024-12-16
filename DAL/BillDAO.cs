using BadmintonManager.DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

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
                return document["_id"].AsObjectId; // Trả về ObjectId của hóa đơn
            }

            return ObjectId.Empty; // Không tìm thấy hóa đơn, trả về ObjectId.Empty
        }


        // Thanh toán hóa đơn
        public void Checkout(ObjectId maHD, decimal giaSan)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", maHD); // Sử dụng _id để tìm theo ObjectId
            var update = Builders<BsonDocument>.Update
                .Set("status", 1) // Cập nhật trạng thái hóa đơn thành đã thanh toán
                .Inc("tongTien", giaSan); // Cộng thêm giá sân

            MongoDataProvider.Instance.UpdateDocument(collectionName, filter, update);
        }

        // Tạo mới hóa đơn
        public void InsertBill(int maSan, decimal giaGioChoi)
        {
            var tongTien = CalculateTotalBill(maSan) + giaGioChoi;

            var newBill = new BsonDocument
            {
                { "maDatSan", BsonNull.Value }, // Null trong MongoDB
                { "ngayLap", DateTime.Now },
                { "tongTien", tongTien },
                { "maSan", maSan },
                { "status", 0 }
            };

            MongoDataProvider.Instance.InsertDocument(collectionName, newBill);
        }

        // Lấy mã hóa đơn lớn nhất
        public ObjectId GetMaxMaHD()
        {
            var documents = MongoDataProvider.Instance.ExecuteQuery(collectionName);
            if (documents.Count > 0)
            {
                // Lấy ObjectId có timestamp lớn nhất (tương ứng với dữ liệu được tạo gần nhất)
                return documents.Max(doc => doc["_id"].AsObjectId);
            }
            return ObjectId.Empty; // Trả về ObjectId.Empty nếu không có hóa đơn nào
        }

        // Hàm tính tổng tiền từ mã sân
        private decimal CalculateTotalBill(int maSan)
        {
            // Giả định tính tổng tiền dựa trên logic tùy chỉnh
            var filter = Builders<BsonDocument>.Filter.Eq("maSan", maSan);
            var document = MongoDataProvider.Instance.GetDocument("San", filter);

            if (document != null && document.Contains("giaSan"))
            {
                return document["giaSan"].AsDecimal;
            }

            return 0; // Trả về 0 nếu không tìm thấy thông tin sân
        }
    }
}
