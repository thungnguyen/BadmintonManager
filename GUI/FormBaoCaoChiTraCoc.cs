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
    public partial class FormBaoCaoChiTraCoc : Form
    {
        public FormBaoCaoChiTraCoc()
        {
            InitializeComponent();
        }

        private void FormBaoCaoChiTraCoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLySanDataSet.PhieuChi' table. You can move, or remove it, as needed.
            this.phieuChiTableAdapter.Fill(this.quanLySanDataSet.PhieuChi);

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            foreach (var row in quanLySanDataSet.PhieuChi)
            {
                Console.WriteLine($"NgayLap: {row.NgayLap}");
            }
            
            // Lấy giá trị từ DateTimePicker
            DateTime tuNgay = datePickerFrom.Value.Date;
            DateTime denNgay = datePickerTo.Value.Date;

            // Kiểm tra nếu từ ngày > đến ngày
            if (tuNgay > denNgay)
            {
                MessageBox.Show("Từ ngày không được lớn hơn đến ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị khoảng thời gian lọc (debug)
            MessageBox.Show($"Lọc từ ngày: {tuNgay:dd/MM/yyyy} đến ngày: {denNgay:dd/MM/yyyy}");

            // Lọc dữ liệu dựa vào khoảng thời gian
            var filteredData = quanLySanDataSet.PhieuChi
                .Where(row => row.NgayLap.Date >= tuNgay && row.NgayLap.Date <= denNgay)
                .ToList();

            if (filteredData.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn nào trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Hiển thị dữ liệu lọc vào DataGridView
            dataGridView1.DataSource = filteredData;

            // Tính tổng tiền dựa vào cột DaTra
            decimal tongTien = filteredData.Sum(row => row.DaTra);

            // Hiển thị tổng tiền lên TextBox
            txtTongTien.Text = tongTien.ToString("N0");
        }

    }
}
