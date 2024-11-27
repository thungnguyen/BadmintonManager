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

            cbLoaiHH.DataSource = dataTable;
            cbLoaiHH.DisplayMember = "TenLoaiHH"; // Hiển thị tên loại hàng hóa
            cbLoaiHH.ValueMember = "MaLoaiHH";   // Giá trị là mã loại hàng hóa
            cbLoaiHH.SelectedIndex = -1;        // Không chọn mặc định
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
       
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
          
        }


    }
}
