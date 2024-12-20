using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using BadmintonManager.DTO;

namespace BadmintonManager.DAL
{
    public class GiaSanDAL_MongoDB
    {
        private readonly MongoDBConnection _mongoDBConnection;
        private readonly IMongoCollection<BsonDocument> _giaSanCollection;

        public GiaSanDAL_MongoDB()
        {
            _mongoDBConnection = new MongoDBConnection();
            var database = _mongoDBConnection.Connect();
            _giaSanCollection = database.GetCollection<BsonDocument>("BangGiaSan"); // Tên collection trong MongoDB
        }

        public List<GiaSanDTO> GetGiaSanByLoaiKhach(string loaiKhach)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("loaiKH", loaiKhach);
            var giaSanDocuments = _giaSanCollection.Find(filter).ToList();

            List<GiaSanDTO> danhSachGiaSan = new List<GiaSanDTO>();

            foreach (var doc in giaSanDocuments)
            {
                var giaSan = new GiaSanDTO
                {
                    GiaTruoc17 = doc["gioBatDau"].AsString == "05:00:00" ? doc["gia"].AsDecimal : 0,
                    GiaSau17 = doc["gioBatDau"].AsString == "17:00:00" ? doc["gia"].AsDecimal : 0,
                    GioBatDau = TimeSpan.Parse(doc["gioBatDau"].AsString),
                    GioKetThuc = TimeSpan.Parse(doc["gioKetThuc"].AsString),
                    LoaiKhach = doc["loaiKH"].AsString
                };
                danhSachGiaSan.Add(giaSan);
            }

            return danhSachGiaSan;
        }
    }
}