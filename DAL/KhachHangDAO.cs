using BadmintonManager.DTO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace BadmintonManager.DAO
{
    internal class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KhachHangDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private KhachHangDAO() { }

        // Lấy danh sách khách hàng
        public List<KhachHang> GetListKhachHang()
        {
            List<KhachHang> listKhachHang = new List<KhachHang>();
            string collectionName = "KhachHang"; // Tên collection MongoDB

            // Truy vấn tất cả khách hàng từ MongoDB
            var documents = MongoDataProvider.Instance.ExecuteQuery(collectionName);

            foreach (var item in documents)
            {
                KhachHang kh = new KhachHang(item);  // Chuyển đổi từ BsonDocument sang đối tượng KhachHang
                listKhachHang.Add(kh);
            }
            return listKhachHang;
        }
    }
}
