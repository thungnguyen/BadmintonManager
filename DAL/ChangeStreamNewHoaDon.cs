using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Configuration;  // Đảm bảo bạn thêm tham chiếu tới namespace này
using System.Threading.Tasks;

namespace BadmintonManager.DAL
{
    internal class ChangeStreamNewHoaDon
    {
        private static IMongoDatabase database;

        private string connectionString = ConfigurationManager.ConnectionStrings["MongoDbConnectionString"].ConnectionString;
        private string databaseName = "QuanLySan"; // Tên cơ sở dữ liệu của bạn

        public ChangeStreamNewHoaDon()
        {
            // Khởi tạo MongoDB client và database khi lớp ChangeStreamNewHoaDon được tạo
            var client = new MongoClient(connectionString); // Sử dụng connectionString từ App.config
            database = client.GetDatabase(databaseName);

            // Bắt đầu lắng nghe các thay đổi
            StartListening();
        }

        public void StartListening()
        {
            var collection = database.GetCollection<BsonDocument>("HoaDon");

            // Thiết lập pipeline để lắng nghe các thay đổi
            var pipeline = PipelineDefinition<ChangeStreamDocument<BsonDocument>, ChangeStreamDocument<BsonDocument>>.Create(
                new BsonDocument { { "$match", new BsonDocument { { "operationType", "update" } } } });

            // Lắng nghe thay đổi (insert, update, delete)
            var changeStream = collection.Watch(pipeline);

            // Đọc các thay đổi khi chúng xảy ra
            changeStream.ForEachAsync(change =>
            {
                // Xử lý thay đổi mà không in ra thông báo
                HandleChange(change);

            }).Wait();
        }

        public void HandleChange(ChangeStreamDocument<BsonDocument> change)
        {
            // Lấy mã sân từ tài liệu thay đổi
            var maSan = change.FullDocument["MaSan"].AsInt32;

            // Cập nhật trạng thái sân trong collection "San" mà không thông báo
            var sanCollection = database.GetCollection<BsonDocument>("San");
            var filter = Builders<BsonDocument>.Filter.Eq("MaSan", maSan);
            var update = Builders<BsonDocument>.Update.Set("Status", "Có người");

            sanCollection.UpdateOne(filter, update);
        }
    }
}
