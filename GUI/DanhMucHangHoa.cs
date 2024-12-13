using BadmintonManager.BLL;
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
                var dataTable = _hangHoaBLL.GetProducts(searchTerm);
                dgvHangHoa.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
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
                MessageBox.Show("Please select a product to delete.");
                return;
            }


            var selectedRow = dgvHangHoa.SelectedRows[0];
            int maHH = Convert.ToInt32(selectedRow.Cells["MaHH"].Value);


            var confirmResult = MessageBox.Show(
                "Bạn có muốn xoá danh mục sản phẩm này?",
                "Xác nhận xoá danh mục sản phẩm",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _hangHoaBLL.DeleteProduct(maHH);
                    MessageBox.Show("Sản phẩm xoá thành công");
                    LoadTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xoá: {ex.Message}");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvHangHoa.CurrentRow != null)
            {
                // Lấy sản phẩm được chọn từ DataGridView
                int selectedProductId = (int)dgvHangHoa.CurrentRow.Cells["MaHH"].Value;
                var product = _hangHoaBLL.GetProductById(selectedProductId);

                if (product != null)
                {
                    // Mở form sửa hàng hoá
                    var editForm = new SuaHangHoa(product);
                    editForm.ShowDialog();

                    // Refresh lại danh sách sau khi sửa
                    LoadTable();
                }
            }
        }

        private void addnewLoaiHHbtn_Click(object sender, EventArgs e)
        {
            using (DanhSachLoaiHH formDanhSachLoaiHH = new DanhSachLoaiHH())
            {
                formDanhSachLoaiHH.ShowDialog(); // Open the form modally
            }
        }
    }
}
