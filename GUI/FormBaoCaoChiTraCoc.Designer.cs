namespace BadmintonManager.GUI
{
    partial class FormBaoCaoChiTraCoc
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
            this.maPhieuChiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maDatSanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maSanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maKHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuNgayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daTraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayLapDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phieuChiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLySanDataSet = new BadmintonManager.QuanLySanDataSet();
            this.phieuChiTableAdapter = new BadmintonManager.QuanLySanDataSetTableAdapters.PhieuChiTableAdapter();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phieuChiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maPhieuChiDataGridViewTextBoxColumn,
            this.maDatSanDataGridViewTextBoxColumn,
            this.maSanDataGridViewTextBoxColumn,
            this.maKHDataGridViewTextBoxColumn,
            this.tuNgayDataGridViewTextBoxColumn,
            this.daTraDataGridViewTextBoxColumn,
            this.ngayLapDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.phieuChiBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(11, 147);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(993, 203);
            this.dataGridView1.TabIndex = 0;
            // 
            // maPhieuChiDataGridViewTextBoxColumn
            // 
            this.maPhieuChiDataGridViewTextBoxColumn.DataPropertyName = "MaPhieuChi";
            this.maPhieuChiDataGridViewTextBoxColumn.HeaderText = "Mã phiếu chi";
            this.maPhieuChiDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maPhieuChiDataGridViewTextBoxColumn.Name = "maPhieuChiDataGridViewTextBoxColumn";
            this.maPhieuChiDataGridViewTextBoxColumn.ReadOnly = true;
            this.maPhieuChiDataGridViewTextBoxColumn.Width = 150;
            // 
            // maDatSanDataGridViewTextBoxColumn
            // 
            this.maDatSanDataGridViewTextBoxColumn.DataPropertyName = "MaDatSan";
            this.maDatSanDataGridViewTextBoxColumn.HeaderText = "Mã đặt sân";
            this.maDatSanDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maDatSanDataGridViewTextBoxColumn.Name = "maDatSanDataGridViewTextBoxColumn";
            this.maDatSanDataGridViewTextBoxColumn.Width = 150;
            // 
            // maSanDataGridViewTextBoxColumn
            // 
            this.maSanDataGridViewTextBoxColumn.DataPropertyName = "MaSan";
            this.maSanDataGridViewTextBoxColumn.HeaderText = "Mã sân";
            this.maSanDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maSanDataGridViewTextBoxColumn.Name = "maSanDataGridViewTextBoxColumn";
            this.maSanDataGridViewTextBoxColumn.Width = 150;
            // 
            // maKHDataGridViewTextBoxColumn
            // 
            this.maKHDataGridViewTextBoxColumn.DataPropertyName = "MaKH";
            this.maKHDataGridViewTextBoxColumn.HeaderText = "Mã KH";
            this.maKHDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maKHDataGridViewTextBoxColumn.Name = "maKHDataGridViewTextBoxColumn";
            this.maKHDataGridViewTextBoxColumn.Width = 150;
            // 
            // tuNgayDataGridViewTextBoxColumn
            // 
            this.tuNgayDataGridViewTextBoxColumn.DataPropertyName = "TuNgay";
            this.tuNgayDataGridViewTextBoxColumn.HeaderText = "Ngày bắt đầu";
            this.tuNgayDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.tuNgayDataGridViewTextBoxColumn.Name = "tuNgayDataGridViewTextBoxColumn";
            this.tuNgayDataGridViewTextBoxColumn.Width = 150;
            // 
            // daTraDataGridViewTextBoxColumn
            // 
            this.daTraDataGridViewTextBoxColumn.DataPropertyName = "DaTra";
            this.daTraDataGridViewTextBoxColumn.HeaderText = "Chi hoàn cọc";
            this.daTraDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.daTraDataGridViewTextBoxColumn.Name = "daTraDataGridViewTextBoxColumn";
            this.daTraDataGridViewTextBoxColumn.Width = 150;
            // 
            // ngayLapDataGridViewTextBoxColumn
            // 
            this.ngayLapDataGridViewTextBoxColumn.DataPropertyName = "NgayLap";
            this.ngayLapDataGridViewTextBoxColumn.HeaderText = "Ngày lập";
            this.ngayLapDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.ngayLapDataGridViewTextBoxColumn.Name = "ngayLapDataGridViewTextBoxColumn";
            this.ngayLapDataGridViewTextBoxColumn.Width = 150;
            // 
            // phieuChiBindingSource
            // 
            this.phieuChiBindingSource.DataMember = "PhieuChi";
            this.phieuChiBindingSource.DataSource = this.quanLySanDataSet;
            // 
            // quanLySanDataSet
            // 
            this.quanLySanDataSet.DataSetName = "QuanLySanDataSet";
            this.quanLySanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // phieuChiTableAdapter
            // 
            this.phieuChiTableAdapter.ClearBeforeFill = true;
            // 
            // datePickerFrom
            // 
            this.datePickerFrom.Location = new System.Drawing.Point(300, 70);
            this.datePickerFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datePickerFrom.Name = "datePickerFrom";
            this.datePickerFrom.Size = new System.Drawing.Size(258, 22);
            this.datePickerFrom.TabIndex = 1;
            // 
            // datePickerTo
            // 
            this.datePickerTo.Location = new System.Drawing.Point(300, 103);
            this.datePickerTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.Size = new System.Drawing.Size(258, 22);
            this.datePickerTo.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnTimKiem.Location = new System.Drawing.Point(583, 93);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(67, 31);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(720, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tổng chi:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTongTien.Location = new System.Drawing.Point(809, 103);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(166, 26);
            this.txtTongTien.TabIndex = 6;
            // 
            // FormBaoCaoChiTraCoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 360);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.datePickerTo);
            this.Controls.Add(this.datePickerFrom);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormBaoCaoChiTraCoc";
            this.Text = "Báo cáo chi trả tiền cọc";
            this.Load += new System.EventHandler(this.FormBaoCaoChiTraCoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phieuChiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private QuanLySanDataSet quanLySanDataSet;
        private System.Windows.Forms.BindingSource phieuChiBindingSource;
        private QuanLySanDataSetTableAdapters.PhieuChiTableAdapter phieuChiTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn maPhieuChiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDatSanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maKHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tuNgayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn daTraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayLapDataGridViewTextBoxColumn;
        private System.Windows.Forms.DateTimePicker datePickerFrom;
        private System.Windows.Forms.DateTimePicker datePickerTo;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTongTien;
    }
}