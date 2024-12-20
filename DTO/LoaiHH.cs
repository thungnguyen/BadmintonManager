using MongoDB.Bson;

namespace BadmintonManager.DTO
{
    internal class LoaiHH
    {
        // Khởi tạo từ các tham số
        public LoaiHH(int maLoaiHH, string tenLoaiHH, ObjectId _id)
        {
            this._Id = _id;
            this.MaLoaiHH = maLoaiHH;
            this.TenLoaiHH = tenLoaiHH;
        }

        // Khởi tạo từ BsonDocument
        public LoaiHH(BsonDocument doc)
        {
            this._Id = doc.Contains("_id") ? doc["_id"].AsObjectId : ObjectId.Empty;
            this.MaLoaiHH = doc.Contains("maLoaiHH") ? doc["maLoaiHH"].ToInt32() : 0;
            this.TenLoaiHH = doc.Contains("tenLoaiHH") ? doc["tenLoaiHH"].ToString() : string.Empty;
        }
        public ObjectId _Id { get; set; }
        private int maLoaiHH;
        public int MaLoaiHH
        {
            get { return maLoaiHH; }
            set { maLoaiHH = value; }
        }

        private string tenLoaiHH;
        public string TenLoaiHH
        {
            get { return tenLoaiHH; }
            set { tenLoaiHH = value; }
        }
    }
}
