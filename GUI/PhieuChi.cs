using BadmintonManager.BAL;
using BadmintonManager.DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class PhieuChi : Form
    {
        private PhieuChiDTO phieuChiDTO;
        private DanhSachLichSanBAL lichSanBAL;
        private PhieuChiBAL phieuChiBAL;
        private string connectionString;

        public PhieuChi(PhieuChiDTO phieuChiDTO)
        {
            InitializeComponent();
            this.phieuChiDTO = phieuChiDTO;

            // Khởi tạo các lớp BAL
            lichSanBAL = new DanhSachLichSanBAL();
            phieuChiBAL = new PhieuChiBAL();

            // Lấy chuỗi kết nối từ cấu hình
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Không tìm thấy chuỗi kết nối!");
                return;
            }

            // Hiển thị thông tin lịch sân vào các TextBox
            txtMaDatSan.Text = phieuChiDTO.MaDatSan.ToString();
            txtMaSan.Text = phieuChiDTO.MaSan;
            txtMaKH.Text = phieuChiDTO.MaKH;
            txtTuNgay.Text = DateTime.Now.ToString("yyyy-MM-dd"); // Ngày mặc định là hiện tại
            txtDaTra.Text = phieuChiDTO.DaTra;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ giao diện và kiểm tra dữ liệu
                if (!int.TryParse(txtMaDatSan.Text, out int maDatSan))
                {
                    MessageBox.Show("Mã đặt sân phải là một số hợp lệ.");
                    return;
                }

                string maSan = txtMaSan.Text;
                string maKH = txtMaKH.Text;

                if (!DateTime.TryParse(txtTuNgay.Text, out DateTime tuNgay))
                {
                    MessageBox.Show("Ngày không hợp lệ.");
                    return;
                }

                if (!decimal.TryParse(txtDaTra.Text, out decimal daTra))
                {
                    MessageBox.Show("Số tiền đã trả phải là một số hợp lệ.");
                    return;
                }

                // Tạo đối tượng PhieuChiDTO
                PhieuChiDTO phieuChi = new PhieuChiDTO
                {
                    MaDatSan = maDatSan,
                    MaSan = maSan,
                    MaKH = maKH,
                    TuNgay = tuNgay,
                    DaTra = daTra.ToString(),
                    NgayLap = DateTime.Now // Tự động gán ngày lập
                };

                // Gọi BAL để lưu phiếu chi
                bool isSaved = phieuChiBAL.LuuPhieuChi(phieuChi);

                if (isSaved)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // 1. Xoá ChiTietLichDatSan
                        string deleteChiTietLichDatSanQuery = "DELETE FROM ChiTietLichDatSan WHERE MaDatSan = @MaDatSan";
                        using (SqlCommand cmd1 = new SqlCommand(deleteChiTietLichDatSanQuery, conn))
                        {
                            cmd1.Parameters.Add(new SqlParameter("@MaDatSan", SqlDbType.Int) { Value = maDatSan });
                            cmd1.ExecuteNonQuery();
                        }

                        // 2. Xoá LichDatSan
                        string deleteLichDatSanQuery = "DELETE FROM LichDatSan WHERE MaDatSan = @MaDatSan";
                        using (SqlCommand cmd2 = new SqlCommand(deleteLichDatSanQuery, conn))
                        {
                            cmd2.Parameters.Add(new SqlParameter("@MaDatSan", SqlDbType.Int) { Value = maDatSan });
                            cmd2.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Đã lưu phiếu chi và xoá dữ liệu liên quan thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu phiếu chi!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng định dạng. Vui lòng kiểm tra lại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form
        }

        private void PhieuChi_Load(object sender, EventArgs e)
        {
            // Sự kiện khi form được load (nếu cần thực hiện thêm)
        }
    }
}
