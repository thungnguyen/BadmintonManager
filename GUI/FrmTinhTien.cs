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
            //LoadHangHoaByLoaiHH();
            //LoadHangHoa();
            //cbLoaiHH.SelectedValueChanged += cbLoaiHH_SelectedValueChanged;
            
            // Đăng ký sự kiện SelectedIndexChanged cho ComboBox cbTenHH
            //cbTenHH.SelectedIndexChanged += cbTenHH_SelectedIndexChanged;

            LoadSanData();
            LoadKhachHang();
            LoadLoaiKH();
            //cbLoaiKH.SelectedIndexChanged += cbLoaiKH_SelectedIndexChanged;
            // Đặt giá trị ban đầu cho txtTienCuoi là 0đ

        }

        #region methods
        private void LoadLoaiKH()
        {
            // Tạo DataTable để chứa các lựa chọn
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("TenLoaiKH", typeof(string)); // Cột để hiển thị
            dataTable.Columns.Add("MaLoaiKH", typeof(string)); // Cột để lưu giá trị tương ứng

            // Thêm các lựa chọn vào DataTable
            dataTable.Rows.Add("Vãng Lai", "Vang lai");
            dataTable.Rows.Add("Cố Định", "Co dinh");

            // Gắn dữ liệu vào ComboBox
            cbLoaiKH.DataSource = dataTable;
            cbLoaiKH.DisplayMember = "TenLoaiKH"; // Hiển thị tên
            cbLoaiKH.ValueMember = "MaLoaiKH"; // Giá trị là mã loại khách hàng (vang lai/co dinh)
            cbLoaiKH.SelectedIndex = 0; // Mặc định chọn Vãng Lai
        }
        // Phương thức để load danh sách khách hàng vào ComboBox
        private void LoadKhachHang()
        {
            try
            {

                // Tạo kết nối tới cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Mở kết nối
                    connection.Open();

                    // Câu lệnh SQL để lấy danh sách khách hàng
                    string query = "SELECT MaKH, TenKH FROM KhachHang";

                    // Tạo SqlDataAdapter để thực thi câu lệnh và lưu kết quả vào DataTable
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dtKhachHang = new DataTable();
                    dataAdapter.Fill(dtKhachHang);

                    // Thêm dòng "Tất cả" vào đầu DataTable
                    DataRow row = dtKhachHang.NewRow();
                    row["MaKH"] = 0;  // Mã khách hàng cho "Tất cả" (có thể là giá trị đặc biệt như 0 hoặc null)
                    row["TenKH"] = "Tất cả";
                    dtKhachHang.Rows.InsertAt(row, 0);

                    // Đặt nguồn dữ liệu cho ComboBox
                    cbKhachHang.DataSource = dtKhachHang;
                    cbKhachHang.DisplayMember = "TenKH"; // Hiển thị tên khách hàng
                    cbKhachHang.ValueMember = "MaKH";   // Giá trị của mỗi mục trong ComboBox là mã khách hàng

                    // Đóng kết nối
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message);
            }
        }






        //Load Loai Hang Hoa



        private void LoadLoaiHH()
        {
            List<LoaiHH> listLoaiHH = LoaiHHDAO.Instance.GetListLoaiHH();
            cbLoaiHH.DataSource = listLoaiHH;
            cbLoaiHH.DisplayMember = "TenLoaiHH";


        }
        //Load Hang hoa theo loai hang hoa
        
        private void LoadHangHoaByLoaiHH(int maLoaiHH)
        {
            List<HH> listHH = HHDAO.Instance.GetListByLoaiHH(maLoaiHH);
            cbHH.DataSource = listHH;
            cbHH.DisplayMember = "TenHH";
            cbHH.ValueMember = "MaHH";
            
        }
        //Get selected hang hoa name from combobox and list view
        private void ShowTenHH(int maHH)
        {
            List<HH> listHH = HHDAO.Instance.GetItemByMaHH(maHH);
            cbTenHH.DataSource = listHH;
            cbTenHH.DisplayMember = "TenHH";
            cbTenHH.ValueMember = "MaHH";
        }
        //Get dongia for selected

        void ShowHangHoa(int maLoaiHH)
        {
            lsvHangHoa.Items.Clear();  // Xóa tất cả các mục hiện tại trong ListView
            List<HH> listHangHoa = HHDAO.Instance.GetListByLoaiHH(maLoaiHH);  // Lấy danh sách hàng hóa theo loại

            foreach (HH item in listHangHoa)
            {
                // Tạo một ListViewItem với tên hàng hóa
                ListViewItem lsvItem = new ListViewItem(item.TenHH.ToString());  // Chỉ thêm tên hàng hóa vào cột đầu tiên

                // Lưu mã hàng hóa vào thuộc tính Tag (giá trị ẩn)
                lsvItem.Tag = item.MaHH;

                // Thêm các thông tin khác nếu cần
                // Ví dụ: lsvItem.SubItems.Add(item.GiaBanLon.ToString()); để thêm giá bán lớn

                // Thêm ListViewItem vào ListView
                lsvHangHoa.Items.Add(lsvItem);
            }
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
                    donViTinhList.Add(item.DonViTinhLon);  // Thêm DonViTinhLon
                    donViTinhList.Add(item.DonViTinhNho);  // Thêm DonViTinhNho
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
        private void ShowDonGia (int maHH, string donvitinh)
        {
            List<HH> listHH = HHDAO.Instance.GetDonGiaByMaHHAnDVT(maHH, donvitinh);
            if (listHH != null && listHH.Count > 0)
            {
                // Tạo danh sách đơn vị tính để thêm vào ComboBox
                List<decimal> donGiaList = new List<decimal>();

                foreach (var item in listHH)
                {
                    donGiaList.Add(item.GiaBanLon);  // Thêm DonViTinhLon
                    donGiaList.Add(item.GiaBanNho);  // Thêm DonViTinhNho
                }

                // Đặt DataSource cho ComboBox
                txtDonGia.tex = donGiaList;
            }
            else
            {
                cbDonGia.DataSource = null; // Xóa dữ liệu nếu không tìm thấy
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
            txtTongTien.Text = tongTien.ToString("C0", new CultureInfo("vi-VN"));
            
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
      
        #endregion
        #region events
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
            int foodID = (cbHH.SelectedItem as HH).MaHH;
            int soLuong = (int)nudSoLuong.Value;
            if (maHD == -1)
            {
                BillDAO.Instance.InsertBill(san.MaSan);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxMaHD(), foodID, soLuong);

            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(maHD, foodID, soLuong);
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
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            San san = lsvBill.Tag as San;
            int maHD = BillDAO.Instance.GetUnCheckBillIDByMaSan(san.MaSan);

            if (maHD != -1)
            {
                if (MessageBox.Show("Bạn có chắc muốn thanh toán hóa đơn cho sân " + san.TenSan + " không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.Checkout(maHD);
                    ShowBill(san.MaSan);

                }
            }
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
        private void lsvHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maHH = 0;
            if (lsvHangHoa.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsvHangHoa.SelectedItems[0];  // Lấy mục được chọn
                maHH = (int)selectedItem.Tag;  // Lấy mã hàng hóa từ thuộc tính Tag
                ShowDonViTinh(maHH);
                ShowTenHH(maHH);// Làm gì đó với mã hàng hóa (maHangHoa)
            }
            else
                return;
        }
        private void cbDonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion


        private void cbLoaiHH_SelectedValueChanged(object sender, EventArgs e)
        {
         

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void cbTenHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        


        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
         
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            
        }
        // phần thêm hàng hóa vào hóa đơn




        //Hàm cập nhật tổng tiền


        private void dgvDanhSachHangHoa_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //TinhTongTien();
        }

        private void dgvDanhSachHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)  // Kiểm tra xem có phải là hàng hợp lệ không
            //{
            //    DataGridViewRow row = dgvDanhSachHangHoa.Rows[e.RowIndex];

            //    // Đặt giá trị của ComboBox để hiển thị tên hàng hóa
            //    cbTenHH.SelectedValue = row.Cells["MaHH"].Value;

            //    // Cập nhật giá trị của NumericUpDown (nudSoLuong) từ cột Số Lượng trong DataGridView
            //    nudSoLuong.Value = Convert.ToDecimal(row.Cells["SoLuong"].Value);
            //}
        }

        private void btnDelHH_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Kiểm tra nếu có dòng nào được chọn trong DataGridView
            //    if (dgvDanhSachHangHoa.SelectedRows.Count > 0)
            //    {
            //        // Lấy chỉ mục của dòng được chọn
            //        int selectedIndex = dgvDanhSachHangHoa.SelectedRows[0].Index;

            //        // Lấy mã HDSP của dòng đã chọn
            //        int maHDSPToDelete = Convert.ToInt32(dgvDanhSachHangHoa.Rows[selectedIndex].Cells["MaHDSP"].Value);

            //        // Tìm đối tượng cần xóa trong danh sách
            //        var itemToRemove = danhSachHangHoaTemp.FirstOrDefault(item => item.MaHDSP == maHDSPToDelete);

            //        if (itemToRemove != null)
            //        {
            //            // Xóa khỏi danh sách
            //            danhSachHangHoaTemp.Remove(itemToRemove);
            //        }

            //        // Cập nhật lại MaHDSP cho các dòng còn lại
            //        for (int i = 0; i < danhSachHangHoaTemp.Count; i++)
            //        {
            //            danhSachHangHoaTemp[i].MaHDSP = i + 1; // Gán lại giá trị MaHDSP (tạo lại thứ tự)
            //        }

            //        // Cập nhật lại DataGridView để phản ánh thay đổi
            //        dgvDanhSachHangHoa.DataSource = null;
            //        dgvDanhSachHangHoa.DataSource = danhSachHangHoaTemp;

            //        // Ẩn các cột không cần thiết
            //        dgvDanhSachHangHoa.Columns["MaHD"].Visible = false;
            //        dgvDanhSachHangHoa.Columns["MaHH"].Visible = false;
            //        dgvDanhSachHangHoa.Columns.Remove("DonViTinh");

            //        // Cập nhật lại các header cột
            //        dgvDanhSachHangHoa.Columns["MaHDSP"].HeaderText = "Mã HDSP";
            //        dgvDanhSachHangHoa.Columns["TenHH"].HeaderText = "Tên HH";
            //        dgvDanhSachHangHoa.Columns["SoLuong"].HeaderText = "Số Lượng";
            //        dgvDanhSachHangHoa.Columns["DonGia"].HeaderText = "Đơn Giá";
            //        dgvDanhSachHangHoa.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            //    }
            //    else
            //    {
            //        MessageBox.Show("Vui lòng chọn hàng hóa cần xóa.");
            //    }

            //    //Tính lại tổng tiền sau khi xóa
            //        TinhTongTien();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi xóa hàng hóa: " + ex.Message);
            //}
        }



        //

        private void dtpGioVao_ValueChanged(object sender, EventArgs e)
        {
            //// Tự động tính toán số giờ thuê khi thay đổi giờ vào
            //TinhSoGioThue();
            //TinhTienSan();
        }

        private void dtpGioRa_ValueChanged(object sender, EventArgs e)
        {
            //// Tự động tính toán số giờ thuê khi thay đổi giờ ra
            //TinhSoGioThue();
            //TinhTienSan();
        }

        private void nudSoGioThue_ValueChanged(object sender, EventArgs e)
        {
            //// Tính toán giờ ra khi thay đổi số giờ thuê
            //TinhGioRa();
            //TinhTienSan();
        }

        // Hàm tính tổng tiền cuối và hiển thị vào txtTienCuoi


        private void txtGiaSan_TextChanged(object sender, EventArgs e)
        {
            //TinhTienCuoi();
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            //TinhTienCuoi();
        }

        private void txtTienCuoi_TextChanged(object sender, EventArgs e)
        {
            //TinhTienThua();
        }

        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            //TinhTienThua();
        }

        private void cbLoaiKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TinhTienSan();
        }

      

       
    }
}




