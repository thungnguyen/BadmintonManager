using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class DanhSachTaiKhoan : Form
    {
        private string connectionString = "Data Source=DESKTOP-CESMAPL\\SQLEXPRESS;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False";

        public DanhSachTaiKhoan()
        {
            InitializeComponent();
        }

        // Khi Form tải, tải dữ liệu lên DataGridView
        private void DanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Phương thức tải dữ liệu từ database lên DataGridView
        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM TaiKhoanNhanVien";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Thêm cột VaiTroHienThi vào DataTable
                    //dataTable.Columns.Add("VaiTroHienThi", typeof(string));

                    //foreach (DataRow row in dataTable.Rows)
                    //{
                    //    row["VaiTroHienThi"] = row["VaiTro"].ToString() == "0" ? "Quản lý" : "Nhân viên";
                    //}

                    // Gán DataSource trước
                    dgvTaiKhoan.DataSource = dataTable;

                    // Ẩn cột VaiTro
                    if (dgvTaiKhoan.Columns["VaiTro"] != null)
                    {
                        dgvTaiKhoan.Columns["VaiTro"].Visible = false;
                    }

                    // Ẩn cột MaNV
                    if (dgvTaiKhoan.Columns["MaNV"] != null)
                    {
                        dgvTaiKhoan.Columns["MaNV"].Visible = false;
                    }

                    // Đổi tên cột VaiTroHienThi
                    //if (dgvTaiKhoan.Columns["VaiTroHienThi"] != null)
                    //{
                    //    dgvTaiKhoan.Columns["VaiTroHienThi"].HeaderText = "Vai Trò";
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }


        // Nút Thêm: Chuyển sang form DangKyTaiKhoan
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DangKyTaiKhoan formDangKy = new DangKyTaiKhoan();
                if (formDangKy.ShowDialog() == DialogResult.OK) // Chờ form thêm tài khoản đóng
                {
                    LoadData(); // Cập nhật lại dữ liệu sau khi thêm
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form thêm tài khoản: " + ex.Message);
            }
        }


        private void btnThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                DangKyTaiKhoan formDangKy = new DangKyTaiKhoan();
                if (formDangKy.ShowDialog() == DialogResult.OK) // Chờ form thêm tài khoản đóng
                {
                    LoadData(); // Cập nhật lại dữ liệu sau khi thêm
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form thêm tài khoản: " + ex.Message);
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            // Nút Sửa: Cập nhật thông tin tài khoản
            
                try
                {
                    DataTable changes = ((DataTable)dgvTaiKhoan.DataSource).GetChanges(); // Lấy các thay đổi
                    if (changes != null)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            foreach (DataRow row in changes.Rows)
                            {
                                string query = @"UPDATE TaiKhoanNhanVien
                                             SET TenNV = @TenNV, TenDangNhap = @TenDangNhap, 
                                                 MatKhau = @MatKhau, VaiTro = @VaiTro, SDT = @SDT
                                             WHERE MaNV = @MaNV";

                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                command.Parameters.AddWithValue("@MaNV", row["MaNV"]);
                                command.Parameters.AddWithValue("@TenNV", row["TenNV"]);
                                    command.Parameters.AddWithValue("@TenDangNhap", row["TenDangNhap"]);
                                    command.Parameters.AddWithValue("@MatKhau", row["MatKhau"]);
                                    command.Parameters.AddWithValue("@VaiTro", row["VaiTro"]);
                                    command.Parameters.AddWithValue("@SDT", row["SDT"]);

                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                        MessageBox.Show("Cập nhật thành công!");
                        LoadData(); // Cập nhật lại dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("Không có thay đổi nào cần lưu.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
                }
            }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            // Nút Xóa: Xóa tài khoản đã chọn

                try
                {
                    if (dgvTaiKhoan.SelectedRows.Count > 0)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow row in dgvTaiKhoan.SelectedRows)
                            {
                                int maNV = Convert.ToInt32(row.Cells["MaNV"].Value); // Khóa chính

                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    string query = "DELETE FROM TaiKhoanNhanVien WHERE MaNV = @MaNV";
                                    using (SqlCommand command = new SqlCommand(query, connection))
                                    {
                                        command.Parameters.AddWithValue("@MaNV", maNV);
                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                            MessageBox.Show("Xóa thành công!");
                            LoadData(); // Tải lại dữ liệu
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn tài khoản cần xóa.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message);
                }
            }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
