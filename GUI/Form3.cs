using BadmintonManager.BAL;
using System;
using System.Windows.Forms;
using BadmintonManager.DTO;

namespace BadmintonManager.GUI
{
    public partial class Form3 : Form
    {
        private PhieuChiDTO phieuChiDTO;
        private DanhSachLichSanBAL lichSanBAL;

        public Form3(PhieuChiDTO phieuChiDTO)
        {
            InitializeComponent();
            this.phieuChiDTO = phieuChiDTO;
            lichSanBAL = new DanhSachLichSanBAL();

            // Hiển thị thông tin lịch sân vào các textbox
            txtMaDatSan.Text = phieuChiDTO.MaDatSan.ToString();
            txtMaSan.Text = phieuChiDTO.MaSan.ToString();
            txtMaKH.Text = phieuChiDTO.MaKH.ToString();
            txtTuNgay.Text = phieuChiDTO.TuNgay.ToString("yyyy-MM-dd");
            txtDaTra.Text = phieuChiDTO.DaTra.ToString();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Gọi phương thức hủy lịch từ BAL và truyền mã đặt sân
            bool success = lichSanBAL.HuyLichSan(phieuChiDTO.MaDatSan);
            if (success)
            {
                MessageBox.Show("Đã hủy lịch thành công!");
                this.Close(); // Đóng form sau khi hủy lịch thành công
            }
            else
            {
                MessageBox.Show("Lỗi khi hủy lịch!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form mà không thực hiện hành động gì
        }
    }
}
