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
                // Fetch products, optionally filtered by search term
                var dataTable = _hangHoaBLL.HangHoaList(searchTerm);
                dgvHangHoa.DataSource = dataTable;
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"Gặp lỗi khi lấy hàng hoá: {ex.Message}");
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            using (var addForm = new ThemHangHoa())
            {
                var result = addForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadTable();
                }
            }
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
            if (dgvHangHoa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn một sản phẩm để xoá.");
                return;
            }

            // Get the selected row
            var selectedRow = dgvHangHoa.SelectedRows[0];
            var maHH = selectedRow.Cells["MaHH"].Value?.ToString();

            if (string.IsNullOrEmpty(maHH))
            {
                MessageBox.Show("Không thể xác định mã sản phẩm để xoá.");
                return;
            }

            // Confirm deletion
            var confirmResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xoá sản phẩm này?",
                "Xác nhận xoá",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _hangHoaBLL.XoaHH(new HangHoa { MaHH = maHH });
                    MessageBox.Show("Sản phẩm đã được xoá thành công.");
                    LoadTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xoá sản phẩm: {ex.Message}");
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
