using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class FormThietLapLoaiKhachHang : Form
    {
        // Chuỗi kết nối tới cơ sở dữ liệu
        private string connectionString = "Data Source=LAPTOP-13092004\\SQLEXPRESS01;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False";

        public FormThietLapLoaiKhachHang()
        {
            InitializeComponent();
        }

        // Hàm tự động sinh mã loại khách hàng mới
        private string SinhMaLoaiKhachHangMoi()
        {
            string maLoaiMoi = "001"; // Giá trị mặc định nếu chưa có loại khách hàng
            string query = "SELECT MAX(MaLoaiKH) AS MaLonNhat FROM LoaiKhachHang";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    int soMoi = int.Parse(result.ToString()) + 1;
                    maLoaiMoi = soMoi.ToString("D3"); // Format lại (vd: "002")
                }
            }

            return maLoaiMoi;
        }

        // Xử lý khi nhấn nút Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox
            string tenLoai = txtTenLoaiKH.Text.Trim();

            // Kiểm tra thông tin nhập vào
            if (string.IsNullOrEmpty(tenLoai))
            {
                MessageBox.Show("Vui lòng nhập tên loại khách hàng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tự động sinh mã loại khách hàng mới
            string maLoaiKH = SinhMaLoaiKhachHangMoi();

            // Thêm loại khách hàng vào cơ sở dữ liệu
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO LoaiKhachHang (MaLoaiKH, TenLoaiKH) VALUES (@MaLoaiKH, @TenLoaiKH)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@MaLoaiKH", maLoaiKH);
                    cmd.Parameters.AddWithValue("@TenLoaiKH", tenLoai);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Thêm loại khách hàng thành công! Mã loại: {maLoaiKH}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa trắng TextBox sau khi thêm thành công
                txtTenLoaiKH.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm loại khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenLoaiKH = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(226, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "THIẾT LẬP LOẠI KHÁCH HÀNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(47, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "LOẠI KHÁCH HÀNG";
            // 
            // txtTenLoaiKH
            // 
            this.txtTenLoaiKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTenLoaiKH.Location = new System.Drawing.Point(272, 168);
            this.txtTenLoaiKH.Name = "txtTenLoaiKH";
            this.txtTenLoaiKH.Size = new System.Drawing.Size(355, 28);
            this.txtTenLoaiKH.TabIndex = 2;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLuu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLuu.Location = new System.Drawing.Point(553, 302);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(115, 48);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // FormThietLapLoaiKhachHang
            // 
            this.ClientSize = new System.Drawing.Size(828, 425);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtTenLoaiKH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormThietLapLoaiKhachHang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private Label label2;
        private TextBox txtTenLoaiKH;
        private Button btnLuu;
    }
}
