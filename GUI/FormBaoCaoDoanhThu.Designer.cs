namespace BadmintonManager.GUI
{
    partial class FormBaoCaoDoanhThu
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.hoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLySanDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLySanDataSet1 = new BadmintonManager.QuanLySanDataSet();
            this.hoaDonTableAdapter = new BadmintonManager.QuanLySanDataSetTableAdapters.HoaDonTableAdapter();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.quanLySanDataSet1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.baoCaoDoanhThuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.baoCaoDoanhThuTableAdapter = new BadmintonManager.QuanLySanDataSetTableAdapters.BaoCaoDoanhThuTableAdapter();
            this.maHDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fKBaoCaoDoanMaHD5CD6CB2BBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fKThanhToanMaHD6D0D32F4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.thanhToanTableAdapter = new BadmintonManager.QuanLySanDataSetTableAdapters.ThanhToanTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baoCaoDoanhThuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKBaoCaoDoanMaHD5CD6CB2BBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKThanhToanMaHD6D0D32F4BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maHDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.fKThanhToanMaHD6D0D32F4BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(11, 137);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(856, 214);
            this.dataGridView1.TabIndex = 0;
            // 
            // hoaDonBindingSource
            // 
            this.hoaDonBindingSource.DataMember = "HoaDon";
            this.hoaDonBindingSource.DataSource = this.quanLySanDataSet1BindingSource;
            // 
            // quanLySanDataSet1BindingSource
            // 
            this.quanLySanDataSet1BindingSource.DataSource = this.quanLySanDataSet1;
            this.quanLySanDataSet1BindingSource.Position = 0;
            // 
            // quanLySanDataSet1
            // 
            this.quanLySanDataSet1.DataSetName = "QuanLySanDataSet1";
            this.quanLySanDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hoaDonTableAdapter
            // 
            this.hoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTongTien.Location = new System.Drawing.Point(618, 90);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(166, 26);
            this.txtTongTien.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(529, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tổng thu:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnTimKiem.Location = new System.Drawing.Point(392, 80);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(67, 31);
            this.btnTimKiem.TabIndex = 9;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // datePickerTo
            // 
            this.datePickerTo.Location = new System.Drawing.Point(108, 90);
            this.datePickerTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.Size = new System.Drawing.Size(258, 22);
            this.datePickerTo.TabIndex = 8;
            // 
            // datePickerFrom
            // 
            this.datePickerFrom.Location = new System.Drawing.Point(108, 57);
            this.datePickerFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datePickerFrom.Name = "datePickerFrom";
            this.datePickerFrom.Size = new System.Drawing.Size(258, 22);
            this.datePickerFrom.TabIndex = 7;
            // 
            // quanLySanDataSet1BindingSource1
            // 
            this.quanLySanDataSet1BindingSource1.DataSource = this.quanLySanDataSet1;
            this.quanLySanDataSet1BindingSource1.Position = 0;
            // 
            // baoCaoDoanhThuBindingSource
            // 
            this.baoCaoDoanhThuBindingSource.DataMember = "BaoCaoDoanhThu";
            this.baoCaoDoanhThuBindingSource.DataSource = this.quanLySanDataSet1BindingSource1;
            // 
            // baoCaoDoanhThuTableAdapter
            // 
            this.baoCaoDoanhThuTableAdapter.ClearBeforeFill = true;
            // 
            // maHDDataGridViewTextBoxColumn
            // 
            this.maHDDataGridViewTextBoxColumn.DataPropertyName = "MaHD";
            this.maHDDataGridViewTextBoxColumn.HeaderText = "MaHD";
            this.maHDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.maHDDataGridViewTextBoxColumn.Name = "maHDDataGridViewTextBoxColumn";
            this.maHDDataGridViewTextBoxColumn.ReadOnly = true;
            this.maHDDataGridViewTextBoxColumn.Width = 125;
            // 
            // fKBaoCaoDoanMaHD5CD6CB2BBindingSource
            // 
            this.fKBaoCaoDoanMaHD5CD6CB2BBindingSource.DataMember = "FK__BaoCaoDoan__MaHD__5CD6CB2B";
            this.fKBaoCaoDoanMaHD5CD6CB2BBindingSource.DataSource = this.hoaDonBindingSource;
            // 
            // fKThanhToanMaHD6D0D32F4BindingSource
            // 
            this.fKThanhToanMaHD6D0D32F4BindingSource.DataMember = "FK__ThanhToan__MaHD__6D0D32F4";
            this.fKThanhToanMaHD6D0D32F4BindingSource.DataSource = this.hoaDonBindingSource;
            // 
            // thanhToanTableAdapter
            // 
            this.thanhToanTableAdapter.ClearBeforeFill = true;
            // 
            // FormBaoCaoDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 360);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.datePickerTo);
            this.Controls.Add(this.datePickerFrom);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormBaoCaoDoanhThu";
            this.Text = "Thống kê doanh thu";
            this.Load += new System.EventHandler(this.FormBaoCaoDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baoCaoDoanhThuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKBaoCaoDoanMaHD5CD6CB2BBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKThanhToanMaHD6D0D32F4BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource quanLySanDataSet1BindingSource;
        private QuanLySanDataSet quanLySanDataSet1;
        private System.Windows.Forms.BindingSource hoaDonBindingSource;
        private QuanLySanDataSetTableAdapters.HoaDonTableAdapter hoaDonTableAdapter;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DateTimePicker datePickerTo;
        private System.Windows.Forms.DateTimePicker datePickerFrom;
        private System.Windows.Forms.BindingSource quanLySanDataSet1BindingSource1;
        private System.Windows.Forms.BindingSource baoCaoDoanhThuBindingSource;
        private QuanLySanDataSetTableAdapters.BaoCaoDoanhThuTableAdapter baoCaoDoanhThuTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn maHDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource fKBaoCaoDoanMaHD5CD6CB2BBindingSource;
        private System.Windows.Forms.BindingSource fKThanhToanMaHD6D0D32F4BindingSource;
        private QuanLySanDataSetTableAdapters.ThanhToanTableAdapter thanhToanTableAdapter;
    }
}