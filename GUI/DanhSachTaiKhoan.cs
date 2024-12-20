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
                    account.Id,       // Thêm Id vào đây
                    account.MaNV,
                    account.TenNV,
                    account.TenDangNhap,
                    account.MatKhau,
                    account.VaiTro,
                    account.SDT
                }).ToList();

                // Ẩn các cột không cần thiết
                if (dgvTaiKhoanmoi.Columns["Id"] != null)
                {
                    dgvTaiKhoanmoi.Columns["Id"].Visible = false;
                }
                if (dgvTaiKhoanmoi.Columns["VaiTro"] != null)
                {
                    dgvTaiKhoanmoi.Columns["VaiTro"].Visible = false;
                }
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
        // Phương thức sự kiện cho nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu nhập
                if (string.IsNullOrEmpty(txtTenNV.Text) ||
                    string.IsNullOrEmpty(txtTenDangNhap.Text) ||
                    string.IsNullOrEmpty(txtMatKhau.Text) ||
                    string.IsNullOrEmpty(txtSDT.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm.");
                    return;
                }

                // Kiểm tra trùng tên đăng nhập
                var allAccounts = taiKhoanBAL.GetAllAccounts();
                if (allAccounts.Any(acc => acc.TenDangNhap == txtTenDangNhap.Text.Trim()))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng tài khoản mới
                var newAccount = new TaiKhoanNhanVienDTO
                {
                    TenNV = txtTenNV.Text.Trim(),
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    SDT = txtSDT.Text.Trim(),
                    VaiTro = "Nhân viên" // Hoặc vai trò tùy chọn
                };

                // Thêm tài khoản vào database
                bool isAdded = taiKhoanBAL.AddTaiKhoan(newAccount);
                if (isAdded)
                {
                    MessageBox.Show("Thêm tài khoản thành công!");
                    LoadData(); // Cập nhật lại bảng
                    ClearTextBoxes(); // Xóa thông tin trong TextBox sau khi thêm
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private string currentAccountId; // Thêm biến này ở đầu class

        private void dgvTaiKhoanmoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoanmoi.Rows[e.RowIndex];

                string tenDangNhap = row.Cells["TenDangNhap"].Value?.ToString();

                if (!string.IsNullOrEmpty(tenDangNhap))
                {
                    // Lưu thông tin của tài khoản đang được chọn
                    currentAccountId = row.Cells["Id"]?.Value?.ToString(); // Thêm dòng này
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
                if (!isEditing)
                {
                    if (dgvTaiKhoanmoi.SelectedRows.Count == 1)
                    {
                        DataGridViewRow selectedRow = dgvTaiKhoanmoi.SelectedRows[0];

                        // Lưu thông tin của tài khoản đang được sửa
                        currentAccountId = selectedRow.Cells["Id"].Value.ToString();
                        txtTenNV.Text = selectedRow.Cells["TenNV"].Value.ToString();
                        txtTenDangNhap.Text = selectedRow.Cells["TenDangNhap"].Value.ToString();
                        txtMatKhau.Text = selectedRow.Cells["MatKhau"].Value.ToString();
                        txtSDT.Text = selectedRow.Cells["SDT"].Value.ToString();

                        isEditing = true;
                        btnSua.Text = "Lưu";
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn một tài khoản để sửa.");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtTenNV.Text) || string.IsNullOrEmpty(txtTenDangNhap.Text) ||
                        string.IsNullOrEmpty(txtMatKhau.Text) || string.IsNullOrEmpty(txtSDT.Text))
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi lưu.");
                        return;
                    }

                    int maNV = Convert.ToInt32(dgvTaiKhoanmoi.SelectedRows[0].Cells["MaNV"].Value);
                    string newTenDangNhap = txtTenDangNhap.Text.Trim();

                    // Kiểm tra tên đăng nhập trùng
                    if (taiKhoanBAL.IsTenDangNhapExists(newTenDangNhap, maNV))
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại! Vui lòng chọn tên đăng nhập khác.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    TaiKhoanNhanVienDTO taiKhoan = new TaiKhoanNhanVienDTO
                    {
                        Id = currentAccountId,  // Thêm Id vào đây
                        MaNV = maNV,
                        TenNV = txtTenNV.Text.Trim(),
                        TenDangNhap = newTenDangNhap,
                        MatKhau = txtMatKhau.Text.Trim(),
                        SDT = txtSDT.Text.Trim(),
                        VaiTro = "Nhân viên"
                    };

                    if (taiKhoanBAL.UpdateAccount(taiKhoan))
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        LoadData();

                        isEditing = false;
                        btnSua.Text = "Sửa";
                        ClearTextBoxes();
                        currentAccountId = null; // Reset currentAccountId
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
