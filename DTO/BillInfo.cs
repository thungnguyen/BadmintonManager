using MongoDB.Bson;

public class BillInfo
{
    public ObjectId MaHD { get; set; }
    public ObjectId MaHH { get; set; }
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public decimal ThanhTien { get; set; }
    public string DonViTinh { get; set; }

    public BillInfo(ObjectId maHD, ObjectId maHH, int soLuong, decimal donGia, decimal thanhTien, string donViTinh)
    {
        MaHD = maHD;
        MaHH = maHH;
        SoLuong = soLuong;
        DonGia = donGia;
        ThanhTien = thanhTien;
        DonViTinh = donViTinh;
    }

    public BillInfo(BsonDocument doc)
    {
        MaHD = doc["maHD"].AsObjectId;
        MaHH = doc["maHH"].AsObjectId;
        SoLuong = doc["soLuong"].ToInt32();
        DonGia = doc["donGia"].ToDecimal();
        ThanhTien = doc["thanhTien"].ToDecimal();
        DonViTinh = doc["donViTinh"].AsString;
    }
}