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
        private string connectionString = "Data Source=DESKTOP-CESMAPL\\SQLEXPRESS;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False";
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
        private void ShowDonGia ()
        {
            // Kiểm tra ComboBox mã hàng hóa
            if (cbTenHH.SelectedValue == null || cbDonViTinh.SelectedItem == null)
            {
               
                return;
            }

            // Lấy mã hàng hóa từ cbMaHH
            int maHH = (int)cbTenHH.SelectedValue;

            // Lấy đơn vị tính từ cbDonViTinh
            string donViTinh = cbDonViTinh.Text;

            // Ví dụ: Lấy đơn giá từ DAO dựa trên mã hàng hóa và đơn vị tính
            decimal donGia = HHDAO.Instance.GetDonGiaByMaHHAndDVT(maHH, donViTinh);

            txtDonGia.Text = donGia.ToString("N0");  // Hiển thị đơn giá lên TextBox
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


        #endregion
        #region events
        private void dtpGioVao_ValueChanged(object sender, EventArgs e)
        {
            TinhSoGioThue();

        }

        private void dtpGioRa_ValueChanged(object sender, EventArgs e)
        {
            TinhSoGioThue();
        }

        private void nudSoGioThue_ValueChanged(object sender, EventArgs e)
        {
            TinhGioRa();
        }



        private void btnSan_Click(object sender, EventArgs e)
        {
            int maSan = ((sender as Button).Tag as San).MaSan;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(maSan);
            // Lấy tên sân từ đối tượng San dựa trên MaSan
            string tenSan = ((sender as Button).Tag as San).TenSan;
            lbTenSan.Text = tenSan;
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
                BillDAO.Instance.InsertBill(san.MaSan , giaSan);
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
                if (MessageBox.Show("Bạn có chắc muốn thanh toán hóa đơn cho " + san.TenSan + " không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.Checkout(maHD);
                    ShowBill(san.MaSan);

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
            // Lấy giá trị loại khách hàng từ ComboBox
            string loaiKH = GetLoaiKHSelectedValue();

            // Lấy thời gian từ các DateTimePicker (gioVao và gioRa)
            TimeSpan gioBatDau = dtpGioVao.Value.TimeOfDay;  // Lấy giá trị giờ vào từ dtpGioVao
            TimeSpan gioKetThuc = dtpGioRa.Value.TimeOfDay;  // Lấy giá trị giờ ra từ dtpGioRa

            // Gọi phương thức tính giá sân
            decimal giaTien = CalculateTotalPrice(gioBatDau, gioKetThuc, loaiKH);

            // Hiển thị giá trị vào một label hoặc một nơi hiển thị khác
            txtGiaSan.Text = giaTien.ToString("N0");
        }


        #endregion
    }
}




