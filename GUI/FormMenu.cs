using System;
using System.Drawing;
using System.Windows.Forms;
using BadmintonManager.Theme;


namespace BadmintonManager.GUI
{
    public partial class FormMenu : Form
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        //Constructor
        public FormMenu()
        {
            InitializeComponent();
            random = new Random();
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //ThemeColor.PrimaryColor = color;
                    //ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }


        private void button3_Click(object sender, EventArgs e)//btnTaiKhoan
        {
            OpenChildForm(new GUI.DanhSachTaiKhoan(), sender);
        }

        private void btnLichSan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUI.DatSan(), sender);
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUI.DanhMucHangHoa(), sender);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUI.DanhSachTaiKhoan(), sender);
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUI.DanhSachTaiKhoan(), sender);
        }

        private void btnQuanLySan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUI.DatSan(), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME"; // Cập nhật tiêu đề mặc định
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;

            // Chỉ ẩn nút khi không có form con
            if (activeForm == null)
            {
                btnCloseChildForm.Visible = false;
            }
            else
            {
                btnCloseChildForm.Visible = true;
            }
        }


        private void btnThietLapSan_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new GUI.ThietLapSan(), sender);
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new GUI.FrmTinhTien(), sender);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            //// Đóng form hiện tại
            //this.Hide();

            //// Mở form đăng nhập
            //DangNhap formDangNhap = new DangNhap();
            //    formDangNhap.Show();

        }
    }
}
