using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class BaoCaoDoanhThuForm : Form
    {
        private static MongoClient _mongoClient;
        private static IMongoDatabase _database;
        private static readonly string ConnectionString = "mongodb+srv://khoa:3112@clusterkhoa.1b5ey.mongodb.net/";
        private static readonly string DatabaseName = "QuanLySan"; // Tên database bạn muốn kết nối

        private IMongoCollection<HoaDon> hoaDonCollection;

        public BaoCaoDoanhThuForm()
        {
            InitializeComponent();
            // Kết nối MongoDB Atlas
            _mongoClient = new MongoClient(ConnectionString);
            _database = _mongoClient.GetDatabase(DatabaseName);
            hoaDonCollection = _database.GetCollection<HoaDon>("HoaDon");  // "HoaDon" là tên collection
        }

        private void BaoCaoDoanhThuForm_Load(object sender, EventArgs e)
        {
            // Khởi tạo DataGridView và thêm cột
            dataGridViewDoanhThu.Columns.Add("MaHD", "Mã Hóa Đơn");
            dataGridViewDoanhThu.Columns.Add("NgayLap", "Ngày Lập");
            dataGridViewDoanhThu.Columns.Add("TongTien", "Tổng Tiền");

            // Lấy dữ liệu từ MongoDB và hiển thị lên DataGridView
            var hoaDons = hoaDonCollection.Find(h => h.NgayLap >= dateTimePickerFrom.Value && h.NgayLap <= dateTimePickerTo.Value).ToList();

            foreach (var hoaDon in hoaDons)
            {
                dataGridViewDoanhThu.Rows.Add(hoaDon.MaHD, hoaDon.NgayLap.ToString("yyyy-MM-dd HH:mm:ss"), hoaDon.TongTien);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Lọc lại dữ liệu theo ngày từ và đến
            DateTime fromDate = dateTimePickerFrom.Value;
            DateTime toDate = dateTimePickerTo.Value;

            var hoaDons = hoaDonCollection.Find(h => h.NgayLap >= fromDate && h.NgayLap <= toDate).ToList();

            decimal totalAmount = 0;
            foreach (var hoaDon in hoaDons)
            {
                totalAmount += hoaDon.TongTien;
            }

            // Hiển thị tổng tiền trong TextBox
            txtTongTien.Text = totalAmount.ToString("C");
        }

        private void dataGridViewDoanhThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BaoCaoDoanhThuForm_Load_1(object sender, EventArgs e)
        {

        }
    }

    // Định nghĩa class HoaDon cho MongoDB
    public class HoaDon
    {
        public ObjectId Id { get; set; }
        public int MaHD { get; set; }
        public string MaDatSan { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public int MaSan { get; set; }
        public int Status { get; set; }
    }
}
