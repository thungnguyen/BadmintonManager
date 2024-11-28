using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class GiaSan : Form
    {
        private string connectionString = "Data Source=DESKTOP-CESMAPL\\SQLEXPRESS;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False";

        public GiaSan()
        {
            InitializeComponent();
            LoadLoaiKhachHang();
        }
        private void LoadLoaiKhachHang()
        {
            string query = "SELECT MaLoaiKH, TenLoaiKH FROM LoaiKhachHang";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable loaiKhachHangTable = new DataTable();
                adapter.Fill(loaiKhachHangTable);

                cbLoaiKH.DataSource = loaiKhachHangTable;
                cbLoaiKH.DisplayMember = "TenLoaiKH";
                cbLoaiKH.ValueMember = "MaLoaiKH";
            }
        }
        private void LoadGiaSanData()
        {
    try
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT MaGia, MaLoaiKH, GioBatDau, GioKetThuc, Gia FROM GiaSan";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Định dạng các cột giờ
            foreach (DataRow row in dt.Rows)
            {
                if (TimeSpan.TryParse(row["GioBatDau"].ToString(), out TimeSpan gioBatDau))
                {
                    row["GioBatDau"] = gioBatDau;
                }
                if (TimeSpan.TryParse(row["GioKetThuc"].ToString(), out TimeSpan gioKetThuc))
                {
                    row["GioKetThuc"] = gioKetThuc;
                }
            }

            dgvGiaSan.DataSource = dt;
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Lỗi khi tải dữ liệu GiaSan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
        }
        private string FormatTime(TimeSpan time)
        {
            DateTime dateTime = DateTime.Today.Add(time);
            return dateTime.ToString("h:mm tt", new System.Globalization.CultureInfo("vi-VN"));
        }

        private void GiaSan_Load(object sender, EventArgs e)
        {
            LoadGiaSanData(); // Tải dữ liệu GiaSan lên DataGridView khi form khởi động
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO GiaSan (MaGia, MaLoaiKH, GioBatDau, GioKetThuc, Gia) VALUES (@MaGia, @MaLoaiKH, @GioBatDau, @GioKetThuc, @Gia)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaGia", int.Parse(txtMaGia.Text));
                    command.Parameters.AddWithValue("@MaLoaiKH", cbLoaiKH.SelectedValue);
                    command.Parameters.AddWithValue("@GioBatDau", dtpBegin.Value.TimeOfDay);
                    command.Parameters.AddWithValue("@GioKetThuc", dtpEnd.Value.TimeOfDay);
                    command.Parameters.AddWithValue("@Gia", decimal.Parse(txtGia.Text));

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Thêm dữ liệu thành công!");

                    // Làm mới DataGridView
                    LoadGiaSanData();
                }
            }
        }

        private void dgvGiaSan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGiaSan.Rows[e.RowIndex];
                txtMaGia.Text = row.Cells[0].Value.ToString();
                cbLoaiKH.SelectedValue = row.Cells[1].Value;
                dtpBegin.Value = DateTime.Today + (TimeSpan)row.Cells[3].Value;
                dtpEnd.Value = DateTime.Today + (TimeSpan)row.Cells[4].Value;
                txtGia.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE GiaSan SET MaLoaiKH = @MaLoaiKH, GioBatDau = @GioBatDau, GioKetThuc = @GioKetThuc, Gia = @Gia WHERE MaGia = @MaGia";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaGia", int.Parse(txtMaGia.Text));
                        cmd.Parameters.AddWithValue("@MaLoaiKH", cbLoaiKH.SelectedValue);
                        cmd.Parameters.AddWithValue("@GioBatDau", dtpBegin.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@GioKetThuc", dtpEnd.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@Gia", decimal.Parse(txtGia.Text));

                        cmd.ExecuteNonQuery();
                    }

                    LoadGiaSanData();
                    MessageBox.Show("Cập nhật giá sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật giá sân: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string maGia = txtMaGia.Text.Trim(); // Lấy Mã Giá từ TextBox

            // Kiểm tra xem có Mã Giá nào được chọn không
            if (!string.IsNullOrEmpty(maGia))
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa giá sân này?", "Xóa giá sân", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        // Xóa giá sân trong cơ sở dữ liệu dựa trên MaGia
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM GiaSan WHERE MaGia = @MaGia";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@MaGia", maGia);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Xóa giá sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGiaSanData(); // Cập nhật lại danh sách sau khi xóa
                        txtMaGia.Clear(); // Xóa TextBox Mã Giá
                        txtGia.Clear(); // Xóa TextBox Giá
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa giá sân: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Mã Giá để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
