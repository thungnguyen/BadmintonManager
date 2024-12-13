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
        private KhachHangBAL khachHangBAL; // Thêm đối tượng để lấy dữ liệu khách hàng

        public Form1()
        {
            InitializeComponent();
            lichSanBAL = new DanhSachLichSanBAL();
            khachHangBAL = new KhachHangBAL(); // Khởi tạo đối tượng KhachHangBAL
        }

        // Phương thức để tải toàn bộ dữ liệu
        private void LoadData()
        {
            try
            {
                // Gọi phương thức lấy tất cả dữ liệu lịch sân
                DataTable dataTable = lichSanBAL.LayTatCaLichSan();

                // Gán dữ liệu vào DataGridView
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dataTable;

                    // Ẩn cột MaKH
                    dataGridView1.Columns["maKHDataGridViewTextBoxColumn"].Visible = false;

                    // Thêm cột TenKH vào vị trí của MaKH
                    DataGridViewTextBoxColumn colTenKH = new DataGridViewTextBoxColumn();
                    colTenKH.Name = "TenKH";
                    colTenKH.HeaderText = "Tên KH";

                    // Insert the new column at the same position as MaKH
                    dataGridView1.Columns.Insert(dataGridView1.Columns["maKHDataGridViewTextBoxColumn"].Index, colTenKH);

                    // Duyệt qua từng dòng và thay thế MaKH bằng TenKH
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int maKH = Convert.ToInt32(row.Cells["maKHDataGridViewTextBoxColumn"].Value);
                            string tenKH = GetTenKhachHangById(maKH);
                            row.Cells["TenKH"].Value = tenKH; // Cập nhật tên khách hàng vào cột TenKH
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        // Phương thức lấy tên khách hàng từ MaKH
        private string GetTenKhachHangById(int maKH)
        {
            // Truy vấn bảng KhachHang để lấy TenKH từ MaKH
            string tenKH = string.Empty;
            try
            {
                // Giả sử bạn có phương thức GetTenKhachHangById trong lớp KhachHangBAL
                tenKH = khachHangBAL.GetTenKhachHangById(maKH);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy tên khách hàng: " + ex.Message);
            }
            return tenKH;
        }

        // Sự kiện khi form được mở
        private void Form1_Load(object sender, EventArgs e)
        {
            // Load toàn bộ dữ liệu khi form mở lên
            LoadData();
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

            // Cập nhật lại cột TenKH khi tìm kiếm
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    int maKH = Convert.ToInt32(row.Cells["MaKH"].Value);
                    string tenKH = GetTenKhachHangById(maKH);
                    row.Cells["TenKH"].Value = tenKH; // Cập nhật tên khách hàng vào cột mới
                }
            }
        }

        // Sự kiện khi nhấn nút Hủy lịch
        private void btnHuyLich_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy mã đặt sân từ cột trong DataGridView
                string maDatSan = dataGridView1.SelectedRows[0].Cells["maDatSanDataGridViewTextBoxColumn"].Value?.ToString();
                if (int.TryParse(maDatSan, out int maDatSanInt))
                {
                    // Lấy dữ liệu chi tiết của lịch đã chọn từ DataGridView
                    DataRow selectedRow = ((DataRowView)dataGridView1.SelectedRows[0].DataBoundItem).Row;

                    // Lấy ngày TuNgay từ dòng được chọn
                    DateTime tuNgay = Convert.ToDateTime(selectedRow["TuNgay"]);

                    // Kiểm tra xem thời gian hủy có còn trong vòng 2 ngày trước TuNgay không
                    if ((tuNgay - DateTime.Now).TotalDays < 2)
                    {
                        MessageBox.Show("Quá thời gian để hủy lịch. Phải hủy ít nhất 2 ngày trước thời gian đặt sân.");
                        return;
                    }

                    // Nếu điều kiện hủy hợp lệ, tạo đối tượng PhieuChiDTO
                    PhieuChiDTO phieuChiDTO = new PhieuChiDTO
                    {
                        MaDatSan = maDatSanInt,
                        MaSan = Convert.ToString(selectedRow["MaSan"]),
                        TenKH = Convert.ToString(selectedRow["TenKH"]),
                        TuNgay = tuNgay,
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

        // Sự kiện khi nhấn nút Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Gọi lại phương thức LoadData để tải lại toàn bộ dữ liệu
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
