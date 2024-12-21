using BadmintonManager.DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BadmintonManager.DAO
{
    internal class LoaiHHDAO
    {
        private static LoaiHHDAO instance;
        public static LoaiHHDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiHHDAO();
                return LoaiHHDAO.instance;
            }
            private set
            {
                LoaiHHDAO.instance = value;
            }
        }
        private LoaiHHDAO() { }

        public List<LoaiHH> GetListLoaiHH()
        {
            List<LoaiHH> list = new List<LoaiHH>();
            string collectionName = "LoaiHH"; // Tên collection MongoDB
            var filter = Builders<BsonDocument>.Filter.Empty; // Lọc tất cả các tài liệu
            var documents = MongoDataProvider.Instance.ExecuteQuery(collectionName, filter);

            foreach (var doc in documents)
            {
                // Chuyển đổi từ BsonDocument sang LoaiHH (có thể cần điều chỉnh constructor của LoaiHH để nhận BsonDocument)
                LoaiHH loaiHH = new LoaiHH(doc);
                list.Add(loaiHH);
            }

            return list;
        }
    }
}
