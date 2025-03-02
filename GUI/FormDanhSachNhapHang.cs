using BadmintonManager.DTO;
using QuanLyNhapHang.BLL;
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
    public partial class FormDanhSachNhapHang : Form
    {
        private NhapHangBLL _nhapHangBLL;
        public FormDanhSachNhapHang()
        {
            InitializeComponent();
            _nhapHangBLL = new NhapHangBLL();

        }

        private void FormDanhSachNhapHang_Load(object sender, EventArgs e)
        {
            TaiDanhSachNhapHang();
        }

        private void TaiDanhSachNhapHang()
        {
            try
            {
                List<NhapHang> danhSachNhapHang = _nhapHangBLL.LayDanhSachPhieuNhap();

                // Debug: Kiểm tra danh sách nhập hàng
                foreach (var nhapHang in danhSachNhapHang)
                {
                    Console.WriteLine($"Mã: {nhapHang.MaNhapHang}, Ngày: {nhapHang.NgayNhap}, Tổng: {nhapHang.TongTien}");
                }

                dgvDanhSachNhapHang.DataSource = danhSachNhapHang;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiDanhSachNhapHang();
        }

        private void dgvDanhSachNhapHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSachNhapHang.Columns[e.ColumnIndex].Name == "TongTien" && e.Value != null)
            {
                e.Value = $"{Convert.ToDecimal(e.Value):N0} VND";
                e.FormattingApplied = true;
            }
        }

    }
}
