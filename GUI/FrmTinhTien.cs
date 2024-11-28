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
    public partial class FrmTinhTien : Form
    {
        private string connectionString = "Data Source=DESKTOP-CESMAPL\\SQLEXPRESS;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False";
        public FrmTinhTien()
        {
            InitializeComponent();
        }

        private void FrmTinhTien_Load(object sender, EventArgs e)
        {
            LoadLoaiHH();
            LoadHangHoa();
            dgvHangHoa.RowPostPaint += dgvHangHoa_RowPostPaint;
            cbLoaiHH.SelectedValueChanged += cbLoaiHH_SelectedValueChanged;

        }
        private void LoadLoaiHH()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaLoaiHH, TenLoaiHH FROM LoaiHH";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Thêm dòng "Tất cả" vào DataTable
                    DataRow allRow = dataTable.NewRow();
                    allRow["MaLoaiHH"] = DBNull.Value; // Giá trị null để nhận diện "Tất cả"
                    allRow["TenLoaiHH"] = "Tất cả";
                    dataTable.Rows.InsertAt(allRow, 0); // Thêm vào vị trí đầu tiên

                    cbLoaiHH.DataSource = dataTable;
                    cbLoaiHH.DisplayMember = "TenLoaiHH"; // Hiển thị tên loại hàng hóa
                    cbLoaiHH.ValueMember = "MaLoaiHH";   // Giá trị là mã loại hàng hóa
                    cbLoaiHH.SelectedIndex = 0;          // Chọn "Tất cả" mặc định
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại hàng hóa: " + ex.Message);
            }
        }
        private void LoadHangHoa(string maLoaiHH = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaHH, TenHH, DonViTinhNhap, GiaNhap, GiaBan, SoLuong FROM HangHoa";

                    if (!string.IsNullOrEmpty(maLoaiHH))
                    {
                        query += " WHERE MaLoaiHH = @MaLoaiHH";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    if (!string.IsNullOrEmpty(maLoaiHH))
                    {
                        command.Parameters.AddWithValue("@MaLoaiHH", maLoaiHH);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvHangHoa.DataSource = dataTable;

                    // Ẩn tất cả các cột ngoại trừ TenHH
                    foreach (DataGridViewColumn column in dgvHangHoa.Columns)
                    {
                        if (column.Name != "TenHH") // Chỉ hiển thị cột TenHH
                        {
                            column.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hàng hóa: " + ex.Message);
            }
        }
        private void dgvHangHoa_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(dgvHangHoa.RowHeadersDefaultCellStyle.ForeColor))
            {
                // Vẽ số thứ tự lên Header của từng hàng
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                                      dgvHangHoa.DefaultCellStyle.Font,
                                      brush,
                                      e.RowBounds.Location.X + 10,
                                      e.RowBounds.Location.Y + 4);
            }
        }
       
        

        private void cbLoaiHH_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbLoaiHH.SelectedValue == null || cbLoaiHH.SelectedValue == DBNull.Value)
            {
                LoadHangHoa(); // Hiển thị toàn bộ
            }
            else if (int.TryParse(cbLoaiHH.SelectedValue.ToString(), out int maLoaiHH))
            {
                LoadHangHoa(maLoaiHH.ToString()); // Lọc theo loại
            }

        }
        private DataTable TimKiemHangHoa(string keyword, string maLoaiHH = null)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT MaHH, TenHH, DonViTinhNhap, GiaNhap, GiaBan, SoLuong
                FROM HangHoa
                WHERE (TenHH LIKE @keyword OR MaHH = @mahh)";

                    // Nếu có mã loại hàng hóa, thêm điều kiện lọc
                    if (!string.IsNullOrEmpty(maLoaiHH))
                    {
                        query += " AND MaLoaiHH = @MaLoaiHH";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();

                        // Thêm tham số tìm kiếm
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                        if (int.TryParse(keyword, out int mahh))
                        {
                            cmd.Parameters.AddWithValue("@mahh", mahh);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@mahh", DBNull.Value);
                        }

                        // Nếu có mã loại hàng hóa, thêm tham số lọc
                        if (!string.IsNullOrEmpty(maLoaiHH))
                        {
                            cmd.Parameters.AddWithValue("@MaLoaiHH", maLoaiHH);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt); // Điền dữ liệu vào DataTable
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }

            return dt;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim(); // Lấy giá trị từ textbox tìm kiếm

            // Kiểm tra xem có lọc loại hàng hóa không
            string maLoaiHH = null; // Mặc định không lọc
            if (cbLoaiHH.SelectedValue != null && cbLoaiHH.SelectedValue != DBNull.Value)
            {
                maLoaiHH = cbLoaiHH.SelectedValue.ToString();
            }

            // Gọi phương thức tìm kiếm với từ khóa và mã loại hàng hóa (nếu có)
            DataTable dt = TimKiemHangHoa(keyword, maLoaiHH);

            if (dt.Rows.Count > 0)
            {
                dgvHangHoa.DataSource = dt; // Hiển thị dữ liệu lên DataGridView
            }
            else
            {
                MessageBox.Show("Không tìm thấy hàng hóa phù hợp!");
            }
        }
    }
}
