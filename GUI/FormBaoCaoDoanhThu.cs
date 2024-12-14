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
    public partial class FormBaoCaoDoanhThu : Form
    {
        public FormBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void FormBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            // Nạp dữ liệu từ bảng HoaDon vào dataset khi form được tải
            this.hoaDonTableAdapter.Fill(this.quanLySanDataSet1.HoaDon);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các DateTimePicker
            DateTime tuNgay = datePickerFrom.Value.Date;
            DateTime denNgay = datePickerTo.Value.Date;

            // Kiểm tra tính hợp lệ của khoảng thời gian
            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lọc dữ liệu trong khoảng thời gian
            var filteredData = quanLySanDataSet1.HoaDon
                .Where(row => row.NgayLap.Date >= tuNgay && row.NgayLap.Date <= denNgay)
                .ToList();

            // Kiểm tra nếu không có hóa đơn nào thỏa mãn
            if (filteredData.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn nào trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Hiển thị dữ liệu lọc lên DataGridView
            dataGridView1.DataSource = filteredData;

            // Tính tổng tiền
            decimal tongTien = filteredData.Sum(row => row.TongTien);

            // Hiển thị tổng tiền lên TextBox
            txtTongTien.Text = tongTien.ToString("N0");
        }
    }
}
