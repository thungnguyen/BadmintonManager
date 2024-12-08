using BadmintonManager.BLL;
using BadmintonManager.DTO;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class SuaHangHoa : Form
    {
        private HangHoaBLL _hangHoaBLL;
        private LoaiHHBLL _loaiHHBLL;
        private HangHoa _currentProduct; // Sản phẩm hiện tại

        public SuaHangHoa(HangHoa product)
        {
            InitializeComponent();
            _hangHoaBLL = new HangHoaBLL();
            _loaiHHBLL = new LoaiHHBLL();
            _currentProduct = product;
        }

        private void SuaHangHoa_Load(object sender, EventArgs e)
        {
            try
            {
                // Load danh sách loại hàng hóa vào ComboBox
                var categories = _loaiHHBLL.GetAllCategories();
                cmbLoaiHH.DataSource = categories;
                cmbLoaiHH.DisplayMember = "TenLoaiHH";
                cmbLoaiHH.ValueMember = "MaLoaiHH";

                // Hiển thị thông tin sản phẩm hiện tại
                txtTenHH.Text = _currentProduct.TenHH;
                txtMoTa.Text = _currentProduct.MoTa;
                txtdvtinhnho.Text = _currentProduct.DonViTinhNho;
                txtdvtinhlon.Text = _currentProduct.DonViTinhLon;
                txtHeSoQuyDoi.Text = _currentProduct.HeSoQuyDoi.ToString();
                txtGiaNhapLon.Text = _currentProduct.GiaNhapLon.ToString();
                txtGiaNhapNho.Text = _currentProduct.GiaNhapNho.ToString();
                txtGiaBanLon.Text = _currentProduct.GiaBanLon.ToString();
                txtGiaBanNho.Text = _currentProduct.GiaBanNho.ToString();
                txtSoLuongTonLon.Text = _currentProduct.SoLuongTonLon.ToString();
                txtSoLuongTonNho.Text = _currentProduct.SoLuongTonNho.ToString();
                cmbLoaiHH.SelectedValue = _currentProduct.MaLoaiHH;

                // Đặt các trường tồn kho thành chỉ đọc
                txtSoLuongTonLon.ReadOnly = true;
                txtSoLuongTonNho.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool ValidateInputs()
        {
            // Tên hàng hóa không được để trống
            if (string.IsNullOrWhiteSpace(txtTenHH.Text))
            {
                MessageBox.Show("Tên hàng hoá không được để trống!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Loại hàng hóa phải được chọn
            if (cmbLoaiHH.SelectedValue == null)
            {
                MessageBox.Show("Hãy chọn loại hàng hoá!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Hệ số quy đổi phải là số nguyên dương
            if (!int.TryParse(txtHeSoQuyDoi.Text, out int heSoQuyDoi) || heSoQuyDoi <= 0)
            {
                MessageBox.Show("Hệ số quy đổi phải là số nguyên dương!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Đơn vị tính nhỏ chỉ chứa chữ cái
            string donViTinhNho = txtdvtinhnho.Text.Trim();
            string donViTinhLon = txtdvtinhlon.Text.Trim();

            if (string.IsNullOrWhiteSpace(donViTinhNho) ||
                string.IsNullOrWhiteSpace(donViTinhLon))
            {
                MessageBox.Show("Đơn vị tính không được để trống!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(donViTinhNho, @"^[\p{L}\s]+$") ||
            !Regex.IsMatch(donViTinhLon, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Đơn vị tính chỉ được chứa chữ cái!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            try
            {
                // Cập nhật thông tin sản phẩm
                _currentProduct.TenHH = txtTenHH.Text;
                _currentProduct.MoTa = txtMoTa.Text;
                _currentProduct.DonViTinhNho = txtdvtinhnho.Text;
                _currentProduct.DonViTinhLon = txtdvtinhlon.Text;
                _currentProduct.HeSoQuyDoi = int.Parse(txtHeSoQuyDoi.Text);
                _currentProduct.GiaNhapLon = decimal.Parse(txtGiaNhapLon.Text);
                _currentProduct.GiaNhapNho = decimal.Parse(txtGiaNhapNho.Text);
                _currentProduct.GiaBanLon = decimal.Parse(txtGiaBanLon.Text);
                _currentProduct.GiaBanNho = decimal.Parse(txtGiaBanNho.Text);
                _currentProduct.MaLoaiHH = (int)cmbLoaiHH.SelectedValue;

                // Gọi BLL để lưu thay đổi
                _hangHoaBLL.UpdateProduct(_currentProduct);

                MessageBox.Show("Cập nhật sản phẩm thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Huỷ quá trình sửa danh mục sản phẩm", "Huỷ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
