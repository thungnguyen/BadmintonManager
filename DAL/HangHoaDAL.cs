using MongoDB.Driver;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;

namespace BadmintonManager.DAL
{
    public class HangHoaDAL
    {
        private readonly IMongoCollection<HangHoa> _hangHoaCollection;


        public HangHoaDAL()
        {
            // Initialize MongoDB connection and get the collection
            var client = new MongoClient("mongodb://localhost:27017"); 
            var database = client.GetDatabase("BadmintonManager");   
            _hangHoaCollection = database.GetCollection<HangHoa>("HangHoa"); 
        }

        /// <summary>
        /// Retrieves all products from the MongoDB collection
        /// </summary>
        public List<HangHoa> GetAllProducts()
        {
            return _hangHoaCollection.Find(_ => true).ToList();
        }

        /// <summary>
        /// Retrieves a product by its ID
        /// </summary>
        public HangHoa GetProductById(string id)
        {
            return _hangHoaCollection.Find(product => product.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Adds a new product to the MongoDB collection
        /// </summary>
        public void AddProduct(HangHoa product)
        {
            _hangHoaCollection.InsertOne(product);
        }

        /// <summary>
        /// Updates an existing product in the MongoDB collection
        /// </summary>
        public void UpdateProduct(string id, HangHoa updatedProduct)
        {
            _hangHoaCollection.ReplaceOne(product => product.Id == id, updatedProduct);
        }

        /// <summary>
        /// Deletes a product by its ID
        /// </summary>
        public void DeleteProduct(string id)
        {
            var result = _hangHoaCollection.DeleteOne(product => product.Id == id);
            if (result.DeletedCount == 0)
            {
                throw new Exception("No product found with the specified ID.");
            }
        }

        /// <summary>
        /// Retrieves products matching a search term
        /// </summary>
        public List<HangHoa> GetProducts(string searchTerm = null)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return GetAllProducts();
            }

            // Perform a case-insensitive search on the "TenHH" field
            var filter = Builders<HangHoa>.Filter.Regex("tenHH", new MongoDB.Bson.BsonRegularExpression(searchTerm, "i"));
            return _hangHoaCollection.Find(filter).ToList();
        }
    }
}
