using System;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DAL
{
    public class MongoDBConnection
    {
        private static MongoClient _mongoClient;
        private static IMongoDatabase _database;
        private static readonly string ConnectionString = "mongodb+srv://khoa:3112@clusterkhoa.1b5ey.mongodb.net/";
        private static readonly string DatabaseName = "QuanLySan";

        public IMongoDatabase Connect()
        {
            if (_mongoClient == null)
            {
                try
                {
                    _mongoClient = new MongoClient(ConnectionString);
                    Console.WriteLine("Đã kết nối tới MongoDB thành công.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi kết nối MongoDB: {ex.Message}");
                    throw;  // Ném lại exception để các tầng khác xử lý
                }
            }

            try
            {
                _database = _mongoClient.GetDatabase(DatabaseName);
                Console.WriteLine($"Kết nối thành công tới database: {DatabaseName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kết nối tới database '{DatabaseName}': {ex.Message}");
                throw;
            }

            return _database;
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            var database = Connect();
            return database.GetCollection<T>(collectionName);
        }
    }
}
