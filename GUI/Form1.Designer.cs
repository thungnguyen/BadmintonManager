using BadmintonManager;
using System;

namespace BadmintonManager.GUI
{
    partial class Form1
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
        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Thêm logic xử lý sự kiện khi Form được tải ở đây.
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.maDatSanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maSanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maKHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maGiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuNgayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.denNgayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuGioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.denGioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoiGianDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiKHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soBuoiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.layGiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canThanhToanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daTraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conLaiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lichDatSanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLySanDataSet = new BadmintonManager.QuanLySanDataSet();
            this.lichDatSanTableAdapter = new BadmintonManager.QuanLySanDataSetTableAdapters.LichDatSanTableAdapter();
            this.btnHuyLich = new System.Windows.Forms.Button();
            this.dateTimePickerTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnTim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lichDatSanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maDatSanDataGridViewTextBoxColumn,
            this.maSanDataGridViewTextBoxColumn,
            this.maKHDataGridViewTextBoxColumn,
            this.maGiaDataGridViewTextBoxColumn,
            this.tuNgayDataGridViewTextBoxColumn,
            this.denNgayDataGridViewTextBoxColumn,
            this.tuGioDataGridViewTextBoxColumn,
            this.denGioDataGridViewTextBoxColumn,
            this.thoiGianDataGridViewTextBoxColumn,
            this.loaiKHDataGridViewTextBoxColumn,
            this.soBuoiDataGridViewTextBoxColumn,
            this.layGiaDataGridViewTextBoxColumn,
            this.canThanhToanDataGridViewTextBoxColumn,
            this.daTraDataGridViewTextBoxColumn,
            this.conLaiDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.lichDatSanBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 183);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1415, 255);
            this.dataGridView1.TabIndex = 0;
            // 
            // maDatSanDataGridViewTextBoxColumn
            // 
            this.maDatSanDataGridViewTextBoxColumn.DataPropertyName = "MaDatSan";
            this.maDatSanDataGridViewTextBoxColumn.HeaderText = "MaDatSan";
            this.maDatSanDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maDatSanDataGridViewTextBoxColumn.Name = "maDatSanDataGridViewTextBoxColumn";
            this.maDatSanDataGridViewTextBoxColumn.ReadOnly = true;
            this.maDatSanDataGridViewTextBoxColumn.Width = 150;
            // 
            // maSanDataGridViewTextBoxColumn
            // 
            this.maSanDataGridViewTextBoxColumn.DataPropertyName = "MaSan";
            this.maSanDataGridViewTextBoxColumn.HeaderText = "MaSan";
            this.maSanDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maSanDataGridViewTextBoxColumn.Name = "maSanDataGridViewTextBoxColumn";
            this.maSanDataGridViewTextBoxColumn.Width = 150;
            // 
            // maKHDataGridViewTextBoxColumn
            // 
            this.maKHDataGridViewTextBoxColumn.DataPropertyName = "MaKH";
            this.maKHDataGridViewTextBoxColumn.HeaderText = "MaKH";
            this.maKHDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maKHDataGridViewTextBoxColumn.Name = "maKHDataGridViewTextBoxColumn";
            this.maKHDataGridViewTextBoxColumn.Width = 150;
            // 
            // maGiaDataGridViewTextBoxColumn
            // 
            this.maGiaDataGridViewTextBoxColumn.DataPropertyName = "MaGia";
            this.maGiaDataGridViewTextBoxColumn.HeaderText = "MaGia";
            this.maGiaDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maGiaDataGridViewTextBoxColumn.Name = "maGiaDataGridViewTextBoxColumn";
            this.maGiaDataGridViewTextBoxColumn.Width = 150;
            // 
            // tuNgayDataGridViewTextBoxColumn
            // 
            this.tuNgayDataGridViewTextBoxColumn.DataPropertyName = "TuNgay";
            this.tuNgayDataGridViewTextBoxColumn.HeaderText = "TuNgay";
            this.tuNgayDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.tuNgayDataGridViewTextBoxColumn.Name = "tuNgayDataGridViewTextBoxColumn";
            this.tuNgayDataGridViewTextBoxColumn.Width = 150;
            // 
            // denNgayDataGridViewTextBoxColumn
            // 
            this.denNgayDataGridViewTextBoxColumn.DataPropertyName = "DenNgay";
            this.denNgayDataGridViewTextBoxColumn.HeaderText = "DenNgay";
            this.denNgayDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.denNgayDataGridViewTextBoxColumn.Name = "denNgayDataGridViewTextBoxColumn";
            this.denNgayDataGridViewTextBoxColumn.Width = 150;
            // 
            // tuGioDataGridViewTextBoxColumn
            // 
            this.tuGioDataGridViewTextBoxColumn.DataPropertyName = "TuGio";
            this.tuGioDataGridViewTextBoxColumn.HeaderText = "TuGio";
            this.tuGioDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.tuGioDataGridViewTextBoxColumn.Name = "tuGioDataGridViewTextBoxColumn";
            this.tuGioDataGridViewTextBoxColumn.Width = 150;
            // 
            // denGioDataGridViewTextBoxColumn
            // 
            this.denGioDataGridViewTextBoxColumn.DataPropertyName = "DenGio";
            this.denGioDataGridViewTextBoxColumn.HeaderText = "DenGio";
            this.denGioDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.denGioDataGridViewTextBoxColumn.Name = "denGioDataGridViewTextBoxColumn";
            this.denGioDataGridViewTextBoxColumn.Width = 150;
            // 
            // thoiGianDataGridViewTextBoxColumn
            // 
            this.thoiGianDataGridViewTextBoxColumn.DataPropertyName = "ThoiGian";
            this.thoiGianDataGridViewTextBoxColumn.HeaderText = "ThoiGian";
            this.thoiGianDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.thoiGianDataGridViewTextBoxColumn.Name = "thoiGianDataGridViewTextBoxColumn";
            this.thoiGianDataGridViewTextBoxColumn.Width = 150;
            // 
            // loaiKHDataGridViewTextBoxColumn
            // 
            this.loaiKHDataGridViewTextBoxColumn.DataPropertyName = "LoaiKH";
            this.loaiKHDataGridViewTextBoxColumn.HeaderText = "LoaiKH";
            this.loaiKHDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.loaiKHDataGridViewTextBoxColumn.Name = "loaiKHDataGridViewTextBoxColumn";
            this.loaiKHDataGridViewTextBoxColumn.Width = 150;
            // 
            // soBuoiDataGridViewTextBoxColumn
            // 
            this.soBuoiDataGridViewTextBoxColumn.DataPropertyName = "SoBuoi";
            this.soBuoiDataGridViewTextBoxColumn.HeaderText = "SoBuoi";
            this.soBuoiDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.soBuoiDataGridViewTextBoxColumn.Name = "soBuoiDataGridViewTextBoxColumn";
            this.soBuoiDataGridViewTextBoxColumn.Width = 150;
            // 
            // layGiaDataGridViewTextBoxColumn
            // 
            this.layGiaDataGridViewTextBoxColumn.DataPropertyName = "LayGia";
            this.layGiaDataGridViewTextBoxColumn.HeaderText = "LayGia";
            this.layGiaDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.layGiaDataGridViewTextBoxColumn.Name = "layGiaDataGridViewTextBoxColumn";
            this.layGiaDataGridViewTextBoxColumn.Width = 150;
            // 
            // canThanhToanDataGridViewTextBoxColumn
            // 
            this.canThanhToanDataGridViewTextBoxColumn.DataPropertyName = "CanThanhToan";
            this.canThanhToanDataGridViewTextBoxColumn.HeaderText = "CanThanhToan";
            this.canThanhToanDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.canThanhToanDataGridViewTextBoxColumn.Name = "canThanhToanDataGridViewTextBoxColumn";
            this.canThanhToanDataGridViewTextBoxColumn.Width = 150;
            // 
            // daTraDataGridViewTextBoxColumn
            // 
            this.daTraDataGridViewTextBoxColumn.DataPropertyName = "DaTra";
            this.daTraDataGridViewTextBoxColumn.HeaderText = "DaTra";
            this.daTraDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.daTraDataGridViewTextBoxColumn.Name = "daTraDataGridViewTextBoxColumn";
            this.daTraDataGridViewTextBoxColumn.Width = 150;
            // 
            // conLaiDataGridViewTextBoxColumn
            // 
            this.conLaiDataGridViewTextBoxColumn.DataPropertyName = "ConLai";
            this.conLaiDataGridViewTextBoxColumn.HeaderText = "ConLai";
            this.conLaiDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.conLaiDataGridViewTextBoxColumn.Name = "conLaiDataGridViewTextBoxColumn";
            this.conLaiDataGridViewTextBoxColumn.ReadOnly = true;
            this.conLaiDataGridViewTextBoxColumn.Width = 150;
            // 
            // lichDatSanBindingSource
            // 
            this.lichDatSanBindingSource.DataMember = "LichDatSan";
            this.lichDatSanBindingSource.DataSource = this.quanLySanDataSet;
            // 
            // quanLySanDataSet
            // 
            this.quanLySanDataSet.DataSetName = "QuanLySanDataSet";
            this.quanLySanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lichDatSanTableAdapter
            // 
            this.lichDatSanTableAdapter.ClearBeforeFill = true;
            // 
            // btnHuyLich
            // 
            this.btnHuyLich.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnHuyLich.Location = new System.Drawing.Point(12, 123);
            this.btnHuyLich.Name = "btnHuyLich";
            this.btnHuyLich.Size = new System.Drawing.Size(110, 45);
            this.btnHuyLich.TabIndex = 1;
            this.btnHuyLich.Text = "Hủy Lịch";
            this.btnHuyLich.UseVisualStyleBackColor = true;
            this.btnHuyLich.Click += new System.EventHandler(this.btnHuyLich_Click);
            // 
            // dateTimePickerTuNgay
            // 
            this.dateTimePickerTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateTimePickerTuNgay.Location = new System.Drawing.Point(322, 135);
            this.dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            this.dateTimePickerTuNgay.Size = new System.Drawing.Size(256, 28);
            this.dateTimePickerTuNgay.TabIndex = 2;
            // 
            // dateTimePickerDenNgay
            // 
            this.dateTimePickerDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateTimePickerDenNgay.Location = new System.Drawing.Point(668, 135);
            this.dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            this.dateTimePickerDenNgay.Size = new System.Drawing.Size(256, 28);
            this.dateTimePickerDenNgay.TabIndex = 3;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnTim.Location = new System.Drawing.Point(930, 123);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(102, 45);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 450);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.dateTimePickerDenNgay);
            this.Controls.Add(this.dateTimePickerTuNgay);
            this.Controls.Add(this.btnHuyLich);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Lịch đặt sân";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lichDatSanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private QuanLySanDataSet quanLySanDataSet;
        private System.Windows.Forms.BindingSource lichDatSanBindingSource;
        private QuanLySanDataSetTableAdapters.LichDatSanTableAdapter lichDatSanTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDatSanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maKHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maGiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tuNgayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn denNgayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tuGioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn denGioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoiGianDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaiKHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soBuoiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn layGiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn canThanhToanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn daTraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conLaiDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnHuyLich;
        private System.Windows.Forms.DateTimePicker dateTimePickerTuNgay;
        private System.Windows.Forms.DateTimePicker dateTimePickerDenNgay;
        private System.Windows.Forms.Button btnTim;
    }
}