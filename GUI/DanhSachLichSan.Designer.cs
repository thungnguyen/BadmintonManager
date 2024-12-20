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
            this.lsvDatSan = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // maDatSanDataGridViewTextBoxColumn
            // 
            // 
            // maSanDataGridViewTextBoxColumn
            // 
            // btnHuyLich
            // 
            this.btnHuyLich.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnHuyLich.Location = new System.Drawing.Point(615, 76);
            this.btnHuyLich.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHuyLich.Name = "btnHuyLich";
            this.btnHuyLich.Size = new System.Drawing.Size(74, 29);
            this.btnHuyLich.TabIndex = 1;
            this.btnHuyLich.Text = "Hủy Lịch";
            this.btnHuyLich.UseVisualStyleBackColor = true;
            this.btnHuyLich.Click += new System.EventHandler(this.btnHuyLich_Click);
            // 
            // dateTimePickerTuNgay
            // 
            this.dateTimePickerTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateTimePickerTuNgay.Location = new System.Drawing.Point(401, 47);
            this.dateTimePickerTuNgay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            this.dateTimePickerTuNgay.Size = new System.Drawing.Size(205, 21);
            this.dateTimePickerTuNgay.TabIndex = 2;
            // 
            // dateTimePickerDenNgay
            // 
            this.dateTimePickerDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateTimePickerDenNgay.Location = new System.Drawing.Point(401, 80);
            this.dateTimePickerDenNgay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            this.dateTimePickerDenNgay.Size = new System.Drawing.Size(205, 21);
            this.dateTimePickerDenNgay.TabIndex = 3;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnTim.Location = new System.Drawing.Point(615, 44);
            this.btnTim.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(74, 29);
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
            this.label2.Location = new System.Drawing.Point(334, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Đến ngày";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(693, 44);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "Làm mới";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(87, 59);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.TimTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimTenKH.Location = new System.Drawing.Point(250, 55);
            this.TimTenKH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TimTenKH.Name = "TimTenKH";
            this.TimTenKH.Size = new System.Drawing.Size(53, 26);
            this.TimTenKH.TabIndex = 10;
            this.TimTenKH.Text = "Tìm";
            this.TimTenKH.UseVisualStyleBackColor = true;
            this.TimTenKH.Click += new System.EventHandler(this.btnTimTenKH_Click);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnTinhTien.Location = new System.Drawing.Point(693, 76);
            this.btnTinhTien.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(74, 29);
            this.btnTinhTien.TabIndex = 12;
            this.btnTinhTien.Text = "Tính tiền";
            this.btnTinhTien.UseVisualStyleBackColor = true;
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // lsvDatSan
            // 
            this.lsvDatSan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lsvDatSan.FullRowSelect = true;
            this.lsvDatSan.GridLines = true;
            this.lsvDatSan.HideSelection = false;
            this.lsvDatSan.Location = new System.Drawing.Point(12, 115);
            this.lsvDatSan.Name = "lsvDatSan";
            this.lsvDatSan.Size = new System.Drawing.Size(835, 165);
            this.lsvDatSan.TabIndex = 13;
            this.lsvDatSan.UseCompatibleStateImageBehavior = false;
            this.lsvDatSan.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên sân";
            this.columnHeader1.Width = 101;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên KH";
            this.columnHeader2.Width = 93;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Từ ngày";
            this.columnHeader3.Width = 107;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Đến ngày";
            this.columnHeader4.Width = 75;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Từ giờ";
            this.columnHeader5.Width = 75;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Đến giờ";
            this.columnHeader6.Width = 84;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Loại KH";
            this.columnHeader7.Width = 67;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Số buổi";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Cần thanh toán";
            this.columnHeader9.Width = 111;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Đã trả";
            // 
            // DanhSachLichSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 292);
            this.Controls.Add(this.lsvDatSan);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DanhSachLichSan";
            this.Text = "Lịch đặt sân";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.ListView lsvDatSan;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}