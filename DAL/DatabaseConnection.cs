using MongoDB.Driver;
using System;

namespace BadmintonManager.DAL
{
    internal class DatabaseConnection
    {
        /// <summary>
        /// Manages MongoDB connection and provides utility methods for database interactions
        /// </summary>

        // MongoDB connection string
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MongoDbConnectionString"].ConnectionString;

        // Hardcoded database name
        private static string databaseName = "QuanLySan";

        // MongoDB Client instance
        private static MongoClient client = null;

        // MongoDatabase instance
        private static IMongoDatabase database = null;

        /// <summary>
        /// Gets a MongoDatabase instance (singleton pattern)
        /// </summary>
        public static IMongoDatabase GetDatabase()
        {
            if (database == null)
            {
                try
                {
                    if (client == null)
                    {
                        client = new MongoClient(connectionString);
                    }
                    database = client.GetDatabase(databaseName);
                }
                catch (Exception ex)
                {
                    // Log error here
                    throw new InvalidOperationException("MongoDB database could not be initialized.", ex);
                }
            }
            return database;
        }
    }
}
