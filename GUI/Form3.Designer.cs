namespace BadmintonManager.GUI
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaDatSan = new System.Windows.Forms.Label();
            this.txtMaDatSan = new System.Windows.Forms.TextBox();
            this.lblMaSan = new System.Windows.Forms.Label();
            this.txtMaSan = new System.Windows.Forms.TextBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.txtTuNgay = new System.Windows.Forms.TextBox();
            this.lblDaTra = new System.Windows.Forms.Label();
            this.txtDaTra = new System.Windows.Forms.TextBox();  // Thay CheckBox bằng TextBox
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // lblMaDatSan
            // 
            this.lblMaDatSan.AutoSize = true;
            this.lblMaDatSan.Location = new System.Drawing.Point(20, 20);
            this.lblMaDatSan.Name = "lblMaDatSan";
            this.lblMaDatSan.Size = new System.Drawing.Size(76, 13);
            this.lblMaDatSan.TabIndex = 0;
            this.lblMaDatSan.Text = "Mã Đặt Sân:";
            // 
            // txtMaDatSan
            // 
            this.txtMaDatSan.Location = new System.Drawing.Point(120, 20);
            this.txtMaDatSan.Name = "txtMaDatSan";
            this.txtMaDatSan.ReadOnly = true;
            this.txtMaDatSan.Size = new System.Drawing.Size(200, 20);
            this.txtMaDatSan.TabIndex = 1;

            // 
            // lblMaSan
            // 
            this.lblMaSan.AutoSize = true;
            this.lblMaSan.Location = new System.Drawing.Point(20, 60);
            this.lblMaSan.Name = "lblMaSan";
            this.lblMaSan.Size = new System.Drawing.Size(51, 13);
            this.lblMaSan.TabIndex = 2;
            this.lblMaSan.Text = "Mã Sân:";
            // 
            // txtMaSan
            // 
            this.txtMaSan.Location = new System.Drawing.Point(120, 60);
            this.txtMaSan.Name = "txtMaSan";
            this.txtMaSan.ReadOnly = true;
            this.txtMaSan.Size = new System.Drawing.Size(200, 20);
            this.txtMaSan.TabIndex = 3;

            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(20, 100);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(91, 13);
            this.lblMaKH.TabIndex = 4;
            this.lblMaKH.Text = "Mã Khách Hàng:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(120, 100);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.Size = new System.Drawing.Size(200, 20);
            this.txtMaKH.TabIndex = 5;

            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(20, 140);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(51, 13);
            this.lblTuNgay.TabIndex = 6;
            this.lblTuNgay.Text = "Từ Ngày:";
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.Location = new System.Drawing.Point(120, 140);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.ReadOnly = true;
            this.txtTuNgay.Size = new System.Drawing.Size(200, 20);
            this.txtTuNgay.TabIndex = 7;

            // 
            // lblDaTra
            // 
            this.lblDaTra.AutoSize = true;
            this.lblDaTra.Location = new System.Drawing.Point(20, 180);
            this.lblDaTra.Name = "lblDaTra";
            this.lblDaTra.Size = new System.Drawing.Size(47, 13);
            this.lblDaTra.TabIndex = 8;
            this.lblDaTra.Text = "Đã Trả:";

            // 
            // txtDaTra
            // 
            this.txtDaTra.Location = new System.Drawing.Point(120, 180);
            this.txtDaTra.Name = "txtDaTra";
            this.txtDaTra.ReadOnly = true; // Hiển thị số tiền đã trả
            this.txtDaTra.Size = new System.Drawing.Size(200, 20);
            this.txtDaTra.TabIndex = 9;

            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(120, 220);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(75, 23);
            this.btnXacNhan.TabIndex = 10;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);

            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(200, 220);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(350, 280);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtDaTra);
            this.Controls.Add(this.lblDaTra);
            this.Controls.Add(this.txtTuNgay);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.lblMaKH);
            this.Controls.Add(this.txtMaSan);
            this.Controls.Add(this.lblMaSan);
            this.Controls.Add(this.txtMaDatSan);
            this.Controls.Add(this.lblMaDatSan);
            this.Name = "Form3";
            this.Text = "Chi Tiết Phiếu Chi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblMaDatSan;
        private System.Windows.Forms.TextBox txtMaDatSan;
        private System.Windows.Forms.Label lblMaSan;
        private System.Windows.Forms.TextBox txtMaSan;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.TextBox txtTuNgay;
        private System.Windows.Forms.Label lblDaTra;
        private System.Windows.Forms.TextBox txtDaTra; // TextBox cho số tiền đã trả
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
    }
}
