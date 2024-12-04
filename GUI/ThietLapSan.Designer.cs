namespace BadmintonManager.GUI
{
    partial class ThietLapSan
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
            this.dgvDanhSachSan = new System.Windows.Forms.DataGridView();
            this.sanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLySanDataSet = new BadmintonManager.QuanLySanDataSet();
            this.sanTableAdapter = new BadmintonManager.QuanLySanDataSetTableAdapters.SanTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenSan = new System.Windows.Forms.TextBox();
            this.txtMaSan = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPrices = new System.Windows.Forms.Button();
            this.maSanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thiết Lập Sân";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvDanhSachSan
            // 
            this.dgvDanhSachSan.AutoGenerateColumns = false;
            this.dgvDanhSachSan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachSan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maSanDataGridViewTextBoxColumn,
            this.tenSanDataGridViewTextBoxColumn});
            this.dgvDanhSachSan.DataSource = this.sanBindingSource;
            this.dgvDanhSachSan.Location = new System.Drawing.Point(22, 118);
            this.dgvDanhSachSan.Name = "dgvDanhSachSan";
            this.dgvDanhSachSan.Size = new System.Drawing.Size(245, 215);
            this.dgvDanhSachSan.TabIndex = 1;
            this.dgvDanhSachSan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachSan_CellClick);
            // 
            // sanBindingSource
            // 
            this.sanBindingSource.DataMember = "San";
            this.sanBindingSource.DataSource = this.quanLySanDataSet;
            // 
            // quanLySanDataSet
            // 
            this.quanLySanDataSet.DataSetName = "QuanLySanDataSet";
            this.quanLySanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sanTableAdapter
            // 
            this.sanTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Sân:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã sân:";
            // 
            // txtTenSan
            // 
            this.txtTenSan.Location = new System.Drawing.Point(371, 127);
            this.txtTenSan.Name = "txtTenSan";
            this.txtTenSan.Size = new System.Drawing.Size(207, 20);
            this.txtTenSan.TabIndex = 4;
            // 
            // txtMaSan
            // 
            this.txtMaSan.Location = new System.Drawing.Point(371, 168);
            this.txtMaSan.Name = "txtMaSan";
            this.txtMaSan.Size = new System.Drawing.Size(207, 20);
            this.txtMaSan.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(315, 222);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 30);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(419, 222);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(98, 30);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(523, 222);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 30);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrices
            // 
            this.btnPrices.Location = new System.Drawing.Point(315, 277);
            this.btnPrices.Name = "btnPrices";
            this.btnPrices.Size = new System.Drawing.Size(98, 30);
            this.btnPrices.TabIndex = 9;
            this.btnPrices.Text = "Giá sân";
            this.btnPrices.UseVisualStyleBackColor = true;
            this.btnPrices.Click += new System.EventHandler(this.btnPrices_Click);
            // 
            // maSanDataGridViewTextBoxColumn
            // 
            this.maSanDataGridViewTextBoxColumn.DataPropertyName = "MaSan";
            this.maSanDataGridViewTextBoxColumn.HeaderText = "MaSan";
            this.maSanDataGridViewTextBoxColumn.Name = "maSanDataGridViewTextBoxColumn";
            // 
            // tenSanDataGridViewTextBoxColumn
            // 
            this.tenSanDataGridViewTextBoxColumn.DataPropertyName = "TenSan";
            this.tenSanDataGridViewTextBoxColumn.HeaderText = "TenSan";
            this.tenSanDataGridViewTextBoxColumn.Name = "tenSanDataGridViewTextBoxColumn";
            // 
            // ThietLapSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 450);
            this.Controls.Add(this.btnPrices);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtMaSan);
            this.Controls.Add(this.txtTenSan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDanhSachSan);
            this.Controls.Add(this.label1);
            this.Name = "ThietLapSan";
            this.Text = "Thiết Lập Sân";
            this.Load += new System.EventHandler(this.ThietLapSan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDanhSachSan;
        private QuanLySanDataSet quanLySanDataSet;
        private System.Windows.Forms.BindingSource sanBindingSource;
        private QuanLySanDataSetTableAdapters.SanTableAdapter sanTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenSan;
        private System.Windows.Forms.TextBox txtMaSan;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPrices;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSanDataGridViewTextBoxColumn;
    }
}