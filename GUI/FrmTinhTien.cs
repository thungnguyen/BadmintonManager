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
            frameCount = PricePerHourDAO.Instance.GetFrameCount(gioBatDau, gioKetThuc);
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
            lsvHangHoa.Items.Clear();
            List<HH> listHangHoa = HHDAO.Instance.GetListByLoaiHH(maLoaiHH); 

            foreach (HH item in listHangHoa)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenHH.ToString());
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
                List<string> donViTinhList = new List<string>();

                foreach (var item in listHH)
                {
                    donViTinhList.Add(item.DonViTinhNho); 
                    donViTinhList.Add(item.DonViTinhLon);  
                }

                cbDonViTinh.DataSource = donViTinhList;
            }
            else
            {
                cbDonViTinh.DataSource = null;
            }
        }
        // Show DonGia theo maHH va donViTinh
        private void ShowDonGia()
        {
            if (cbTenHH.SelectedValue == null || cbDonViTinh.SelectedItem == null)
            {
                return;
            }
            try
            {
                int maHH = 0;
                if (int.TryParse(cbTenHH.SelectedValue.ToString(), out maHH)) 
                {
                    string donViTinh = cbDonViTinh.Text;

                    decimal donGia = HHDAO.Instance.GetDonGiaByMaHHAndDVT(maHH, donViTinh);

                    txtDonGia.Text = donGia.ToString("N0");
                }
            }
            catch (Exception ex)
            {
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
            int soLuong = (int)nudSoLuong.Value;
            decimal donGia = Convert.ToDecimal(txtDonGia.Text);
            decimal thanhTien = soLuong * donGia;
            txtThanhTien.Text = thanhTien.ToString("N0");
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

            DateTime startTime = DateTime.Now;
            DateTime resultTime = startTime.AddHours((double)nudSoGioThue.Value).Add(duration);
        }
        private Dictionary<int, decimal> sanPrices = new Dictionary<int, decimal>();
        private void CalculateAndSaveSanPrice(San san)
        {
            string loaiKH = GetLoaiKHSelectedValue();
            TimeSpan gioBatDau = dtpGioVao.Value.TimeOfDay;
            TimeSpan gioKetThuc = dtpGioRa.Value.TimeOfDay;

            decimal giaSan = CalculateTotalPrice(gioBatDau, gioKetThuc, loaiKH);

            sanPrices[san.MaSan] = giaSan;
            txtGiaSan.Text = giaSan.ToString();
        }
        private int maGiaChon = -1;
        private int soBuoiDaDat;
        private int maDSan;
        #endregion
        #region events 
        private void dtpGioVao_ValueChanged(object sender, EventArgs e)
        {
            dtpGioVao.Value = RoundToNearestHalfHour(dtpGioVao.Value);
            if (dtpGioRa.Value < dtpGioVao.Value)
            {
                dtpGioRa.Value = dtpGioVao.Value;
            }
            UpdateDuration();
        }
        private void dtpGioRa_ValueChanged(object sender, EventArgs e)
        {
            if (dtpGioRa.Value < dtpGioVao.Value)
            {
                dtpGioRa.Value = dtpGioVao.Value;
            }
            else
            {
                dtpGioRa.Value = RoundToNearestHalfHour(dtpGioRa.Value);
                UpdateDuration();
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
                decimal giaSan = 0;
                if (sanPrices.ContainsKey(san.MaSan))
                {
                    giaSan = sanPrices[san.MaSan];
                }

                if (MessageBox.Show("Bạn có chắc muốn thanh toán hóa đơn cho " + san.TenSan + " không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.Checkout(maHD, giaSan);
                    sanPrices.Remove(san.MaSan);
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
            this.Close();
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
            Form1 chonlichdat = new Form1();
            chonlichdat.OnLichSanSelected += (maDatSan, maSan, maKH, maGia, tuGio, denGio, loaiKH, daTra) =>
            {
                maDSan = maDatSan;
                maGiaChon = maGia;
                decimal giaSan = BangGiaSanDAO.Instance.LayGia(maGia);
                if(daTra >= giaSan)
                {
                    int SoBuoi = (int)(daTra / giaSan);
                    soBuoiDaDat = SoBuoi;
                }
                foreach (Control control in flpSan.Controls)
                {
                    if (control is Button btnSan && btnSan.Tag is San san && san.MaSan == maSan)
                    {
                        btnSan.PerformClick();
                        break;
                    }
                }
                dtpGioVao.Value = tuGio;
                dtpGioRa.Value = denGio;
                KhachHang khachHang = KhachHangDAO.Instance.GetListKhachHang()
                    .FirstOrDefault(kh => kh.MaKH == maKH);

                if (khachHang != null)
                {
                    cbKhachHang.SelectedValue = maKH;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Button btnSan = sender as Button;
            if (btnSan != null && btnSan.Tag != null)
            {
                San san = (San)btnSan.Tag;

                int maHD = BillDAO.Instance.GetUnCheckBillIDByMaSan(san.MaSan);

                if (maHD == -1)
                {
                    decimal giaSan = BangGiaSanDAO.Instance.LayGia(maGiaChon);
                    BillDAO.Instance.InsertBill(san.MaSan, giaSan);
                    int soBuoi = soBuoiDaDat;
                    if (soBuoi > 0)
                    {
                        BillDAO.Instance.UpdateSoBuoiDaDat(maDSan, soBuoi);
                    }
                }
                else
                {
                    MessageBox.Show("Sân này đã có người sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion
    }
}




