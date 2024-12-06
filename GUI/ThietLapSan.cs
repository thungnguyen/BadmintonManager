using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class ThietLapSan : Form
    {
        private string connectionString = "Data Source=DESKTOP-CESMAPL\\SQLEXPRESS;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False";

        public ThietLapSan()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT MaSan, TenSan FROM San";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDanhSachSan.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ThietLapSan_Load(object sender, EventArgs e)
        {
            LoadData(); // Tải dữ liệu lên DataGridView khi form khởi động
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenSan.Text) && !string.IsNullOrEmpty(txtTenSan.Text))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO San (MaSan, TenSan) VALUES (@MaSan, @TenSan)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaSan", txtMaSan.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenSan", txtTenSan.Text.Trim());
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Cập nhật lại danh sách sau khi thêm
                    txtMaSan.Clear();
                    txtTenSan.Clear(); // Xóa nội dung trong TextBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm sân: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tên sân hoặc mã sân chưa được nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvDanhSachSan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ dòng được chọn
                DataGridViewRow row = dgvDanhSachSan.Rows[e.RowIndex];

                // Kiểm tra và đảm bảo rằng tên cột chính xác
                txtMaSan.Text = row.Cells[0].Value.ToString(); // Giả sử MaSan là cột đầu tiên
                txtTenSan.Text = row.Cells[1].Value.ToString(); // Giả sử TenSan là cột thứ hai
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string MaSan = txtMaSan.Text.Trim(); // Lấy Mã Sân đã nhập vào TextBox
            string TenSan = txtTenSan.Text.Trim(); // Lấy Tên Sân đã nhập vào TextBox

            if (!string.IsNullOrEmpty(MaSan) && !string.IsNullOrEmpty(TenSan))
            {
                try
                {
                    // Kết nối đến cơ sở dữ liệu để cập nhật thông tin sân
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE San SET TenSan = @TenSan WHERE MaSan = @MaSan";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaSan", MaSan); // Tham số MaSan
                        cmd.Parameters.AddWithValue("@TenSan", TenSan); // Tham số TenSan
                        conn.Open();
                        cmd.ExecuteNonQuery(); // Thực hiện câu lệnh cập nhật
                    }

                    MessageBox.Show("Cập nhật sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Cập nhật lại danh sách sau khi sửa
                    txtMaSan.Clear(); // Xóa TextBox Mã Sân
                    txtTenSan.Clear(); // Xóa TextBox Tên Sân
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật sân: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string MaSan = txtMaSan.Text.Trim(); // Lấy Mã Sân từ TextBox

            // Kiểm tra xem có Mã Sân nào được chọn không
            if (!string.IsNullOrEmpty(MaSan))
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sân này?", "Xóa sân", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        // Xóa sân trong cơ sở dữ liệu dựa trên MaSan
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM San WHERE MaSan = @MaSan";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@MaSan", MaSan);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Xóa sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Cập nhật lại danh sách sau khi xóa
                        txtMaSan.Clear(); // Xóa TextBox Mã Sân
                        txtTenSan.Clear(); // Xóa TextBox Tên Sân
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa sân: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sân để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrices_Click(object sender, EventArgs e)
        {
            GiaSan giaSan = new GiaSan();
            giaSan.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
