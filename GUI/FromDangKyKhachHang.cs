using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class FormDangKyKhachHang : Form
    {
        // Chuỗi kết nối tới cơ sở dữ liệu
        private string connectionString = "Data Source=LAPTOP-13092004\\SQLEXPRESS01;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False";
        public FormDangKyKhachHang()
        {
            InitializeComponent();
        }


        // Hàm tự động sinh mã khách hàng mới
        private string SinhMaKhachHangMoi()
        {
            string maKhachHangMoi = "001"; // Giá trị mặc định nếu chưa có khách hàng
            string query = "SELECT MAX(MaKH) AS MaLonNhat FROM KhachHang";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    string maLonNhat = result.ToString(); // Ví dụ: "KH005"
                    string phanSo = maLonNhat.Substring(10); // Lấy phần số (vd: "005")
                    int soMoi = int.Parse(phanSo) + 1;
                    maKhachHangMoi = "" + soMoi.ToString("D3"); // Format lại (vd: "KH006")
                }
            }

            return maKhachHangMoi;
        }

        // Xử lý khi nhấn nút Đăng Ký
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();

            // Kiểm tra thông tin nhập vào
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng số điện thoại (10 chữ số)
            if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm 10 chữ số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tự động sinh mã khách hàng mới
            string maKhachHang = SinhMaKhachHangMoi();

            // Thêm khách hàng vào cơ sở dữ liệu
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO KhachHang (MaKH, TenKH, SDT) VALUES (@MaKH, @TenKH, @SDT)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@MaKH", maKhachHang);
                    cmd.Parameters.AddWithValue("@TenKH", hoTen);
                    cmd.Parameters.AddWithValue("@SDT", sdt);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Đăng ký thành công! Mã khách hàng: {maKhachHang}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa trắng các TextBox sau khi thêm thành công
                txtHoTen.Clear();
                txtSoDienThoai.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đăng ký khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
