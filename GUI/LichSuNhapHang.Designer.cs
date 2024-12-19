namespace BadmintonManager.GUI
{
    partial class LichSuNhapHang
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
            this.dgvNhapHang = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.NhapHangbtn = new System.Windows.Forms.Button();
            this.refreshtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNhapHang
            // 
            this.dgvNhapHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhapHang.Location = new System.Drawing.Point(12, 89);
            this.dgvNhapHang.Name = "dgvNhapHang";
            this.dgvNhapHang.RowHeadersWidth = 51;
            this.dgvNhapHang.RowTemplate.Height = 24;
            this.dgvNhapHang.Size = new System.Drawing.Size(660, 300);
            this.dgvNhapHang.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(184, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lịch Sử Nhập Hàng";
            // 
            // NhapHangbtn
            // 
            this.NhapHangbtn.Location = new System.Drawing.Point(519, 395);
            this.NhapHangbtn.Name = "NhapHangbtn";
            this.NhapHangbtn.Size = new System.Drawing.Size(153, 65);
            this.NhapHangbtn.TabIndex = 11;
            this.NhapHangbtn.Text = "Thêm đơn nhập hàng mới";
            this.NhapHangbtn.UseVisualStyleBackColor = true;
            this.NhapHangbtn.Click += new System.EventHandler(this.NhapHangbtn_Click);
            // 
            // refreshtn
            // 
            this.refreshtn.Location = new System.Drawing.Point(360, 395);
            this.refreshtn.Name = "refreshtn";
            this.refreshtn.Size = new System.Drawing.Size(153, 65);
            this.refreshtn.TabIndex = 12;
            this.refreshtn.Text = "Làm Mới";
            this.refreshtn.UseVisualStyleBackColor = true;
            this.refreshtn.Click += new System.EventHandler(this.detailNhapHangbtn_Click);
            // 
            // LichSuNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 484);
            this.Controls.Add(this.refreshtn);
            this.Controls.Add(this.NhapHangbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvNhapHang);
            this.Name = "LichSuNhapHang";
            this.Text = "LichSuNhapHang";
            this.Load += new System.EventHandler(this.LichSuNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNhapHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button NhapHangbtn;
        private System.Windows.Forms.Button refreshtn;
    }
}