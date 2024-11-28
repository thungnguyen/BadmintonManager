namespace BadmintonManager.GUI
{
    partial class FrmTinhTien
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cbLoaiHH = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dgvCTSP = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDonViTinh = new System.Windows.Forms.ComboBox();
            this.BtnDelHH = new System.Windows.Forms.Button();
            this.btnAddHH = new System.Windows.Forms.Button();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cbTenHH = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTSP)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dgvHangHoa);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.cbLoaiHH);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 426);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(139, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(42, 20);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHangHoa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHangHoa.ColumnHeadersHeight = 20;
            this.dgvHangHoa.Location = new System.Drawing.Point(6, 69);
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.Size = new System.Drawing.Size(175, 354);
            this.dgvHangHoa.TabIndex = 6;
            this.dgvHangHoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHangHoa_CellClick);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(44, 43);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(93, 20);
            this.txtTimKiem.TabIndex = 3;
            // 
            // cbLoaiHH
            // 
            this.cbLoaiHH.FormattingEnabled = true;
            this.cbLoaiHH.Location = new System.Drawing.Point(44, 17);
            this.cbLoaiHH.Name = "cbLoaiHH";
            this.cbLoaiHH.Size = new System.Drawing.Size(137, 21);
            this.cbLoaiHH.TabIndex = 2;
            this.cbLoaiHH.SelectedValueChanged += new System.EventHandler(this.cbLoaiHH_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhóm";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.dataGridView2);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(593, 12);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(195, 426);
            this.flowLayoutPanel4.TabIndex = 4;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 92);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(192, 331);
            this.dataGridView2.TabIndex = 0;
            // 
            // dgvCTSP
            // 
            this.dgvCTSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTSP.Location = new System.Drawing.Point(6, 88);
            this.dgvCTSP.Name = "dgvCTSP";
            this.dgvCTSP.Size = new System.Drawing.Size(372, 129);
            this.dgvCTSP.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtGiamGia);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbDonViTinh);
            this.panel2.Controls.Add(this.BtnDelHH);
            this.panel2.Controls.Add(this.btnAddHH);
            this.panel2.Controls.Add(this.txtDonGia);
            this.panel2.Controls.Add(this.nudSoLuong);
            this.panel2.Controls.Add(this.cbTenHH);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dgvCTSP);
            this.panel2.Location = new System.Drawing.Point(206, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 220);
            this.panel2.TabIndex = 5;
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Location = new System.Drawing.Point(318, 29);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(57, 20);
            this.txtGiamGia.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(191, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "ĐVT";
            // 
            // cbDonViTinh
            // 
            this.cbDonViTinh.FormattingEnabled = true;
            this.cbDonViTinh.Location = new System.Drawing.Point(194, 28);
            this.cbDonViTinh.Name = "cbDonViTinh";
            this.cbDonViTinh.Size = new System.Drawing.Size(55, 21);
            this.cbDonViTinh.TabIndex = 13;
            // 
            // BtnDelHH
            // 
            this.BtnDelHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelHH.Location = new System.Drawing.Point(336, 53);
            this.BtnDelHH.Name = "BtnDelHH";
            this.BtnDelHH.Size = new System.Drawing.Size(42, 24);
            this.BtnDelHH.TabIndex = 12;
            this.BtnDelHH.Text = "Xoá";
            this.BtnDelHH.UseVisualStyleBackColor = true;
            // 
            // btnAddHH
            // 
            this.btnAddHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHH.Location = new System.Drawing.Point(288, 53);
            this.btnAddHH.Name = "btnAddHH";
            this.btnAddHH.Size = new System.Drawing.Size(42, 24);
            this.btnAddHH.TabIndex = 11;
            this.btnAddHH.Text = "Thêm";
            this.btnAddHH.UseVisualStyleBackColor = true;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(255, 28);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(57, 20);
            this.txtDonGia.TabIndex = 10;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(124, 28);
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(64, 20);
            this.nudSoLuong.TabIndex = 7;
            // 
            // cbTenHH
            // 
            this.cbTenHH.FormattingEnabled = true;
            this.cbTenHH.Location = new System.Drawing.Point(3, 27);
            this.cbTenHH.Name = "cbTenHH";
            this.cbTenHH.Size = new System.Drawing.Size(115, 21);
            this.cbTenHH.TabIndex = 5;
            this.cbTenHH.SelectedIndexChanged += new System.EventHandler(this.cbTenHH_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Giảm giá";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Đơn giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số lượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mặt hàng";
            // 
            // FrmTinhTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTinhTien";
            this.Text = "Tính tiền";
            this.Load += new System.EventHandler(this.FrmTinhTien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTSP)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cbLoaiHH;
        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.DataGridView dgvCTSP;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTenHH;
        private System.Windows.Forms.Button btnAddHH;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button BtnDelHH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDonViTinh;
        private System.Windows.Forms.TextBox txtGiamGia;
    }
}