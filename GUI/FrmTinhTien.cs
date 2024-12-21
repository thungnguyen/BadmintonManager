using BadmintonManager.DAO;
using BadmintonManager.DTO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = BadmintonManager.DTO.Menu;

namespace BadmintonManager.GUI
{
    public partial class FrmTinhTien : Form
    {
        public FrmTinhTien()
        {
            InitializeComponent();
        }

        private void FrmTinhTien_Load(object sender, EventArgs e)
        {
            LoadLoaiHH();
            LoadSanData();
            LoadKhachHang();
            LoadLoaiKHComboBox();
            TinhGioRa();
            LoadTongTien();

        }

        #region methods

        //Mongo chạy thành công
        //Mongo chạy thành công
        //Mongo chạy thành công
        private void LoadLoaiHH()
        {
            List<LoaiHH> listLoaiHH = LoaiHHDAO.Instance.GetListLoaiHH();
            cbLoaiHH.DataSource = listLoaiHH;
            cbLoaiHH.DisplayMember = "TenLoaiHH";
        }
        private void LoadHangHoaByLoaiHH(ObjectId maLoaiHH)
        {
            List<HH> listHH = HHDAO.Instance.GetListByLoaiHH(maLoaiHH);
            cbHH.DataSource = listHH;
            cbHH.DisplayMember = "TenHH";   // Hiển thị tên hàng hóa
            cbHH.ValueMember = "Id";        // Dùng ObjectId làm giá trị của ComboBox
        }

