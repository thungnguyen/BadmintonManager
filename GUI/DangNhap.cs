using BadmintonManager.BAL;
using BadmintonManager.DTO;
using BadmintonManager.GUI;
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
        private TaiKhoanNhanVienBAL taiKhoanBAL;

        public DangNhap()
        {
            InitializeComponent();
            taiKhoanBAL = new TaiKhoanNhanVienBAL();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text.Trim();

            TaiKhoanNhanVienDTO taiKhoan = taiKhoanBAL.DangNhap(tenDangNhap, matKhau);

            if (taiKhoan != null)
            {
                int maNV = taiKhoanBAL.LayMaNV(tenDangNhap, matKhau);

                if (taiKhoan.VaiTro == "0") // Quản lý
                {
                    MessageBox.Show($"Chào quản lý! MaNV: {maNV}");
                    GDQuanLy formQuanLy = new GDQuanLy();
                    formQuanLy.Show();
                }
                else if (taiKhoan.VaiTro == "1") // Nhân viên
                {
                    MessageBox.Show($"Chào nhân viên! MaNV: {maNV}");
                    FormMenu formNhanVien = new FormMenu();
                    formNhanVien.Show();
                }

                this.Hide(); // Ẩn form đăng nhập
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
            }
        }
    }
}
