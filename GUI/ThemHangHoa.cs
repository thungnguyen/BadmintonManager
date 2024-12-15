using BadmintonManager.BLL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class ThemHangHoa : Form
    {
        private HangHoaBLL _hangHoaBLL;
        private LoaiHHBLL _loaiHHBLL;

        public ThemHangHoa()
        {
            InitializeComponent();
            _hangHoaBLL = new HangHoaBLL();
            _loaiHHBLL = new LoaiHHBLL();
        }

        private void ThemHangHoa_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo BLL
                LoaiHHBLL loaiHHBLL = new LoaiHHBLL();

                // Lấy danh sách LoaiHH
                List<LoaiHH> danhSachLoaiHH = loaiHHBLL.GetLoaiHHList();

                // Gắn dữ liệu vào ComboBox
                cmbLoaiHH.DataSource = danhSachLoaiHH;
                cmbLoaiHH.DisplayMember = "TenLoaiHH"; 
                cmbLoaiHH.ValueMember = "MaLoaiHH";

                // Make SoLuongTonNho readonly
                txtSoLuongTonNho.ReadOnly = true;

                // Attach event handlers for real-time calculation
                txtSoLuongTonLon.TextChanged += (s, ev) => UpdateSoLuongTonNho();
                txtHeSoQuyDoi.TextChanged += (s, ev) => UpdateSoLuongTonNho();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu loại hàng hóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSoLuongTonNho()
        {
            if (int.TryParse(txtSoLuongTonLon.Text, out int soLuongTonLon) &&
                int.TryParse(txtHeSoQuyDoi.Text, out int heSoQuyDoi) &&
                heSoQuyDoi > 0) // Ensure HeSoQuyDoi is valid
            {
                // Calculate SoLuongTonNho
                int soLuongTonNho = soLuongTonLon * heSoQuyDoi;

                // Update the readonly textbox
                txtSoLuongTonNho.Text = soLuongTonNho.ToString();
            }
            else
            {
                // Clear the SoLuongTonNho textbox if inputs are invalid
                txtSoLuongTonNho.Text = string.Empty;
            }
        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các điều khiển trên form
                string tenHangHoa = txtTenHH.Text;
                string moTa = txtMoTa.Text;
                string maLoaiHH = cmbLoaiHH.SelectedValue.ToString();  // Lấy mã loại hàng hóa từ ComboBox
                string dvtNho = txtdvtinhnho.Text;
                string dvtLon = txtdvtinhlon.Text;
                int heSoQuyDoi = Int32.Parse(txtHeSoQuyDoi.Text);  // Chuyển đổi từ TextBox
                decimal giaNhapNho = decimal.Parse(txtGiaNhapNho.Text);
                decimal giaNhapLon = decimal.Parse(txtGiaNhapLon.Text);
                decimal giaBanNho = decimal.Parse(txtGiaBanNho.Text);
                decimal giaBanLon = decimal.Parse(txtGiaBanLon.Text);
                int soLuongTonNho = int.Parse(txtSoLuongTonNho.Text);
                int soLuongTonLon = int.Parse(txtSoLuongTonLon.Text);

                // Tạo đối tượng HangHoa từ dữ liệu đã nhập
                HangHoa newHangHoa = new HangHoa
                {
                    TenHH = tenHangHoa,
                    MoTa = moTa,
                    MaLoaiHH = maLoaiHH,
                    DonViTinhLon = dvtNho,
                    DonViTinhNho = dvtLon,
                    HeSoQuyDoi = heSoQuyDoi,
                    GiaNhapNho = giaNhapNho,
                    GiaNhapLon = giaNhapLon,
                    GiaBanNho = giaBanNho,
                    GiaBanLon = giaBanLon,
                    SoLuongTonNho = soLuongTonNho,
                    SoLuongTonLon = soLuongTonLon
                };

                // Gọi phương thức thêm hàng hóa từ BLL
                _hangHoaBLL.ThemHH(newHangHoa);

                MessageBox.Show("Thêm hàng hóa thành công."); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hàng hóa: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Huỷ quá trình thêm danh mục mới", "Huỷ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
