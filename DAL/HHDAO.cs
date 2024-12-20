using BadmintonManager.DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BadmintonManager.DAO
{
    internal class HHDAO
    {
        private static HHDAO instance;
        public static HHDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HHDAO();
                return HHDAO.instance;
            }
            private set
            {
                HHDAO.instance = value;
            }
        }
        private HHDAO() { }

        // Lấy danh sách hàng hóa theo mã loại hàng hóa
        public List<HH> GetListByLoaiHH(ObjectId LoaiKH)
        {
            List<HH> list = new List<HH>();
            string collectionName = "HangHoa";
            var filter = Builders<BsonDocument>.Filter.Eq("maLoaiHH", LoaiKH);
            var documents = MongoDataProvider.Instance.ExecuteQuery(collectionName, filter);
            foreach (var doc in documents)
            {
                HH hanghoa = new HH(doc);
                list.Add(hanghoa);
            }

            return list;
        }
        // Lấy danh sách hàng hóa theo mã hàng hóa (sử dụng _id thay vì maHH)
        public List<HH> GetItemByMaHH(ObjectId id)
        {
            List<HH> list = new List<HH>();
            string collectionName = "HangHoa"; // Tên collection MongoDB

            // Lọc hàng hóa theo _id (MongoDB identifier)
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var documents = MongoDataProvider.Instance.ExecuteQuery(collectionName, filter);

            foreach (var doc in documents)
            {
                // Chuyển đổi từ BsonDocument sang HH
                HH hanghoa = new HH(doc);
                list.Add(hanghoa);
            }

            return list;
        }

        // Lấy đơn giá của hàng hóa theo _id hàng hóa và đơn vị tính
        public decimal GetDonGiaByMaHHAndDVT(ObjectId id, string donViTinh)
        {
            string collectionName = "HangHoa"; // Tên collection MongoDB

            // Lọc theo _id hàng hóa
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var document = MongoDataProvider.Instance.ExecuteQuery(collectionName, filter).FirstOrDefault();
            if (document != null)
            {
                if (donViTinh == document["donViTinhLon"].AsString)
                {
                    // Trả về giá bán lớn nếu đơn vị tính là DonViTinhLon
                    return document["giaBanLon"].ToDecimal();
                }
                else if (donViTinh == document["donViTinhNho"].AsString)
                {
                    // Trả về giá bán nhỏ nếu đơn vị tính là DonViTinhNho
                    return document["giaBanNho"].ToDecimal();
                }
            }

            // Trường hợp không tìm thấy hoặc không khớp đơn vị tính, trả về 0
            return 0;
        }

    }
}