        void ShowHangHoa(ObjectId maLoaiHH)
        {
            lsvHangHoa.Items.Clear();
            List<HH> listHangHoa = HHDAO.Instance.GetListByLoaiHH(maLoaiHH);

            foreach (HH item in listHangHoa)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenHH.ToString());
                lsvItem.Tag = item.Id;
                lsvHangHoa.Items.Add(lsvItem);
            }
        }
        private void LoadKhachHang()
        {
            List<KhachHang> khachhang = KhachHangDAO.Instance.GetListKhachHang();
            cbKhachHang.DataSource = khachhang;
            cbKhachHang.DisplayMember = "TenKH";
            cbKhachHang.ValueMember = "Id";
        }
        private List<LoaiKH> loaiKHList = new List<LoaiKH>();
        private void LoadLoaiKHComboBox()
        {
            loaiKHList.Add(new LoaiKH("Vãng Lai", "Vang lai"));
            loaiKHList.Add(new LoaiKH("Cố Định", "Co dinh"));
            foreach (var loaiKH in loaiKHList)
            {
                cbLoaiKH.Items.Add(loaiKH.DisplayName);
            }
            cbLoaiKH.SelectedIndex = 0;
        }
        private string GetLoaiKHSelectedValue()
        {
            string selectedDisplayValue = cbLoaiKH.SelectedItem.ToString();
            LoaiKH selectedLoaiKH = loaiKHList.FirstOrDefault(l => l.DisplayName == selectedDisplayValue);
            return selectedLoaiKH?.Value;
        }
        private void ShowTenHH(ObjectId id)
        {
            List<HH> listHH = HHDAO.Instance.GetItemByMaHH(id);
            cbTenHH.DataSource = listHH;
            cbTenHH.DisplayMember = "TenHH";
            cbTenHH.ValueMember = "Id"; // Use Id as the value member
        }
        private void ShowDonViTinh(ObjectId id) // Sử dụng ObjectId thay vì int maHH
        {
            // Gọi phương thức GetItemByMaHH với ObjectId
            List<HH> listHH = HHDAO.Instance.GetItemByMaHH(id);

            if (listHH != null && listHH.Count > 0)
            {
                // Tạo danh sách đơn vị tính từ kết quả
                List<string> donViTinhList = new List<string>();

                foreach (var item in listHH)
                {
                    if (!string.IsNullOrEmpty(item.DonViTinhNho))
                    {
                        donViTinhList.Add(item.DonViTinhNho);
                    }

                    if (!string.IsNullOrEmpty(item.DonViTinhLon))
                    {
                        donViTinhList.Add(item.DonViTinhLon);
                    }
                }

                // Thiết lập DataSource cho ComboBox
                cbDonViTinh.DataSource = donViTinhList;
            }
            else
            {
                // Nếu không có dữ liệu, đặt DataSource về null
                cbDonViTinh.DataSource = null;
            }
        }
        private void ShowDonGia()
        {
            if (cbTenHH.SelectedValue == null || cbDonViTinh.SelectedItem == null)
            {
                return;
            }
            try
            {
                if (cbTenHH.SelectedValue is ObjectId maHH)
                {
                    string donViTinh = cbDonViTinh.Text;
                    decimal donGia = HHDAO.Instance.GetDonGiaByMaHHAndDVT(maHH, donViTinh);
                    txtDonGia.Text = donGia.ToString("N0"); // Định dạng đơn giá là số nguyên
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Load Bill
        void ShowBill(int masan)
        {
            lsvBill.Items.Clear();
            List<Menu> listBillInfo = MenuDAO.Instance.GetListMenuBySan(masan);
            decimal tongTien = 0;
            foreach (Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenHangHoa.ToString());

                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Unit.ToString());
                lsvItem.SubItems.Add(item.Price.ToString("N0"));
                lsvItem.SubItems.Add(item.TotalPrices.ToString("N0"));
                tongTien += item.TotalPrices;
                lsvBill.Items.Add(lsvItem);
            }
            txtTongTien.Text = tongTien.ToString("N0");
            LoadSanData();
        }
        private void ShowThanhTien()
        {
            int soLuong = (int)nudSoLuong.Value;
            decimal donGia = Convert.ToDecimal(txtDonGia.Text);
            decimal thanhTien = soLuong * donGia;
            txtThanhTien.Text = thanhTien.ToString("N0");
        }
        private void LoadSanData()
        {
            flpSan.Controls.Clear();
            List<San> sanList = SanDAO.Instance.LoadSanList();
            foreach (San san in sanList)
            {
                Button btnSan = new Button() { Width = SanDAO.SanWidth, Height = SanDAO.SanHeight };
                btnSan.Text = san.TenSan + Environment.NewLine + san.Status;
                switch (san.Status)
                {
                    case "Trống":
                        btnSan.BackColor = Color.AliceBlue;
                        break;
                    default:
                        btnSan.BackColor = Color.LightPink;
                        break;
                }
                btnSan.Click += btnSan_Click;
                btnSan.Tag = san;

                flpSan.Controls.Add(btnSan);
            }
        }
        private DateTime RoundToNearestHalfHour(DateTime dt)
        {
            int minutes = dt.Minute;
            if (minutes < 15)
                minutes = 0;
            else if (minutes < 45)
                minutes = 30;
            else
            {
                minutes = 0;
                dt = dt.AddHours(1);
            }
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, minutes, 0);
        }
        private void UpdateDuration()
        {
            TimeSpan duration = dtpGioRa.Value - dtpGioVao.Value;
            DateTime startTime = DateTime.Now; // Hoặc có thể thay bằng thời gian bắt đầu khác
            DateTime resultTime = startTime.AddHours((double)nudSoGioThue.Value).Add(duration);
        }
        private Dictionary<int, decimal> sanPrices = new Dictionary<int, decimal>();
        private void CalculateAndSaveSanPrice(San san)
        {
            string loaiKH = GetLoaiKHSelectedValue();
            TimeSpan gioBatDau = dtpGioVao.Value.TimeOfDay;
            TimeSpan gioKetThuc = dtpGioRa.Value.TimeOfDay;

            decimal giaSan = CalculateTotalPrice(gioBatDau, gioKetThuc, loaiKH);
            san.GiaSan = giaSan;
            sanPrices[san.MaSan] = giaSan;
            txtGiaSan.Text = giaSan.ToString("N0");
        }
        //Mongo chạy thành công
        //Mongo chạy thành công
        //Mongo chạy thành công
        private void LoadTongTien()
        {
            decimal giaSan = Convert.ToDecimal(txtGiaSan.Text);
            decimal tongTien = Convert.ToDecimal(txtTongTien.Text);
            decimal tienCuoi = giaSan + tongTien;
            decimal giamGia = nudGiamGia.Value;
            decimal tienSauGiamGia = tienCuoi - (tienCuoi * (giamGia / 100));
            txtTienCuoi.Text = tienSauGiamGia.ToString("N0");
        }

        private void TinhTienThua()
        {
            decimal KhachDua = Convert.ToDecimal(txtKhachDua.Text);
            decimal TongTien = Convert.ToDecimal(txtTienCuoi.Text);
            decimal TienThua = KhachDua - TongTien;
            if (TienThua < 0)
            {
                TienThua = 0;
            }
            txtTienThua.Text = TienThua.ToString("N0");
        }
        public decimal CalculateTotalPrice(TimeSpan gioBatDau, TimeSpan gioKetThuc, string loaiKH)
        {
            decimal giaGioChoi = 0;
            int frameCount = 0;
            frameCount = PricePerHourDAO.Instance.CheckFrameCount(gioBatDau, gioKetThuc);
            if (frameCount <= 0)
            {
                return 0;
            }
            if (frameCount == 1)
            {
                giaGioChoi = PricePerHourDAO.Instance.GetPriceForTimeSlot(gioBatDau, gioKetThuc, loaiKH);
            }
            else
            {
                giaGioChoi = PricePerHourDAO.Instance.GetPriceBetweenTimeFrames(gioBatDau, gioKetThuc, loaiKH);
            }
            return giaGioChoi;
        }

        private void TinhGioRa()
        {
            DateTime gioVao = dtpGioVao.Value;
            double soGioThue = (double)nudSoGioThue.Value;
            int hours = (int)soGioThue; 
            int minutes = (int)((soGioThue - hours) * 60); 
            TimeSpan thoiGianThue = new TimeSpan(hours, minutes, 0);
            DateTime gioRa = gioVao.Add(thoiGianThue);
            dtpGioRa.Value = gioRa;
        }

        private void TinhSoGioThue()
        {
            DateTime gioVao = dtpGioVao.Value;
            DateTime gioRa = dtpGioRa.Value;

            if (gioRa > gioVao)
            {
                // Tính số giờ thuê chính xác, không làm tròn
                TimeSpan thoiGianThue = gioRa - gioVao;
                double soGioThue = thoiGianThue.TotalHours;
                nudSoGioThue.Value = (decimal)soGioThue;
            }
            else
            {
                MessageBox.Show("Giờ ra phải lớn hơn giờ vào!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        //Load Hang hoa theo loai hang hoa
        //Load Hang hoa theo loai hang hoa
        //Load Hang hoa theo loai hang hoa
        //Load Hang hoa theo loai hang hoa
        //Load Hang hoa theo loai hang hoa



        //Load đơn vị tính lên cb 




        // Show DonGia theo maHH va donViTinh

        //LoadSan

        //Show ThanhTien
        private void PrintBill()
        {
            // Tạo một đối tượng PrintDocument
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            // Đưa thông tin từ ListView vào biến toàn cục hoặc trực tiếp sử dụng trong PrintPage
            printDocument.Print();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Cấu hình font và vị trí để in hóa đơn
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font contentFont = new Font("Arial", 10);
            Brush brush = Brushes.Black;

            // Cấu hình chiều rộng giấy A4
            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;
            float margin = 15;
            float startX = margin;
            float columnWidth = (pageWidth - 2 * margin) / 5;
            int headerHeight = 15;

            // In tiêu đề hóa đơn
            string title = "HÓA ĐƠN BÁN HÀNG";
            float titleWidth = e.Graphics.MeasureString(title, headerFont).Width;
            float titleX = (pageWidth - titleWidth) / 2;
            e.Graphics.DrawString(title, headerFont, brush, titleX, 50);

            // In thông tin cửa hàng
            e.Graphics.DrawString("Badminton", headerFont, brush, titleX, 80);
            e.Graphics.DrawString("HOTLINE: 19008386", contentFont, brush, titleX, 100);
            e.Graphics.DrawString("Địa Chỉ: Tiểu Vương Quốc Bình Chánh, Chợ Bàn Cờ, Toà Thánh Tây Ninh", contentFont, brush, titleX, 120);

            // Thông tin khách hàng
            e.Graphics.DrawString("Khách Hàng:" + cbKhachHang.Text, contentFont, brush, startX, 160);
            e.Graphics.DrawString("Điện Thoại: 0933821631", contentFont, brush, startX, 180);
            e.Graphics.DrawString("Địa Chỉ: Tiểu Vương Quốc Bình Chánh, Chợ Bàn Cờ, Toà Thánh Tây Ninh", contentFont, brush, startX, 200);

            // Khoảng cách bắt đầu hiển thị các cột
            int yPos = 240;

            // Tiêu đề các cột
            e.Graphics.DrawString("STT", headerFont, brush, startX, yPos);
            e.Graphics.DrawString("Sản Phẩm", headerFont, brush, startX + columnWidth, yPos);
            e.Graphics.DrawString("ĐVT", headerFont, brush, startX + 2 * columnWidth, yPos);
            e.Graphics.DrawString("SL", headerFont, brush, startX + 3 * columnWidth, yPos);
            e.Graphics.DrawString("Đơn Giá", headerFont, brush, startX + 4 * columnWidth, yPos);
            e.Graphics.DrawString("Thành Tiền", headerFont, brush, startX + 5 * columnWidth, yPos);

            // Vẽ đường viền cho các cột
            yPos += headerHeight; // Dịch xuống dưới tiêu đề cột
            e.Graphics.DrawLine(Pens.Black, startX, yPos, pageWidth - margin, yPos);

            // In chi tiết hóa đơn từ ListView
            yPos += 20; // Bỏ qua dòng tiêu đề cột
            foreach (ListViewItem item in lsvBill.Items)
            {
                e.Graphics.DrawString(item.Index.ToString(), contentFont, brush, startX, yPos); // STT
                e.Graphics.DrawString(item.Text, contentFont, brush, startX + columnWidth, yPos); // Sản Phẩm
                e.Graphics.DrawString(item.SubItems[1].Text, contentFont, brush, startX + 2 * columnWidth, yPos); // ĐVT
                e.Graphics.DrawString(item.SubItems[2].Text, contentFont, brush, startX + 3 * columnWidth, yPos); // SL
                e.Graphics.DrawString(item.SubItems[3].Text, contentFont, brush, startX + 4 * columnWidth, yPos); // Đơn Giá
                e.Graphics.DrawString(item.SubItems[4].Text, contentFont, brush, startX + 5 * columnWidth, yPos); // Thành Tiền

                // Vẽ đường viền dưới các cột cho từng dòng
                e.Graphics.DrawLine(Pens.Black, startX, yPos + 10, pageWidth - margin, yPos + 10);
                yPos += 20; // Dịch xuống 1 dòng
            }

            // In tổng tiền
            string tongTienLabel = "Tổng tiền: " + txtTongTien.Text;
            float totalWidth = e.Graphics.MeasureString(tongTienLabel, headerFont).Width;
            float totalX = pageWidth - totalWidth - margin;
            e.Graphics.DrawString(tongTienLabel, headerFont, brush, totalX, yPos + 40);

            // Ngày và người viết hóa đơn
            e.Graphics.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy"), contentFont, brush, startX, yPos + 80);
            e.Graphics.DrawString("Người viết hóa đơn: ___________________", contentFont, brush, startX, yPos + 100);

            // Cảm ơn khách hàng
            e.Graphics.DrawString("Cảm ơn quý khách!", contentFont, brush, startX, pageWidth + 150);
        }





        #endregion
        #region events 
        private ObjectId? selectedMaDatSan = null; // Biến lưu mã đặt sân (nếu có)
        private void dtpGioVao_ValueChanged(object sender, EventArgs e)
        {
            // Làm tròn thời gian của dtpTuGio
            dtpGioVao.Value = RoundToNearestHalfHour(dtpGioVao.Value);

            // Kiểm tra nếu dtpDenGio nhỏ hơn dtpTuGio, điều chỉnh lại giá trị của dtpDenGio
            if (dtpGioRa.Value < dtpGioVao.Value)
            {
                dtpGioRa.Value = dtpGioVao.Value; // Đặt lại Đến giờ về Từ giờ nếu nhỏ hơn
            }

            // Cập nhật thời gian chênh lệch
            UpdateDuration();

        }

        private void dtpGioRa_ValueChanged(object sender, EventArgs e)
        {
            // Nếu thời gian Đến giờ nhỏ hơn Từ giờ, thông báo lỗi hoặc tự động chỉnh sửa
            if (dtpGioRa.Value < dtpGioVao.Value)
            {
                dtpGioRa.Value = dtpGioVao.Value;
            }
            else
            {
                // Nếu không có vấn đề gì, làm tròn thời gian và cập nhật thời gian chênh lệch
                dtpGioRa.Value = RoundToNearestHalfHour(dtpGioRa.Value);
                UpdateDuration(); // Cập nhật thời gian chênh lệch
            }
        }

        private void nudSoGioThue_ValueChanged(object sender, EventArgs e)
        {
            TinhGioRa();
        }



        private void btnSan_Click(object sender, EventArgs e)
        {
            San selectedSan = (sender as Button).Tag as San;
            lsvBill.Tag = selectedSan;

            ShowBill(selectedSan.MaSan);
            lbTenSan.Text = selectedSan.TenSan;

            // Hiển thị giá sân từ từ điển nếu đã lưu
            if (sanPrices.ContainsKey(selectedSan.MaSan))
            {
                txtGiaSan.Text = sanPrices[selectedSan.MaSan].ToString("N0");
            }
            else
            {
                txtGiaSan.Text = "0";
            }
        }
        private void btnAddHH_Click(object sender, EventArgs e)
        {
            San san = lsvBill.Tag as San;
            if (san == null)
            {
                MessageBox.Show("Vui lòng chọn sân trước khi thêm hàng hóa.", "Thông báo");
                return;
            }

            // Kiểm tra xem người dùng đã chọn hàng hóa chưa
            if (cbTenHH.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn hàng hóa trước khi thêm.", "Thông báo");
                return;
            }

            // Lấy mã hóa đơn chưa thanh toán (nếu có)
            ObjectId maHD = BillDAO.Instance.GetUnCheckBillIDByMaSan(san.MaSan);
            ObjectId foodID = (cbTenHH.SelectedItem as HH).Id; // Sử dụng _id thay vì MaHH
            int soLuong = (int)nudSoLuong.Value;
            string donViTinh = cbDonViTinh.Text;

            // Chuyển đổi giá trị thành decimal
            decimal giaSan = Convert.ToDecimal(txtGiaSan.Text);
            decimal donGia = Convert.ToDecimal(txtDonGia.Text);

            // Nếu chưa có hóa đơn cho sân, tạo mới
            if (maHD == ObjectId.Empty) // Kiểm tra ObjectId.Empty thay vì -1
            {
                // Tạo hóa đơn mới
                BillDAO.Instance.InsertBill(selectedMaDatSan, san.MaSan, giaSan);

                // Lấy mã hóa đơn vừa tạo
                ObjectId newMaHD = BillDAO.Instance.GetMaxMaHD();

                // Thêm thông tin hóa đơn
                BillInfoDAO.Instance.InsertBillInfo(newMaHD, foodID, soLuong, donGia, donViTinh);
            }
            else
            {
                // Nếu đã có hóa đơn, chỉ thêm thông tin hóa đơn
                BillInfoDAO.Instance.InsertBillInfo(maHD, foodID, soLuong, donGia, donViTinh);
            }

            // Hiển thị hóa đơn và tải lại dữ liệu sân
            ShowBill(san.MaSan);
            LoadSanData();
        }
        //
        private void cbLoaiHH_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                ComboBox cb = sender as ComboBox;
                if (cb == null || cb.SelectedItem == null)
                    return;

                // Lấy mục được chọn từ ComboBox
                LoaiHH selected = cb.SelectedItem as LoaiHH;
                if (selected == null)
                    return;

                // Giả sử MaLoaiHH là int, chuyển đổi sang ObjectId
                ObjectId loaiHH = new ObjectId(selected._Id.ToString());

                // Gọi các phương thức xử lý liên quan
                LoadHangHoaByLoaiHH(loaiHH);
                ShowHangHoa(loaiHH);
            
        }
        private void cbHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            HH selected = cb.SelectedItem as HH;
            ObjectId id = selected.Id; // Replace MaHH with _id
            ShowDonViTinh(id); // Pass ObjectId to ShowDonViTinh
            ShowTenHH(id); // Pass ObjectId to ShowTenHH
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            San san = lsvBill.Tag as San;
            ObjectId maHD = BillDAO.Instance.GetUnCheckBillIDByMaSan(san.MaSan); // Đổi kiểu maHD thành ObjectId

            if (maHD != ObjectId.Empty) // So sánh với ObjectId.Empty thay vì -1
            {
                // Lấy giá sân từ từ điển
                //decimal giaSan = 0;
                //if (sanPrices.ContainsKey(san.MaSan))
                //{
                //    giaSan = sanPrices[san.MaSan];
                //}

                if (MessageBox.Show("Bạn có chắc muốn thanh toán hóa đơn cho " + san.TenSan + " không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    // Truyền giá sân vào thủ tục thanh toán
                    BillDAO.Instance.Checkout(maHD); // Đảm bảo phương thức Checkout nhận ObjectId
                    sanPrices.Remove(san.MaSan);
                    ShowBill(san.MaSan);  // Cập nhật lại hóa đơn sau khi thanh toán
                }
            }
        }

        private void lsvHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectId maHH = ObjectId.Empty; // Thay đổi từ int sang ObjectId
            if (lsvHangHoa.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsvHangHoa.SelectedItems[0];
                maHH = (ObjectId)selectedItem.Tag; // Sử dụng ObjectId thay vì int
                ShowDonViTinh(maHH);
                ShowTenHH(maHH);
            }
            else
                return;
        }
        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            // NHẤN VÀO 1 DÒNG TRONG LISTVIEW
        }
        private void cbTenHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectId maHH = ObjectId.Empty; // Sử dụng ObjectId thay vì int
            ComboBox cb = sender as ComboBox;
            if (cbTenHH.SelectedItem == null)
                return;
            HH selected = cb.SelectedItem as HH;
            maHH = selected.Id; // Dùng ObjectId thay vì MaHH
            ShowDonViTinh(maHH);
        }
        private void cbDonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDonGia();

        }
        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            ShowThanhTien();
        }
        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            ShowThanhTien();
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            ShowThanhTien();
        }

        private void txtGiaSan_TextChanged(object sender, EventArgs e)
        {
            LoadTongTien();
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            LoadTongTien();
        }

        private void txtTienCuoi_TextChanged(object sender, EventArgs e)
        {
            TinhTienThua();
        }

        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            TinhTienThua();
        }

        private void cbLoaiKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TinhTienSan();
        }

        private void btnTinhGiaSan_Click(object sender, EventArgs e)
        {
            San selectedSan = lsvBill.Tag as San;
            if (selectedSan != null)
            {
                CalculateAndSaveSanPrice(selectedSan);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sân trước khi tính giá.", "Thông báo");
            }
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            San san = lsvBill.Tag as San;

            ObjectId maHD = BillDAO.Instance.GetUnCheckBillIDByMaSan(san.MaSan);
            ObjectId foodID = (cbTenHH.SelectedItem as HH).Id;
            int soLuong = (int)nudSoLuong.Value;
            string donViTinh = cbDonViTinh.Text;
            decimal giaSan = Convert.ToDecimal(txtGiaSan.Text);
            decimal donGia = Convert.ToDecimal(txtDonGia.Text);

            if (maHD == ObjectId.Empty)
            {
                // Sử dụng mã đặt sân từ biến toàn cục
                BillDAO.Instance.InsertBill(selectedMaDatSan, san.MaSan, giaSan);
            }
            else
            {
                MessageBox.Show("Sân hiện đang có người, xin vui lòng đổi sân hoặc chờ đợi.");
            }

            ShowBill(san.MaSan);
            LoadSanData();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();  // Đóng form hiện tại
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            // Lấy đối tượng San từ lsvBill.Tag
            San san = lsvBill.Tag as San;

            if (san == null)
            {
                MessageBox.Show("Vui lòng chọn sân trước khi in hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Nếu không có sân được chọn, thoát ra khỏi hàm
            }
            ShowBill(san.MaSan);  // Đảm bảo rằng ShowBill đã được gọi và lsvBill đã có dữ liệu

            // Tiến hành in hóa đơn
            PrintBill();  // Sau khi ShowBill được gọi, thực hiện in hóa đơn
        }
        private void btnKhachMoi_Click(object sender, EventArgs e)
        {
            //AddKhachHang addKhachHang = new AddKhachHang();
            //addKhachHang.Show();
        }
        private void btnChooseLichSan_Click(object sender, EventArgs e)
        {
            DanhSachLichSan chonlichdat = new DanhSachLichSan();

            chonlichdat.OnLichSanSelected += (maDatSan, maSan, maKH, tuGio, denGio, loaiKH, daTra) =>
            {
                // Gán giá trị mã đặt sân vào biến toàn cục
                selectedMaDatSan = maDatSan;

                // Kích hoạt nút sân tương ứng
                foreach (Control control in flpSan.Controls)
                {
                    if (control is Button btnSan && btnSan.Tag is San san && san.Id.ToString() == maSan)
                    {
                        btnSan.PerformClick();
                        break;
                    }
                }

                dtpGioVao.Value = tuGio;
                dtpGioRa.Value = denGio;

                // Lấy thông tin khách hàng
                List<KhachHang> danhSachKhachHang = KhachHangDAO.Instance.GetListKhachHang();
                ObjectId objectIdMaKH = ObjectId.Parse(maKH);
                KhachHang khachHang = danhSachKhachHang.FirstOrDefault(kh => kh.Id == objectIdMaKH);

                if (khachHang == null)
                {
                    MessageBox.Show($"Không tìm thấy khách hàng với ID: {objectIdMaKH}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cbKhachHang.SelectedValue = khachHang.Id;
                }

                LoaiKH selectedLoaiKH = loaiKHList.FirstOrDefault(lkh => lkh.Value == loaiKH);
                if (selectedLoaiKH != null)
                {
                    cbLoaiKH.SelectedItem = selectedLoaiKH.DisplayName;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy loại khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            chonlichdat.ShowDialog();
        }


        #endregion


    }
}




