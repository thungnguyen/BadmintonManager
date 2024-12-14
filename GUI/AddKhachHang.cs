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
    public partial class AddKhachHang : Form
    {
        private KhachHangBAL khachHangBAL;

        public AddKhachHang()
        {
            InitializeComponent();
            khachHangBAL = new KhachHangBAL();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {

        }

        private void btnThemKH_Click_1(object sender, EventArgs e)
        {
            string tenKH = txtTenKH.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHangDTO khachHang = new KhachHangDTO
            {
                TenKH = tenKH,
                SDT = sdt
            };

            bool isAdded = khachHangBAL.AddKhachHang(khachHang);

            if (isAdded)
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi thêm thành công

            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
