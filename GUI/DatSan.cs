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
using BadmintonManager.BAL;
using BadmintonManager.DAL;
using BadmintonManager.DTO;
using MongoDB.Bson;
using MongoDB.Driver;



namespace BadmintonManager.GUI
{
    public partial class DatSan : Form
    {
        private readonly LichDatSanBAL lichDatSanBAL;
        private readonly LichDatSanBAL _bal;
        private bool isUpdating = false;
        private readonly GiaSanBAL giaSanBAL;
        private SanBAL sanBAL;
        private KhachHangBAL khachHangBAL;
        public DatSan()
        {
            InitializeComponent();

            dtpTuGio.ValueChanged += dtpTuGio_ValueChanged;
            dtpDenGio.ValueChanged += dtpDenGio_ValueChanged;
            dgvDanhSachNgay.Columns.Clear();
            dgvDanhSachNgay.Columns.Add("colNgayDat", "Ngày Đặt");

            sanBAL = new SanBAL();
            khachHangBAL = new KhachHangBAL();
            giaSanBAL = new GiaSanBAL(); // Đảm bảo khởi tạo đúng
            lichDatSanBAL = new LichDatSanBAL();
            _bal = new LichDatSanBAL();
            SetupInitialControls(); 
        }


        private void DatSan_Load(object sender, EventArgs e)
        {
            LoadKH();
            LoadSan();
        }

        private void SetupInitialControls()
        {
            // Initialize DataGridView columns
            if (!dgvDanhSachNgay.Columns.Contains("colNgayDat"))
            {
                dgvDanhSachNgay.Columns.Add("colNgayDat", "Ngày đặt");
            }

            // Set default values for date time pickers
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;
            dtpTuGio.Value = DateTime.Today.AddHours(8); // 8:00 AM default
            dtpDenGio.Value = DateTime.Today.AddHours(10); // 10:00 AM default
            dtpThoiGian.Value = DateTime.Today;

            //// Initialize numeric fields
            //txtBuoi.Text = "1";
            //txtLayGia.Text = "0";
            //txtThanhToan.Text = "0";
            //txtDaTra.Text = "0";
            //txtConLai.Text = "0";
        }
        //private void cbbKhachHang_DropDown(object sender, EventArgs e)
        //{
        //    // Tạo đối tượng KhachHangDAL để truy vấn dữ liệu
        //    KhachHangDAL dbHelper = new KhachHangDAL();
        //    List<KhachHangDTO> khachHangs = dbHelper.GetKhachHangList();

        //    // Xóa danh sách cũ trong ComboBox
        //    cbbKhachHang.Items.Clear();

        //    // Thiết lập ValueMember và DisplayMember
        //    cbbKhachHang.ValueMember = "Id"; // Sử dụng ObjectId làm giá trị chính
        //    cbbKhachHang.DisplayMember = "TenKH"; // Hiển thị tên khách hàng

        //    // Thêm khách hàng vào ComboBox
        //    foreach (KhachHangDTO khachHang in khachHangs)
        //    {
        //        cbbKhachHang.Items.Add(new { Id = khachHang.Id, TenKH = khachHang.TenKH });
        //    }

        //}

        

        private void LoadKH()
        {
            KhachHangDAL dbHelper = new KhachHangDAL();
            var khachHangs = dbHelper.GetKhachHangList();

            cbbKhachHang.Items.Clear();

            foreach (var item in khachHangs)
            {
                var kh = new KeyValuePair<string, string>(item.Id, item.TenKH);
                cbbKhachHang.Items.Add(kh);
            }
        }

