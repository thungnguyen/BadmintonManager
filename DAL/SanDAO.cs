using MongoDB.Bson;
using MongoDB.Driver;
using BadmintonManager.DTO;
using System.Collections.Generic;

namespace BadmintonManager.DAO
{
    internal class SanDAO
    {
        private static SanDAO instance;

        public static SanDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SanDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        public static int SanWidth = 50;
        public static int SanHeight = 50;

        private SanDAO() { }

        private string collectionName = "San"; // Tên collection trong MongoDB

        public List<San> LoadSanList()
        {
            List<San> sanList = new List<San>();
            var documents = MongoDataProvider.Instance.ExecuteQuery("San"); // 'San' là tên collection MongoDB.

            foreach (var doc in documents)
            {
                San san = new San(doc); // Sử dụng constructor nhận BsonDocument.
                sanList.Add(san);
            }

            return sanList;
        }

        public void InsertSan(string tenSan, int maSan)
        {
            var newDocument = new BsonDocument
            {
                {"maSan" , maSan },
                { "tenSan", tenSan },
                { "status", "Trống" } // Giả định trạng thái mặc định là "Trống"
            };

            MongoDataProvider.Instance.InsertDocument(collectionName, newDocument);
        }

        public void UpdateSan(int maSan, string tenSan)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maSan", maSan);
            var update = Builders<BsonDocument>.Update.Set("tenSan", tenSan);

            MongoDataProvider.Instance.UpdateDocument(collectionName, filter, update);
        }

        public void DeleteSan(int maSan)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maSan", maSan);
            MongoDataProvider.Instance.DeleteDocument(collectionName, filter);
        }
    }
}
