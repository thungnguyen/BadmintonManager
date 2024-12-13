using BadmintonManager.BLL;
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
    public partial class ThemLoaiHH : Form
    {
        private LoaiHHBLL _loaiHHBLL;

        public ThemLoaiHH()
        {
            InitializeComponent();
            _loaiHHBLL = new LoaiHHBLL();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    // Validate input
                    if (string.IsNullOrWhiteSpace(maLoaiHHtxt.Text))
                    {
                        MessageBox.Show("Mã Loại HH không được để trống!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!int.TryParse(maLoaiHHtxt.Text.Trim(), out int maLoaiHH) || maLoaiHH <= 0)
                    {
                        MessageBox.Show("Mã Loại HH phải là số dương.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(tenLoaiHHtxt.Text))
                    {
                        MessageBox.Show("Tên Loại HH không được để trống!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Create a new category
                    LoaiHH category = new LoaiHH
                    {
                        MaLoaiHH = maLoaiHH,
                        TenLoaiHH = tenLoaiHHtxt.Text.Trim()
                    };

                    // Add the category
                    _loaiHHBLL.AddCategory(category);

                    MessageBox.Show("Loại hàng hoá mới đã được thêm thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Close the form
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi thêm loại hàng hoá: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
