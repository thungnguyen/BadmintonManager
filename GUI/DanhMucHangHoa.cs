using BadmintonManager.BLL;
using BadmintonManager.DTO;
using System;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class DanhMucHangHoa : Form
    {
        private HangHoaBLL _hangHoaBLL;

        public DanhMucHangHoa()
        {
            InitializeComponent();
            _hangHoaBLL = new HangHoaBLL();
            LoadTable();
        }


        private void LoadTable(string searchTerm = null)
        {
            try
            {
                // Lấy danh sách hàng hóa từ BLL
                var hangHoaList = _hangHoaBLL.HangHoaList(searchTerm);

                // Kiểm tra nếu danh sách trống
                if (hangHoaList == null || hangHoaList.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu hàng hóa để hiển thị.");
                    dgvHangHoa.DataSource = null;
                    return;
                }

                // Gắn danh sách vào DataGridView
                dgvHangHoa.DataSource = hangHoaList;

                // Ẩn các cột không cần thiết (nếu cần)
                dgvHangHoa.Columns["_id"].Visible = false;

                // Cập nhật tiêu đề cột cho thân thiện hơn
                dgvHangHoa.Columns["MaHH"].HeaderText = "Mã Hàng Hóa";
                dgvHangHoa.Columns["TenHH"].HeaderText = "Tên Hàng Hóa";
                dgvHangHoa.Columns["MoTa"].HeaderText = "Mô Tả";
                dgvHangHoa.Columns["DonViTinhLon"].HeaderText = "Đơn Vị Tính Lớn";
                dgvHangHoa.Columns["DonViTinhNho"].HeaderText = "Đơn Vị Tính Nhỏ";
                dgvHangHoa.Columns["HeSoQuyDoi"].HeaderText = "Hệ Số Quy Đổi";
                dgvHangHoa.Columns["GiaNhapLon"].HeaderText = "Giá Nhập Lớn";
                dgvHangHoa.Columns["GiaNhapNho"].HeaderText = "Giá Nhập Nhỏ";
                dgvHangHoa.Columns["GiaBanLon"].HeaderText = "Giá Bán Lớn";
                dgvHangHoa.Columns["GiaBanNho"].HeaderText = "Giá Bán Nhỏ";
                dgvHangHoa.Columns["SoLuongTonLon"].HeaderText = "SL Tồn Lớn";
                dgvHangHoa.Columns["SoLuongTonNho"].HeaderText = "SL Tồn Nhỏ";
                dgvHangHoa.Columns["MaLoaiHH"].HeaderText = "Mã Loại Hàng Hóa";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            //using (var addForm = new ThemHangHoa())
            //{
            //    var result = addForm.ShowDialog();

            //    if (result == DialogResult.OK)
            //    {
            //        LoadTable();
            //    }
            //}
        }


        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = searchbar.Text.Trim();
            LoadTable(searchTerm); // Pass the search term to filter results
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgvHangHoa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng hóa để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy _id của hàng hóa được chọn
            string selectedId = dgvHangHoa.SelectedRows[0].Cells["_id"].Value.ToString();

            // Xác nhận trước khi xóa
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng hóa này không?",
                                                "Xác nhận xóa",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // Gọi BLL để xóa
                    var hangHoaBLL = new HangHoaBLL();
                    hangHoaBLL.XoaHH(selectedId);

                    // Thông báo xóa thành công
                    MessageBox.Show("Xóa hàng hóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật lại danh sách hàng hóa
                    LoadTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi xóa hàng hóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if (dgvHangHoa.CurrentRow != null)
            //{
            //    // Lấy sản phẩm được chọn từ DataGridView
            //    int selectedProductId = (int)dgvHangHoa.CurrentRow.Cells["MaHH"].Value;
            //    var product = _hangHoaBLL.GetProductById(selectedProductId);

            //    if (product != null)
            //    {
            //        // Mở form sửa hàng hoá
            //        var editForm = new SuaHangHoa(product);
            //        editForm.ShowDialog();

            //        // Refresh lại danh sách sau khi sửa
            //        LoadTable();
            //    }
            //}
        }

        private void addnewLoaiHHbtn_Click(object sender, EventArgs e)
        {
            //using (DanhSachLoaiHH formDanhSachLoaiHH = new DanhSachLoaiHH())
            //{
            //    formDanhSachLoaiHH.ShowDialog(); // Open the form modally
            //}
        }
    }
}
