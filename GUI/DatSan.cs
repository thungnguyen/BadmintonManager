using qlycaulong.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using BadmintonManager.Database;


namespace BadmintonManager.GUI
{
    public partial class DatSan : Form
    {
        public DatSan()
        {
            InitializeComponent();
            cbbKhachHang.DropDown += cbbKhachHang_DropDown;
            cbbTenSan.DropDown += cbbTenSan_DropDown;
            dtpTuGio.ValueChanged += dtpTuGio_ValueChanged;
            dtpDenGio.ValueChanged += dtpDenGio_ValueChanged;
            dgvDanhSachNgay.Columns.Clear();
            dgvDanhSachNgay.Columns.Add("colNgayDat", "Ngày Đặt");

        }


        private void cbbKhachHang_DropDown(object sender, EventArgs e)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            List<KhachHang> khachHangs = dbHelper.GetKhachHangList();

            cbbKhachHang.Items.Clear(); // Xóa các mục cũ

            foreach (KhachHang khachHang in khachHangs)
            {
                cbbKhachHang.Items.Add(khachHang.TenKH); // Hiển thị tên khách hàng
            }
        }

        private void cbbTenSan_DropDown(object sender, EventArgs e)
        {
            try
            {
                SanDatabaseHelper dbHelper = new SanDatabaseHelper();
                List<San> sans = dbHelper.GetSanList(); // Lấy danh sách sân từ database

                cbbTenSan.Items.Clear(); // Xóa các mục cũ

                foreach (San san in sans)
                {
                    cbbTenSan.Items.Add(san.TenSan); // Hiển thị tên sân
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        // Hàm làm tròn thời gian về giờ tròn hoặc 30 phút
        private DateTime RoundToNearestHalfHour(DateTime dt)
        {
            int minutes = dt.Minute;

            // Nếu phút nhỏ hơn 15, làm tròn xuống 00 phút
            if (minutes < 15)
                minutes = 0;
            // Nếu phút từ 15 đến 45, làm tròn xuống 30 phút
            else if (minutes < 45)
                minutes = 30;
            // Nếu phút lớn hơn hoặc bằng 45, làm tròn lên 00 phút và tăng giờ
            else
            {
                minutes = 0;
                dt = dt.AddHours(1);
            }

            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, minutes, 0);
        }

        // Sự kiện khi thay đổi giá trị trong DateTimePicker Từ giờ
        // Hàm xử lý khi giá trị của dtpTuGio thay đổi
        private void dtpTuGio_ValueChanged(object sender, EventArgs e)
        {
            // Làm tròn thời gian của dtpTuGio
            dtpTuGio.Value = RoundToNearestHalfHour(dtpTuGio.Value);

            // Kiểm tra nếu dtpDenGio nhỏ hơn dtpTuGio, điều chỉnh lại giá trị của dtpDenGio
            if (dtpDenGio.Value < dtpTuGio.Value)
            {
                dtpDenGio.Value = dtpTuGio.Value; // Đặt lại Đến giờ về Từ giờ nếu nhỏ hơn
            }

            // Cập nhật thời gian chênh lệch
            UpdateDuration();
        }


        // Sự kiện khi thay đổi giá trị trong DateTimePicker Đến giờ
        // Hàm xử lý khi giá trị của dtpDenGio thay đổi
        private void dtpDenGio_ValueChanged(object sender, EventArgs e)
        {
            // Nếu thời gian Đến giờ nhỏ hơn Từ giờ, thông báo lỗi hoặc tự động chỉnh sửa
            if (dtpDenGio.Value < dtpTuGio.Value)
            {
                // Thông báo lỗi
                MessageBox.Show("Thời gian 'Đến giờ' không thể nhỏ hơn 'Từ giờ'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Đặt lại giá trị của dtpDenGio về giá trị của dtpTuGio
                dtpDenGio.Value = dtpTuGio.Value;
            }
            else
            {
                // Nếu không có vấn đề gì, làm tròn thời gian và cập nhật thời gian chênh lệch
                dtpDenGio.Value = RoundToNearestHalfHour(dtpDenGio.Value);
                UpdateDuration(); // Cập nhật thời gian chênh lệch
            }
        }


        // Cập nhật thời gian chênh lệch giữa 2 DateTimePicker (dtpDenGio - dtpTuGio)
        // Cập nhật thời gian chênh lệch giữa 2 DateTimePicker
        private void UpdateDuration()
        {
            // Tính sự chênh lệch giữa 2 thời gian
            TimeSpan duration = dtpDenGio.Value - dtpTuGio.Value;

            // Cập nhật giá trị của dtpThoiGian với thời gian chênh lệch
            dtpThoiGian.Value = dtpThoiGian.Value.Date.Add(duration); // Đảm bảo thời gian có đúng ngày
        }



        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void DatSan_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void cbbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CapNhatSoBuoi()
        {
            // Đếm số dòng trong DataGridView nhưng bỏ qua dòng trống (nếu có)
            int soNgay = dgvDanhSachNgay.Rows.Cast<DataGridViewRow>()
                                         .Count(row => !row.IsNewRow && row.Cells[0].Value != null);

            // Hiển thị số ngày vào txtBuoi
            txtBuoi.Text = soNgay.ToString();
        }


        private decimal TinhGia()
        {
            try
            {
                // Lấy thông tin từ giao diện
                TimeSpan gioBatDau = dtpTuGio.Value.TimeOfDay;
                TimeSpan gioKetThuc = dtpDenGio.Value.TimeOfDay;
                string loaiKhach = cbLoaiKhach.Checked ? "Co dinh" : "Vang lai";

                // Lấy chuỗi kết nối từ app.config
                string connectionString = ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

                // Kết nối cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Truy vấn bảng BangGiaSan để lấy giá cho trước và sau 17 giờ
                    string query = @"
                SELECT GioBatDau, GioKetThuc, Gia 
                FROM BangGiaSan 
                WHERE LoaiKH = @LoaiKhach 
                ORDER BY GioBatDau";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số cho truy vấn
                        cmd.Parameters.AddWithValue("@LoaiKhach", loaiKhach);

                        // Thực thi truy vấn
                        SqlDataReader reader = cmd.ExecuteReader();

                        decimal totalGia = 0;
                        decimal giaTruoc17 = 0, giaSau17 = 0;

                        // Duyệt qua tất cả các khung giờ và lấy giá
                        while (reader.Read())
                        {
                            TimeSpan gioBatDauBang = reader.GetTimeSpan(0);
                            TimeSpan gioKetThucBang = reader.GetTimeSpan(1);
                            decimal giaTheoGio = reader.GetDecimal(2);

                            // Kiểm tra và lấy giá trước 17 giờ
                            if (gioKetThucBang <= new TimeSpan(17, 0, 0) && gioBatDauBang < new TimeSpan(17, 0, 0))
                            {
                                giaTruoc17 = giaTheoGio;
                            }

                            // Kiểm tra và lấy giá sau 17 giờ
                            if (gioBatDauBang >= new TimeSpan(17, 0, 0) && gioKetThucBang >= new TimeSpan(17, 0, 0))
                            {
                                giaSau17 = giaTheoGio;
                            }
                        }

                        // Nếu thời gian thuê kéo dài qua 17 giờ (ví dụ 16h - 18h)
                        if (gioBatDau < new TimeSpan(17, 0, 0) && gioKetThuc > new TimeSpan(17, 0, 0))
                        {
                            // Tính thời gian trước 17h (từ gioBatDau đến 17h)
                            decimal soGioTruoc17 = (decimal)(new TimeSpan(17, 0, 0) - gioBatDau).TotalHours;

                            // Tính thời gian sau 17h (từ 17h đến gioKetThuc)
                            decimal soGioSau17 = (decimal)(gioKetThuc - new TimeSpan(17, 0, 0)).TotalHours;

                            // Tính giá tổng
                            totalGia = (giaTruoc17 * soGioTruoc17) + (giaSau17 * soGioSau17);
                        }
                        // Nếu thời gian thuê hoàn toàn trước 17 giờ (ví dụ 16h - 17h)
                        else if (gioKetThuc <= new TimeSpan(17, 0, 0))
                        {
                            decimal soGioTruoc17 = (decimal)(gioKetThuc - gioBatDau).TotalHours;
                            totalGia = giaTruoc17 * soGioTruoc17;
                        }
                        // Nếu thời gian thuê hoàn toàn sau 17 giờ (ví dụ 17h - 18h)
                        else if (gioBatDau >= new TimeSpan(17, 0, 0))
                        {
                            decimal soGioSau17 = (decimal)(gioKetThuc - gioBatDau).TotalHours;
                            totalGia = giaSau17 * soGioSau17;
                        }

                        if (totalGia == 0)
                        {
                            MessageBox.Show("Không tìm thấy giá phù hợp cho khung giờ này!", "Thông báo");
                            return 0;
                        }

                        return totalGia;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính giá: " + ex.Message, "Lỗi");
                return 0;
            }
        }





        private void btnDatLich_Click(object sender, EventArgs e)
        {
            {
                // Lấy khoảng thời gian từ DateTimePicker
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                // Kiểm tra khoảng thời gian hợp lệ
                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Nếu khách cố định (cbLoaiKhach được chọn)
                if (cbLoaiKhach.Checked)
                {
                    // Danh sách các thứ được chọn
                    List<DayOfWeek> thuDuocChon = new List<DayOfWeek>();
                    if (checkBox2.Checked) thuDuocChon.Add(DayOfWeek.Monday);    // Thứ 2
                    if (checkBox3.Checked) thuDuocChon.Add(DayOfWeek.Tuesday);   // Thứ 3
                    if (checkBox4.Checked) thuDuocChon.Add(DayOfWeek.Wednesday); // Thứ 4
                    if (checkBox5.Checked) thuDuocChon.Add(DayOfWeek.Thursday);  // Thứ 5
                    if (checkBox6.Checked) thuDuocChon.Add(DayOfWeek.Friday);    // Thứ 6
                    if (checkBox7.Checked) thuDuocChon.Add(DayOfWeek.Saturday);  // Thứ 7
                    if (checkBoxCN.Checked) thuDuocChon.Add(DayOfWeek.Sunday);   // Chủ nhật

                    // Kiểm tra xem có chọn ít nhất một thứ không
                    if (thuDuocChon.Count == 0)
                    {
                        MessageBox.Show("Vui lòng chọn ít nhất một thứ trong tuần.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lấy danh sách các ngày trong khoảng thời gian phù hợp với các thứ được chọn
                    List<DateTime> cacNgayDat = new List<DateTime>();
                    for (DateTime date = tuNgay; date <= denNgay; date = date.AddDays(1))
                    {
                        if (thuDuocChon.Contains(date.DayOfWeek))
                        {
                            cacNgayDat.Add(date);
                        }
                    }

                    // Nếu không có ngày phù hợp, thông báo lỗi
                    if (cacNgayDat.Count == 0)
                    {
                        MessageBox.Show("Không có ngày nào trong khoảng thời gian phù hợp với các thứ được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Hiển thị danh sách các ngày được đặt vào DataGridView
                    dgvDanhSachNgay.Rows.Clear(); // Xóa dữ liệu cũ
                    foreach (var ngay in cacNgayDat)
                    {
                        dgvDanhSachNgay.Rows.Add(ngay.ToString("dd/MM/yyyy")); // Thêm ngày vào DataGridView
                    }

                    MessageBox.Show("Danh sách ngày cố định đã được cập nhật.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Nếu không phải khách cố định, chỉ đặt một ngày duy nhất
                    dgvDanhSachNgay.Rows.Clear(); // Xóa dữ liệu cũ
                    dgvDanhSachNgay.Rows.Add(tuNgay.ToString("dd/MM/yyyy")); // Chỉ thêm ngày bắt đầu
                    MessageBox.Show("Đã đặt lịch cho khách vãng lai.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            CapNhatSoBuoi();
            // Gọi hàm tính giá và hiển thị lên txtLayGia
            decimal gia = TinhGia();
            txtLayGia.Text = gia.ToString("#,0");

            decimal soBuoi = Convert.ToDecimal(txtBuoi.Text);  // Số buổi đã được tính từ dgvDanhSachNgay

            // Tính tổng số tiền thanh toán
            decimal thanhToan = soBuoi * gia;


            // Hiển thị kết quả vào txtThanhToan
            txtThanhToan.Text = thanhToan.ToString("#,0");


            // Lấy giá trị đã trả từ txtDaTra
            decimal daTra = 0;
            if (!decimal.TryParse(txtDaTra.Text, out daTra))
            {
                MessageBox.Show("Vui lòng nhập số tiền đã trả hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tính số tiền còn lại
            decimal conLai = thanhToan - daTra;

            // Hiển thị kết quả vào txtConLai
            txtConLai.Text = conLai.ToString("#,0");

        }

        private void txtBuoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLayGia_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnThuTien_Click(object sender, EventArgs e)
        {
            // Lấy giá trị còn lại từ txtConLai
            decimal conLai = 0;
            if (!decimal.TryParse(txtConLai.Text, out conLai) || conLai < 0)
            {
                MessageBox.Show("Số tiền còn lại không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra nếu số tiền còn lại <= 0
            if (conLai <= 0)
            {
                MessageBox.Show("Đã thu đủ số tiền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Dừng lại nếu đã thu đủ tiền
            }

            // Kiểm tra nếu hình thức thanh toán chưa được chọn
            if (cbHinhThuc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn hình thức thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu không chọn hình thức thanh toán
            }

            // Lấy giá trị số tiền nhập từ txtSoTien
            decimal soTienThu = 0;
            if (!decimal.TryParse(txtSoTien.Text, out soTienThu) || soTienThu < 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra nếu số tiền nhập vào lớn hơn số tiền cần thanh toán
            decimal thanhToan = 0;
            if (!decimal.TryParse(txtThanhToan.Text, out thanhToan))
            {
                MessageBox.Show("Không thể đọc giá trị thanh toán. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (soTienThu > thanhToan)
            {
                MessageBox.Show("Số tiền nhập vào không thể lớn hơn số tiền cần thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng lại nếu số tiền nhập vào lớn hơn số tiền cần thanh toán
            }

            // Làm tròn và định dạng số tiền theo kiểu tiền tệ
            txtSoTien.Text = soTienThu.ToString("#,0");  // Định dạng với dấu chấm phân cách nhóm ba chữ số

            // Lấy giá trị đã trả trước đó từ txtDaTra
            decimal daTra = 0;
            if (!decimal.TryParse(txtDaTra.Text, out daTra))
            {
                daTra = 0; // Nếu chưa có giá trị, mặc định là 0
            }

            // Cộng thêm số tiền vừa thu vào tổng số tiền đã trả
            daTra += soTienThu;

            // Cập nhật giá trị mới vào txtDaTra
            txtDaTra.Text = daTra.ToString("#,0");

            // Tính số tiền còn lại
            decimal conLaiMoi = thanhToan - daTra;

            // Cập nhật giá trị vào txtConLai
            txtConLai.Text = conLaiMoi.ToString("#,0");

            // Cập nhật thông tin vào txtGhiChu (lựa chọn hình thức thanh toán)
            string hinhThucThanhToan = cbHinhThuc.SelectedItem.ToString(); // Lấy giá trị lựa chọn từ ComboBox
            txtGhiChu.Text = hinhThucThanhToan;

            // Thông báo thành công
            MessageBox.Show("Thu tiền thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void dgvDanhSachNgay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
