using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace BadmintonManager.GUI
{
    public partial class DanhMucHangHoa : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;
        public DanhMucHangHoa()
        {
            InitializeComponent();
        }


        private void DanhMucHangHoa_Load_1(object sender, EventArgs e)
        {
            LoadData();

        }


        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM HangHoa   ";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvHangHoa.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void Thembttn_Click(object sender, EventArgs e)
        {
            try
            {
                ThemHangHoa formDangKy = new ThemHangHoa();
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


        private void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any row is selected
                if (dgvHangHoa.SelectedRows.Count > 0)
                {
                    // Get the MaHH of the selected row
                    string maHH = dgvHangHoa.SelectedRows[0].Cells["MaHH"].Value.ToString();

                    // Confirm deletion
                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hàng hóa với mã '{maHH}' không?",
                                                          "Xác nhận xóa",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Perform deletion
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string deleteQuery = "DELETE FROM HangHoa WHERE MaHH = @MaHH";

                            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                            {
                                command.Parameters.AddWithValue("@MaHH", maHH);
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Xóa hàng hóa thành công!");
                                    LoadData(); // Refresh the data grid
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy hàng hóa để xóa.");
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hàng hóa cần xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa hàng hóa: " + ex.Message);
            }
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable changes = ((DataTable)dgvHangHoa.DataSource).GetChanges(); // Lấy các thay đổi
                if (changes != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        foreach (DataRow row in changes.Rows)
                        {
                            string query = @"UPDATE HangHoa
                                 SET TenHH = @TenHH, MaLoaiHH = @MaLoaiHH, 
                                     DonViTinhNhap = @DonViTinhNhap, QuyDoi = @QuyDoi, 
                                     GiaNhap = @GiaNhap, GiaBan = @GiaBan, SoLuong = @SoLuong
                                 WHERE MaHH = @MaHH";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MaHH", row["MaHH"]);
                                command.Parameters.AddWithValue("@TenHH", row["TenHH"]);
                                command.Parameters.AddWithValue("@MaLoaiHH", row["MaLoaiHH"]);
                                command.Parameters.AddWithValue("@DonViTinhNhap", row["DonViTinhNhap"]);
                                command.Parameters.AddWithValue("@QuyDoi", row["QuyDoi"]);
                                command.Parameters.AddWithValue("@GiaNhap", row["GiaNhap"]);
                                command.Parameters.AddWithValue("@GiaBan", row["GiaBan"]);
                                command.Parameters.AddWithValue("@SoLuong", row["SoLuong"]);

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

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
