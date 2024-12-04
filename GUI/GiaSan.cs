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
            LoadGiaSanData();
        }
        private void LoadGiaSanData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT MaGia, LoaiKH, GioBatDau, GioKetThuc, Gia FROM BangGiaSan";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvGiaSan.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO BangGiaSan (LoaiKH, GioBatDau, GioKetThuc, Gia) VALUES (@LoaiKH, @GioBatDau, @GioKetThuc, @Gia)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LoaiKH", txtLoaiKH.Text.Trim());
                        command.Parameters.AddWithValue("@GioBatDau", dtpBegin.Value.TimeOfDay);
                        command.Parameters.AddWithValue("@GioKetThuc", dtpEnd.Value.TimeOfDay);
                        command.Parameters.AddWithValue("@Gia", decimal.Parse(txtGia.Text));

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm dữ liệu thành công!");
                LoadGiaSanData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGiaSan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGiaSan.Rows[e.RowIndex];
                txtMaGia.Text = row.Cells["MaGia"].Value.ToString();
                txtLoaiKH.Text = row.Cells["LoaiKH"].Value.ToString();
                dtpBegin.Value = DateTime.Today + (TimeSpan)row.Cells["GioBatDau"].Value;
                dtpEnd.Value = DateTime.Today + (TimeSpan)row.Cells["GioKetThuc"].Value;
                txtGia.Text = row.Cells["Gia"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE BangGiaSan SET LoaiKH = @LoaiKH, GioBatDau = @GioBatDau, GioKetThuc = @GioKetThuc, Gia = @Gia WHERE MaGia = @MaGia";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaGia", int.Parse(txtMaGia.Text));
                        cmd.Parameters.AddWithValue("@LoaiKH", txtLoaiKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@GioBatDau", dtpBegin.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@GioKetThuc", dtpEnd.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@Gia", decimal.Parse(txtGia.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cập nhật dữ liệu thành công!");
                LoadGiaSanData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaGia.Text))
                {
                    MessageBox.Show("Vui lòng chọn một mục để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM BangGiaSan WHERE MaGia = @MaGia";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaGia", int.Parse(txtMaGia.Text));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Xóa dữ liệu thành công!");
                LoadGiaSanData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
