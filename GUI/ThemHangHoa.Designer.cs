namespace BadmintonManager.GUI
{
    partial class ThemHangHoa
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenHH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLoaiHH = new System.Windows.Forms.ComboBox();
            this.quanLySanDataSet = new BadmintonManager.QuanLySanDataSet();
            this.loaiHHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loaiHHTableAdapter = new BadmintonManager.QuanLySanDataSetTableAdapters.LoaiHHTableAdapter();
            this.labelMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdvtinhnho = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdvtinhlon = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHeSoQuyDoi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGiaNhapLon = new System.Windows.Forms.TextBox();
            this.txtGiaNhapNho = new System.Windows.Forms.TextBox();
            this.txtGiaBanLon = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGiaBanNho = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSoLuongTonLon = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSoLuongTonNho = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiHHBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm danh mục hàng hoá mới";
            // 
            // txtTenHH
            // 
            this.txtTenHH.Location = new System.Drawing.Point(141, 58);
            this.txtTenHH.Name = "txtTenHH";
            this.txtTenHH.Size = new System.Drawing.Size(359, 22);
            this.txtTenHH.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Hàng Hoá";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Loại hàng hoá";
            // 
            // cmbLoaiHH
            // 
            this.cmbLoaiHH.FormattingEnabled = true;
            this.cmbLoaiHH.Location = new System.Drawing.Point(141, 97);
            this.cmbLoaiHH.Name = "cmbLoaiHH";
            this.cmbLoaiHH.Size = new System.Drawing.Size(121, 24);
            this.cmbLoaiHH.TabIndex = 4;
            // 
            // quanLySanDataSet
            // 
            this.quanLySanDataSet.DataSetName = "QuanLySanDataSet";
            this.quanLySanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // loaiHHBindingSource
            // 
            this.loaiHHBindingSource.DataMember = "LoaiHH";
            this.loaiHHBindingSource.DataSource = this.quanLySanDataSet;
            // 
            // loaiHHTableAdapter
            // 
            this.loaiHHTableAdapter.ClearBeforeFill = true;
            // 
            // labelMoTa
            // 
            this.labelMoTa.AutoSize = true;
            this.labelMoTa.Location = new System.Drawing.Point(27, 141);
            this.labelMoTa.Name = "labelMoTa";
            this.labelMoTa.Size = new System.Drawing.Size(40, 16);
            this.labelMoTa.TabIndex = 5;
            this.labelMoTa.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(141, 138);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(225, 96);
            this.txtMoTa.TabIndex = 6;
            this.txtMoTa.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Đơn Vị tính nhỏ";
            // 
            // txtdvtinhnho
            // 
            this.txtdvtinhnho.Location = new System.Drawing.Point(141, 253);
            this.txtdvtinhnho.Name = "txtdvtinhnho";
            this.txtdvtinhnho.Size = new System.Drawing.Size(225, 22);
            this.txtdvtinhnho.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Đơn vị tính lớn";
            // 
            // txtdvtinhlon
            // 
            this.txtdvtinhlon.Location = new System.Drawing.Point(141, 294);
            this.txtdvtinhlon.Name = "txtdvtinhlon";
            this.txtdvtinhlon.Size = new System.Drawing.Size(225, 22);
            this.txtdvtinhlon.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Hệ số quy đổi";
            // 
            // txtHeSoQuyDoi
            // 
            this.txtHeSoQuyDoi.Location = new System.Drawing.Point(141, 334);
            this.txtHeSoQuyDoi.Name = "txtHeSoQuyDoi";
            this.txtHeSoQuyDoi.Size = new System.Drawing.Size(225, 22);
            this.txtHeSoQuyDoi.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(513, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Giá nhập lớn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(513, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Giá nhập nhỏ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(513, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Giá bán lớn";
            // 
            // txtGiaNhapLon
            // 
            this.txtGiaNhapLon.Location = new System.Drawing.Point(618, 58);
            this.txtGiaNhapLon.Name = "txtGiaNhapLon";
            this.txtGiaNhapLon.Size = new System.Drawing.Size(225, 22);
            this.txtGiaNhapLon.TabIndex = 16;
            // 
            // txtGiaNhapNho
            // 
            this.txtGiaNhapNho.Location = new System.Drawing.Point(618, 94);
            this.txtGiaNhapNho.Name = "txtGiaNhapNho";
            this.txtGiaNhapNho.Size = new System.Drawing.Size(225, 22);
            this.txtGiaNhapNho.TabIndex = 17;
            // 
            // txtGiaBanLon
            // 
            this.txtGiaBanLon.Location = new System.Drawing.Point(618, 132);
            this.txtGiaBanLon.Name = "txtGiaBanLon";
            this.txtGiaBanLon.Size = new System.Drawing.Size(225, 22);
            this.txtGiaBanLon.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(513, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Giá bán nhỏ";
            // 
            // txtGiaBanNho
            // 
            this.txtGiaBanNho.Location = new System.Drawing.Point(618, 170);
            this.txtGiaBanNho.Name = "txtGiaBanNho";
            this.txtGiaBanNho.Size = new System.Drawing.Size(225, 22);
            this.txtGiaBanNho.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(493, 207);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "Số lượng tồn lớn";
            // 
            // txtSoLuongTonLon
            // 
            this.txtSoLuongTonLon.Location = new System.Drawing.Point(618, 204);
            this.txtSoLuongTonLon.Name = "txtSoLuongTonLon";
            this.txtSoLuongTonLon.Size = new System.Drawing.Size(225, 22);
            this.txtSoLuongTonLon.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(493, 244);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "Số lượng tồn nhỏ";
            // 
            // txtSoLuongTonNho
            // 
            this.txtSoLuongTonNho.Location = new System.Drawing.Point(618, 241);
            this.txtSoLuongTonNho.Name = "txtSoLuongTonNho";
            this.txtSoLuongTonNho.ReadOnly = true;
            this.txtSoLuongTonNho.Size = new System.Drawing.Size(225, 22);
            this.txtSoLuongTonNho.TabIndex = 24;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(496, 294);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(107, 40);
            this.btnsave.TabIndex = 25;
            this.btnsave.Text = "Lưu";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(618, 294);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 40);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ThemHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 626);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtSoLuongTonNho);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSoLuongTonLon);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtGiaBanNho);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtGiaBanLon);
            this.Controls.Add(this.txtGiaNhapNho);
            this.Controls.Add(this.txtGiaNhapLon);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtHeSoQuyDoi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtdvtinhlon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtdvtinhnho);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.labelMoTa);
            this.Controls.Add(this.cmbLoaiHH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenHH);
            this.Controls.Add(this.label1);
            this.Name = "ThemHangHoa";
            this.Text = "ThemHangHoa";
            this.Load += new System.EventHandler(this.ThemHangHoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiHHBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenHH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLoaiHH;
        private QuanLySanDataSet quanLySanDataSet;
        private System.Windows.Forms.BindingSource loaiHHBindingSource;
        private QuanLySanDataSetTableAdapters.LoaiHHTableAdapter loaiHHTableAdapter;
        private System.Windows.Forms.Label labelMoTa;
        private System.Windows.Forms.RichTextBox txtMoTa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtdvtinhnho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtdvtinhlon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHeSoQuyDoi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGiaNhapLon;
        private System.Windows.Forms.TextBox txtGiaNhapNho;
        private System.Windows.Forms.TextBox txtGiaBanLon;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGiaBanNho;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSoLuongTonLon;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSoLuongTonNho;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnCancel;
    }
}