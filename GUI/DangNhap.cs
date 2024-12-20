using BadmintonManager.BAL;
using BadmintonManager.DTO;
using BadmintonManager.GUI;
using System;
using System.Windows.Forms;

namespace BadmintonManager
{
    public partial class DangNhap : Form
    {
        private readonly TaiKhoanNhanVienBAL _taiKhoanBAL;

        public DangNhap()
        {
            InitializeComponent();
            _taiKhoanBAL = new TaiKhoanNhanVienBAL();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra thông tin đăng nhập
                TaiKhoanNhanVienDTO taiKhoan = _taiKhoanBAL.DangNhap(tenDangNhap, matKhau);

                if (taiKhoan != null)
                {
                    MessageBox.Show($"Chào {taiKhoan.VaiTro}! MaNV: {taiKhoan.MaNV}", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở form menu phù hợp với vai trò
                    OpenMenuForm(taiKhoan);

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenMenuForm(TaiKhoanNhanVienDTO taiKhoan)
        {
            if (taiKhoan.VaiTro == "Quản lý")
            {
                // Mở form quản lý
                FormMenu formNhanVien = new FormMenu();

                formNhanVien.Show();
            }
            else if (taiKhoan.VaiTro == "Nhân viên")
            {
                // Mở form nhân viên
                FormMenu formNhanVien = new FormMenu();

                formNhanVien.Show();
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho textbox (chỉ sử dụng khi thử nghiệm)
            //txtUsername.Text = "nhanvien";
            //txtPassword.Text = "1";
        }
    }
}