using BadmintonManager.BAL;
using BadmintonManager.DTO;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class Form3 : Form
    {
        private PhieuChiDTO phieuChiDTO;
        private DanhSachLichSanBAL lichSanBAL;
        private PhieuChiBAL phieuChiBAL;
        private string connectionString = "Data Source=LAPTOP-JDM8N7NE;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False";

        public Form3(PhieuChiDTO phieuChiDTO)
        {
            InitializeComponent();
            this.phieuChiDTO = phieuChiDTO;
            lichSanBAL = new DanhSachLichSanBAL();
            phieuChiBAL = new PhieuChiBAL();

            // Hiển thị thông tin lịch sân vào các TextBox
            txtMaDatSan.Text = phieuChiDTO.MaDatSan.ToString();
            txtMaSan.Text = phieuChiDTO.MaSan;
            txtMaKH.Text = phieuChiDTO.MaKH;
            txtTuNgay.Text = DateTime.Now.ToString("yyyy-MM-dd"); // Ngày mặc định hiện tại
            txtDaTra.Text = phieuChiDTO.DaTra;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ giao diện
                int maDatSan = int.Parse(txtMaDatSan.Text);
                string maSan = txtMaSan.Text;
                string maKH = txtMaKH.Text;
                string tuNgay = txtTuNgay.Text;
                decimal daTra = decimal.Parse(txtDaTra.Text);

                // Tạo đối tượng PhieuChiDTO
                PhieuChiDTO phieuChi = new PhieuChiDTO
                {
                    MaDatSan = maDatSan,
                    MaSan = maSan,
                    MaKH = maKH,
                    TuNgay = DateTime.Parse(tuNgay),
                    DaTra = daTra.ToString(),
                    NgayLap = DateTime.Now // Ngày lập tự động
                };

                // Gọi BAL để lưu phiếu chi
                bool isSaved = phieuChiBAL.LuuPhieuChi(phieuChi);

                if (isSaved)
                {
                    // Xóa dữ liệu từ ChiTietLichDatSan
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM ChiTietLichDatSan WHERE MaDatSan = @MaDatSan";

                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaDatSan", maDatSan);

                            int rowsAffected = cmd.ExecuteNonQuery(); // Thực thi câu lệnh DELETE
                        }
                    }

                    MessageBox.Show("Đã lưu phiếu chi và xóa chi tiết lịch thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu phiếu chi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            this.Close(); // Đóng form
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form
        }
    }
}