using BadmintonManager.BAL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BadmintonManager
{
    public partial class FormPhieuNhapHang : Form
    {
        private PhieuNhapHangBLL _phieuNhapHangBLL;

        public FormPhieuNhapHang()
        {
            InitializeComponent();
            _phieuNhapHangBLL = new PhieuNhapHangBLL();
        }

        // Load data when the form loads
        private void FormPhieuNhapHang_Load(object sender, EventArgs e)
        {
            LoadPhieuNhapHangData();
        }

        // Method to load PhieuNhapHang data into the DataGridView
        private void LoadPhieuNhapHangData()
        {
            List<PhieuNhapHangDTO> phieuNhapHangList = _phieuNhapHangBLL.GetAllPhieuNhapHangs();
            dataGridViewPhieuNhapHang.DataSource = phieuNhapHangList;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
