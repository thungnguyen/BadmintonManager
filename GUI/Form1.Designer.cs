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
            this.MaDatSan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lichDatSanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLySanDataSet = new BadmintonManager.QuanLySanDataSet();
            this.lichDatSanTableAdapter = new BadmintonManager.QuanLySanDataSetTableAdapters.LichDatSanTableAdapter();
            this.btnHuyLich = new System.Windows.Forms.Button();
            this.dateTimePickerTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnTim = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TimTenKH = new System.Windows.Forms.Button();
            this.btnTinhTien = new System.Windows.Forms.Button();
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
            this.MaDatSan,
            this.MaSan,
            this.MaKH,
            this.MaGia,
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
            this.dataGridView1.Location = new System.Drawing.Point(4, 121);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(844, 166);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // MaDatSan
            // 
            this.MaDatSan.DataPropertyName = "MaDatSan";
            this.MaDatSan.HeaderText = "MaDatSan";
            this.MaDatSan.Name = "MaDatSan";
            this.MaDatSan.ReadOnly = true;
            // 
            // MaSan
            // 
            this.MaSan.DataPropertyName = "MaSan";
            this.MaSan.HeaderText = "MaSan";
            this.MaSan.Name = "MaSan";
            // 
            // MaKH
            // 
            this.MaKH.DataPropertyName = "MaKH";
            this.MaKH.HeaderText = "MaKH";
            this.MaKH.Name = "MaKH";
            // 
            // MaGia
            // 
            this.MaGia.DataPropertyName = "MaGia";
            this.MaGia.HeaderText = "MaGia";
            this.MaGia.Name = "MaGia";
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
            this.btnHuyLich.Location = new System.Drawing.Point(688, 39);
            this.btnHuyLich.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnHuyLich.Name = "btnHuyLich";
            this.btnHuyLich.Size = new System.Drawing.Size(73, 29);
            this.btnHuyLich.TabIndex = 1;
            this.btnHuyLich.Text = "Hủy Lịch";
            this.btnHuyLich.UseVisualStyleBackColor = true;
            this.btnHuyLich.Click += new System.EventHandler(this.btnHuyLich_Click);
            // 
            // dateTimePickerTuNgay
            // 
            this.dateTimePickerTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateTimePickerTuNgay.Location = new System.Drawing.Point(401, 47);
            this.dateTimePickerTuNgay.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            this.dateTimePickerTuNgay.Size = new System.Drawing.Size(205, 21);
            this.dateTimePickerTuNgay.TabIndex = 2;
            // 
            // dateTimePickerDenNgay
            // 
            this.dateTimePickerDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateTimePickerDenNgay.Location = new System.Drawing.Point(401, 79);
            this.dateTimePickerDenNgay.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            this.dateTimePickerDenNgay.Size = new System.Drawing.Size(205, 21);
            this.dateTimePickerDenNgay.TabIndex = 3;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnTim.Location = new System.Drawing.Point(616, 40);
            this.btnTim.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(68, 29);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(334, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(334, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Đến ngày";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(616, 72);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "Làm mới";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(87, 59);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(159, 20);
            this.txtTenKH.TabIndex = 8;
            this.txtTenKH.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(8, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nhập tên KH";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // TimTenKH
            // 
            this.TimTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TimTenKH.Location = new System.Drawing.Point(249, 53);
            this.TimTenKH.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.TimTenKH.Name = "TimTenKH";
            this.TimTenKH.Size = new System.Drawing.Size(63, 29);
            this.TimTenKH.TabIndex = 10;
            this.TimTenKH.Text = "Tìm";
            this.TimTenKH.UseVisualStyleBackColor = true;
            this.TimTenKH.Click += new System.EventHandler(this.btnTimTenKH_Click);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnTinhTien.Location = new System.Drawing.Point(688, 72);
            this.btnTinhTien.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(73, 29);
            this.btnTinhTien.TabIndex = 11;
            this.btnTinhTien.Text = "Tính tiền";
            this.btnTinhTien.UseVisualStyleBackColor = true;
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // maDatSanDataGridViewTextBoxColumn
            // 
            this.maDatSanDataGridViewTextBoxColumn.DataPropertyName = "MaDatSan";
            this.maDatSanDataGridViewTextBoxColumn.HeaderText = "MaDatSan";
            this.maDatSanDataGridViewTextBoxColumn.Name = "maDatSanDataGridViewTextBoxColumn";
            this.maDatSanDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maSanDataGridViewTextBoxColumn
            // 
            this.maSanDataGridViewTextBoxColumn.DataPropertyName = "MaSan";
            this.maSanDataGridViewTextBoxColumn.HeaderText = "MaSan";
            this.maSanDataGridViewTextBoxColumn.Name = "maSanDataGridViewTextBoxColumn";
            // 
            // maKHDataGridViewTextBoxColumn
            // 
            this.maKHDataGridViewTextBoxColumn.DataPropertyName = "MaKH";
            this.maKHDataGridViewTextBoxColumn.HeaderText = "MaKH";
            this.maKHDataGridViewTextBoxColumn.Name = "maKHDataGridViewTextBoxColumn";
            // 
            // maGiaDataGridViewTextBoxColumn
            // 
            this.maGiaDataGridViewTextBoxColumn.DataPropertyName = "MaGia";
            this.maGiaDataGridViewTextBoxColumn.HeaderText = "MaGia";
            this.maGiaDataGridViewTextBoxColumn.Name = "maGiaDataGridViewTextBoxColumn";
            // 
            // tuNgayDataGridViewTextBoxColumn
            // 
            this.tuNgayDataGridViewTextBoxColumn.DataPropertyName = "TuNgay";
            this.tuNgayDataGridViewTextBoxColumn.HeaderText = "TuNgay";
            this.tuNgayDataGridViewTextBoxColumn.Name = "tuNgayDataGridViewTextBoxColumn";
            // 
            // denNgayDataGridViewTextBoxColumn
            // 
            this.denNgayDataGridViewTextBoxColumn.DataPropertyName = "DenNgay";
            this.denNgayDataGridViewTextBoxColumn.HeaderText = "DenNgay";
            this.denNgayDataGridViewTextBoxColumn.Name = "denNgayDataGridViewTextBoxColumn";
            // 
            // tuGioDataGridViewTextBoxColumn
            // 
            this.tuGioDataGridViewTextBoxColumn.DataPropertyName = "TuGio";
            this.tuGioDataGridViewTextBoxColumn.HeaderText = "TuGio";
            this.tuGioDataGridViewTextBoxColumn.Name = "tuGioDataGridViewTextBoxColumn";
            // 
            // denGioDataGridViewTextBoxColumn
            // 
            this.denGioDataGridViewTextBoxColumn.DataPropertyName = "DenGio";
            this.denGioDataGridViewTextBoxColumn.HeaderText = "DenGio";
            this.denGioDataGridViewTextBoxColumn.Name = "denGioDataGridViewTextBoxColumn";
            // 
            // thoiGianDataGridViewTextBoxColumn
            // 
            this.thoiGianDataGridViewTextBoxColumn.DataPropertyName = "ThoiGian";
            this.thoiGianDataGridViewTextBoxColumn.HeaderText = "ThoiGian";
            this.thoiGianDataGridViewTextBoxColumn.Name = "thoiGianDataGridViewTextBoxColumn";
            // 
            // loaiKHDataGridViewTextBoxColumn
            // 
            this.loaiKHDataGridViewTextBoxColumn.DataPropertyName = "LoaiKH";
            this.loaiKHDataGridViewTextBoxColumn.HeaderText = "LoaiKH";
            this.loaiKHDataGridViewTextBoxColumn.Name = "loaiKHDataGridViewTextBoxColumn";
            // 
            // soBuoiDataGridViewTextBoxColumn
            // 
            this.soBuoiDataGridViewTextBoxColumn.DataPropertyName = "SoBuoi";
            this.soBuoiDataGridViewTextBoxColumn.HeaderText = "SoBuoi";
            this.soBuoiDataGridViewTextBoxColumn.Name = "soBuoiDataGridViewTextBoxColumn";
            // 
            // layGiaDataGridViewTextBoxColumn
            // 
            this.layGiaDataGridViewTextBoxColumn.DataPropertyName = "LayGia";
            this.layGiaDataGridViewTextBoxColumn.HeaderText = "LayGia";
            this.layGiaDataGridViewTextBoxColumn.Name = "layGiaDataGridViewTextBoxColumn";
            // 
            // canThanhToanDataGridViewTextBoxColumn
            // 
            this.canThanhToanDataGridViewTextBoxColumn.DataPropertyName = "CanThanhToan";
            this.canThanhToanDataGridViewTextBoxColumn.HeaderText = "CanThanhToan";
            this.canThanhToanDataGridViewTextBoxColumn.Name = "canThanhToanDataGridViewTextBoxColumn";
            // 
            // daTraDataGridViewTextBoxColumn
            // 
            this.daTraDataGridViewTextBoxColumn.DataPropertyName = "DaTra";
            this.daTraDataGridViewTextBoxColumn.HeaderText = "DaTra";
            this.daTraDataGridViewTextBoxColumn.Name = "daTraDataGridViewTextBoxColumn";
            // 
            // conLaiDataGridViewTextBoxColumn
            // 
            this.conLaiDataGridViewTextBoxColumn.DataPropertyName = "ConLai";
            this.conLaiDataGridViewTextBoxColumn.HeaderText = "ConLai";
            this.conLaiDataGridViewTextBoxColumn.Name = "conLaiDataGridViewTextBoxColumn";
            this.conLaiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 297);
            this.Controls.Add(this.btnTinhTien);
            this.Controls.Add(this.TimTenKH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.dateTimePickerDenNgay);
            this.Controls.Add(this.dateTimePickerTuNgay);
            this.Controls.Add(this.btnHuyLich);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "Form1";
            this.Text = "Lịch đặt sân";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lichDatSanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private QuanLySanDataSet quanLySanDataSet;
        private System.Windows.Forms.BindingSource lichDatSanBindingSource;
        private QuanLySanDataSetTableAdapters.LichDatSanTableAdapter lichDatSanTableAdapter;
        private System.Windows.Forms.Button btnHuyLich;
        private System.Windows.Forms.DateTimePicker dateTimePickerTuNgay;
        private System.Windows.Forms.DateTimePicker dateTimePickerDenNgay;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button TimTenKH;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDatSan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGia;
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
    }
}