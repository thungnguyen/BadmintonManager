using BadmintonManager.DAO;
using BadmintonManager.DTO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;  // Thêm dòng này để sử dụng LINQ

using System.Data.SqlClient;
using System.Windows.Forms;
using MongoDB.Driver;
using DnsClient;

namespace BadmintonManager.DAL
{
    public class DanhSachLichSanDAL
    {
        private static DanhSachLichSanDAL instance;
        public static DanhSachLichSanDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DanhSachLichSanDAL();
                return instance;
            }
            private set => instance = value;
        }

        private DanhSachLichSanDAL() { }

        private string collectionName = "LichDatSan";
        private string khachHangCollection = "KhachHang";
        public List<DanhSachLichSanDTO> GetDanhSachLichSan()
        {
            // Lấy tất cả các tài liệu từ collection "LichSan"
            var collection = MongoDataProvider.Instance.GetDatabase().GetCollection<BsonDocument>(collectionName);

            // Tìm tất cả các tài liệu trong collection
            var documents = collection.Find(Builders<BsonDocument>.Filter.Empty).ToList();

            // Chuyển đổi các tài liệu BSON thành đối tượng DTO DanhSachLichSanDTO
            var danhSachLichSan = documents.Select(doc => new DanhSachLichSanDTO(doc)).ToList();

            return danhSachLichSan;
        }
        public string GetTenSanById(string maSan)
        {
            // Chuyển đổi chuỗi maSan thành ObjectId
            if (ObjectId.TryParse(maSan, out ObjectId objectId))
            {
                // Lấy collection "San"
                var collection = MongoDataProvider.Instance.GetDatabase().GetCollection<BsonDocument>("San");

                // Tạo bộ lọc tìm kiếm theo _id là ObjectId
                var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);

                // Tìm kiếm tài liệu
                var result = collection.Find(filter).FirstOrDefault();

                // Trả về tên sân nếu tìm thấy, nếu không thì trả về "Không xác định"
                return result?["tenSan"].AsString ?? "Không xác định";
            }
            else
            {
                // Nếu maSan không phải là một ObjectId hợp lệ
                return "ID không hợp lệ";
            }
        }

        public string GetTenKhachHangById(string maKH)
        {
            // Chuyển đổi chuỗi maKH thành ObjectId
            if (ObjectId.TryParse(maKH, out ObjectId objectId))
            {
                // Lấy collection "KhachHang"
                var collection = MongoDataProvider.Instance.GetDatabase().GetCollection<BsonDocument>("KhachHang");

                // Tạo bộ lọc tìm kiếm theo _id là ObjectId
                var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);

                // Tìm kiếm tài liệu
                var result = collection.Find(filter).FirstOrDefault();

                // Trả về tên khách hàng nếu tìm thấy, nếu không thì trả về "Không xác định"
                return result?["tenKH"].AsString ?? "Không xác định";
            }
            else
            {
                // Nếu maKH không phải là một ObjectId hợp lệ
                return "ID không hợp lệ";
            }
        }

        public bool XoaLichSan(ObjectId maDatSan)
        {
            try
            {
                // Lấy collection từ MongoDB
                var database = MongoDataProvider.Instance.GetDatabase();
                var collection = database.GetCollection<BsonDocument>(collectionName);

                // Tạo filter để tìm kiếm tài liệu cần xóa
                var filter = Builders<BsonDocument>.Filter.Eq("_id", maDatSan);

                // Thực hiện xóa tài liệu
                var result = collection.DeleteOne(filter); // Xóa 1 tài liệu đầu tiên thỏa mãn filter

                // Kiểm tra xem có xóa thành công không
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // Bắt lỗi và hiển thị thông báo
                Console.WriteLine("Lỗi khi xóa lịch sân: " + ex.Message);
                return false;
            }
        }

        public List<BsonDocument> TimKiemLichSan(DateTime tuNgay, DateTime denNgay)
        {
            // Kết nối đến cơ sở dữ liệu MongoDB
            var filter = Builders<BsonDocument>.Filter.Gte("tuNgay", tuNgay) & Builders<BsonDocument>.Filter.Lte("tuNgay", denNgay);

            try
            {
                // Thực thi truy vấn và lấy dữ liệu
                var result = MongoDataProvider.Instance.ExecuteQuery(collectionName, filter);

                return result;  // Trả về danh sách các tài liệu (BsonDocument)
            }
            catch (Exception ex)
            {
                // Bắt lỗi nếu có
                Console.WriteLine("Lỗi khi tìm kiếm lịch: " + ex.Message);
                return new List<BsonDocument>();  // Trả về danh sách trống nếu có lỗi
            }
        }

        public ObjectId TimMaKHTheoTen(string tenKhachHang)
        {
            try
            {
                // Truy cập collection KhachHang
                var collection = MongoDataProvider.Instance.GetDatabase().GetCollection<BsonDocument>("KhachHang");

                // Tạo filter tìm kiếm tên khách hàng
                var filter = Builders<BsonDocument>.Filter.Regex("tenKH", new BsonRegularExpression(tenKhachHang, "i"));

                // Tìm kiếm khách hàng theo tên
                var khachHang = collection.Find(filter).FirstOrDefault();

                // Nếu tìm thấy khách hàng, trả về ObjectId của khách hàng
                if (khachHang != null)
                {
                    return khachHang["_id"].AsObjectId;
                }

                // Trả về ObjectId không hợp lệ nếu không tìm thấy
                return ObjectId.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm khách hàng: " + ex.Message);
                return ObjectId.Empty;
            }
        }
        public List<BsonDocument> TimLichSanTheoMaKH(ObjectId maKH)
        {
            try
            {
                // Truy cập collection LichDatSan
                var collection = MongoDataProvider.Instance.GetDatabase().GetCollection<BsonDocument>("LichDatSan");

                // Tạo filter để tìm các lịch sân có maKH tương ứng
                var filter = Builders<BsonDocument>.Filter.Eq("maKH", maKH);

                // Thực hiện truy vấn tìm kiếm
                var result = collection.Find(filter).ToList();

                return result;  // Trả về danh sách các tài liệu (BsonDocument)
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm lịch sân theo maKH: " + ex.Message);
                return new List<BsonDocument>();  // Trả về danh sách trống nếu có lỗi
            }
        }
                public List<BsonDocument> TimLichSanTheoTenKH(string tenKhachHang)
        {
            // Bước 1: Tìm kiếm maKH theo tên khách hàng
            ObjectId maKH = TimMaKHTheoTen(tenKhachHang);

            // Nếu không tìm thấy maKH, trả về danh sách trống
            if (maKH == ObjectId.Empty)
            {
                Console.WriteLine("Không tìm thấy khách hàng.");
                return new List<BsonDocument>();
            }

            // Bước 2: Tìm kiếm lịch sân theo maKH
            return TimLichSanTheoMaKH(maKH);
        }

        public List<BsonDocument> GetLichSanByMaDatSan(ObjectId maDatSan)
        {
            var result = new List<BsonDocument>();  // Danh sách kết quả trả về

            try
            {
                // Truy cập vào MongoDB và lấy collection LichDatSan
                var collection = MongoDataProvider.Instance.GetDatabase().GetCollection<BsonDocument>("LichDatSan");

                // Tạo filter để tìm kiếm theo ObjectId của MaDatSan
                var filter = Builders<BsonDocument>.Filter.Eq("_id", maDatSan);  // Sử dụng _id cho MongoDB

                // Thực hiện truy vấn để lấy dữ liệu
                result = collection.Find(filter).ToList();  // Trả về danh sách các BsonDocument

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return result;
        }

    }
}
