using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class frmDanhMucHangHoa : Form
    {
        private string connectionString = "Data Source=MSIALPHA15;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False"; // Đặt chuỗi kết nối ở đây

        // Kết nối cơ sở dữ liệu
        SqlConnection con;

        public frmDanhMucHangHoa()
        {
            InitializeComponent();
            con = new SqlConnection(connectionString); // Khởi tạo kết nối
        }

        // Mở kết nối
        private void openCon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        // Đóng kết nối
        private void closeCon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        // Thực thi các câu lệnh SQL thay đổi dữ liệu (insert, update, delete)
        private Boolean ExeData(string cmd)
        {
            openCon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
            closeCon();
            return check;
        }

        // Đọc dữ liệu từ cơ sở dữ liệu
        private DataTable RedData(string cmd)
        {
            openCon();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }
            closeCon();
            return dt;
        }

        // Tải dữ liệu từ cơ sở dữ liệu vào DataGridView
        private void LoadData()
        {
            // Dùng phương thức RedData để đọc dữ liệu từ bảng HangHoa
            DataTable dt = RedData("SELECT * FROM HangHoa"); // Sửa lại bảng cho đúng với tên của bảng bạn
            if (dt != null)
            {
                dgvHangHoa.DataSource = dt; // Gán dữ liệu vào DataGridView
            }
            else
            {
                MessageBox.Show("Không có dữ liệu.");
            }
        }

        // Sự kiện khi form tải, gọi LoadData()
        private void frmDanhMucHangHoa_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Form loaded");  // Kiểm tra xem form có tải không
            LoadData(); // Tải dữ liệu lên DataGridView
        }

        private void frmDanhMucHangHoa_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLySanDataSet.HangHoa' table. You can move, or remove it, as needed.
            this.hangHoaTableAdapter.Fill(this.quanLySanDataSet.HangHoa);

        }
    }
}
