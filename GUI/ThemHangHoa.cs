using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace BadmintonManager.GUI
{
    public partial class ThemHangHoa : Form
    {
        public ThemHangHoa()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void confirm_bttn_Click(object sender, EventArgs e)
        {
            try
            {
                // Connection string
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

                // SQL Insert Query
                string query = @"INSERT INTO HangHoa (MaHH, TenHH, MaLoaiHH, DonViTinhNhap, QuyDoi, GiaNhap, GiaBan, SoLuong)
                                VALUES (@MaHH, @TenHH, @MaLoaiHH, @DonViTinhNhap, @QuyDoi, @GiaNhap, @GiaBan, @SoLuong)";

                // Create SQL Connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create SQL Command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add Parameters
                        command.Parameters.AddWithValue("@MaHH", MaHH_textbox.Text.Trim());
                        command.Parameters.AddWithValue("@TenHH", TenHH_textbox.Text.Trim());
                        command.Parameters.AddWithValue("@MaLoaiHH", LoaiHH_textbox.Text.Trim());
                        command.Parameters.AddWithValue("@DonViTinhNhap", DonviTinhNhap_textbox.Text.Trim());
                        command.Parameters.AddWithValue("@QuyDoi", int.Parse(QuyDoi_textbox.Text.Trim()));
                        command.Parameters.AddWithValue("@GiaNhap", decimal.Parse(GiaNhap_textbox.Text.Trim()));
                        command.Parameters.AddWithValue("@GiaBan", decimal.Parse(GiaBan_textbox.Text.Trim()));
                        command.Parameters.AddWithValue("@SoLuong", int.Parse(SLuong_textbox.Text.Trim()));

                        // Execute Insert
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm hàng hóa thành công!");
                this.DialogResult = DialogResult.OK; // Close the form with OK result
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hàng hóa: " + ex.Message);
            }
        }

        private void cancel_bttn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Close the form with Cancel result
            this.Close();
        }
    }
}
