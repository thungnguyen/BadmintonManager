using BadmintonManager;
using System;

namespace BadmintonManager.GUI
{
    partial class DanhSachLichSan
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
            this.daTraDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.lichDatSanBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(11, 146);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1125, 204);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // maDatSanDataGridViewTextBoxColumn
            // 
            this.maDatSanDataGridViewTextBoxColumn.DataPropertyName = "MaDatSan";
            this.maDatSanDataGridViewTextBoxColumn.HeaderText = "Mã đặt sân";
            this.maDatSanDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maDatSanDataGridViewTextBoxColumn.Name = "maDatSanDataGridViewTextBoxColumn";
            this.maDatSanDataGridViewTextBoxColumn.ReadOnly = true;
            this.maDatSanDataGridViewTextBoxColumn.Width = 150;
            // 
            // maSanDataGridViewTextBoxColumn
            // 
            this.maSanDataGridViewTextBoxColumn.DataPropertyName = "MaSan";
            this.maSanDataGridViewTextBoxColumn.HeaderText = "Sân số";
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
            // maGiaDataGridViewTextBoxColumn
            // 
            this.maGiaDataGridViewTextBoxColumn.DataPropertyName = "MaGia";
            this.maGiaDataGridViewTextBoxColumn.HeaderText = "Mã giá sân";
            this.maGiaDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maGiaDataGridViewTextBoxColumn.Name = "maGiaDataGridViewTextBoxColumn";
            this.maGiaDataGridViewTextBoxColumn.Width = 150;
            // 
            // tuNgayDataGridViewTextBoxColumn
            // 
            this.tuNgayDataGridViewTextBoxColumn.DataPropertyName = "TuNgay";
            this.tuNgayDataGridViewTextBoxColumn.HeaderText = "Ngày bắt đầu";
            this.tuNgayDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.tuNgayDataGridViewTextBoxColumn.Name = "tuNgayDataGridViewTextBoxColumn";
            this.tuNgayDataGridViewTextBoxColumn.Width = 150;
            // 
            // denNgayDataGridViewTextBoxColumn
            // 
            this.denNgayDataGridViewTextBoxColumn.DataPropertyName = "DenNgay";
            this.denNgayDataGridViewTextBoxColumn.HeaderText = "Ngày kết thúc";
            this.denNgayDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.denNgayDataGridViewTextBoxColumn.Name = "denNgayDataGridViewTextBoxColumn";
            this.denNgayDataGridViewTextBoxColumn.Width = 150;
            // 
            // tuGioDataGridViewTextBoxColumn
            // 
            this.tuGioDataGridViewTextBoxColumn.DataPropertyName = "TuGio";
            this.tuGioDataGridViewTextBoxColumn.HeaderText = "Từ";
            this.tuGioDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.tuGioDataGridViewTextBoxColumn.Name = "tuGioDataGridViewTextBoxColumn";
            this.tuGioDataGridViewTextBoxColumn.Width = 150;
            // 
            // denGioDataGridViewTextBoxColumn
            // 
            this.denGioDataGridViewTextBoxColumn.DataPropertyName = "DenGio";
            this.denGioDataGridViewTextBoxColumn.HeaderText = "Đến";
            this.denGioDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.denGioDataGridViewTextBoxColumn.Name = "denGioDataGridViewTextBoxColumn";
            this.denGioDataGridViewTextBoxColumn.Width = 150;
            // 
            // thoiGianDataGridViewTextBoxColumn
            // 
            this.thoiGianDataGridViewTextBoxColumn.DataPropertyName = "ThoiGian";
            this.thoiGianDataGridViewTextBoxColumn.HeaderText = "Thời gian";
            this.thoiGianDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.thoiGianDataGridViewTextBoxColumn.Name = "thoiGianDataGridViewTextBoxColumn";
            this.thoiGianDataGridViewTextBoxColumn.Width = 150;
            // 
            // loaiKHDataGridViewTextBoxColumn
            // 
            this.loaiKHDataGridViewTextBoxColumn.DataPropertyName = "LoaiKH";
            this.loaiKHDataGridViewTextBoxColumn.HeaderText = "Loại KH";
            this.loaiKHDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.loaiKHDataGridViewTextBoxColumn.Name = "loaiKHDataGridViewTextBoxColumn";
            this.loaiKHDataGridViewTextBoxColumn.Width = 150;
            // 
            // soBuoiDataGridViewTextBoxColumn
            // 
            this.soBuoiDataGridViewTextBoxColumn.DataPropertyName = "SoBuoi";
            this.soBuoiDataGridViewTextBoxColumn.HeaderText = "Số buổi";
            this.soBuoiDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.soBuoiDataGridViewTextBoxColumn.Name = "soBuoiDataGridViewTextBoxColumn";
            this.soBuoiDataGridViewTextBoxColumn.Width = 150;
            // 
            // layGiaDataGridViewTextBoxColumn
            // 
            this.layGiaDataGridViewTextBoxColumn.DataPropertyName = "LayGia";
            this.layGiaDataGridViewTextBoxColumn.HeaderText = "Lấy giá";
            this.layGiaDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.layGiaDataGridViewTextBoxColumn.Name = "layGiaDataGridViewTextBoxColumn";
            this.layGiaDataGridViewTextBoxColumn.Width = 150;
            // 
            // canThanhToanDataGridViewTextBoxColumn
            // 
            this.canThanhToanDataGridViewTextBoxColumn.DataPropertyName = "CanThanhToan";
            this.canThanhToanDataGridViewTextBoxColumn.HeaderText = "Cần thanh toán";
            this.canThanhToanDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.canThanhToanDataGridViewTextBoxColumn.Name = "canThanhToanDataGridViewTextBoxColumn";
            this.canThanhToanDataGridViewTextBoxColumn.Width = 150;
            // 
            // daTraDataGridViewTextBoxColumn
            // 
            this.daTraDataGridViewTextBoxColumn.DataPropertyName = "DaTra";
            this.daTraDataGridViewTextBoxColumn.HeaderText = "Đã trả";
            this.daTraDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.daTraDataGridViewTextBoxColumn.Name = "daTraDataGridViewTextBoxColumn";
            this.daTraDataGridViewTextBoxColumn.Width = 150;
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
            this.btnHuyLich.Location = new System.Drawing.Point(820, 94);
            this.btnHuyLich.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuyLich.Name = "btnHuyLich";
            this.btnHuyLich.Size = new System.Drawing.Size(98, 36);
            this.btnHuyLich.TabIndex = 1;
            this.btnHuyLich.Text = "Hủy Lịch";
            this.btnHuyLich.UseVisualStyleBackColor = true;
            this.btnHuyLich.Click += new System.EventHandler(this.btnHuyLich_Click);
            // 
            // dateTimePickerTuNgay
            // 
            this.dateTimePickerTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateTimePickerTuNgay.Location = new System.Drawing.Point(535, 58);
            this.dateTimePickerTuNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            this.dateTimePickerTuNgay.Size = new System.Drawing.Size(272, 24);
            this.dateTimePickerTuNgay.TabIndex = 2;
            // 
            // dateTimePickerDenNgay
            // 
            this.dateTimePickerDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateTimePickerDenNgay.Location = new System.Drawing.Point(535, 98);
            this.dateTimePickerDenNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            this.dateTimePickerDenNgay.Size = new System.Drawing.Size(272, 24);
            this.dateTimePickerDenNgay.TabIndex = 3;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnTim.Location = new System.Drawing.Point(820, 54);
            this.btnTim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(98, 36);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(445, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(445, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Đến ngày";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(924, 54);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Làm mới";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(116, 73);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(211, 22);
            this.txtTenKH.TabIndex = 8;
            this.txtTenKH.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(11, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nhập tên KH";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // TimTenKH
            // 
            this.TimTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TimTenKH.Location = new System.Drawing.Point(332, 65);
            this.TimTenKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TimTenKH.Name = "TimTenKH";
            this.TimTenKH.Size = new System.Drawing.Size(84, 36);
            this.TimTenKH.TabIndex = 10;
            this.TimTenKH.Text = "Tìm";
            this.TimTenKH.UseVisualStyleBackColor = true;
            this.TimTenKH.Click += new System.EventHandler(this.btnTimTenKH_Click);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnTinhTien.Location = new System.Drawing.Point(924, 94);
            this.btnTinhTien.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(99, 36);
            this.btnTinhTien.TabIndex = 12;
            this.btnTinhTien.Text = "Tính tiền";
            this.btnTinhTien.UseVisualStyleBackColor = true;
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // DanhSachLichSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 360);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DanhSachLichSan";
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
        private System.Windows.Forms.Button btnTinhTien;
    }
}