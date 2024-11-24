using BadmintonManager.Database;
using BadmintonManager.GUI;
using qlycaulong.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadmintonManager
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text.Trim();

            TaiKhoanNhanVien taiKhoanDB = new TaiKhoanNhanVien();
            TaiKhoanNhanVien taiKhoan = taiKhoanDB.DangNhap(tenDangNhap, matKhau);

            if (taiKhoan != null)
            {
                // Kiểm tra vai trò và mở form tương ứng
                if (taiKhoan.VaiTro == "0") // Quản lý
                {
                    string tenNV = taiKhoanDB.LayTenNV(tenDangNhap, matKhau);
                    MessageBox.Show($"Chào quản lý {tenNV} đã đăng nhập hệ thống!");
                    FormMenu formMenu = new FormMenu();
                    formMenu.Show();
                }
                else if (taiKhoan.VaiTro == "1") // Nhân viên
                {
                    string tenNV = taiKhoanDB.LayTenNV(tenDangNhap, matKhau);
                    MessageBox.Show($"Chào nhân viên {tenNV} đã đăng nhập hệ thống!");
                    FormMenu formMenu = new FormMenu();
                    formMenu.Show();
                }

                this.Hide(); // Ẩn form đăng nhập
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
