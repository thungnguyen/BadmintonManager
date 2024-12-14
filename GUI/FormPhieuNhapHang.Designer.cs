using System;

namespace BadmintonManager
{
    partial class FormPhieuNhapHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewPhieuNhapHang;
        private System.Windows.Forms.Button btnRefresh;

        // Required method for Designer support
        private void InitializeComponent()
        {
            this.dataGridViewPhieuNhapHang = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhieuNhapHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPhieuNhapHang
            // 
            this.dataGridViewPhieuNhapHang.AllowUserToAddRows = false;
            this.dataGridViewPhieuNhapHang.AllowUserToDeleteRows = false;
            this.dataGridViewPhieuNhapHang.AllowUserToResizeColumns = false;
            this.dataGridViewPhieuNhapHang.AllowUserToResizeRows = false;
            this.dataGridViewPhieuNhapHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhieuNhapHang.Location = new System.Drawing.Point(12, 139);
            this.dataGridViewPhieuNhapHang.Name = "dataGridViewPhieuNhapHang";
            this.dataGridViewPhieuNhapHang.ReadOnly = true;
            this.dataGridViewPhieuNhapHang.RowHeadersVisible = false;
            this.dataGridViewPhieuNhapHang.RowHeadersWidth = 51;
            this.dataGridViewPhieuNhapHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPhieuNhapHang.Size = new System.Drawing.Size(760, 310);
            this.dataGridViewPhieuNhapHang.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 110);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh Sách Nhập Hàng";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(611, 471);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 54);
            this.button1.TabIndex = 3;
            this.button1.Text = "Thêm Phiếu Nhập Hàng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormPhieuNhapHang
            // 
            this.ClientSize = new System.Drawing.Size(816, 582);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dataGridViewPhieuNhapHang);
            this.Name = "FormPhieuNhapHang";
            this.Text = "Phieu Nhap Hang";
            this.Load += new System.EventHandler(this.FormPhieuNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhieuNhapHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Event handler for Refresh button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPhieuNhapHangData();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
