using BadmintonManager.DAO;
using BadmintonManager.DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadmintonManager.DAL
{
    internal class BCDTDAL
    {
        private static BCDTDAL instance;

        public static BCDTDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BCDTDAL();
                }
                return instance;
            }
            private set => instance = value;
        }

        private BCDTDAL() { }

        private string collectionName = "HoaDon"; // Tên collection trong MongoDB
        public List<Bill> GetDanhSachHD()
        {
            try
            {
                // Lấy collection "HoaDon" từ MongoDB
                var collection = MongoDataProvider.Instance.GetDatabase().GetCollection<BsonDocument>("HoaDon");

                // Tìm tất cả các tài liệu trong collection và chuyển đổi thành danh sách Bill
                var documents = collection.Find(Builders<BsonDocument>.Filter.Empty).ToList();
                var danhSachHoaDon = documents
                    .Where(doc => doc.Contains("status") && doc["status"] == 1) // Lọc chỉ lấy các hóa đơn có status = 1
                    .Select(doc => new Bill
                    {
                        Id = doc["_id"].AsObjectId,
                        MaDatSan = doc["maDatSan"].IsBsonNull ? (ObjectId?)null : doc["maDatSan"].AsObjectId,
                        NgayLap = doc["ngayLap"].ToUniversalTime(),
                        TongTien = doc["tongTien"].ToDecimal(),
                        Status = doc["status"].ToInt32()
                    })
                    .ToList();

                return danhSachHoaDon;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Bill>();
            }
        }
    }
}
