namespace BadmintonManager.GUI
{
    partial class TaoPhieuNhapHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblSanPham = new System.Windows.Forms.Label();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.lblSoLuongNhapLon = new System.Windows.Forms.Label();
            this.numSoLuongNhapLon = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongNhapNho = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.txtSoLuongNhapNho = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongNhapLon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Location = new System.Drawing.Point(28, 28);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(76, 16);
            this.lblNgayNhap.TabIndex = 0;
            this.lblNgayNhap.Text = "Ngày Nhập";
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(122, 28);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayNhap.TabIndex = 1;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(28, 70);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(53, 16);
            this.lblGhiChu.TabIndex = 2;
            this.lblGhiChu.Text = "Ghi Chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(122, 67);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(200, 60);
            this.txtGhiChu.TabIndex = 3;
            // 
            // lblSanPham
            // 
            this.lblSanPham.AutoSize = true;
            this.lblSanPham.Location = new System.Drawing.Point(28, 154);
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.Size = new System.Drawing.Size(69, 16);
            this.lblSanPham.TabIndex = 4;
            this.lblSanPham.Text = "Sản Phẩm";
            // 
            // cboSanPham
            // 
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(122, 151);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(200, 24);
            this.cboSanPham.TabIndex = 5;
            // 
            // lblSoLuongNhapLon
            // 
            this.lblSoLuongNhapLon.AutoSize = true;
            this.lblSoLuongNhapLon.Location = new System.Drawing.Point(28, 198);
            this.lblSoLuongNhapLon.Name = "lblSoLuongNhapLon";
            this.lblSoLuongNhapLon.Size = new System.Drawing.Size(125, 16);
            this.lblSoLuongNhapLon.TabIndex = 6;
            this.lblSoLuongNhapLon.Text = "Số Lượng Nhập Lớn";
            // 
            // numSoLuongNhapLon
            // 
            this.numSoLuongNhapLon.Location = new System.Drawing.Point(158, 198);
            this.numSoLuongNhapLon.Name = "numSoLuongNhapLon";
            this.numSoLuongNhapLon.Size = new System.Drawing.Size(120, 22);
            this.numSoLuongNhapLon.TabIndex = 7;
            this.numSoLuongNhapLon.ValueChanged += new System.EventHandler(this.numSoLuongNhapLon_ValueChanged);
            // 
            // lblSoLuongNhapNho
            // 
            this.lblSoLuongNhapNho.AutoSize = true;
            this.lblSoLuongNhapNho.Location = new System.Drawing.Point(28, 240);
            this.lblSoLuongNhapNho.Name = "lblSoLuongNhapNho";
            this.lblSoLuongNhapNho.Size = new System.Drawing.Size(128, 16);
            this.lblSoLuongNhapNho.TabIndex = 8;
            this.lblSoLuongNhapNho.Text = "Số Lượng Nhập Nhỏ";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(122, 282);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 30);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(247, 282);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 30);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtSoLuongNhapNho
            // 
            this.txtSoLuongNhapNho.Location = new System.Drawing.Point(158, 233);
            this.txtSoLuongNhapNho.Name = "txtSoLuongNhapNho";
            this.txtSoLuongNhapNho.Size = new System.Drawing.Size(120, 22);
            this.txtSoLuongNhapNho.TabIndex = 12;
            // 
            // TaoPhieuNhapHang
            // 
            this.ClientSize = new System.Drawing.Size(382, 323);
            this.Controls.Add(this.txtSoLuongNhapNho);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.lblSoLuongNhapNho);
            this.Controls.Add(this.numSoLuongNhapLon);
            this.Controls.Add(this.lblSoLuongNhapLon);
            this.Controls.Add(this.cboSanPham);
            this.Controls.Add(this.lblSanPham);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.dtpNgayNhap);
            this.Controls.Add(this.lblNgayNhap);
            this.Name = "TaoPhieuNhapHang";
            this.Text = "Tạo Phiếu Nhập Hàng Mới";
            this.Load += new System.EventHandler(this.TaoPhieuNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongNhapLon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.Label lblSoLuongNhapLon;
        private System.Windows.Forms.NumericUpDown numSoLuongNhapLon;
        private System.Windows.Forms.Label lblSoLuongNhapNho;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.TextBox txtSoLuongNhapNho;
    }
}
