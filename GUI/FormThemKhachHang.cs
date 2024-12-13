using System;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class FormThemKhachHang : Form
    {
        // Khai báo các controls
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;

        public FormThemKhachHang()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(233, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÊM KHÁCH HÀNG";

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(29, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên:";

            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(29, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số điện thoại:";

            // textBox1
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBox1.Location = new System.Drawing.Point(228, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(317, 32);
            this.textBox1.TabIndex = 3;

            // textBox2
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBox2.Location = new System.Drawing.Point(228, 206);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(317, 32);
            this.textBox2.TabIndex = 4;

            // button1
            this.button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button1.Location = new System.Drawing.Point(420, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "Lưu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // FormThemKhachHang
            this.ClientSize = new System.Drawing.Size(702, 395);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormThemKhachHang";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Xử lý sự kiện khi nhấn "Lưu"
        private void button1_Click(object sender, EventArgs e)
        {
            string tenKH = textBox1.Text;
            string sdt = textBox2.Text;

            // Thêm khách hàng vào cơ sở dữ liệu
            // Bạn cần implement phương thức thêm khách hàng trong BAL hoặc DAL của bạn
            // KhachHangBAL khachHangBAL = new KhachHangBAL();
            // bool isSuccess = khachHangBAL.ThemKhachHang(tenKH, sdt);

            // Thông báo kết quả
            MessageBox.Show("Khách hàng đã được thêm thành công!");
        }
    }
}
