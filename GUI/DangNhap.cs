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
                    int maNV = taiKhoanDB.LayMaNV(tenDangNhap, matKhau);
                    MessageBox.Show($"Chào quản lý! MaNV: {maNV}");
                    GDQuanLy formQuanLy = new GDQuanLy();
                    formQuanLy.Show();
                }
                else if (taiKhoan.VaiTro == "1") // Nhân viên
                {
                    int maNV = taiKhoanDB.LayMaNV(tenDangNhap, matKhau);
                    MessageBox.Show($"Chào nhân viên! MaNV: {maNV}");
                    GDNhanVien formNhanVien = new GDNhanVien();
                    formNhanVien.Show();
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
    }
}
