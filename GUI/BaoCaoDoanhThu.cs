using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BadmintonManager.DAL;
using MongoDB.Driver;
using BadmintonManager.DAO;
using MongoDB.Driver.Linq;

namespace BadmintonManager.GUI
{
    public partial class BaoCaoDoanhThuForm : Form
    {

        public BaoCaoDoanhThuForm()
        {
            InitializeComponent();

        }

        private void BaoCaoDoanhThuForm_Load(object sender, EventArgs e)
        {
            LoadBCDT();
        }
        private void LoadBCDT()
        {
            try
            {
                // Lấy danh sách hóa đơn
                var danhSachHoaDon = BCDTDAL.Instance.GetDanhSachHD();

                // Xóa các item cũ trên ListView
                lsvHoaDon.Items.Clear();

                decimal tongTienTatCa = 0; // Biến để lưu tổng tiền

                // Thêm các hóa đơn vào ListView
                foreach (var hoaDon in danhSachHoaDon)
                {
                    // Tạo ListViewItem và thêm các cột
                    ListViewItem item = new ListViewItem(hoaDon.Id.ToString());
                    item.SubItems.Add(hoaDon.MaDatSan.HasValue ? hoaDon.MaDatSan.ToString() : ""); // Kiểm tra null
                    item.SubItems.Add(hoaDon.NgayLap.HasValue ? hoaDon.NgayLap.Value.ToString("yyyy-MM-dd HH:mm:ss") : ""); // Định dạng ngày giờ
                    item.SubItems.Add(hoaDon.TongTien.HasValue ? hoaDon.TongTien.Value.ToString("N0") : ""); // Định dạng tiền tệ

                    // Cộng tổng tiền
                    if (hoaDon.TongTien.HasValue)
                    {
                        tongTienTatCa += hoaDon.TongTien.Value;
                    }

                    // Thêm item vào ListView
                    lsvHoaDon.Items.Add(item);
                }

                // Hiển thị tổng tiền vào ô txtTongTien
                txtTongTien.Text = tongTienTatCa.ToString("N0", System.Globalization.CultureInfo.CurrentCulture); // Định dạng tiền tệ
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị danh sách hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
        }


    }

    // Định nghĩa class HoaDon

}
