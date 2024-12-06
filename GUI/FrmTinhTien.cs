using qlycaulong.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class FrmTinhTien : Form
    {
        private string connectionString = "Data Source=MSIALPHA15;Initial Catalog=QuanLySan;Integrated Security=True;Encrypt=False";
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
            LoadTenHangHoa();
            // Đăng ký sự kiện SelectedIndexChanged cho ComboBox cbTenHH
            cbTenHH.SelectedIndexChanged += cbTenHH_SelectedIndexChanged;
            txtGiamGia.Text = "0";
            LoadSanData();
            LoadKhachHang();
            LoadLoaiKH();
            nudSoGioThue.Value = 1;
            txtGiaSan.Text = "0";
            cbLoaiKH.SelectedIndexChanged += cbLoaiKH_SelectedIndexChanged;
            // Đặt giá trị ban đầu cho txtTienCuoi là 0đ
            txtTienCuoi.Text = "0";
            txtTongTien.Text = "0";
            txtKhachDua.Text = "0";
            txtTienThua.Text = "0";
        }
        private void LoadLoaiKH()
        {
            // Tạo DataTable để chứa các lựa chọn
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("TenLoaiKH", typeof(string)); // Cột để hiển thị
            dataTable.Columns.Add("MaLoaiKH", typeof(string)); // Cột để lưu giá trị tương ứng

            // Thêm các lựa chọn vào DataTable
            dataTable.Rows.Add("Vãng Lai", "Vang lai");
            dataTable.Rows.Add("Cố Định", "Co dinh");

            // Gắn dữ liệu vào ComboBox
            cbLoaiKH.DataSource = dataTable;
            cbLoaiKH.DisplayMember = "TenLoaiKH"; // Hiển thị tên
            cbLoaiKH.ValueMember = "MaLoaiKH"; // Giá trị là mã loại khách hàng (vang lai/co dinh)
            cbLoaiKH.SelectedIndex = 0; // Mặc định chọn Vãng Lai
        }
        // Phương thức để load danh sách khách hàng vào ComboBox
        private void LoadKhachHang()
            {
                try
                {

                    // Tạo kết nối tới cơ sở dữ liệu
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Mở kết nối
                        connection.Open();

                        // Câu lệnh SQL để lấy danh sách khách hàng
                        string query = "SELECT MaKH, TenKH FROM KhachHang";

                        // Tạo SqlDataAdapter để thực thi câu lệnh và lưu kết quả vào DataTable
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                        DataTable dtKhachHang = new DataTable();
                        dataAdapter.Fill(dtKhachHang);

                        // Thêm dòng "Tất cả" vào đầu DataTable
                        DataRow row = dtKhachHang.NewRow();
                        row["MaKH"] = 0;  // Mã khách hàng cho "Tất cả" (có thể là giá trị đặc biệt như 0 hoặc null)
                        row["TenKH"] = "Tất cả";
                        dtKhachHang.Rows.InsertAt(row, 0);

                        // Đặt nguồn dữ liệu cho ComboBox
                        cbKhachHang.DataSource = dtKhachHang;
                        cbKhachHang.DisplayMember = "TenKH"; // Hiển thị tên khách hàng
                        cbKhachHang.ValueMember = "MaKH";   // Giá trị của mỗi mục trong ComboBox là mã khách hàng

                        // Đóng kết nối
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message);
                }
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

                    DataRow allRow = dataTable.NewRow();
                    allRow["MaLoaiHH"] = DBNull.Value;
                    allRow["TenLoaiHH"] = "Tất cả";
                    dataTable.Rows.InsertAt(allRow, 0);

                    cbLoaiHH.DataSource = dataTable;
                    cbLoaiHH.DisplayMember = "TenLoaiHH";
                    cbLoaiHH.ValueMember = "MaLoaiHH";
                    cbLoaiHH.SelectedIndex = 0;
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
                    string query = @"SELECT MaHH, TenHH, DonViTinhLon, DonViTinhNho, HeSoQuyDoi, GiaBanLon, GiaBanNho, SoLuongTonLon, SoLuongTonNho 
                                      FROM HangHoa";

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
                    string query = @"SELECT MaHH, TenHH, DonViTinhLon, DonViTinhNho, HeSoQuyDoi, GiaBanLon, GiaBanNho, SoLuongTonLon, SoLuongTonNho
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
        // phần chọn thêm hàngg
        // Tải đơn vị tính cho một mã hàng hóa
        private void LoadTenHangHoa()
        {
            string query = "SELECT MaHH, TenHH FROM HangHoa";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable HangHoaTable = new DataTable();
                adapter.Fill(HangHoaTable);

                cbTenHH.DataSource = HangHoaTable;
                cbTenHH.DisplayMember = "TenHH";
                cbTenHH.ValueMember = "MaHH";
            }
        }
        private void LoadDonViTinh(int maHH)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Câu truy vấn để lấy đơn vị tính từ bảng HangHoa theo mã hàng hóa
                    string query = "SELECT DonViTinhLon, DonViTinhNho FROM HangHoa WHERE MaHH = @MaHH";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHH", maHH);

                    SqlDataReader reader = command.ExecuteReader();

                    // Xóa dữ liệu cũ trong ComboBox cbDonViTinh trước khi thêm mới
                    cbDonViTinh.Items.Clear();

                    // Nếu tìm thấy dữ liệu
                    if (reader.Read())
                    {
                        string donViTinhLon = reader["DonViTinhLon"].ToString();
                        string donViTinhNho = reader["DonViTinhNho"].ToString();

                        // Thêm đơn vị tính vào ComboBox cbDonViTinh
                        if (!string.IsNullOrEmpty(donViTinhLon))
                        {
                            cbDonViTinh.Items.Add(donViTinhLon);
                        }
                        if (!string.IsNullOrEmpty(donViTinhNho))
                        {
                            cbDonViTinh.Items.Add(donViTinhNho);
                        }

                        // Chọn đơn vị tính đầu tiên trong ComboBox
                        if (cbDonViTinh.Items.Count > 0)
                        {
                            cbDonViTinh.SelectedIndex = 0;  // Chọn đơn vị tính đầu tiên
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin đơn vị tính cho hàng hóa này.");
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin đơn vị tính: " + ex.Message);
            }
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Kiểm tra xem có phải là hàng hợp lệ không
            {
                DataGridViewRow row = dgvHangHoa.Rows[e.RowIndex];

                // Đặt giá trị của ComboBox để hiển thị tên hàng hóa
                cbTenHH.SelectedValue = row.Cells["MaHH"].Value;


            }
        }

        private void cbTenHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có giá trị nào được chọn trong ComboBox cbTenHH
            if (cbTenHH.SelectedValue != null && cbTenHH.SelectedValue != DBNull.Value)
            {
                // Lấy đối tượng DataRowView từ SelectedItem
                DataRowView selectedRow = (DataRowView)cbTenHH.SelectedItem;

                // Lấy mã hàng hóa (MaHH) từ DataRowView
                int maHH = Convert.ToInt32(selectedRow["MaHH"]);

                // Gọi hàm LoadDonViTinh để tải đơn vị tính cho mã hàng hóa đã chọn
                LoadDonViTinh(maHH);
            }
        }

        private void cbDonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có sản phẩm đã được chọn trong cbTenHH và đơn vị tính đã được chọn trong cbDonViTinh
            if (cbTenHH.SelectedValue != null && cbTenHH.SelectedValue != DBNull.Value && cbDonViTinh.SelectedItem != null)
            {
                // Lấy đối tượng DataRowView từ SelectedItem
                DataRowView selectedRow = (DataRowView)cbTenHH.SelectedItem;

                // Lấy mã hàng hóa (MaHH) từ DataRowView
                int maHH = Convert.ToInt32(selectedRow["MaHH"]);
                string donViTinh = cbDonViTinh.SelectedItem.ToString(); // Lấy đơn vị tính từ cbDonViTinh

                // Gọi hàm GetGiaBan để lấy giá bán dựa trên mã hàng hóa và đơn vị tính đã chọn
                GetGiaBan(maHH, donViTinh);

                // Lấy số lượng tồn kho và cập nhật giới hạn của nudSoLuong
                GetSoLuongTon(maHH, donViTinh);

                // Gọi lại tính toán thành tiền ngay lập tức sau khi thay đổi đơn vị tính
                nudSoLuong_ValueChanged(sender, e);
            }
        }
        private void GetGiaBan(int maHH, string donViTinh)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Câu truy vấn lấy giá bán của sản phẩm theo đơn vị tính
                    string query = "SELECT GiaBanLon, GiaBanNho, DonViTinhLon, DonViTinhNho FROM HangHoa WHERE MaHH = @MaHH";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHH", maHH);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        decimal giaBan = 0;

                        // Kiểm tra đơn vị tính và lấy giá tương ứng
                        if (donViTinh == reader["DonViTinhLon"].ToString())
                        {
                            giaBan = Convert.ToDecimal(reader["GiaBanLon"]);
                        }
                        else if (donViTinh == reader["DonViTinhNho"].ToString())
                        {
                            giaBan = Convert.ToDecimal(reader["GiaBanNho"]);
                        }

                        // Hiển thị giá bán vào ô txtDonGia
                        txtDonGia.Text = giaBan.ToString("N0"); // Định dạng giá theo kiểu tiền tệ
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin giá bán cho sản phẩm này.");
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy giá bán: " + ex.Message);
            }
        }
        private void GetSoLuongTon(int maHH, string donViTinh)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Câu truy vấn lấy số lượng tồn kho theo mã hàng hóa và đơn vị tính
                    string query = "SELECT SoLuongTonLon, SoLuongTonNho, DonViTinhLon, DonViTinhNho FROM HangHoa WHERE MaHH = @MaHH";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHH", maHH);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        decimal soLuongTon = 0;

                        // Kiểm tra đơn vị tính và lấy số lượng tương ứng
                        if (donViTinh == reader["DonViTinhLon"].ToString())
                        {
                            soLuongTon = Convert.ToDecimal(reader["SoLuongTonLon"]);
                        }
                        else if (donViTinh == reader["DonViTinhNho"].ToString())
                        {
                            soLuongTon = Convert.ToDecimal(reader["SoLuongTonNho"]);
                        }

                        // Cập nhật giới hạn cho nudSoLuong
                        nudSoLuong.Minimum = 1;
                        nudSoLuong.Maximum = soLuongTon;

                        // Đặt giá trị mặc định là 1
                        nudSoLuong.Value = 1;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin số lượng tồn kho cho sản phẩm này.");
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy số lượng tồn kho: " + ex.Message);
            }
        }

        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            // Tính toán thành tiền khi số lượng thay đổi
            decimal donGia = Convert.ToDecimal(txtDonGia.Text);
            decimal soLuong = nudSoLuong.Value;
            decimal thanhTien = donGia * soLuong;

            // Lấy giá trị giảm giá từ txtGiamGia và chuyển đổi sang decimal
            decimal giamGia = 0;
            if (!string.IsNullOrEmpty(txtGiamGia.Text) && decimal.TryParse(txtGiamGia.Text, out giamGia))
            {
                // Nếu có giá trị giảm giá hợp lệ, trừ vào thành tiền
                thanhTien -= giamGia;
            }

            // Đảm bảo thành tiền không âm
            if (thanhTien < 0)
            {
                thanhTien = 0;
            }

            // Hiển thị thành tiền vào ô txtThanhTien
            txtThanhTien.Text = thanhTien.ToString("C0", new CultureInfo("vi-VN"));
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có thay đổi trong ô txtGiamGia
            // Cập nhật lại thành tiền khi giá trị giảm giá thay đổi
            nudSoLuong_ValueChanged(sender, e);
        }
        // phần thêm hàng hóa vào hóa đơn

        public class HangHoaTemp
        {
            public int MaHDSP { get; set; }
            public int MaHD { get; set; }
            public int MaHH { get; set; }
            public string TenHH { get; set; }
            public string DonViTinh { get; set; }
            public int SoLuong { get; set; }
            public decimal DonGia { get; set; }
            public decimal ThanhTien { get; set; }
        }
        private List<HangHoaTemp> danhSachHangHoaTemp = new List<HangHoaTemp>();
        private int maHDSPCounter = 1;

        private void btnAddHH_Click(object sender, EventArgs e)
        {

            // Lấy thông tin hàng hóa từ các điều khiển
            int maHH = Convert.ToInt32(cbTenHH.SelectedValue);
            DataRowView selectedRow = (DataRowView)cbTenHH.SelectedItem;
            string tenHH = selectedRow["TenHH"].ToString();
            string donViTinh = cbDonViTinh.SelectedItem.ToString();
            decimal donGia = Convert.ToDecimal(txtDonGia.Text);
            decimal soLuong = nudSoLuong.Value;
            decimal thanhTien = donGia * soLuong;

            // Kiểm tra giảm giá và tính lại thành tiền
            decimal giamGia = 0;
            if (decimal.TryParse(txtGiamGia.Text, out giamGia))
            {
                thanhTien -= giamGia;
            }

            // Đảm bảo thành tiền không âm
            if (thanhTien < 0)
            {
                thanhTien = 0;
            }

            // Tạo đối tượng HangHoaTemp và thêm vào danh sách
            HangHoaTemp hangHoaTemp = new HangHoaTemp
            {
                MaHDSP = maHDSPCounter++,
                MaHH = maHH,
                TenHH = tenHH,
                DonViTinh = donViTinh,
                DonGia = donGia,
                SoLuong = (int)soLuong,
                ThanhTien = thanhTien
            };

            danhSachHangHoaTemp.Add(hangHoaTemp);

            // Cập nhật giao diện (hiển thị danh sách lên DataGridView)
            dgvDanhSachHangHoa.DataSource = null;
            dgvDanhSachHangHoa.DataSource = danhSachHangHoaTemp;

            // Ẩn các cột không cần thiết
            dgvDanhSachHangHoa.Columns["MaHD"].Visible = false;
            dgvDanhSachHangHoa.Columns["MaHH"].Visible = false;

            // Xóa cột "Đơn Vị Tính"
            dgvDanhSachHangHoa.Columns.Remove("DonViTinh");

            // Cập nhật các cột còn
            dgvDanhSachHangHoa.Columns["MaHDSP"].HeaderText = "Mã HDSP";
            dgvDanhSachHangHoa.Columns["TenHH"].HeaderText = "Tên HH";
            dgvDanhSachHangHoa.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvDanhSachHangHoa.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvDanhSachHangHoa.Columns["ThanhTien"].HeaderText = "Thành Tiền";
        }

        // Hàm cập nhật tổng tiền
        private void TinhTongTien()
        {
            decimal tongTien = 0;

            // Duyệt qua tất cả các dòng trong DataGridView
            foreach (DataGridViewRow row in dgvDanhSachHangHoa.Rows)
            {
                // Kiểm tra dòng có dữ liệu
                if (!row.IsNewRow)
                {
                    // Lấy giá trị từ cột Gia và SoLuong (cần đảm bảo các cột này có tên đúng)
                    decimal thanhtien = Convert.ToDecimal(row.Cells["thanhTien"].Value);



                    tongTien += thanhtien;
                }
            }

            // Cập nhật giá trị vào ô txtTongTien
            txtTongTien.Text = tongTien.ToString("C0", new CultureInfo("vi-VN"));  // C2 để định dạng thành tiền tệ
        }

        private void dgvDanhSachHangHoa_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TinhTongTien();
        }

        private void dgvDanhSachHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Kiểm tra xem có phải là hàng hợp lệ không
            {
                DataGridViewRow row = dgvDanhSachHangHoa.Rows[e.RowIndex];

                // Đặt giá trị của ComboBox để hiển thị tên hàng hóa
                cbTenHH.SelectedValue = row.Cells["MaHH"].Value;

                // Cập nhật giá trị của NumericUpDown (nudSoLuong) từ cột Số Lượng trong DataGridView
                nudSoLuong.Value = Convert.ToDecimal(row.Cells["SoLuong"].Value);
            }
        }

        private void btnDelHH_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu có dòng nào được chọn trong DataGridView
                if (dgvDanhSachHangHoa.SelectedRows.Count > 0)
                {
                    // Lấy chỉ mục của dòng được chọn
                    int selectedIndex = dgvDanhSachHangHoa.SelectedRows[0].Index;

                    // Lấy mã HDSP của dòng đã chọn
                    int maHDSPToDelete = Convert.ToInt32(dgvDanhSachHangHoa.Rows[selectedIndex].Cells["MaHDSP"].Value);

                    // Tìm đối tượng cần xóa trong danh sách
                    var itemToRemove = danhSachHangHoaTemp.FirstOrDefault(item => item.MaHDSP == maHDSPToDelete);

                    if (itemToRemove != null)
                    {
                        // Xóa khỏi danh sách
                        danhSachHangHoaTemp.Remove(itemToRemove);
                    }

                    // Cập nhật lại MaHDSP cho các dòng còn lại
                    for (int i = 0; i < danhSachHangHoaTemp.Count; i++)
                    {
                        danhSachHangHoaTemp[i].MaHDSP = i + 1; // Gán lại giá trị MaHDSP (tạo lại thứ tự)
                    }

                    // Cập nhật lại DataGridView để phản ánh thay đổi
                    dgvDanhSachHangHoa.DataSource = null;
                    dgvDanhSachHangHoa.DataSource = danhSachHangHoaTemp;

                    // Ẩn các cột không cần thiết
                    dgvDanhSachHangHoa.Columns["MaHD"].Visible = false;
                    dgvDanhSachHangHoa.Columns["MaHH"].Visible = false;
                    dgvDanhSachHangHoa.Columns.Remove("DonViTinh");

                    // Cập nhật lại các header cột
                    dgvDanhSachHangHoa.Columns["MaHDSP"].HeaderText = "Mã HDSP";
                    dgvDanhSachHangHoa.Columns["TenHH"].HeaderText = "Tên HH";
                    dgvDanhSachHangHoa.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dgvDanhSachHangHoa.Columns["DonGia"].HeaderText = "Đơn Giá";
                    dgvDanhSachHangHoa.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hàng hóa cần xóa.");
                }

                // Tính lại tổng tiền sau khi xóa
                TinhTongTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa hàng hóa: " + ex.Message);
            }
        }
        private void LoadSanData()
        {
            // Tạo kết nối với cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    conn.Open();

                    // Truy vấn để lấy tên sân
                    string query = "SELECT MaSan, TenSan FROM San";  // Lấy mã sân và tên sân

                    // Tạo DataAdapter và DataTable để lưu trữ kết quả
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();

                    // Điền dữ liệu vào DataTable
                    da.Fill(dt);

                    // Gán dữ liệu vào DataGridView
                    dgvSan.DataSource = dt;

                    // Ẩn cột MaSan
                    dgvSan.Columns["MaSan"].Visible = false;

                    // Đặt tiêu đề cột TenSan
                    dgvSan.Columns["TenSan"].HeaderText = "Tên Sân";

                    // Căn giữa văn bản trong cột TenSan
                    dgvSan.Columns["TenSan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                    // Tự động điều chỉnh kích thước cột theo nội dung
                    dgvSan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
        private void dgvSan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có chọn vào hàng hợp lệ hay không
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dgvSan.Rows[e.RowIndex];

                // Lấy tên sân từ cột "TenSan"
                string tenSan = selectedRow.Cells["TenSan"].Value.ToString();

                // Cập nhật label hiển thị tên sân
                lbTenSan.Text = tenSan;
                // Đổi màu label khi cập nhật
                lbTenSan.ForeColor = Color.Black;
                lbTenSan.Font = new Font("Arial", 12, FontStyle.Bold);
            }
        }

        //
        private void TinhGioRa()
        {
            DateTime gioVao = dtpGioVao.Value;
            double soGioThue = (double)nudSoGioThue.Value;

            // Chuyển đổi số giờ thuê thành TimeSpan
            int hours = (int)soGioThue; // Lấy phần nguyên của giờ
            int minutes = (int)((soGioThue - hours) * 60); // Lấy phần lẻ và chuyển thành phút
            TimeSpan thoiGianThue = new TimeSpan(hours, minutes, 0);

            // Tính giờ ra
            DateTime gioRa = gioVao.Add(thoiGianThue);
            dtpGioRa.Value = gioRa;
        }

        private void TinhSoGioThue()
        {
            DateTime gioVao = dtpGioVao.Value;
            DateTime gioRa = dtpGioRa.Value;

            if (gioRa > gioVao)
            {
                // Tính số giờ thuê chính xác, không làm tròn
                TimeSpan thoiGianThue = gioRa - gioVao;
                double soGioThue = thoiGianThue.TotalHours;
                nudSoGioThue.Value = (decimal)soGioThue;
            }
            else
            {
                MessageBox.Show("Giờ ra phải lớn hơn giờ vào!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
        }

        private void TinhTienSan()
        {
            DateTime gioVao = dtpGioVao.Value;  // Giờ vào
            DateTime gioRa = dtpGioRa.Value;    // Giờ ra
            double soGioThue = (double)nudSoGioThue.Value;  // Số giờ thuê từ NumericUpDown

            // Kiểm tra giờ ra phải lớn hơn giờ vào
            if (gioRa > gioVao)
            {
                // Tính số giờ thuê chính xác
                TimeSpan thoiGianThue = gioRa - gioVao;
                soGioThue = thoiGianThue.TotalHours;  // Tính số giờ thực tế

                // Kiểm tra xem có giá trị LoaiKH hợp lệ không
                if (cbLoaiKH.SelectedValue != null)
                {
                    string loaiKH = cbLoaiKH.SelectedValue.ToString();  // Loại khách hàng (Vãng Lai, Cố Định)

                    // Kiểm tra giá trị trả về từ phương thức LayGiaSan
                    decimal giaSan = LayGiaSan(loaiKH, gioVao);  // Phương thức này sẽ truy vấn cơ sở dữ liệu

                    if (giaSan > 0)
                    {
                        // Tính tổng tiền sân
                        decimal tienSan = giaSan * (decimal)soGioThue;
                        txtGiaSan.Text = tienSan.ToString("C0", new CultureInfo("vi-VN"));  // Hiển thị tiền Việt
                    }
                }
            }
        }

        // Phương thức lấy giá sân từ cơ sở dữ liệu
        private decimal LayGiaSan(string loaiKH, DateTime gioVao)
        {
            decimal giaSan = 0;

            if (string.IsNullOrEmpty(loaiKH))
            {
                return giaSan;  // Nếu loaiKH không hợp lệ, trả về 0
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Gia FROM BangGiaSan WHERE LoaiKH = @LoaiKH AND @GioVao BETWEEN GioBatDau AND GioKetThuc";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LoaiKH", loaiKH);
                        command.Parameters.AddWithValue("@GioVao", gioVao.TimeOfDay);  // Chỉ lấy phần giờ từ GioVao

                        // Thực thi câu lệnh và lấy kết quả
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            giaSan = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn cơ sở dữ liệu: " + ex.Message);
            }

            return giaSan;
        }


        private void dtpGioVao_ValueChanged(object sender, EventArgs e)
        {
            // Tự động tính toán số giờ thuê khi thay đổi giờ vào
            TinhSoGioThue();
            TinhTienSan();
        }

        private void dtpGioRa_ValueChanged(object sender, EventArgs e)
        {
            // Tự động tính toán số giờ thuê khi thay đổi giờ ra
            TinhSoGioThue();
            TinhTienSan();
        }

        private void nudSoGioThue_ValueChanged(object sender, EventArgs e)
        {
            // Tính toán giờ ra khi thay đổi số giờ thuê
            TinhGioRa();
            TinhTienSan();
        }
        
        // Hàm tính tổng tiền cuối và hiển thị vào txtTienCuoi
        private void TinhTienCuoi()
        {
            // Tính tiền sân (đã có sẵn trong TinhTienSan)
            decimal tienSan = 0;
            if (decimal.TryParse(txtGiaSan.Text, NumberStyles.Currency, new CultureInfo("vi-VN"), out tienSan))
            {
                // Tính tiền hàng hóa (đã có sẵn trong TinhTongTien)
                decimal tongTienHangHoa = 0;
                if (decimal.TryParse(txtTongTien.Text, NumberStyles.Currency, new CultureInfo("vi-VN"), out tongTienHangHoa))
                {
                    // Tổng tiền cuối là tổng tiền sân + tiền hàng hóa
                    decimal tienCuoi = tienSan + tongTienHangHoa;

                    // Hiển thị vào txtTienCuoi
                    txtTienCuoi.Text = tienCuoi.ToString("C0", new CultureInfo("vi-VN"));
                }
            }
        }
        private void TinhTienThua()
        {
            decimal tienCuoi = 0;
            decimal khachDua = 0;

            // Kiểm tra và chuyển đổi giá trị tiền cuối
            if (decimal.TryParse(txtTienCuoi.Text, NumberStyles.Currency, new CultureInfo("vi-VN"), out tienCuoi))
            {
                // Kiểm tra và chuyển đổi giá trị tiền khách đưa, nếu chưa nhập thì giữ giá trị 0
                if (decimal.TryParse(txtKhachDua.Text, NumberStyles.Currency, new CultureInfo("vi-VN"), out khachDua))
                {
                    // Tính tiền thừa: Khách đưa - Tiền cuối
                    decimal tienThua = khachDua - tienCuoi;

                    // Nếu tiền thừa là âm, đặt lại tiền thừa về 0
                    if (tienThua < 0)
                    {
                        tienThua = 0;
                    }

                    // Hiển thị tiền thừa vào txtTienThua
                    txtTienThua.Text = tienThua.ToString("C0", new CultureInfo("vi-VN"));
                }
                else
                {
                    // Nếu chưa nhập tiền khách đưa thì đặt giá trị tiền thừa về 0
                    txtTienThua.Text = "0";
                }
            }
            else
            {
                // Nếu chưa nhập tiền cuối, đặt giá trị tiền thừa về 0
                txtTienThua.Text = "0";
            }
        }

        private void txtGiaSan_TextChanged(object sender, EventArgs e)
        {
            TinhTienCuoi();
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            TinhTienCuoi();
        }

        private void txtTienCuoi_TextChanged(object sender, EventArgs e)
        {
            TinhTienThua();
        }

        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            TinhTienThua();
        }

        private void cbLoaiKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTienSan();
        }
    }
}



