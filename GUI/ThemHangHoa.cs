using BadmintonManager.BLL;
using BadmintonManager.DTO;
using System;
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
                // Load product categories into ComboBox
                var categories = _loaiHHBLL.GetAllCategories();
                cmbLoaiHH.DataSource = categories;
                cmbLoaiHH.DisplayMember = "TenLoaiHH"; // Column for display
                cmbLoaiHH.ValueMember = "MaLoaiHH";   // Column for value

                // Make SoLuongTonNho readonly
                txtSoLuongTonNho.ReadOnly = true;

                // Attach event handlers for real-time calculation
                txtSoLuongTonLon.TextChanged += (s, ev) => UpdateSoLuongTonNho();
                txtHeSoQuyDoi.TextChanged += (s, ev) => UpdateSoLuongTonNho();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool ValidateInputs()
        {
            // Tên hàng hoá không được để trống
            if (string.IsNullOrWhiteSpace(txtTenHH.Text))
            {
                MessageBox.Show("Tên hàng hoá không được để trống!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Loại hàng hoá phải được chọn
            if (cmbLoaiHH.SelectedValue == null)
            {
                MessageBox.Show("Hãy chọn loại hàng hoá!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra giá trị số (Hệ số quy đổi phải là số nguyên dương)
            if (!int.TryParse(txtHeSoQuyDoi.Text, out int heSoQuyDoi) || heSoQuyDoi <= 0)
            {
                MessageBox.Show("Hệ số quy đổi phải là số nguyên dương!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra giá trị tiền (phải là số dương)
            if (!decimal.TryParse(txtGiaNhapLon.Text, out decimal giaNhapLon) || giaNhapLon <= 0 ||
                !decimal.TryParse(txtGiaNhapNho.Text, out decimal giaNhapNho) || giaNhapNho <= 0 ||
                !decimal.TryParse(txtGiaBanLon.Text, out decimal giaBanLon) || giaBanLon <= 0 ||
                !decimal.TryParse(txtGiaBanNho.Text, out decimal giaBanNho) || giaBanNho <= 0)
            {
                MessageBox.Show("Giá nhập và giá bán phải là số dương!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra số lượng tồn kho (phải là số nguyên không âm)
            if (!int.TryParse(txtSoLuongTonLon.Text, out int soLuongTonLon) || soLuongTonLon < 0 ||
                !int.TryParse(txtSoLuongTonNho.Text, out int soLuongTonNho) || soLuongTonNho < 0)
            {
                MessageBox.Show("Số lượng tồn kho phải là số nguyên không âm!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra giá bán không nhỏ hơn giá nhập
            if (giaBanLon < giaNhapLon || giaBanNho < giaNhapNho)
            {
                MessageBox.Show("Giá bán không được nhỏ hơn giá nhập!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra đơn vị tính nhỏ chỉ chứa chữ
            if (!Regex.IsMatch(txtdvtinhnho.Text, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Đơn vị tính nhỏ chỉ được chứa chữ!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra đơn vị tính lớn chỉ chứa chữ
            if (!Regex.IsMatch(txtdvtinhlon.Text, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Đơn vị tính lớn chỉ được chứa chữ!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return; // Nếu không hợp lệ, dừng tại đây
            }

            try
            {
                // Validate form inputs
                if (string.IsNullOrWhiteSpace(txtTenHH.Text))
                {
                    MessageBox.Show("Tên hàng hoá không được để trống!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbLoaiHH.SelectedValue == null)
                {
                    MessageBox.Show("Hãy chọn loại hàng hoá!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse numeric fields safely using TryParse
                if (!int.TryParse(txtHeSoQuyDoi.Text, out int heSoQuyDoi))
                {
                    MessageBox.Show("Hệ số quy đổi phải là một số hợp lệ!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtGiaNhapLon.Text, out decimal giaNhapLon) ||
                    !decimal.TryParse(txtGiaNhapNho.Text, out decimal giaNhapNho) ||
                    !decimal.TryParse(txtGiaBanLon.Text, out decimal giaBanLon) ||
                    !decimal.TryParse(txtGiaBanNho.Text, out decimal giaBanNho))
                {
                    MessageBox.Show("Giá nhập và giá bán phải là số hợp lệ!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtSoLuongTonLon.Text, out int soLuongTonLon) ||
                    !int.TryParse(txtSoLuongTonNho.Text, out int soLuongTonNho))
                {
                    MessageBox.Show("Số lượng tồn phải là số hợp lệ!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create new HangHoaDTO object
                var newProduct = new HangHoa
                {
                    TenHH = txtTenHH.Text,
                    MaLoaiHH = (int)cmbLoaiHH.SelectedValue,
                    MoTa = txtMoTa.Text,
                    DonViTinhNho = txtdvtinhnho.Text,
                    DonViTinhLon = txtdvtinhlon.Text,
                    HeSoQuyDoi = heSoQuyDoi,
                    GiaNhapLon = giaNhapLon,
                    GiaNhapNho = giaNhapNho,
                    GiaBanLon = giaBanLon,
                    GiaBanNho = giaBanNho,
                    SoLuongTonLon = soLuongTonLon,
                    SoLuongTonNho = soLuongTonNho
                };

                // Save new product using BLL
                _hangHoaBLL.AddProduct(newProduct);

                MessageBox.Show("Thêm hàng hoá thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Close the form after saving
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
