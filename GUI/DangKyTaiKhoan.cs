using BadmintonManager.Database;
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
    public partial class DangKyTaiKhoan : Form
    {
        public DangKyTaiKhoan()
        {
            InitializeComponent();
        }


        private void btnTao_Click_1(object sender, EventArgs e)
        {
            {
                try
                {
                    // Lấy dữ liệu từ các TextBox
                    string tenNV = txtTenNV.Text.Trim();
                    string sdt = txtSDT.Text.Trim();
                    string tenDangNhap = txtTenDangNhap.Text.Trim();
                    string matKhau = txtMatKhau.Text.Trim();

                    if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tạo đối tượng tài khoản mới
                    TaiKhoanNhanVien taiKhoan = new TaiKhoanNhanVien
                    {
                        TenNV = tenNV,
                        SDT = sdt,
                        TenDangNhap = tenDangNhap,
                        MatKhau = matKhau,
                        VaiTro = "Nhân viên"
                    };

                    // Thêm vào database
                    TaiKhoanNhanVien db = new TaiKhoanNhanVien();
                    if (db.ThemTaiKhoan(taiKhoan))
                    {
                        MessageBox.Show("Đăng ký tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

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
