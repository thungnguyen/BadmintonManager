namespace BadmintonManager.GUI
{
    partial class Form4
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
            this.maBCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maLoaiBCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maHDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maHDSPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maDatSanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgianBDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgianKTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongDoanhThuSanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongDoanhThuSPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongDoanhThuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baoCaoDoanhThuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLySanDataSet = new BadmintonManager.QuanLySanDataSet();
            this.baoCaoDoanhThuTableAdapter = new BadmintonManager.QuanLySanDataSetTableAdapters.BaoCaoDoanhThuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baoCaoDoanhThuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maBCDataGridViewTextBoxColumn,
            this.maLoaiBCDataGridViewTextBoxColumn,
            this.maHDDataGridViewTextBoxColumn,
            this.maHDSPDataGridViewTextBoxColumn,
            this.maDatSanDataGridViewTextBoxColumn,
            this.tgianBDDataGridViewTextBoxColumn,
            this.tgianKTDataGridViewTextBoxColumn,
            this.tongDoanhThuSanDataGridViewTextBoxColumn,
            this.tongDoanhThuSPDataGridViewTextBoxColumn,
            this.tongDoanhThuDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.baoCaoDoanhThuBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(-5, 163);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1265, 250);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // maBCDataGridViewTextBoxColumn
            // 
            this.maBCDataGridViewTextBoxColumn.DataPropertyName = "MaBC";
            this.maBCDataGridViewTextBoxColumn.HeaderText = "MaBC";
            this.maBCDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maBCDataGridViewTextBoxColumn.Name = "maBCDataGridViewTextBoxColumn";
            this.maBCDataGridViewTextBoxColumn.Width = 150;
            // 
            // maLoaiBCDataGridViewTextBoxColumn
            // 
            this.maLoaiBCDataGridViewTextBoxColumn.DataPropertyName = "MaLoaiBC";
            this.maLoaiBCDataGridViewTextBoxColumn.HeaderText = "MaLoaiBC";
            this.maLoaiBCDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maLoaiBCDataGridViewTextBoxColumn.Name = "maLoaiBCDataGridViewTextBoxColumn";
            this.maLoaiBCDataGridViewTextBoxColumn.Width = 150;
            // 
            // maHDDataGridViewTextBoxColumn
            // 
            this.maHDDataGridViewTextBoxColumn.DataPropertyName = "MaHD";
            this.maHDDataGridViewTextBoxColumn.HeaderText = "MaHD";
            this.maHDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maHDDataGridViewTextBoxColumn.Name = "maHDDataGridViewTextBoxColumn";
            this.maHDDataGridViewTextBoxColumn.Width = 150;
            // 
            // maHDSPDataGridViewTextBoxColumn
            // 
            this.maHDSPDataGridViewTextBoxColumn.DataPropertyName = "MaHDSP";
            this.maHDSPDataGridViewTextBoxColumn.HeaderText = "MaHDSP";
            this.maHDSPDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maHDSPDataGridViewTextBoxColumn.Name = "maHDSPDataGridViewTextBoxColumn";
            this.maHDSPDataGridViewTextBoxColumn.Width = 150;
            // 
            // maDatSanDataGridViewTextBoxColumn
            // 
            this.maDatSanDataGridViewTextBoxColumn.DataPropertyName = "MaDatSan";
            this.maDatSanDataGridViewTextBoxColumn.HeaderText = "MaDatSan";
            this.maDatSanDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maDatSanDataGridViewTextBoxColumn.Name = "maDatSanDataGridViewTextBoxColumn";
            this.maDatSanDataGridViewTextBoxColumn.Width = 150;
            // 
            // tgianBDDataGridViewTextBoxColumn
            // 
            this.tgianBDDataGridViewTextBoxColumn.DataPropertyName = "TgianBD";
            this.tgianBDDataGridViewTextBoxColumn.HeaderText = "TgianBD";
            this.tgianBDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.tgianBDDataGridViewTextBoxColumn.Name = "tgianBDDataGridViewTextBoxColumn";
            this.tgianBDDataGridViewTextBoxColumn.Width = 150;
            // 
            // tgianKTDataGridViewTextBoxColumn
            // 
            this.tgianKTDataGridViewTextBoxColumn.DataPropertyName = "TgianKT";
            this.tgianKTDataGridViewTextBoxColumn.HeaderText = "TgianKT";
            this.tgianKTDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.tgianKTDataGridViewTextBoxColumn.Name = "tgianKTDataGridViewTextBoxColumn";
            this.tgianKTDataGridViewTextBoxColumn.Width = 150;
            // 
            // tongDoanhThuSanDataGridViewTextBoxColumn
            // 
            this.tongDoanhThuSanDataGridViewTextBoxColumn.DataPropertyName = "TongDoanhThuSan";
            this.tongDoanhThuSanDataGridViewTextBoxColumn.HeaderText = "TongDoanhThuSan";
            this.tongDoanhThuSanDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.tongDoanhThuSanDataGridViewTextBoxColumn.Name = "tongDoanhThuSanDataGridViewTextBoxColumn";
            this.tongDoanhThuSanDataGridViewTextBoxColumn.Width = 150;
            // 
            // tongDoanhThuSPDataGridViewTextBoxColumn
            // 
            this.tongDoanhThuSPDataGridViewTextBoxColumn.DataPropertyName = "TongDoanhThuSP";
            this.tongDoanhThuSPDataGridViewTextBoxColumn.HeaderText = "TongDoanhThuSP";
            this.tongDoanhThuSPDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.tongDoanhThuSPDataGridViewTextBoxColumn.Name = "tongDoanhThuSPDataGridViewTextBoxColumn";
            this.tongDoanhThuSPDataGridViewTextBoxColumn.Width = 150;
            // 
            // tongDoanhThuDataGridViewTextBoxColumn
            // 
            this.tongDoanhThuDataGridViewTextBoxColumn.DataPropertyName = "TongDoanhThu";
            this.tongDoanhThuDataGridViewTextBoxColumn.HeaderText = "TongDoanhThu";
            this.tongDoanhThuDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.tongDoanhThuDataGridViewTextBoxColumn.Name = "tongDoanhThuDataGridViewTextBoxColumn";
            this.tongDoanhThuDataGridViewTextBoxColumn.Width = 150;
            // 
            // baoCaoDoanhThuBindingSource
            // 
            this.baoCaoDoanhThuBindingSource.DataMember = "BaoCaoDoanhThu";
            this.baoCaoDoanhThuBindingSource.DataSource = this.quanLySanDataSet;
            // 
            // quanLySanDataSet
            // 
            this.quanLySanDataSet.DataSetName = "QuanLySanDataSet";
            this.quanLySanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // baoCaoDoanhThuTableAdapter
            // 
            this.baoCaoDoanhThuTableAdapter.ClearBeforeFill = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baoCaoDoanhThuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private QuanLySanDataSet quanLySanDataSet;
        private System.Windows.Forms.BindingSource baoCaoDoanhThuBindingSource;
        private QuanLySanDataSetTableAdapters.BaoCaoDoanhThuTableAdapter baoCaoDoanhThuTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn maBCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maLoaiBCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maHDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maHDSPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDatSanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgianBDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgianKTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongDoanhThuSanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongDoanhThuSPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongDoanhThuDataGridViewTextBoxColumn;
    }
}