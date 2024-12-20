//using BadmintonManager.BAL;
//using BadmintonManager.DTO;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace BadmintonManager.GUI
//{
//    public partial class DanhSachLoaiHH : Form
//    {
//        private LoaiHHBLL _loaiHHBLL;
//        public DanhSachLoaiHH()
//        {
//            InitializeComponent();
//            _loaiHHBLL = new LoaiHHBLL();
//        }

//        private void DanhSachLoaiHH_Load(object sender, EventArgs e)
//        {
//            // TODO: This line of code loads data into the 'quanLySanDataSet.LoaiHH' table. You can move, or remove it, as needed.
//            this.loaiHHTableAdapter.Fill(this.quanLySanDataSet.LoaiHH);

//        }
//        private void LoadCategories()
//        {
//            try
//            {
//                // Call the BLL to get all categories and bind them to the DataGridView
//                dgvLoaiHH.DataSource = _loaiHHBLL.GetAllCategories();

//                // Optionally, adjust the column names and formatting if necessary
//                dgvLoaiHH.Columns["MaLoaiHH"].HeaderText = "Mã Loại HH";
//                dgvLoaiHH.Columns["TenLoaiHH"].HeaderText = "Tên Loại HH";
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Đã xảy ra lỗi khi tải danh sách loại hàng hoá: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void savebtn_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                // Validate input
//                if (string.IsNullOrWhiteSpace(maloaiHHtxt.Text))
//                {
//                    MessageBox.Show("Mã Loại HH không được để trống!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                if (!int.TryParse(maloaiHHtxt.Text.Trim(), out int maLoaiHH) || maLoaiHH <= 0)
//                {
//                    MessageBox.Show("Mã Loại HH phải là số dương.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                if (string.IsNullOrWhiteSpace(tenloaiHHtxt.Text))
//                {
//                    MessageBox.Show("Tên Loại HH không được để trống!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                // Check if MaLoaiHH already exists
//                if (_loaiHHBLL.IsCategoryExists(maLoaiHH)) // Add this method in your BLL
//                {
//                    MessageBox.Show("Mã Loại HH đã tồn tại!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                // Create a new category
//                LoaiHHDTO category = new LoaiHHDTO
//                {
//                    MaLoaiHH = maLoaiHH,
//                    TenLoaiHH = tenloaiHHtxt.Text.Trim()
//                };

//                // Add the category
//                _loaiHHBLL.AddCategory(category);

//                MessageBox.Show("Loại hàng hoá mới đã được thêm thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

//                // Refresh DataGridView
//                LoadCategories(); // Implement this method to reload the data
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Đã xảy ra lỗi khi thêm loại hàng hoá: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void cancelbtn_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }

//        private void deletebtn_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (!int.TryParse(maloaiHHtxt.Text.Trim(), out int maLoaiHH) || maLoaiHH <= 0)
//                {
//                    MessageBox.Show("Vui lòng chọn một loại hàng hoá để xoá!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                // Confirm deletion
//                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá loại hàng hoá này?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//                if (result == DialogResult.Yes)
//                {
//                    _loaiHHBLL.DeleteCategory(maLoaiHH); // Implement this method in BLL

//                    MessageBox.Show("Loại hàng hoá đã được xoá thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

//                    // Refresh DataGridView
//                    LoadCategories(); // Implement this method to reload the data
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Đã xảy ra lỗi khi xoá loại hàng hoá: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void editbtn_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (!int.TryParse(maloaiHHtxt.Text.Trim(), out int maLoaiHH) || maLoaiHH <= 0)
//                {
//                    MessageBox.Show("Mã Loại HH phải là số dương.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                if (string.IsNullOrWhiteSpace(tenloaiHHtxt.Text))
//                {
//                    MessageBox.Show("Tên Loại HH không được để trống!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                LoaiHHDTO updatedCategory = new LoaiHHDTO
//                {
//                    MaLoaiHH = maLoaiHH,
//                    TenLoaiHH = tenloaiHHtxt.Text.Trim()
//                };

//                //_loaiHHBLL.UpdateCategory(updatedCategory); // Implement this method in BLL

//                MessageBox.Show("Loại hàng hoá đã được cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

//                // Refresh DataGridView
//                LoadCategories(); // Implement this method to reload the data
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Đã xảy ra lỗi khi cập nhật loại hàng hoá: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void dgvLoaiHH_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex >= 0) 
//            {
//                DataGridViewRow row = dgvLoaiHH.Rows[e.RowIndex];
//                maloaiHHtxt.Text = row.Cells["MaLoaiHH"].Value.ToString();
//                tenloaiHHtxt.Text = row.Cells["TenLoaiHH"].Value.ToString();
//            }
//        }
//    }
//   }

