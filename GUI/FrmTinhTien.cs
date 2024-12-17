using BadmintonManager.DAO;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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


        private void LoadKhachHang()
        {
            List<KhachHang> khachhang = KhachHangDAO.Instance.GetListKhachHang();
            cbKhachHang.DataSource = khachhang;
            cbKhachHang.DisplayMember = "TenKH";
            cbKhachHang.ValueMember = "MaKH";
        }
        private List<LoaiKH> loaiKHList = new List<LoaiKH>();
        private void LoadLoaiKHComboBox()
        {
            loaiKHList.Add(new LoaiKH("Vãng Lai", "Vang lai"));
            loaiKHList.Add(new LoaiKH("Cố Định", "Co dinh"));

            // Thêm giá trị hiển thị vào ComboBox
            foreach (var loaiKH in loaiKHList)
            {
                cbLoaiKH.Items.Add(loaiKH.DisplayName);
            }

            // Chọn giá trị mặc định (ví dụ chọn "Vãng Lại" mặc định)
            cbLoaiKH.SelectedIndex = 0;
        }
        private string GetLoaiKHSelectedValue()
        {
            // Lấy giá trị hiển thị từ ComboBox
            string selectedDisplayValue = cbLoaiKH.SelectedItem.ToString();

            // Tìm LoaiKH có DisplayName khớp và trả về giá trị thực (Value)
            LoaiKH selectedLoaiKH = loaiKHList.FirstOrDefault(l => l.DisplayName == selectedDisplayValue);

            return selectedLoaiKH?.Value;  // Trả về giá trị thực (Value), nếu không tìm thấy thì null
        }
        //Load Loai Hang Hoa
        private void LoadLoaiHH()
        {
            List<LoaiHH> listLoaiHH = LoaiHHDAO.Instance.GetListLoaiHH();
            cbLoaiHH.DataSource = listLoaiHH;
            cbLoaiHH.DisplayMember = "TenLoaiHH";


        }

        public decimal CalculateTotalPrice(TimeSpan gioBatDau, TimeSpan gioKetThuc, string loaiKH)
        {
            decimal giaGioChoi = 0;
            int frameCount = 0;

            // Bước 1: Kiểm tra số lượng khung giờ không trùng lặp
            frameCount = PricePerHourDAO.Instance.GetFrameCount(gioBatDau, gioKetThuc);

            if (frameCount <= 0)
            {
                // Nếu không có khung giờ hợp lệ, trả về 0
                return 0;
            }

            // Bước 2: Nếu chỉ có một khung giờ, gọi thủ tục tính giá cho một khung giờ
            if (frameCount == 1)
            {
                giaGioChoi = PricePerHourDAO.Instance.GetPriceForTimeSlot(gioBatDau, gioKetThuc, loaiKH);
            }
            else
            {
                // Bước 3: Nếu có nhiều khung giờ, gọi thủ tục tính giá cho các khung giờ giữa 2 thời điểm
                giaGioChoi = PricePerHourDAO.Instance.GetPriceBetweenTimeFrames(gioBatDau, gioKetThuc, loaiKH);
            }

            return giaGioChoi;


        }
        private void TinhGioRa()
        {
            DateTime gioVao = dtpGioVao.Value;
            double soGioThue = (double)nudSoGioThue.Value;

            // Chuyển đổi số giờ thuê thành TimeSpan
            int hours = (int)soGioThue; // Lấy phần nguyên của giờ
            int minutes = (int)((soGioThue - hours) * 60); // Lấy phần lẻ và chuyển thành phút
            TimeSpan thoiGianThue = new TimeSpan(hours, minutes, 0);

            // Tính giờ ra
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

        private void LoadHangHoaByLoaiHH(int maLoaiHH)
        {
            List<HH> listHH = HHDAO.Instance.GetListByLoaiHH(maLoaiHH);
            cbHH.DataSource = listHH;
            cbHH.DisplayMember = "TenHH";
            cbHH.ValueMember = "MaHH";

        }
        void ShowHangHoa(int maLoaiHH)
        {
            lsvHangHoa.Items.Clear();  // Xóa tất cả các mục hiện tại trong ListView
            List<HH> listHangHoa = HHDAO.Instance.GetListByLoaiHH(maLoaiHH);  // Lấy danh sách hàng hóa theo loại

            foreach (HH item in listHangHoa)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenHH.ToString());  // Chỉ thêm tên hàng hóa vào cột đầu tiên
                lsvItem.Tag = item.MaHH;
                lsvHangHoa.Items.Add(lsvItem);
            }
        }


        //Get selected hang hoa name from combobox and list view
        private void ShowTenHH(int maHH)
        {
            List<HH> listHH = HHDAO.Instance.GetItemByMaHH(maHH);
            cbTenHH.DataSource = listHH;
            cbTenHH.DisplayMember = "TenHH";
            cbTenHH.ValueMember = "MaHH";
        }


        //Load đơn vị tính lên cb 
        private void ShowDonViTinh(int maHH)
        {
            List<HH> listHH = HHDAO.Instance.GetItemByMaHH(maHH);
            if (listHH != null && listHH.Count > 0)
            {
                // Tạo danh sách đơn vị tính để thêm vào ComboBox
                List<string> donViTinhList = new List<string>();

                foreach (var item in listHH)
                {
                    donViTinhList.Add(item.DonViTinhNho);  // Thêm DonViTinhNho
                    donViTinhList.Add(item.DonViTinhLon);  // Thêm DonViTinhLon
                }

                // Đặt DataSource cho ComboBox
                cbDonViTinh.DataSource = donViTinhList;
            }
            else
            {
                cbDonViTinh.DataSource = null; // Xóa dữ liệu nếu không tìm thấy
            }
        }
        // Show DonGia theo maHH va donViTinh
        private void ShowDonGia()
        {
            // Kiểm tra ComboBox mã hàng hóa và đơn vị tính
            if (cbTenHH.SelectedValue == null || cbDonViTinh.SelectedItem == null)
            {
                // Nếu chưa có lựa chọn trong ComboBox, không làm gì và thoát
                return;
            }

            try
            {
                // Lấy mã hàng hóa từ cbTenHH, chỉ thực hiện nếu có giá trị hợp lệ
                int maHH = 0;
                if (int.TryParse(cbTenHH.SelectedValue.ToString(), out maHH))  // Kiểm tra và ép kiểu an toàn
                {
                    // Lấy đơn vị tính từ cbDonViTinh
                    string donViTinh = cbDonViTinh.Text;

                    // Lấy đơn giá từ DAO dựa trên mã hàng hóa và đơn vị tính
                    decimal donGia = HHDAO.Instance.GetDonGiaByMaHHAndDVT(maHH, donViTinh);

                    // Hiển thị đơn giá lên TextBox
                    txtDonGia.Text = donGia.ToString("N0");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có vấn đề xảy ra
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiển thị thành tiền theo đơn giá và số lượng

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
        //LoadSan
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
        //Show ThanhTien
        private void ShowThanhTien()
        {
            // Lấy số lượng từ NumericUpDown
            int soLuong = (int)nudSoLuong.Value;

            // Lấy đơn giá từ TextBox
            decimal donGia = Convert.ToDecimal(txtDonGia.Text);

            decimal thanhTien = soLuong * donGia;

            // Hiển thị thành tiền vào TextBox, với định dạng tiền tệ
            txtThanhTien.Text = thanhTien.ToString("N0");
        }
        // Hàm làm tròn thời gian về giờ tròn hoặc 30 phút
        private DateTime RoundToNearestHalfHour(DateTime dt)
        {
            int minutes = dt.Minute;

            // Nếu phút nhỏ hơn 15, làm tròn xuống 00 phút
            if (minutes < 15)
                minutes = 0;
            // Nếu phút từ 15 đến 45, làm tròn xuống 30 phút
            else if (minutes < 45)
                minutes = 30;
            // Nếu phút lớn hơn hoặc bằng 45, làm tròn lên 00 phút và tăng giờ
            else
            {
                minutes = 0;
                dt = dt.AddHours(1);
            }

            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, minutes, 0);
        }
        private void UpdateDuration()
        {
            // Tính sự chênh lệch giữa 2 thời gian
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

            // Lưu giá sân vào từ điển
            sanPrices[san.MaSan] = giaSan;

            // Hiển thị giá sân
            txtGiaSan.Text = giaSan.ToString();
        }

        #endregion
        #region events 
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
                txtGiaSan.Text = sanPrices[selectedSan.MaSan].ToString();
            }
            else
            {
                txtGiaSan.Text = "0";
            }
        }
        private void btnAddHH_Click(object sender, EventArgs e)
        {
            San san = lsvBill.Tag as San;

            int maHD = BillDAO.Instance.GetUnCheckBillIDByMaSan(san.MaSan);
            int foodID = (cbTenHH.SelectedItem as HH).MaHH;
            int soLuong = (int)nudSoLuong.Value;
            string donViTinh = cbDonViTinh.Text;
            // Chuyển đổi giá trị thành decimal
            decimal giaSan = Convert.ToDecimal(txtGiaSan.Text);
            decimal donGia = Convert.ToDecimal(txtDonGia.Text);

            if (maHD == -1)
            {
                BillDAO.Instance.InsertBill(san.MaSan, giaSan);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxMaHD(), foodID, soLuong, donGia, donViTinh);

            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(maHD, foodID, soLuong, donGia, donViTinh);
            }
            ShowBill(san.MaSan);

            LoadSanData();
        }
        //
        private void cbLoaiHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            int loaiHH = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            LoaiHH selected = cb.SelectedItem as LoaiHH;
            loaiHH = selected.MaLoaiHH;
            LoadHangHoaByLoaiHH(loaiHH);
            ShowHangHoa(loaiHH);
        }

        //
        private void cbHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maHH = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            HH selected = cb.SelectedItem as HH;
            maHH = selected.MaHH;
            ShowDonViTinh(maHH);
            ShowTenHH(maHH);
        }
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            San san = lsvBill.Tag as San;
            int maHD = BillDAO.Instance.GetUnCheckBillIDByMaSan(san.MaSan);

            if (maHD != -1)
            {
                // Lấy giá sân từ từ điển
                decimal giaSan = 0;
                if (sanPrices.ContainsKey(san.MaSan))
                {
                    giaSan = sanPrices[san.MaSan];
                }

                if (MessageBox.Show("Bạn có chắc muốn thanh toán hóa đơn cho " + san.TenSan + " không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    // Truyền giá sân vào thủ tục thanh toán
                    BillDAO.Instance.Checkout(maHD, giaSan);
                    sanPrices.Remove(san.MaSan);
                    ShowBill(san.MaSan);  // Cập nhật lại hóa đơn sau khi thanh toán
                }
            }
        }

        private void lsvHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maHH = 0;
            if (lsvHangHoa.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsvHangHoa.SelectedItems[0];
                maHH = (int)selectedItem.Tag;
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
            int maHH = 0;
            ComboBox cb = sender as ComboBox;
            if (cbTenHH.SelectedItem == null)
                return;
            HH selected = cb.SelectedItem as HH;
            maHH = selected.MaHH;
            ShowDonViTinh(maHH);
        }

        private void cbDonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Gọi ShowDonGia khi thay đổi đơn vị tính
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
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();  // Đóng form hiện tại
        }

        private void btnKhachMoi_Click(object sender, EventArgs e)
        {
            AddKhachHang addKhachHang = new AddKhachHang();
            addKhachHang.ShowDialog();
            LoadKhachHang();
        }
        private void cbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void btnChooseLichSan_Click(object sender, EventArgs e)
        {
            // Mở Form1 (Lịch đặt sân)
            Form1 chonlichdat = new Form1();

            // Đăng ký sự kiện OnLichSanSelected
            chonlichdat.OnLichSanSelected += (maSan, maKH, maGia, tuGio, denGio, loaiKH, datRa) =>
            {
                //// Gán các giá trị vào giao diện hoặc xử lý dữ liệu
                //lblMaSan.Text = $"Mã Sân: {maSan}";
                //lblMaKH.Text = $"Mã Khách Hàng: {maKH}";
                //lblMaGia.Text = $"Mã Giá: {maGia}";
                //lblThoiGian.Text = $"Thời gian: {tuGio:HH:mm} - {denGio:HH:mm}";
                //lblLoaiKH.Text = $"Loại KH: {loaiKH}";
                //lblDaTra.Text = $"Đã trả: {(datRa ? "Có" : "Không")}";

                // Tự động chọn nút sân có mã sân trùng khớp
                foreach (Control control in flpSan.Controls)
                {
                    if (control is Button btnSan && btnSan.Tag is San san && san.MaSan == maSan)
                    {
                        btnSan.PerformClick(); // Kích hoạt sự kiện click của nút sân
                        break;
                    }
                }

                // Tìm kiếm tên khách hàng tương ứng với maKH và gán vào ComboBox
                KhachHang khachHang = KhachHangDAO.Instance.GetListKhachHang()
                    .FirstOrDefault(kh => kh.MaKH == maKH);

                if (khachHang != null)
                {
                    cbKhachHang.SelectedValue = maKH;
                }
                else
                {
                    // Nếu không tìm thấy khách hàng, có thể thông báo hoặc bỏ qua
                    MessageBox.Show("Không tìm thấy khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            // Hiển thị Form1
            chonlichdat.ShowDialog();
        }

        #endregion

      
    }
}




