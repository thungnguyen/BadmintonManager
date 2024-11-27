namespace BadmintonManager.GUI
{
    partial class GiaSan
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
            this.dgvGiaSan = new System.Windows.Forms.DataGridView();
            this.maGiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maLoaiKHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioBatDauDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioKetThucDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaSanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLySanDataSet = new BadmintonManager.QuanLySanDataSet();
            this.giaSanTableAdapter = new BadmintonManager.QuanLySanDataSetTableAdapters.GiaSanTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaGia = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.cbLoaiKH = new System.Windows.Forms.ComboBox();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaSanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(319, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giá Sân";
            // 
            // dgvGiaSan
            // 
            this.dgvGiaSan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGiaSan.AutoGenerateColumns = false;
            this.dgvGiaSan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaSan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maGiaDataGridViewTextBoxColumn,
            this.maLoaiKHDataGridViewTextBoxColumn,
            this.giaDataGridViewTextBoxColumn,
            this.gioBatDauDataGridViewTextBoxColumn,
            this.gioKetThucDataGridViewTextBoxColumn});
            this.dgvGiaSan.DataSource = this.giaSanBindingSource;
            this.dgvGiaSan.Location = new System.Drawing.Point(12, 267);
            this.dgvGiaSan.Name = "dgvGiaSan";
            this.dgvGiaSan.Size = new System.Drawing.Size(544, 171);
            this.dgvGiaSan.TabIndex = 1;
            this.dgvGiaSan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGiaSan_CellClick);
            // 
            // maGiaDataGridViewTextBoxColumn
            // 
            this.maGiaDataGridViewTextBoxColumn.DataPropertyName = "MaGia";
            this.maGiaDataGridViewTextBoxColumn.HeaderText = "MaGia";
            this.maGiaDataGridViewTextBoxColumn.Name = "maGiaDataGridViewTextBoxColumn";
            // 
            // maLoaiKHDataGridViewTextBoxColumn
            // 
            this.maLoaiKHDataGridViewTextBoxColumn.DataPropertyName = "MaLoaiKH";
            this.maLoaiKHDataGridViewTextBoxColumn.HeaderText = "MaLoaiKH";
            this.maLoaiKHDataGridViewTextBoxColumn.Name = "maLoaiKHDataGridViewTextBoxColumn";
            // 
            // giaDataGridViewTextBoxColumn
            // 
            this.giaDataGridViewTextBoxColumn.DataPropertyName = "Gia";
            this.giaDataGridViewTextBoxColumn.HeaderText = "Gia";
            this.giaDataGridViewTextBoxColumn.Name = "giaDataGridViewTextBoxColumn";
            // 
            // gioBatDauDataGridViewTextBoxColumn
            // 
            this.gioBatDauDataGridViewTextBoxColumn.DataPropertyName = "GioBatDau";
            this.gioBatDauDataGridViewTextBoxColumn.HeaderText = "GioBatDau";
            this.gioBatDauDataGridViewTextBoxColumn.Name = "gioBatDauDataGridViewTextBoxColumn";
            // 
            // gioKetThucDataGridViewTextBoxColumn
            // 
            this.gioKetThucDataGridViewTextBoxColumn.DataPropertyName = "GioKetThuc";
            this.gioKetThucDataGridViewTextBoxColumn.HeaderText = "GioKetThuc";
            this.gioKetThucDataGridViewTextBoxColumn.Name = "gioKetThucDataGridViewTextBoxColumn";
            // 
            // giaSanBindingSource
            // 
            this.giaSanBindingSource.DataMember = "GiaSan";
            this.giaSanBindingSource.DataSource = this.quanLySanDataSet;
            // 
            // quanLySanDataSet
            // 
            this.quanLySanDataSet.DataSetName = "QuanLySanDataSet";
            this.quanLySanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // giaSanTableAdapter
            // 
            this.giaSanTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Giá:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Loại KH:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Giá:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Giờ kết thúc:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Giờ bắt đầu:";
            // 
            // txtMaGia
            // 
            this.txtMaGia.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtMaGia.Location = new System.Drawing.Point(123, 79);
            this.txtMaGia.Name = "txtMaGia";
            this.txtMaGia.Size = new System.Drawing.Size(200, 20);
            this.txtMaGia.TabIndex = 7;
            // 
            // txtGia
            // 
            this.txtGia.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtGia.Location = new System.Drawing.Point(123, 153);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(200, 20);
            this.txtGia.TabIndex = 8;
            // 
            // cbLoaiKH
            // 
            this.cbLoaiKH.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbLoaiKH.FormattingEnabled = true;
            this.cbLoaiKH.Location = new System.Drawing.Point(123, 115);
            this.cbLoaiKH.Name = "cbLoaiKH";
            this.cbLoaiKH.Size = new System.Drawing.Size(200, 21);
            this.cbLoaiKH.TabIndex = 9;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBegin.Location = new System.Drawing.Point(123, 186);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.ShowUpDown = true;
            this.dtpBegin.Size = new System.Drawing.Size(200, 20);
            this.dtpBegin.TabIndex = 10;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEnd.Location = new System.Drawing.Point(123, 219);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpEnd.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAdd.Location = new System.Drawing.Point(367, 79);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 39);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUpdate.Location = new System.Drawing.Point(367, 134);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(66, 39);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.Location = new System.Drawing.Point(367, 186);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 39);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // GiaSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpBegin);
            this.Controls.Add(this.cbLoaiKH);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.txtMaGia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvGiaSan);
            this.Controls.Add(this.label1);
            this.Name = "GiaSan";
            this.Text = "GiaSan";
            this.Load += new System.EventHandler(this.GiaSan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaSanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvGiaSan;
        private QuanLySanDataSet quanLySanDataSet;
        private System.Windows.Forms.BindingSource giaSanBindingSource;
        private QuanLySanDataSetTableAdapters.GiaSanTableAdapter giaSanTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn maGiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maLoaiKHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioBatDauDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioKetThucDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaGia;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.ComboBox cbLoaiKH;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}