        private void LoadSan()
        {
            SanBAL dbHelper = new SanBAL();
            var sans = dbHelper.GetAllSans();

            cbbTenSan.Items.Clear();
            foreach (var item in sans)
            {
                var san = new KeyValuePair<string, string>(item.Id, item.TenSan);
                cbbTenSan.Items.Add(san);
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
        private void UpdateDuration()
        {
            // Tính sự chênh lệch giữa 2 thời gian
            TimeSpan duration = dtpDenGio.Value - dtpTuGio.Value;

            // Cập nhật giá trị của dtpThoiGian với thời gian chênh lệch
            dtpThoiGian.Value = dtpThoiGian.Value.Date.Add(duration); // Đảm bảo thời gian có đúng ngày
        }



        private void CapNhatSoBuoi()
        {
            // Đếm số dòng trong DataGridView nhưng bỏ qua dòng trống (nếu có)
            int soNgay = dgvDanhSachNgay.Rows.Cast<DataGridViewRow>()
                                         .Count(row => !row.IsNewRow && row.Cells[0].Value != null);
            // Hiển thị số ngày vào txtBuoi
            txtBuoi.Text = soNgay.ToString();
        }

        private void btnDatLich_Click(object sender, EventArgs e)
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
                if (checkBox2.Checked) thuDuocChon.Add(DayOfWeek.Monday);
                if (checkBox3.Checked) thuDuocChon.Add(DayOfWeek.Tuesday);
                if (checkBox4.Checked) thuDuocChon.Add(DayOfWeek.Wednesday);
                if (checkBox5.Checked) thuDuocChon.Add(DayOfWeek.Thursday);
                if (checkBox6.Checked) thuDuocChon.Add(DayOfWeek.Friday);
                if (checkBox7.Checked) thuDuocChon.Add(DayOfWeek.Saturday);
                if (checkBoxCN.Checked) thuDuocChon.Add(DayOfWeek.Sunday);

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
                dgvDanhSachNgay.Rows.Clear();
                foreach (var ngay in cacNgayDat)
                {
                    dgvDanhSachNgay.Rows.Add(ngay.ToString("dd/MM/yyyy"));
                }

                MessageBox.Show("Danh sách ngày cố định đã được cập nhật.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Nếu không phải khách cố định, chỉ đặt một ngày duy nhất
                dgvDanhSachNgay.Rows.Clear();
                dgvDanhSachNgay.Rows.Add(tuNgay.ToString("dd/MM/yyyy"));
                MessageBox.Show("Đã đặt lịch cho khách vãng lai.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CapNhatSoBuoi();

            // Tính giá tiền dựa vào thời gian
            decimal gia = giaSanBAL.TinhGia(cbLoaiKhach.Checked, dtpTuGio.Value.TimeOfDay, dtpDenGio.Value.TimeOfDay);
            txtLayGia.Text = gia.ToString("#,0");

            decimal soBuoi = Convert.ToDecimal(txtBuoi.Text);
            decimal thanhToan = soBuoi * gia;
            txtThanhToan.Text = thanhToan.ToString("#,0");

            decimal daTra;
            if (!decimal.TryParse(txtDaTra.Text, out daTra))
            {
                MessageBox.Show("Vui lòng nhập số tiền đã trả hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal conLai = thanhToan - daTra;
            txtConLai.Text = conLai.ToString("#,0");
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

            decimal thanhToan = 0;
            if (!decimal.TryParse(txtThanhToan.Text, out thanhToan))
            {
                MessageBox.Show("Không thể đọc giá trị thanh toán. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (soTienThu > thanhToan)
            {
                MessageBox.Show("Số tiền nhập vào không thể lớn hơn số tiền cần thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

           
            txtSoTien.Text = soTienThu.ToString("#,0"); 

            decimal daTra = 0;
            if (!decimal.TryParse(txtDaTra.Text, out daTra))
            {
                daTra = 0; 
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



        // Trong form (button4_Click)
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs() == false)
                {
                    return;
                }

                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;
                TimeSpan tuGio = dtpTuGio.Value.TimeOfDay;
                TimeSpan denGio = dtpDenGio.Value.TimeOfDay;

                if (tuGio >= denGio)
                {
                    MessageBox.Show("Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                KeyValuePair<string, string> selectedSan = (KeyValuePair<string, string>)cbbTenSan.SelectedItem;

                List<DateTime> ngayDat = new List<DateTime>();
                for (DateTime date = tuNgay; date <= denNgay; date = date.AddDays(1))
                {
                    ngayDat.Add(date.Date);
                }

                var lichDatSanDTO = new LichDatSanDTO
                {
                    MaSan = selectedSan.Key,
                    NgayDat = ngayDat,
                    TuGio = tuGio,
                    DenGio = denGio
                };

                var (isTrungLich, ngayTrung, thoiGianTrung) = _bal.CheckTrungLich(lichDatSanDTO);

                if (isTrungLich)
                {
                    var message = new System.Text.StringBuilder();
                    message.AppendLine($"Phát hiện trùng lịch tại sân: {selectedSan.Value}");
                    message.AppendLine("\nChi tiết các ngày trùng lịch:");

                    for (int i = 0; i < ngayTrung.Count; i++)
                    {
                        message.AppendLine($"- Ngày {ngayTrung[i].ToString("dd/MM/yyyy")}");
                        message.AppendLine($"  Thời gian trùng: {thoiGianTrung[i]}");
                    }

                    message.AppendLine("\nVui lòng chọn thời gian khác!");

                    MessageBox.Show(message.ToString(),
                        "Cảnh báo trùng lịch",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Không có lịch trùng, bạn có thể tiếp tục đặt sân!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi kiểm tra lịch: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs() == false)
                    return;

                var lichDatSanDTO = CreateLichDatSanDTO();

           

                // Lưu lịch đặt sân
                if (_bal.SaveLichDatSan(lichDatSanDTO))
                {
                    MessageBox.Show("Lưu lịch đặt sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowScheduleCheckResult(bool isLichTrung)
        {
            if (isLichTrung)
            {
                MessageBox.Show(
                    "Lịch đã bị trùng. Vui lòng chọn lại giờ!",
                    "Lỗi trùng lịch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                MessageBox.Show(
                    "Không có lịch trùng. Tiếp tục đặt sân.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void ClearForm()
        {
            cbbTenSan.SelectedIndex = -1;
            cbbKhachHang.SelectedIndex = -1;
            dgvDanhSachNgay.Rows.Clear();
            txtBuoi.Text = "1";
            txtLayGia.Text = "0";
            txtThanhToan.Text = "0";
            txtDaTra.Text = "0";
            txtConLai.Text = "0";
            cbLoaiKhach.Checked = false;
            SetupInitialControls();
        }

        private bool ValidateInputs()
        {
            if (cbbTenSan.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sân trước khi kiểm tra!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            KeyValuePair<string, string> selectedSan = (KeyValuePair<string, string>)cbbTenSan.SelectedItem;
            if (string.IsNullOrEmpty(selectedSan.Key))
            {
                MessageBox.Show("Không thể lấy thông tin sân, vui lòng thử lại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private List<DateTime> GetSelectedDates()
        {
            var dates = new List<DateTime>();
            foreach (DataGridViewRow row in dgvDanhSachNgay.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    dates.Add(DateTime.Parse(row.Cells[0].Value.ToString()));
                }
            }
            return dates;
        }

        private LichDatSanDTO CreateLichDatSanDTO()
        {

            KeyValuePair<string, string> selectedSan = (KeyValuePair<string, string>)cbbTenSan.SelectedItem;
            KeyValuePair<string, string> selectedKH = (KeyValuePair<string, string>)cbbKhachHang.SelectedItem;

            return new LichDatSanDTO
            {
                MaSan = selectedSan.Key, // Lấy Key từ KeyValuePair
                MaKH = selectedKH.Key,   // Lấy Key từ KeyValuePair
                TuNgay = dtpTuNgay.Value,
                DenNgay = dtpDenNgay.Value,
                TuGio = dtpTuGio.Value.TimeOfDay,
                DenGio = dtpDenGio.Value.TimeOfDay,
                LoaiKH = cbLoaiKhach.Checked ? "Co dinh" : "Vang lai",
                SoBuoi = int.Parse(txtBuoi.Text),
                LayGia = decimal.Parse(txtLayGia.Text),
                CanThanhToan = decimal.Parse(txtThanhToan.Text),
                DaTra = decimal.Parse(txtDaTra.Text),
                ConLai = decimal.Parse(txtConLai.Text),
                ThoiGian = dtpThoiGian.Value.TimeOfDay,
                NgayDat = GetSelectedDates()
            };
        }

        private void btnThemKhach_Click(object sender, EventArgs e)
        {
            AddKhachHang themKH = new AddKhachHang();
            themKH.Show();
        }

  
    }
}
