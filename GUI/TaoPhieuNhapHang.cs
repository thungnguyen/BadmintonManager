using BadmintonManager.BAL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class TaoPhieuNhapHang : Form
    {
        private HangHoaBLL _hangHoaBLL;
        public TaoPhieuNhapHang()
        {
            InitializeComponent();
            _hangHoaBLL = new HangHoaBLL();
        }

        private void LoadProducts()
        {
            try
            {
                // Lấy danh sách sản phẩm
                List<HangHoa> products = _hangHoaBLL.GetAllProducts();

                // Thêm mục chọn mặc định
                cboSanPham.DisplayMember = "TenHH";
                cboSanPham.ValueMember = "MaHH";

                // Tạo danh sách mới có thêm sản phẩm mặc định
                var productList = new List<HangHoa> { new HangHoa { MaHH = 0, TenHH = "Chọn sản phẩm" } };
                productList.AddRange(products);

                cboSanPham.DataSource = productList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaoPhieuNhapHang_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void numSoLuongNhapLon_ValueChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue is int productId && productId > 0)
            {
                int soLuongNhapLon = (int)numSoLuongNhapLon.Value;

                try
                {
                    // Lấy hệ số quy đổi từ BLL
                    decimal heSoQuyDoi = _hangHoaBLL.GetHeSoQuyDoiForProduct(productId);

                    // Tính toán số lượng nhỏ
                    decimal soLuongTonNho = soLuongNhapLon * heSoQuyDoi;
                    txtSoLuongNhapNho.Text = soLuongTonNho.ToString("N0");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tính toán số lượng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtSoLuongNhapNho.Clear();
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            SavePhieuNhap();
        }

        private void SavePhieuNhap()
        {
            try
            {
                // Kiểm tra sản phẩm đã được chọn
                if (cboSanPham.SelectedValue == null || (int)cboSanPham.SelectedValue <= 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm hợp lệ.");
                    return;
                }

                // Kiểm tra số lượng nhập lớn
                if (numSoLuongNhapLon.Value <= 0)
                {
                    MessageBox.Show("Số lượng nhập lớn phải lớn hơn 0.");
                    return;
                }

                // Lấy thông tin từ form
                int maSanPham = (int)cboSanPham.SelectedValue;
                DateTime ngayNhap = dtpNgayNhap.Value;
                string ghiChu = txtGhiChu.Text;
                int soLuongNhapLon = (int)numSoLuongNhapLon.Value;
                int soLuongNhapNho;
                if (!int.TryParse(txtSoLuongNhapNho.Text, out soLuongNhapNho) || soLuongNhapNho < 0)
                {
                    MessageBox.Show("Số lượng nhập nhỏ không hợp lệ.");
                    return;
                }

                // Tạo đối tượng NhapHangDTO
                NhapHangDTO nhapHang = new NhapHangDTO
                {
                    NgayNhap = ngayNhap,
                    GhiChu = ghiChu,
                    TongSoLuong = soLuongNhapLon  // Tổng số lượng là soLuongNhapLon
                };

                // Lưu phiếu nhập và lấy mã nhập hàng vừa được tạo
                int maNhapHang = _hangHoaBLL.SaveNhapHang(nhapHang);

                // Tạo đối tượng ChiTietNhapHangDTO
                ChiTietNhapHangDTO chiTietNhapHang = new ChiTietNhapHangDTO
                {
                    MaNhapHang = maNhapHang,
                    MaHH = maSanPham,
                    SoLuongNhapLon = soLuongNhapLon,
                    SoLuongNhapNho = soLuongNhapNho
                };

                // Lưu chi tiết phiếu nhập
                _hangHoaBLL.SaveChiTietNhapHang(chiTietNhapHang);

                // Hiển thị thông báo thành công
                MessageBox.Show("Phiếu nhập hàng đã được lưu thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập hàng: " + ex.Message);
            }
        }



        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
