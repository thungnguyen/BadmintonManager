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
            this.Load += AddKhachHang_Load; // Đăng ký sự kiện load

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
                LoadKhachHangData(); // Cập nhật DataGridView
                txtTenKH.Clear();    // Xóa dữ liệu cũ trên textbox
                txtSDT.Clear();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            private void LoadKhachHangData()
            {
                try
                {
                    List<KhachHangDTO> danhSachKhachHang = khachHangBAL.GetAllKhachHangs();
                    dgvKhachHang.DataSource = danhSachKhachHang; // Gán dữ liệu vào DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        private void AddKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHangData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddKhachHang_Load_1(object sender, EventArgs e)
        {

        }
    }
}
