using BadmintonManager.DAO;
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
    public partial class TaoSan : Form
    {
        public TaoSan()
        {
            InitializeComponent();
        }
       

        private void LoadData()
        {
            lsvSan.Items.Clear();  // Xóa tất cả các mục hiện tại trong ListView
            List<San> listSan = SanDAO.Instance.LoadSanList();  // Lấy danh sách sân

            foreach (DTO.San item in listSan)
            {
                ListViewItem lsvItem = new ListViewItem(item.MaSan.ToString());  // Thêm mã sân vào cột đầu tiên
                lsvItem.SubItems.Add(item.TenSan.ToString());  // Thêm tên sân vào cột thứ hai
                lsvItem.SubItems.Add(item.Status.ToString());  // Thêm trạng thái sân vào cột thứ ba

                // Thêm ListViewItem vào ListView
                lsvSan.Items.Add(lsvItem);
            }
        }
        private void DeleteSan(int maSan)
        {
            SanDAO.Instance.DeleteSan(maSan);
            MessageBox.Show("Xóa sân thành công!");
        }
        private void UpdateSan(int maSan, string tenSan)
        {
            SanDAO.Instance.UpdateSan(maSan, tenSan);
            MessageBox.Show("Cập nhật sân thành công!");
        }
        private void lsvSan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSan.SelectedItems.Count > 0)
            {
                // Lấy MaSan và TenSan của mục được chọn
                int maSan = int.Parse(lsvSan.SelectedItems[0].SubItems[0].Text);
                string tenSan = lsvSan.SelectedItems[0].SubItems[1].Text;

                // Hiển thị tên sân vào TextBox
                txtTenSan.Text = tenSan;
            }
            else
            {
                txtTenSan.Clear(); // Xóa text nếu không có mục nào được chọn
            }
        }

        private void TaoSan_Load(object sender, EventArgs e)
        {
            LoadData(); // Tải dữ liệu lên DataGridView khi form khởi động
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string tenSan = txtTenSan.Text;
            if (tenSan == "")
            {
                MessageBox.Show("Vui lòng nhập tên sân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SanDAO.Instance.InsertSan(tenSan);
            MessageBox.Show("Thêm sân thành công!");
            LoadData(); // Tải lại dữ liệu vào ListView
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lsvSan.SelectedItems.Count > 0)
            {
                int maSan = int.Parse(lsvSan.SelectedItems[0].SubItems[0].Text);
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sân này?", "Xóa sân", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    DeleteSan(maSan);  // Gọi phương thức xóa sân
                    LoadData();  // Tải lại dữ liệu vào ListView sau khi xóa
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sân để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lsvSan.SelectedItems.Count > 0)
            {
                int maSan = int.Parse(lsvSan.SelectedItems[0].SubItems[0].Text);
                string tenSan = txtTenSan.Text.Trim();

                if (!string.IsNullOrEmpty(tenSan))
                {
                    UpdateSan(maSan, tenSan);  // Gọi phương thức cập nhật sân
                    LoadData();  // Tải lại dữ liệu vào ListView sau khi cập nhật
                }
                else
                {
                    MessageBox.Show("Tên sân không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sân để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrices_Click(object sender, EventArgs e)
        {
            BangGiaSan bangGiaSanForm = new BangGiaSan();
            bangGiaSanForm.ShowDialog();
        }
    }
}
