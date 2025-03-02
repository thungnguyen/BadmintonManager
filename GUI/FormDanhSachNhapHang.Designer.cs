namespace BadmintonManager.GUI
{
    partial class FormDanhSachNhapHang
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDanhSachNhapHang = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachNhapHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDanhSachNhapHang
            // 
            this.dgvDanhSachNhapHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachNhapHang.Location = new System.Drawing.Point(13, 74);
            this.dgvDanhSachNhapHang.Name = "dgvDanhSachNhapHang";
            this.dgvDanhSachNhapHang.RowHeadersWidth = 51;
            this.dgvDanhSachNhapHang.RowTemplate.Height = 24;
            this.dgvDanhSachNhapHang.Size = new System.Drawing.Size(775, 294);
            this.dgvDanhSachNhapHang.TabIndex = 0;
            this.dgvDanhSachNhapHang.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDanhSachNhapHang_CellFormatting);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(12, 374);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(153, 64);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới danh sách";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh Sách Nhập Hàng";
            // 
            // FormDanhSachNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.dgvDanhSachNhapHang);
            this.Name = "FormDanhSachNhapHang";
            this.Text = "FormDanhSachNhapHang";
            this.Load += new System.EventHandler(this.FormDanhSachNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachNhapHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDanhSachNhapHang;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label1;
    }
}