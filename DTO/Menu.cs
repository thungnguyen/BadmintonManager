using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BadmintonManager.DTO
{
    internal class Menu
    {
        public Menu(string tenHangHoa, int count, decimal price, decimal totalPrices, string unit)
        {
            this.TenHangHoa = tenHangHoa;
            this.Count = count;
            this.Price = price;
            this.TotalPrices = totalPrices;
            this.Unit = unit;
        }
        public Menu() { }
        public Menu(BsonDocument doc)
        {
            this.TenHangHoa = doc.Contains("tenHH") ? doc["tenHH"].AsString : "Tên sản phẩm không có sẵn";
            this.Count = doc.Contains("soLuong") ? doc["soLuong"].AsInt32 : 0;
            this.Price = doc.Contains("donGia") ? doc["donGia"].ToDecimal() : 0;
            this.TotalPrices = doc.Contains("thanhTien") ? doc["thanhTien"].ToDecimal() : 0;
            this.Unit = doc.Contains("donViTinh") ? doc["donViTinh"].AsString : "Không xác định";
        }

        [BsonElement("tenHH")]
        public string TenHangHoa { get; set; }

        [BsonElement("soLuong")]
        public int Count { get; set; }

        [BsonElement("donGia")]
        public decimal Price { get; set; }

        [BsonElement("thanhTien")]
        public decimal TotalPrices { get; set; }

        [BsonElement("donViTinh")]
        public string Unit { get; set; }
    }
}
