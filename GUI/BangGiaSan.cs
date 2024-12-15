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
    public partial class BangGiaSan : Form
    {
        public BangGiaSan()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.BangGiaSan_Load);
        }
        private void BangGiaSan_Load(object sender, EventArgs e)
        {
            LoadListGiaSan();
        }
        private void LoadListGiaSan()
        {
            lsvGiaSan.Items.Clear();  // Xóa tất cả các mục hiện tại trong ListView
            List<DTO.BangGiaSan> listSan = BangGiaSanDAO.Instance.GetListGiaSan();  // Lấy danh sách sân

            foreach (DTO.BangGiaSan item in listSan)
            {
                ListViewItem lsvItem = new ListViewItem(item.MaGia.ToString());  // Thêm mã sân vào cột đầu tiên
                lsvItem.SubItems.Add(item.LoaiKH.ToString());  // Thêm tên sân vào cột thứ hai
                lsvItem.SubItems.Add(item.Gia.ToString());  // Thêm giá sân vào cột thứ ba
                lsvItem.SubItems.Add(item.GioBatDau.ToString());  // Thêm giờ bắt đầu vào cột thứ tư
                lsvItem.SubItems.Add(item.GioKetThuc.ToString());  // Thêm giờ kết thúc vào cột thứ năm
                lsvGiaSan.Items.Add(lsvItem);  // Thêm ListViewItem vào ListView
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string loaiKH = txtLoaiKH.Text; // Lấy loại khách hàng từ TextBox
            decimal gia = Convert.ToDecimal(txtGia.Text); // Lấy giá từ TextBox
            DateTime gioBatDau = dtpBegin.Value;  // Lấy giá trị DateTime từ dtpBegin
            DateTime gioKetThuc = dtpEnd.Value;  // Lấy giá trị DateTime từ dtpEnd

            // Chuyển đổi sang TimeSpan (chỉ lấy phần giờ và phút)
            TimeSpan timeSpanBatDau = gioBatDau.TimeOfDay;
            TimeSpan timeSpanKetThuc = gioKetThuc.TimeOfDay;

            // Gọi phương thức InsertGiaSan trong DAO để thêm dữ liệu vào bảng
            BangGiaSanDAO.Instance.InsertGiaSan(loaiKH, timeSpanBatDau, timeSpanKetThuc, gia);

            MessageBox.Show("Giá sân đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Tải lại dữ liệu hoặc làm mới giao diện nếu cần thiết
            LoadListGiaSan();

        }

        private void lsvGiaSan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn trong ListView
            if (lsvGiaSan.SelectedItems.Count > 0)
            {
                // Lấy mục đầu tiên của dòng được chọn (vì chỉ có một dòng được chọn tại một thời điểm)
                ListViewItem selectedItem = lsvGiaSan.SelectedItems[0];

                // Lấy giá trị từ các cột của dòng được chọn và gán vào các ô nhập liệu (TextBox)
                string loaiKH = selectedItem.SubItems[1].Text;  // Cột Loại KH
                DateTime gioBatDau = DateTime.Parse(selectedItem.SubItems[3].Text);  // Cột Giờ Bắt Đầu
                DateTime gioKetThuc = DateTime.Parse(selectedItem.SubItems[4].Text);  // Cột Giờ Kết Thúc
                decimal gia = decimal.Parse(selectedItem.SubItems[2].Text);  // Cột Giá

                // Gán các giá trị này vào các TextBox hoặc DateTimePicker tương ứng
                txtLoaiKH.Text = loaiKH;
                dtpBegin.Value = gioBatDau;
                dtpEnd.Value = gioKetThuc;
                txtGia.Text = gia.ToString("N0");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lsvGiaSan.SelectedItems.Count > 0)
            {
                // Lấy mã giá từ dòng được chọn
                int maGia = int.Parse(lsvGiaSan.SelectedItems[0].SubItems[0].Text); // Giả sử MaGia là cột đầu tiên

                string loaiKH = txtLoaiKH.Text;
                DateTime gioBatDau = dtpBegin.Value;
                DateTime gioKetThuc = dtpEnd.Value;
                decimal gia = decimal.Parse(txtGia.Text);

                // Gọi phương thức update để cập nhật giá trị vào cơ sở dữ liệu
                BangGiaSanDAO.Instance.UpdateGiaSan(maGia, loaiKH, gioBatDau.TimeOfDay, gioKetThuc.TimeOfDay, gia);

                // Tải lại dữ liệu vào ListView
                LoadListGiaSan();

                MessageBox.Show("Cập nhật giá sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn giá để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn trong ListView
            if (lsvGiaSan.SelectedItems.Count > 0)
            {
                // Lấy mã giá từ dòng được chọn
                int maGia = int.Parse(lsvGiaSan.SelectedItems[0].SubItems[0].Text); // Giả sử MaGia là cột đầu tiên

                // Hiển thị hộp thoại xác nhận
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa giá sân này?", "Xóa giá sân", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Nếu người dùng chọn Yes, thực hiện xóa
                if (dialogResult == DialogResult.Yes)
                {
                    BangGiaSanDAO.Instance.DeleteGiaSan(maGia);  // Gọi phương thức xóa giá sân
                    LoadListGiaSan();  // Tải lại dữ liệu vào ListView sau khi xóa
                    MessageBox.Show("Xóa giá sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn giá để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
