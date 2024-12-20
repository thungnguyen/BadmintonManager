using BadmintonManager.DAL;
using BadmintonManager.DAO;
using BadmintonManager.DTO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class DanhSachLichSan : Form
    {
        //private DanhSachLichSanBAL lichSanBAL;
        //private KhachHangBLL khachHangBAL;


public delegate void LichSanSelectedHandler(ObjectId maDatSan, string maSan, string maKH, DateTime tuGio, DateTime denGio, string loaiKH, decimal daTra);

    // Event để thông báo khi một dòng được chọn
    public event LichSanSelectedHandler OnLichSanSelected;

    public DanhSachLichSan()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
        }
        void LoadDanhSach()
        {
            try
            {
                // Xóa tất cả các item hiện tại trong ListView trước khi thêm mới
                lsvDatSan.Items.Clear();

                // Lấy danh sách các lịch sân từ DAL
                List<DanhSachLichSanDTO> danhSachLichSan = DanhSachLichSanDAL.Instance.GetDanhSachLichSan();
                foreach (DanhSachLichSanDTO lichSan in danhSachLichSan)
                {
                    string tenSan = DanhSachLichSanDAL.Instance.GetTenSanById(lichSan.MaSan);
                    string tenKhachHang = DanhSachLichSanDAL.Instance.GetTenKhachHangById(lichSan.MaKH);

                    // Tạo ListViewItem và thêm các cột
                    ListViewItem item = new ListViewItem(tenSan);
                    item.SubItems.Add(tenKhachHang);
                    item.SubItems.Add(lichSan.TuNgay.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(lichSan.DenNgay.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(lichSan.TuGio);
                    item.SubItems.Add(lichSan.DenGio);
                    item.SubItems.Add(lichSan.LoaiKH);
                    item.SubItems.Add(lichSan.SoBuoi.ToString());
                    item.SubItems.Add(lichSan.CanThanhToan.ToString("N0"));
                    item.SubItems.Add(lichSan.DaTra.ToString("N0"));

                    // Gắn Tag với đối tượng DanhSachLichSanDTO
                    item.Tag = lichSan;

                    // Thêm item vào ListView
                    lsvDatSan.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnTim_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Lấy giá trị từ các control (ví dụ như TextBox, DateTimePicker)
            //    string tenKhachHang = txtTenKH.Text.Trim();  // Giả sử có TextBox để nhập tên khách hàng
            //    DateTime tuNgay = dateTimePickerTuNgay.Value;         // DateTimePicker để chọn ngày bắt đầu
            //    DateTime denNgay = dateTimePickerDenNgay.Value;       // DateTimePicker để chọn ngày kết thúc

            //    // Gọi phương thức tìm kiếm từ MongoDB
            //    var result = DanhSachLichSanDAL.Instance.TimLichSanTheoTenKH(tenKhachHang);

            //    // Lọc thêm theo khoảng thời gian nếu cần
            //    var filteredResult = result.Where(lichSan =>
            //        lichSan["tuNgay"].ToUniversalTime() >= tuNgay && lichSan["denNgay"].ToUniversalTime() <= denNgay).ToList();

            //    // Hiển thị kết quả vào ListView
            //    lsvDatSan.Items.Clear();  // Xóa các mục hiện tại trong ListView
            //    foreach (var lichSan in filteredResult)
            //    {
            //        string tenSan = lichSan["tenSan"].ToString();
            //        string tenKhach = lichSan["khachHangInfo"]["tenKH"].ToString();
            //        string tuNgayStr = lichSan["tuNgay"].ToString("dd/MM/yyyy");
            //        string denNgayStr = lichSan["denNgay"].ToString("dd/MM/yyyy");

            //        ListViewItem item = new ListViewItem(tenSan);
            //        item.SubItems.Add(tenKhach);
            //        item.SubItems.Add(tuNgayStr);
            //        item.SubItems.Add(denNgayStr);
            //        item.SubItems.Add(lichSan["tuGio"].ToString());
            //        item.SubItems.Add(lichSan["denGio"].ToString());
            //        item.SubItems.Add(lichSan["loaiKH"].ToString());
            //        item.SubItems.Add(lichSan["soBuoi"].ToString());
            //        item.SubItems.Add(lichSan["canThanhToan"].ToString("N0"));
            //        item.SubItems.Add(lichSan["daTra"].ToString("N0"));

            //        lsvDatSan.Items.Add(item);  // Thêm mục vào ListView
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        // Phương thức lấy tên khách hàng từ MaKH
        //private string GetTenKhachHangById(int maKH)
        //{
        //    // Truy vấn bảng KhachHang để lấy TenKH từ MaKH
        //    string tenKH = string.Empty;
        //    try
        //    {
        //        // Giả sử bạn có phương thức GetTenKhachHangById trong lớp KhachHangBAL
        //        tenKH = khachHangBAL.GetTenKhachHangById(maKH);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi lấy tên khách hàng: " + ex.Message);
        //    }
        //    return tenKH;
        //}

        // Sự kiện khi form được mở

private void btnTimTenKH_Click(object sender, EventArgs e)
{
    try
    {
        // Lấy tên khách hàng từ TextBox
        string tenKhachHang = txtTenKH.Text.Trim();

        // Kiểm tra nếu tên khách hàng không rỗng
        if (!string.IsNullOrEmpty(tenKhachHang))
        {
            // Tìm kiếm lịch sân theo tên khách hàng
            List<BsonDocument> result = DanhSachLichSanDAL.Instance.TimLichSanTheoTenKH(tenKhachHang);

            // Kiểm tra nếu có kết quả tìm kiếm
            if (result.Count > 0)
            {
                // Xóa các mục cũ trong ListView
                lsvDatSan.Items.Clear();

                // Duyệt qua các kết quả và thêm vào ListView
                foreach (var lichSan in result)
                {
                    // Tạo một ListViewItem và thêm thông tin
                    ListViewItem item = new ListViewItem(lichSan["tenSan"].ToString());
                    item.SubItems.Add(lichSan["khachHangInfo"]["tenKH"].ToString());

                    // Định dạng ngày giờ
                    item.SubItems.Add(lichSan["tuNgay"].ToUniversalTime().ToLocalTime().ToString("dd/MM/yyyy"));
                    item.SubItems.Add(lichSan["denNgay"].ToUniversalTime().ToLocalTime().ToString("dd/MM/yyyy"));
                    item.SubItems.Add(lichSan["tuGio"].ToString());
                    item.SubItems.Add(lichSan["denGio"].ToString());

                    // Chuyển đổi các giá trị thành chuỗi và định dạng
                    item.SubItems.Add(lichSan["loaiKH"].ToString());
                    item.SubItems.Add(lichSan["soBuoi"].ToString());
                    item.SubItems.Add(Convert.ToDecimal(lichSan["canThanhToan"]).ToString("N0"));
                    item.SubItems.Add(Convert.ToDecimal(lichSan["daTra"]).ToString("N0"));

                    // Thêm item vào ListView
                    lsvDatSan.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy lịch sân cho khách hàng: " + tenKhachHang, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            MessageBox.Show("Vui lòng nhập tên khách hàng để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
        // Sự kiện khi nhấn nút Hủy lịch
        private void btnHuyLich_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    // Lấy mã đặt sân từ cột trong DataGridView
            //    string maDatSan = dataGridView1.SelectedRows[0].Cells["maDatSanDataGridViewTextBoxColumn"].Value?.ToString();
            //    if (int.TryParse(maDatSan, out int maDatSanInt))
            //    {
            //        // Lấy dữ liệu chi tiết của lịch đã chọn từ DataGridView
            //        DataRow selectedRow = ((DataRowView)dataGridView1.SelectedRows[0].DataBoundItem).Row;

            //        // Lấy ngày TuNgay từ dòng được chọn
            //        DateTime tuNgay = Convert.ToDateTime(selectedRow["TuNgay"]);

            //        // Kiểm tra xem thời gian hủy có còn trong vòng 2 ngày trước TuNgay không
            //        if ((tuNgay - DateTime.Now).TotalDays < 2)
            //        {
            //            MessageBox.Show("Quá thời gian để hủy lịch. Phải hủy ít nhất 2 ngày trước thời gian đặt sân.");
            //            return;
            //        }

            //        // Nếu điều kiện hủy hợp lệ, tạo đối tượng PhieuChiDTO
            //        PhieuChiDTO phieuChiDTO = new PhieuChiDTO
            //        {
            //            MaDatSan = maDatSanInt,
            //            MaSan = Convert.ToString(selectedRow["MaSan"]),
            //            MaKH = Convert.ToString(selectedRow["MaKH"]),
            //            TuNgay = tuNgay,
            //            DaTra = Convert.ToString(selectedRow["DaTra"])
            //        };

            //        // Mở Form Phieu Chi và truyền đối tượng vào
            //        PhieuChi phieuChi = new PhieuChi(phieuChiDTO);
            //        phieuChi.ShowDialog();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn một dòng để hủy.");
            //}
        }
        // Sự kiện khi nhấn nút Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Gọi lại phương thức LoadData để tải lại toàn bộ dữ liệu
            //LoadData();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn trong ListView
            if (lsvDatSan.SelectedItems.Count > 0)
            {
                try
                {
                    // Lấy dòng được chọn
                    ListViewItem selectedItem = lsvDatSan.SelectedItems[0];

                    // Lấy đối tượng DanhSachLichSanDTO từ Tag của item
                    DanhSachLichSanDTO lichSan = (DanhSachLichSanDTO)selectedItem.Tag;

                    if (lichSan != null)
                    {
                        // Chuyển đổi các giá trị cần thiết
                        DateTime tuGio = DateTime.Parse(lichSan.TuGio); // Chuyển đổi từ string sang DateTime
                        DateTime denGio = DateTime.Parse(lichSan.DenGio);

                        // Gọi delegate để truyền thông tin từ dòng được chọn
                        OnLichSanSelected?.Invoke(
                            lichSan.Id,           // ObjectId
                            lichSan.MaSan,        // string
                            lichSan.MaKH,         // string
                            tuGio,                // DateTime
                            denGio,               // DateTime
                            lichSan.LoaiKH,       // string
                            lichSan.DaTra         // decimal
                        );

                        // Đóng form sau khi xử lý
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trước khi tiếp tục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
