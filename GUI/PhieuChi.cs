using BadmintonManager.BAL;
using BadmintonManager.DTO;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class PhieuChi : Form
    {
        private PhieuChiDTO phieuChiDTO;
        private DanhSachLichSanBAL lichSanBAL;
        private PhieuChiBAL phieuChiBAL;
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

        public PhieuChi(PhieuChiDTO phieuChiDTO)
        {
            InitializeComponent();
            this.phieuChiDTO = phieuChiDTO;
            lichSanBAL = new DanhSachLichSanBAL();
            phieuChiBAL = new PhieuChiBAL();

            // Hiển thị thông tin lịch sân vào các TextBox
            txtMaDatSan.Text = phieuChiDTO.MaDatSan.ToString();
            txtMaSan.Text = phieuChiDTO.MaSan.ToString();
            txtMaKH.Text = phieuChiDTO.MaKH.ToString();
            txtTuNgay.Text = DateTime.Now.ToString("yyyy-MM-dd"); // Ngày mặc định hiện tại
            txtDaTra.Text = phieuChiDTO.DaTra.ToString();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ giao diện
                int maDatSan = int.Parse(txtMaDatSan.Text);
                int maSan = Convert.ToInt32(txtMaSan.Text);
                int maKH = Convert.ToInt32(txtMaKH.Text);
                string tuNgay = txtTuNgay.Text;
                decimal daTra = decimal.Parse(txtDaTra.Text);

                // Tạo đối tượng PhieuChiDTO
                PhieuChiDTO phieuChi = new PhieuChiDTO
                {

                    MaDatSan = maDatSan,
                    MaSan = maSan,
                    MaKH = maKH,
                    TuNgay = DateTime.Parse(tuNgay),
                    DaTra = daTra,
                    NgayLap = DateTime.Now // Ngày lập tự động
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
                            cmd1.Parameters.Add(new SqlParameter("@MaDatSan", System.Data.SqlDbType.Int) { Value = maDatSan });
                            cmd1.ExecuteNonQuery();
                        }

                        // 2. Xoá LichDatSan
                        string deleteLichDatSanQuery = "DELETE FROM LichDatSan WHERE MaDatSan = @MaDatSan";
                        using (SqlCommand cmd2 = new SqlCommand(deleteLichDatSanQuery, conn))
                        {
                            cmd2.Parameters.Add(new SqlParameter("@MaDatSan", System.Data.SqlDbType.Int) { Value = maDatSan });
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form
        }
    }
}
