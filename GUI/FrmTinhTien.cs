using BadmintonManager.DAO;
using BadmintonManager.DTO;
using MongoDB.Bson;
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
            cbKhachHang.ValueMember = "MaKH";
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
            ObjectId maHD = BillDAO.Instance.GetUnCheckBillIDByMaSan(san.MaSan);
            ObjectId foodID = (cbTenHH.SelectedItem as HH).Id; // Sử dụng _id thay vì MaHH
            int soLuong = (int)nudSoLuong.Value;
            string donViTinh = cbDonViTinh.Text;
            // Chuyển đổi giá trị thành decimal
            decimal giaSan = Convert.ToDecimal(txtGiaSan.Text);
            decimal donGia = Convert.ToDecimal(txtDonGia.Text);

            if (maHD == ObjectId.Empty) // Kiểm tra ObjectId.Empty thay vì -1
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


        //
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
                decimal giaSan = 0;
                if (sanPrices.ContainsKey(san.MaSan))
                {
                    giaSan = sanPrices[san.MaSan];
                }

                if (MessageBox.Show("Bạn có chắc muốn thanh toán hóa đơn cho " + san.TenSan + " không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    // Truyền giá sân vào thủ tục thanh toán
                    BillDAO.Instance.Checkout(maHD, giaSan); // Đảm bảo phương thức Checkout nhận ObjectId
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

            ObjectId maHD = BillDAO.Instance.GetUnCheckBillIDByMaSan(san.MaSan); // Đổi kiểu maHD thành ObjectId
            ObjectId foodID = (cbTenHH.SelectedItem as HH).Id; // Sử dụng _id thay vì MaHH
            int soLuong = (int)nudSoLuong.Value;
            string donViTinh = cbDonViTinh.Text;
            // Chuyển đổi giá trị thành decimal
            decimal giaSan = Convert.ToDecimal(txtGiaSan.Text);
            decimal donGia = Convert.ToDecimal(txtDonGia.Text);

            if (maHD == ObjectId.Empty) // Kiểm tra ObjectId.Empty thay vì -1
            {
                BillDAO.Instance.InsertBill(san.MaSan, giaSan);
            }
            else
                MessageBox.Show("Sân hiện đang có người xin vui lòng đổi sân hoặc chờ đợi");
            ShowBill(san.MaSan);
            LoadSanData();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();  // Đóng form hiện tại
        }


        #endregion

    }
}




