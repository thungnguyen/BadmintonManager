using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace BadmintonManager.GUI
{
    public partial class DanhMucHangHoa : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;
        public DanhMucHangHoa()
        {
            InitializeComponent();
        }

        private void DanhMucHangHoa_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM TaiKhoanNhanVien";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvHangHoa.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void Thembttn_Click(object sender, EventArgs e)
        {
            try
            {
                DangKyTaiKhoan formDangKy = new DangKyTaiKhoan();
                if (formDangKy.ShowDialog() == DialogResult.OK) // Chờ form thêm tài khoản đóng
                {
                    LoadData(); // Cập nhật lại dữ liệu sau khi thêm
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form thêm tài khoản: " + ex.Message);
            }
        }

        private void DanhMucHangHoa_Load_1(object sender, EventArgs e)
        {
            LoadData();
            
        }
    }
}
