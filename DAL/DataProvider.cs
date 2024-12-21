using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace BadmintonManager.DAO
{
    public class MongoDataProvider
    {
        private static MongoDataProvider instance;
        public static MongoDataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MongoDataProvider();
                }
                return instance;
            }
            private set => instance = value;
        }

        private MongoDataProvider() { }
        private string connectionString = ConfigurationManager.ConnectionStrings["MongoDbConnectionString"].ConnectionString;
        private string databaseName = "QuanLySan"; // Replace with your database name

        public IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(connectionString);
            return client.GetDatabase(databaseName);
        }

        public List<BsonDocument> ExecuteQuery(string collectionName, FilterDefinition<BsonDocument> filter = null)
        {
            var database = GetDatabase();
            var collection = database.GetCollection<BsonDocument>(collectionName);

            filter = filter ?? Builders<BsonDocument>.Filter.Empty; // If no filter provided, return all documents

            return collection.Find(filter).ToList();
        }

        public void InsertDocument(string collectionName, BsonDocument document)
        {
            var database = GetDatabase();
            var collection = database.GetCollection<BsonDocument>(collectionName);

            collection.InsertOne(document);
        }

        public void UpdateDocument(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            var database = GetDatabase();
            var collection = database.GetCollection<BsonDocument>(collectionName);

            collection.UpdateOne(filter, update);
        }

        public void DeleteDocument(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var database = GetDatabase();
            var collection = database.GetCollection<BsonDocument>(collectionName);

            collection.DeleteOne(filter);
        }

        public BsonValue ExecuteScalar(string collectionName, FilterDefinition<BsonDocument> filter, string fieldName)
        {
            var database = GetDatabase();
            var collection = database.GetCollection<BsonDocument>(collectionName);

            var document = collection.Find(filter).FirstOrDefault();
            return document != null && document.Contains(fieldName) ? document[fieldName] : BsonNull.Value;
        }
        public BsonDocument GetDocument(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var database = GetDatabase();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            return collection.Find(filter).FirstOrDefault();  // Trả về tài liệu đầu tiên nếu có, hoặc null nếu không tìm thấy
        }
        public long CountDocuments(string collectionName, FilterDefinition<BsonDocument> filter = null)
        {
            var database = GetDatabase();
            var collection = database.GetCollection<BsonDocument>(collectionName);

            filter = filter ?? Builders<BsonDocument>.Filter.Empty;

            return collection.CountDocuments(filter);
        }
        public void ExecuteStoredProcedure(string storedProcedureName, params object[] parameters)
        {
            // MongoDB không hỗ trợ Stored Procedures theo cách của SQL Server.
            // Thay vào đó, bạn có thể triển khai logic thông qua mã ứng dụng.
            throw new NotImplementedException("Stored procedures are not supported in MongoDB.");
        }


    }
}   