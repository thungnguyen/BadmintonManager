using BadmintonManager.BAL;
using BadmintonManager.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class Form1 : Form
    {
        private DanhSachLichSanBAL lichSanBAL;

        public Form1()
        {
            InitializeComponent();
            lichSanBAL = new DanhSachLichSanBAL();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load toàn bộ dữ liệu khi form mở lên
            LoadData();
        }

        // Phương thức để tải toàn bộ dữ liệu
        private void LoadData()
        {
            // Gọi phương thức lấy tất cả dữ liệu lịch sân
            DataTable dataTable = lichSanBAL.LayTatCaLichSan();

            // Gán dữ liệu vào DataGridView
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.");
            }
        }

        // Sự kiện khi nhấn nút Hủy lịch
        private void btnHuyLich_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maDatSan = dataGridView1.SelectedRows[0].Cells["maDatSanDataGridViewTextBoxColumn"].Value?.ToString();
                if (int.TryParse(maDatSan, out int maDatSanInt))
                {
                    // Lấy dữ liệu chi tiết của lịch đã chọn từ DataGridView
                    DataRow selectedRow = ((DataRowView)dataGridView1.SelectedRows[0].DataBoundItem).Row;

                    // Tạo đối tượng mới để truyền thông tin sang Form3
                    PhieuChiDTO phieuChiDTO = new PhieuChiDTO
                    {
                        MaDatSan = maDatSanInt,
                        MaSan = Convert.ToString(selectedRow["MaSan"]),
                        MaKH = Convert.ToString(selectedRow["MaKH"]),
                        TuNgay = Convert.ToDateTime(selectedRow["TuNgay"]),
                        DaTra = Convert.ToString(selectedRow["DaTra"])
                    };

                    // Mở Form3 và truyền đối tượng vào
                    Form3 form3 = new Form3(phieuChiDTO);
                    form3.ShowDialog(); // Mở Form3 như một hộp thoại (modal)
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để hủy.");
            }
        }

        // Sự kiện khi nhấn nút Tìm kiếm
        private void btnTim_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dateTimePickerTuNgay.Value;
            DateTime denNgay = dateTimePickerDenNgay.Value;

            // Gọi phương thức để tìm kiếm lịch sân theo khoảng thời gian
            DataTable dataTable = lichSanBAL.TimLichSan(tuNgay, denNgay);

            // Gán dữ liệu tìm được vào DataGridView
            dataGridView1.DataSource = dataTable;
        }
    }
}
