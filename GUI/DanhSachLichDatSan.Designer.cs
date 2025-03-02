namespace BadmintonManager.GUI
{
    partial class DanhSachLichDatSan
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
            this.dtpNgayChon = new System.Windows.Forms.DateTimePicker();
            this.dgvLichDatSan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichDatSan)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpNgayChon
            // 
            this.dtpNgayChon.Location = new System.Drawing.Point(12, 107);
            this.dtpNgayChon.Name = "dtpNgayChon";
            this.dtpNgayChon.Size = new System.Drawing.Size(238, 22);
            this.dtpNgayChon.TabIndex = 0;
            // 
            // dgvLichDatSan
            // 
            this.dgvLichDatSan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichDatSan.Location = new System.Drawing.Point(12, 148);
            this.dgvLichDatSan.Name = "dgvLichDatSan";
            this.dgvLichDatSan.RowHeadersWidth = 51;
            this.dgvLichDatSan.RowTemplate.Height = 24;
            this.dgvLichDatSan.Size = new System.Drawing.Size(776, 335);
            this.dgvLichDatSan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(296, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 41);
            this.label1.TabIndex = 41;
            this.label1.Text = "LỊCH ĐẶT SÂN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(256, 106);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.TabIndex = 42;
            this.btnLamMoi.Text = "Refresh";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // DanhSachLichDatSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 513);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLichDatSan);
            this.Controls.Add(this.dtpNgayChon);
            this.Name = "DanhSachLichDatSan";
            this.Text = "DanhSachLichDatSan";
            this.Load += new System.EventHandler(this.DanhSachLichDatSan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichDatSan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNgayChon;
        private System.Windows.Forms.DataGridView dgvLichDatSan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLamMoi;
    }
}