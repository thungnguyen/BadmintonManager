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
    public partial class LichSuNhapHang : Form
    {
        private NhapHangBLL _nhapHangBLL;
        public LichSuNhapHang()
        {
            InitializeComponent();
            _nhapHangBLL = new NhapHangBLL();
        }

        private void LichSuNhapHang_Load(object sender, EventArgs e)
        {
            LoadNhapHangData();
        }

        private void LoadNhapHangData()
        {
            try
            {
                // Lấy dữ liệu từ BLL
                List<NhapHangDTO> nhapHangs = _nhapHangBLL.GetNhapHang();

                // Gán dữ liệu vào DataGridView
                dgvNhapHang.DataSource = nhapHangs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NhapHangbtn_Click(object sender, EventArgs e)
        {
            using (var addForm = new TaoPhieuNhapHang())
            {
                var result = addForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadNhapHangData();
                }
            }
        }

        private void detailNhapHangbtn_Click(object sender, EventArgs e)
        {
            LoadNhapHangData();
        }
    }
}
