using BadmintonManager.BLL;
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
            LoadLoaiHH();
        }

        private void LoadLoaiHH()
        {
            // Giả sử bạn có phương thức trong lớp BAL để lấy danh sách các loại hàng hoá
            var loaiHHList = _loaiHHBLL.GetLoaiHHList();
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

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
