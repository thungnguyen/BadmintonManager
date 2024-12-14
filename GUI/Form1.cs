﻿using BadmintonManager.BAL;
using BadmintonManager.DAL;
using BadmintonManager.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class Form1 : Form
    {
        private DanhSachLichSanBAL lichSanBAL;
        private KhachHangBLL khachHangBAL; // Thêm đối tượng để lấy dữ liệu khách hàng

        public Form1()
        {
            InitializeComponent();
            lichSanBAL = new DanhSachLichSanBAL();
            khachHangBAL = new KhachHangBLL(); // Khởi tạo đối tượng KhachHangBAL
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

                    // Thêm cột TenKH vào vị trí của MaKH (nếu chưa có)
                    if (!dataGridView1.Columns.Contains("TenKH"))
                    {
                        DataGridViewTextBoxColumn colTenKH = new DataGridViewTextBoxColumn();
                        colTenKH.Name = "TenKH";
                        colTenKH.HeaderText = "Tên KH";

                        // Insert the new column at the same position as MaKH
                        dataGridView1.Columns.Insert(dataGridView1.Columns["maKHDataGridViewTextBoxColumn"].Index, colTenKH);
                    }

                    // Duyệt qua từng dòng và thay thế MaKH bằng TenKH
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int maKH = Convert.ToInt32(row.Cells["maKHDataGridViewTextBoxColumn"].Value);
                            string tenKH = GetTenKhachHangById(maKH);  // Lấy tên khách hàng từ MaKH

                            // Kiểm tra nếu tên khách hàng không rỗng
                            if (!string.IsNullOrEmpty(tenKH))
                            {
                                row.Cells["TenKH"].Value = tenKH; // Cập nhật tên khách hàng vào cột TenKH
                            }
                            else
                            {
                                row.Cells["TenKH"].Value = "Không tìm thấy"; // Nếu không tìm thấy tên, hiển thị thông báo
                            }
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dateTimePickerTuNgay.Value;
            DateTime denNgay = dateTimePickerDenNgay.Value;

            // Gọi phương thức để tìm kiếm lịch sân theo khoảng thời gian
            DataTable dataTable = lichSanBAL.TimLichSan(tuNgay, denNgay);

            // Gán dữ liệu tìm được vào DataGridView
            dataGridView1.DataSource = dataTable;

            // Cập nhật tên khách hàng cho các dòng
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                // Duyệt qua từng dòng và thay thế MaKH bằng TenKH
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int maKH = Convert.ToInt32(row.Cells["maKHDataGridViewTextBoxColumn"].Value);
                        string tenKH = GetTenKhachHangById(maKH);  // Lấy tên khách hàng từ MaKH
                        row.Cells["TenKH"].Value = tenKH; // Cập nhật tên khách hàng vào cột TenKH
                    }
                }
            }
        }

        private void btnTimTenKH_Click(object sender, EventArgs e)
        {
            // Lấy tên khách hàng từ TextBox
            string tenKhachHang = txtTenKH.Text.Trim();

            // Kiểm tra nếu tên khách hàng không rỗng
            if (!string.IsNullOrEmpty(tenKhachHang))
            {
                // Tạo thể hiện của DanhSachLichSanDAL
                DanhSachLichSanDAL danhSachLichSanDAL = new DanhSachLichSanDAL();

                // Gọi phương thức tìm kiếm lịch sân theo tên khách hàng
                DataTable dataTable = danhSachLichSanDAL.TimLichSanTheoTenKH(tenKhachHang);

                // Gán dữ liệu tìm được vào DataGridView
                dataGridView1.DataSource = dataTable;

                // Cập nhật tên khách hàng cho các dòng
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    // Duyệt qua từng dòng và thay thế MaKH bằng TenKH
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int maKH = Convert.ToInt32(row.Cells["maKHDataGridViewTextBoxColumn"].Value);
                            string tenKH = GetTenKhachHangById(maKH);  // Lấy tên khách hàng từ MaKH
                            row.Cells["TenKH"].Value = tenKH; // Cập nhật tên khách hàng vào cột TenKH
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng để tìm kiếm.");
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
                        MaKH = Convert.ToString(selectedRow["MaKH"]),
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
