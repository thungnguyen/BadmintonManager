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
            lsvGiaSan.Items.Clear();

            // Lấy danh sách các giá sân từ MongoDB thông qua phương thức GetListGiaSan
            List<BangGiaSanDTO> listGiaSan = BangGiaSanDAO.Instance.GetListGiaSan();

            // Duyệt qua các đối tượng BangGiaSanDTO và hiển thị chúng trong ListView
            foreach (BangGiaSanDTO item in listGiaSan)
            {
                // Tạo ListViewItem mới từ dữ liệu trong DTO
                ListViewItem lsvItem = new ListViewItem(item.MaGia.ToString());  // Hiển thị MaGia
                lsvItem.SubItems.Add(item.LoaiKH);  // Hiển thị LoaiKH
                lsvItem.SubItems.Add(item.Gia.ToString());  // Hiển thị Gia, định dạng tiền tệ
                lsvItem.SubItems.Add(item.GioBatDau.ToString());  // Hiển thị GioBatDau
                lsvItem.SubItems.Add(item.GioKetThuc.ToString());  // Hiển thị GioKetThuc
                // Thêm item vào ListView
                lsvGiaSan.Items.Add(lsvItem);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            int maGia = Convert.ToInt32(txtMaGia.Text.Trim());  // Lấy mã giá từ TextBox và chuyển thành kiểu int
            string loaiKH = txtLoaiKH.Text;  // Lấy loại khách hàng từ TextBox

            // Lấy giá từ TextBox và kiểm tra hợp lệ
            decimal gia = decimal.Parse(txtGia.Text);

            // Lấy giá trị từ DateTimePicker
            DateTime gioBatDau = dtpBegin.Value;
            DateTime gioKetThuc = dtpEnd.Value;

            // Kiểm tra giờ bắt đầu và giờ kết thúc có hợp lệ hay không (giờ bắt đầu phải trước giờ kết thúc)
            TimeSpan timeSpanBatDau = gioBatDau.TimeOfDay;
            TimeSpan timeSpanKetThuc = gioKetThuc.TimeOfDay;

            // Gọi phương thức InsertGiaSan trong DAO để thêm dữ liệu vào bảng
            try
            {
                BangGiaSanDAO.Instance.InsertGiaSan(maGia, loaiKH, timeSpanBatDau, timeSpanKetThuc, gia);

                // Tải lại dữ liệu hoặc làm mới giao diện nếu cần thiết
                LoadListGiaSan();  // Gọi phương thức để tải lại dữ liệu từ MongoDB
            }
            catch (Exception ex)
            {
                // In ra lỗi nếu có
                MessageBox.Show("Đã xảy ra lỗi khi thêm giá sân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lsvGiaSan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvGiaSan.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsvGiaSan.SelectedItems[0];

                string maGia = selectedItem.SubItems[0].Text;
                string loaiKH = selectedItem.SubItems[1].Text;
                string giaStr = selectedItem.SubItems[2].Text;
                string gioBatDauStr = selectedItem.SubItems[3].Text;
                string gioKetThucStr = selectedItem.SubItems[4].Text;

                // Ép kiểu trực tiếp mà không kiểm tra
                TimeSpan gioBatDau = TimeSpan.Parse(gioBatDauStr);
                TimeSpan gioKetThuc = TimeSpan.Parse(gioKetThucStr);

                // Gán giá trị vào các ô nhập liệu
                txtMaGia.Text = maGia;
                txtLoaiKH.Text = loaiKH;

                // Dùng DateTime.Today để thiết lập giá trị DateTimePicker
                dtpBegin.Value = DateTime.Today.Add(gioBatDau);
                dtpEnd.Value = DateTime.Today.Add(gioKetThuc);

                txtGia.Text = giaStr.ToString();  // Định dạng giá thành tiền tệ
                txtMaGia.Enabled = false;
            }
            else
            {
                txtLoaiKH.Clear();
                txtGia.Clear();
                dtpBegin.Value = DateTime.Now;
                dtpEnd.Value = DateTime.Now;
                txtMaGia.Clear();
                txtMaGia.Enabled = true;
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
            if (lsvGiaSan.SelectedItems.Count > 0)
            {
                int maGia = int.Parse(lsvGiaSan.SelectedItems[0].SubItems[0].Text);
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa giá sân này?", "Xóa giá sân", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    BangGiaSanDAO.Instance.DeleteGiaSan(maGia);
                    LoadListGiaSan();
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
