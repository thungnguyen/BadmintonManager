using BadmintonManager.BAL;
using System;
using System.Windows.Forms;
using BadmintonManager.DTO;

namespace BadmintonManager.GUI
{
    public partial class DangKyTaiKhoan : Form
    {
                private readonly TaiKhoanNhanVienBAL _bal = new TaiKhoanNhanVienBAL();


        // Tạo sự kiện DataUpdated
        public event EventHandler DataUpdated;

        public DangKyTaiKhoan()
        {
            InitializeComponent();
        }


        private void btnTao_Click_1(object sender, EventArgs e)
        {
            {
                try
                {
                    string tenNV = txtTenNV.Text.Trim();
                    string sdt = txtSDT.Text.Trim();
                    string tenDangNhap = txtTenDangNhap.Text.Trim();
                    string matKhau = txtMatKhau.Text.Trim();

                    if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    TaiKhoanNhanVienDTO taiKhoan = new TaiKhoanNhanVienDTO
                    {
                        TenNV = tenNV,
                        SDT = sdt,
                        TenDangNhap = tenDangNhap,
                        MatKhau = matKhau,
                        VaiTro = "Nhân viên"
                    };

                    if (_bal.ThemTaiKhoan(taiKhoan))
                    {
                        MessageBox.Show("Đăng ký tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Gọi sự kiện DataUpdated
                        DataUpdated?.Invoke(this, EventArgs.Empty);
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
