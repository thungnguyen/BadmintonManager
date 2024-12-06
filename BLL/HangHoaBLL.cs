using BadmintonManager.DAL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BadmintonManager.BLL
{
    /// <summary>
    /// Business Logic Layer for Product Management
    /// </summary>
    public class HangHoaBLL
    {
        private HangHoaDAL _hangHoaDAL;

        public HangHoaBLL()
        {
            _hangHoaDAL = new HangHoaDAL();
        }

        /// <summary>
        /// Gets all products with business logic applied
        /// </summary>
        public List<HangHoa> GetAllProducts()
        {
            var products = _hangHoaDAL.GetAllProducts();

            // Example of LINQ-based business logic
            return products
                .Where(p => p.GiaBanLon > 0)
                .OrderBy(p => p.TenHH)
                .ToList();
        }

        /// <summary>
        /// Validates and adds a new product
        /// </summary>
        public int AddProduct(HangHoa product)
        {
            // Business validation
            if (string.IsNullOrWhiteSpace(product.TenHH))
            {
                throw new ArgumentException("Product name cannot be empty");
            }

            if (product.GiaBanLon <= 0)
            {
                throw new ArgumentException("Product price must be greater than zero");
            }

            return _hangHoaDAL.AddProduct(product);
        }

        /// <summary>
        /// Gets products by category
        /// </summary>
        public List<HangHoa> GetProductsByCategory(int categoryId)
        {
            var products = _hangHoaDAL.GetAllProducts();
            return products
                .Where(p => p.MaLoaiHH == categoryId)
                .ToList();
        }
    }
}
