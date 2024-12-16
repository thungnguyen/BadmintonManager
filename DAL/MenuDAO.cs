using BadmintonManager.DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BadmintonManager.DAO
{
    internal class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new MenuDAO();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        private MenuDAO() { }

        // Hàm này sử dụng MongoDB để lấy danh sách Menu theo mã sân
        public List<Menu> GetListMenuBySan(int maSan)
        {
            List<Menu> listMenu = new List<Menu>();

            // Lọc các hóa đơn theo mã sân và trạng thái hóa đơn là 0 (mới)
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("status", 0),
                Builders<BsonDocument>.Filter.Eq("maSan", maSan)
            );

            // Truy vấn MongoDB để lấy các hóa đơn
            var billItems = MongoDataProvider.Instance.ExecuteQuery("HoaDon", filter);

            foreach (var bill in billItems)
            {
                // Lấy thông tin các sản phẩm từ bảng chi tiết hóa đơn
                var detailFilter = Builders<BsonDocument>.Filter.Eq("maHD", bill["_id"].AsObjectId); // Lấy _id của hóa đơn (ObjectId)
                var productDetails = MongoDataProvider.Instance.ExecuteQuery("HDSP", detailFilter);

                foreach (var productDetail in productDetails)
                {
                    var productFilter = Builders<BsonDocument>.Filter.Eq("_id", productDetail["maHH"].AsObjectId); // Lấy ObjectId của sản phẩm
                    var product = MongoDataProvider.Instance.ExecuteQuery("HangHoa", productFilter).FirstOrDefault();

                    if (product != null)
                    {
                        // Lấy tên sản phẩm một cách an toàn
                        string productName = product.Contains("tenHH") ? product["tenHH"].AsString : "Tên sản phẩm không có sẵn";
                        int soLuong = productDetail["soLuong"].ToInt32(); // Lấy số lượng từ chi tiết hóa đơn

                        // Xác định giá bán theo đơn vị tính trong chi tiết hóa đơn (HDSP)
                        decimal price = 0;
                        if (productDetail["donViTinh"] == product["donViTinhLon"]) // So sánh với đơn vị tính lớn của sản phẩm
                        {
                            price = product["giaBanLon"].ToDecimal();
                        }
                        else if (productDetail["donViTinh"] == product["donViTinhNho"]) // So sánh với đơn vị tính nhỏ của sản phẩm
                        {
                            price = product["giaBanNho"].ToDecimal();
                        }

                        // Kiểm tra điều kiện DonViTinh để tính tổng giá trị nếu đúng
                        if (productDetail["donViTinh"] == product["donViTinhLon"] || productDetail["donViTinh"] == product["donViTinhNho"])
                        {
                            // Tính tổng giá trị cho sản phẩm
                            decimal totalPrice = soLuong * price;

                            // Tạo đối tượng Menu và thêm vào listMenu
                            var menu = new Menu
                            {
                                TenHangHoa = productName,     // Gán tên sản phẩm
                                Count = soLuong,              // Gán số lượng
                                Unit = productDetail["donViTinh"].AsString, // Gán đơn vị tính từ chi tiết hóa đơn
                                Price = price,                // Gán giá bán
                                TotalPrices = totalPrice      // Gán tổng giá trị
                            };
                            listMenu.Add(menu); // Thêm vào listMenu
                        }
                    }
                }
            }

            return listMenu;
        }



    }
}
