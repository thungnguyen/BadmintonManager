using BadmintonManager.BLL;
using BadmintonManager.DAL;
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
    public partial class TaoHangHoa : Form
    {
        private HangHoaBLL _hangHoaBLL;
        private LoaiHHBLL _loaiHHBLL;
        public TaoHangHoa()
        {
            InitializeComponent();
            _loaiHHBLL = new LoaiHHBLL();
            _hangHoaBLL = new HangHoaBLL();
            LoadLoaiHH();
        }

        private void LoadLoaiHH()
        {
            // Giả sử bạn có phương thức trong lớp BAL để lấy danh sách các loại hàng hoá
            var loaiHHList = _loaiHHBLL.LoaiHHList();
            LoaiHHcmb.DataSource = loaiHHList;
            LoaiHHcmb.DisplayMember = "TenLoaiHH"; 
            LoaiHHcmb.ValueMember = "_id"; 
        }

        private void SoLuongTonLontxt_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(SoLuongTonLontxt.Text, out int soLuongTonLon))
            {
                // Kiểm tra xem giá trị HeSoQuyDoi đã được nhập vào chưa
                if (int.TryParse(HeSoQuyDoitxt.Text, out int heSoQuyDoi))
                {
                    // Tính toán giá trị SoLuongTonNho
                    int soLuongTonNho = soLuongTonLon * heSoQuyDoi;

                    // Cập nhật giá trị cho ô SoLuongTonNho
                    SoLuongTonNhotxt.Text = soLuongTonNho.ToString();
                }
                else
                {
                    // Nếu giá trị HeSoQuyDoi không hợp lệ, bạn có thể thông báo lỗi hoặc để ô SoLuongTonNho trống
                    SoLuongTonNhotxt.Text = string.Empty;
                }
            }
            else
            {
                // Nếu giá trị SoLuongTonLon không hợp lệ, bạn có thể đặt lại giá trị SoLuongTonNho hoặc thông báo lỗi
                SoLuongTonNhotxt.Text = string.Empty;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tenHHtxt.Text) || string.IsNullOrEmpty(motatxt.Text) ||
                string.IsNullOrEmpty(DonViTinhLontxt.Text) || string.IsNullOrEmpty(DonViTinhNhotxt.Text) ||
                string.IsNullOrEmpty(HeSoQuyDoitxt.Text) || string.IsNullOrEmpty(GiaNhapLontxt.Text) ||
                string.IsNullOrEmpty(GiaNhapNhotxt.Text) || string.IsNullOrEmpty(GiaBanLontxt.Text) ||
                string.IsNullOrEmpty(GiaBanNhotxt.Text) || string.IsNullOrEmpty(SoLuongTonLontxt.Text) ||
                string.IsNullOrEmpty(SoLuongTonNhotxt.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            try
            {
                var hangHoa = new HangHoa
                {
                    TenHH = tenHHtxt.Text,
                    MoTa = motatxt.Text,
                    DonViTinhLon = DonViTinhLontxt.Text,
                    DonViTinhNho = DonViTinhNhotxt.Text,
                    HeSoQuyDoi = int.Parse(HeSoQuyDoitxt.Text),
                    GiaNhapLon = decimal.Parse(GiaNhapLontxt.Text),
                    GiaNhapNho = decimal.Parse(GiaNhapNhotxt.Text),
                    GiaBanLon = decimal.Parse(GiaBanLontxt.Text),
                    GiaBanNho = decimal.Parse(GiaBanNhotxt.Text),
                    SoLuongTonLon = int.Parse(SoLuongTonLontxt.Text),
                    SoLuongTonNho = int.Parse(SoLuongTonNhotxt.Text),
                    MaLoaiHH = (string)LoaiHHcmb.SelectedValue
                };

                // Gọi lớp BAL để thêm hàng hoá vào database
                _hangHoaBLL.ThemHH(hangHoa);
                MessageBox.Show("Thêm hàng hoá thành công.");
                this.Close(); // Đóng form sau khi thêm thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
