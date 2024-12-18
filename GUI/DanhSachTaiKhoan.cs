using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BadmintonManager.DTO;
using BadmintonManager.BAL;

namespace BadmintonManager.GUI
{
    public partial class DanhSachTaiKhoan : Form
    {
        private TaiKhoanBAL taiKhoanBAL = new TaiKhoanBAL();

        public DanhSachTaiKhoan()
        {
            InitializeComponent();
        }

        private void DanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<TaiKhoanNhanVienDTO> accounts = taiKhoanBAL.GetAllAccounts();
                dgvTaiKhoanmoi.DataSource = accounts.Select(account => new
                {
                    account.MaNV,
                    account.TenNV,
                    account.TenDangNhap,
                    account.MatKhau,
                    account.SDT,
                    account.VaiTro,
                }).ToList();

                //if (dgvTaiKhoanmoi.Columns["VaiTro"] != null)
                //{
                //    dgvTaiKhoanmoi.Columns["VaiTro"].Visible = false;
                //}

                if (dgvTaiKhoanmoi.Columns["MaNV"] != null)
                {
                    dgvTaiKhoanmoi.Columns["MaNV"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu không được để trống
                if (string.IsNullOrEmpty(txtTenNV.Text) || string.IsNullOrEmpty(txtTenDangNhap.Text) ||
                    string.IsNullOrEmpty(txtMatKhau.Text) || string.IsNullOrEmpty(txtSDT.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm.");
                    return;
                }

                // Tạo đối tượng DTO từ dữ liệu trong TextBox
                TaiKhoanNhanVienDTO taiKhoanMoi = new TaiKhoanNhanVienDTO
                {
                    TenNV = txtTenNV.Text.Trim(),
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    VaiTro = "Nhân viên", // Mặc định vai trò
                    SDT = txtSDT.Text.Trim()
                };

                // Gọi BAL để thêm tài khoản
                taiKhoanBAL.AddAccount(taiKhoanMoi);

                // Thông báo và làm mới dữ liệu
                MessageBox.Show("Thêm tài khoản thành công!");
                LoadData();

                // Xóa thông tin trong TextBox sau khi thêm
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message);
            }
        }


        // Phương thức gọi lại khi sự kiện DataUpdated được gọi
        private void FormDangKy_DataUpdated(object sender, EventArgs e)
        {
            LoadData(); // Làm mới dữ liệu sau khi thêm tài khoản
        }

        private void dgvTaiKhoanmoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không phải header
            {
                DataGridViewRow row = dgvTaiKhoanmoi.Rows[e.RowIndex];

                // Lấy dữ liệu từ TenDangNhap để tìm tài khoản
                string tenDangNhap = row.Cells["TenDangNhap"].Value?.ToString();

                if (!string.IsNullOrEmpty(tenDangNhap))
                {
                    // Hiển thị dữ liệu lên các TextBox
                    txtTenNV.Text = row.Cells["TenNV"].Value?.ToString();
                    txtTenDangNhap.Text = tenDangNhap;
                    txtMatKhau.Text = row.Cells["MatKhau"].Value?.ToString();
                    txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                }
                else
                {
                    MessageBox.Show("Không thể lấy dữ liệu Tên Đăng Nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private bool isEditing = false; // Biến trạng thái để theo dõi chế độ chỉnh sửa

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isEditing) // Khi bấm nút lần đầu để hiển thị thông tin
                {
                    if (dgvTaiKhoanmoi.SelectedRows.Count == 1)
                    {
                        DataGridViewRow selectedRow = dgvTaiKhoanmoi.SelectedRows[0];

                        // Lấy thông tin từ hàng được chọn
                        txtTenNV.Text = selectedRow.Cells["TenNV"].Value.ToString();
                        txtTenDangNhap.Text = selectedRow.Cells["TenDangNhap"].Value.ToString();
                        txtMatKhau.Text = selectedRow.Cells["MatKhau"].Value.ToString();
                        txtSDT.Text = selectedRow.Cells["SDT"].Value.ToString();

                        // Chuyển sang chế độ chỉnh sửa
                        isEditing = true;
                        btnSua.Text = "Lưu";
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn một tài khoản để sửa.");
                    }
                }
                else // Khi bấm nút lần thứ hai để lưu thay đổi
                {
                    if (string.IsNullOrEmpty(txtTenNV.Text) || string.IsNullOrEmpty(txtTenDangNhap.Text) ||
                        string.IsNullOrEmpty(txtMatKhau.Text) || string.IsNullOrEmpty(txtSDT.Text))
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi lưu.");
                        return;
                    }

                    // Lấy MaNV từ hàng đang được chọn
                    int maNV = Convert.ToInt32(dgvTaiKhoanmoi.SelectedRows[0].Cells["MaNV"].Value);

                    // Tạo đối tượng DTO từ dữ liệu trong TextBox
                    TaiKhoanNhanVienDTO taiKhoan = new TaiKhoanNhanVienDTO
                    {
                        MaNV = maNV,
                        TenNV = txtTenNV.Text.Trim(),
                        TenDangNhap = txtTenDangNhap.Text.Trim(),
                        MatKhau = txtMatKhau.Text.Trim(),
                        SDT = txtSDT.Text.Trim(),
                        VaiTro = "Nhân viên" // Hoặc lấy từ dữ liệu nếu cần
                    };

                    // Gọi phương thức BAL để cập nhật
                    taiKhoanBAL.UpdateAccount(taiKhoan);

                    // Hiển thị thông báo và làm mới dữ liệu
                    MessageBox.Show("Cập nhật thành công!");
                    LoadData();

                    // Đặt lại trạng thái và nút
                    isEditing = false;
                    btnSua.Text = "Sửa";

                    // Xóa thông tin trong TextBox
                    ClearTextBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Hàm xóa thông tin trong các TextBox
        private void ClearTextBoxes()
        {
            txtTenNV.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtSDT.Clear();
        }




        // Phương thức sự kiện cho nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTaiKhoanmoi.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvTaiKhoanmoi.SelectedRows)
                    {
                        int maNV = Convert.ToInt32(row.Cells["MaNV"].Value);
                        taiKhoanBAL.DeleteAccount(maNV);
                    }
                    MessageBox.Show("Xóa thành công!");
                    LoadData(); // Tải lại dữ liệu
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn tài khoản cần xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message);
            }
        }
    }
}
