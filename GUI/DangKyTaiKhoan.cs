using BadmintonManager.BAL;
using BadmintonManager.DTO;
using System;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class DangKyTaiKhoan : Form
    {
        private TaiKhoanBAL taiKhoanBAL;
        // Định nghĩa sự kiện DataUpdated
        public event EventHandler DataUpdated;
        public DangKyTaiKhoan()
        {
            InitializeComponent();
            taiKhoanBAL = new TaiKhoanBAL();
        }

        private void btnTao_Click(object sender, EventArgs e)
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

            bool isAdded = taiKhoanBAL.AddTaiKhoan(taiKhoan);

            if (isAdded)
            {
                MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnDataUpdated(); // Gọi sự kiện DataUpdated để form DanhSachTaiKhoan tự động làm mới
                this.Close(); // Đóng form sau khi thêm thành công
             }
            else
            {
                MessageBox.Show("Đăng ký tài khoản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Phương thức để kích hoạt sự kiện DataUpdated
        protected virtual void OnDataUpdated()
        {
            DataUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
