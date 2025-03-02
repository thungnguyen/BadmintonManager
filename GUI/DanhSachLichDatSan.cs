using BadmintonManager.BAL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class DanhSachLichDatSan : Form
    {
        private readonly SanBAL _sanBAL;
        private readonly LichDatSanBAL _lichDatSanBAL;
        public DanhSachLichDatSan()
        {
            InitializeComponent();
            _sanBAL = new SanBAL();
            _lichDatSanBAL = new LichDatSanBAL();
            Load += DanhSachLichDatSan_Load;
        }

        private void DanhSachLichDatSan_Load(object sender, EventArgs e)
        {
            // Khởi tạo giao diện
            dtpNgayChon.Value = DateTime.Now;
            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Lấy danh sách sân
                List<SanDTO> danhSachSan = _sanBAL.GetAllSans();

                // Lấy danh sách lịch đặt sân theo ngày
                DateTime ngayChon = dtpNgayChon.Value.Date;
                List<LichDatSanDTO> danhSachLichDat = _lichDatSanBAL.GetLichDatSanByDate(ngayChon);

                // Tạo bảng hiển thị
                DataTable table = CreateScheduleTable(danhSachSan, danhSachLichDat);

                // Gắn dữ liệu vào DataGridView
                dgvLichDatSan.DataSource = table;

                // Định dạng DataGridView
                FormatGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable CreateScheduleTable(List<SanDTO> danhSachSan, List<LichDatSanDTO> danhSachLichDat)
        {
            DataTable table = new DataTable();

            // Thêm cột đầu tiên: Thời gian
            table.Columns.Add("Thời gian", typeof(string));

            // Thêm cột cho từng sân
            foreach (var san in danhSachSan)
            {
                table.Columns.Add(san.TenSan, typeof(string));
            }

            // Tạo hàng thời gian (5:00 - 24:00)
            for (TimeSpan time = new TimeSpan(5, 0, 0); time < new TimeSpan(24, 0, 0); time += TimeSpan.FromMinutes(30))
            {
                DataRow row = table.NewRow();
                row["Thời gian"] = time.ToString(@"hh\:mm");

                // Điền trạng thái lịch đặt
                foreach (var san in danhSachSan)
                {
                    var lich = danhSachLichDat.FirstOrDefault(x =>
                        int.TryParse(x.MaSan, out var maSan) && maSan == san.MaSan &&
                        x.NgayDat.Contains(dtpNgayChon.Value.Date) &&
                        (time >= x.TuGio && time < x.DenGio));

                    row[san.TenSan] = lich != null ? "Đang đặt" : "Trống";
                }

                table.Rows.Add(row);
            }

            return table;
        }

        private void FormatGridView()
        {
            dgvLichDatSan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichDatSan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLichDatSan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLichDatSan.DefaultCellStyle.BackColor = Color.White;
            dgvLichDatSan.DefaultCellStyle.ForeColor = Color.Black;
            dgvLichDatSan.EnableHeadersVisualStyles = false;
        }
    }
}
