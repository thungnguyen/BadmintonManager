//namespace BadmintonManager.GUI
//{
//    partial class DanhSachLoaiHH
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            this.dgvLoaiHH = new System.Windows.Forms.DataGridView();
//            this.maLoaiHHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.tenLoaiHHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.loaiHHBindingSource = new System.Windows.Forms.BindingSource(this.components);
//            this.quanLySanDataSet = new BadmintonManager.QuanLySanDataSet();
//            this.label1 = new System.Windows.Forms.Label();
//            this.loaiHHTableAdapter = new BadmintonManager.QuanLySanDataSetTableAdapters.LoaiHHTableAdapter();
//            this.maloaiHHtxt = new System.Windows.Forms.TextBox();
//            this.tenloaiHHtxt = new System.Windows.Forms.TextBox();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.savebtn = new System.Windows.Forms.Button();
//            this.cancelbtn = new System.Windows.Forms.Button();
//            this.label4 = new System.Windows.Forms.Label();
//            this.panel1 = new System.Windows.Forms.Panel();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiHH)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.loaiHHBindingSource)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).BeginInit();
//            this.panel1.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // dgvLoaiHH
//            // 
//            this.dgvLoaiHH.AutoGenerateColumns = false;
//            this.dgvLoaiHH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvLoaiHH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.maLoaiHHDataGridViewTextBoxColumn,
//            this.tenLoaiHHDataGridViewTextBoxColumn});
//            this.dgvLoaiHH.DataSource = this.loaiHHBindingSource;
//            this.dgvLoaiHH.Location = new System.Drawing.Point(12, 73);
//            this.dgvLoaiHH.Name = "dgvLoaiHH";
//            this.dgvLoaiHH.RowHeadersWidth = 51;
//            this.dgvLoaiHH.RowTemplate.Height = 24;
//            this.dgvLoaiHH.Size = new System.Drawing.Size(322, 223);
//            this.dgvLoaiHH.TabIndex = 0;
//            this.dgvLoaiHH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiHH_CellContentClick);
//            // 
//            // maLoaiHHDataGridViewTextBoxColumn
//            // 
//            this.maLoaiHHDataGridViewTextBoxColumn.DataPropertyName = "MaLoaiHH";
//            this.maLoaiHHDataGridViewTextBoxColumn.HeaderText = "MaLoaiHH";
//            this.maLoaiHHDataGridViewTextBoxColumn.MinimumWidth = 6;
//            this.maLoaiHHDataGridViewTextBoxColumn.Name = "maLoaiHHDataGridViewTextBoxColumn";
//            this.maLoaiHHDataGridViewTextBoxColumn.ReadOnly = true;
//            this.maLoaiHHDataGridViewTextBoxColumn.Width = 125;
//            // 
//            // tenLoaiHHDataGridViewTextBoxColumn
//            // 
//            this.tenLoaiHHDataGridViewTextBoxColumn.DataPropertyName = "TenLoaiHH";
//            this.tenLoaiHHDataGridViewTextBoxColumn.HeaderText = "TenLoaiHH";
//            this.tenLoaiHHDataGridViewTextBoxColumn.MinimumWidth = 6;
//            this.tenLoaiHHDataGridViewTextBoxColumn.Name = "tenLoaiHHDataGridViewTextBoxColumn";
//            this.tenLoaiHHDataGridViewTextBoxColumn.Width = 125;
//            // 
//            // loaiHHBindingSource
//            // 
//            this.loaiHHBindingSource.DataMember = "LoaiHH";
//            this.loaiHHBindingSource.DataSource = this.quanLySanDataSet;
//            // 
//            // quanLySanDataSet
//            // 
//            this.quanLySanDataSet.DataSetName = "QuanLySanDataSet";
//            this.quanLySanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label1.Location = new System.Drawing.Point(12, 25);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(228, 25);
//            this.label1.TabIndex = 1;
//            this.label1.Text = "Danh sách loại hàng hoá";
//            // 
//            // loaiHHTableAdapter
//            // 
//            this.loaiHHTableAdapter.ClearBeforeFill = true;
//            // 
//            // maloaiHHtxt
//            // 
//            this.maloaiHHtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.maloaiHHtxt.Location = new System.Drawing.Point(203, 70);
//            this.maloaiHHtxt.Name = "maloaiHHtxt";
//            this.maloaiHHtxt.Size = new System.Drawing.Size(173, 27);
//            this.maloaiHHtxt.TabIndex = 2;
//            // 
//            // tenloaiHHtxt
//            // 
//            this.tenloaiHHtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.tenloaiHHtxt.Location = new System.Drawing.Point(203, 114);
//            this.tenloaiHHtxt.Name = "tenloaiHHtxt";
//            this.tenloaiHHtxt.Size = new System.Drawing.Size(173, 27);
//            this.tenloaiHHtxt.TabIndex = 3;
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label2.Location = new System.Drawing.Point(10, 72);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(175, 25);
//            this.label2.TabIndex = 4;
//            this.label2.Text = "Mã Loại Hàng Hoá";
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label3.Location = new System.Drawing.Point(10, 113);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(182, 25);
//            this.label3.TabIndex = 5;
//            this.label3.Text = "Tên Loại Hàng Hoá";
//            // 
//            // savebtn
//            // 
//            this.savebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.savebtn.Location = new System.Drawing.Point(203, 158);
//            this.savebtn.Name = "savebtn";
//            this.savebtn.Size = new System.Drawing.Size(75, 35);
//            this.savebtn.TabIndex = 6;
//            this.savebtn.Text = "Thêm";
//            this.savebtn.UseVisualStyleBackColor = true;
//            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
//            // 
//            // cancelbtn
//            // 
//            this.cancelbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.cancelbtn.Location = new System.Drawing.Point(301, 158);
//            this.cancelbtn.Name = "cancelbtn";
//            this.cancelbtn.Size = new System.Drawing.Size(75, 35);
//            this.cancelbtn.TabIndex = 7;
//            this.cancelbtn.Text = "Huỷ";
//            this.cancelbtn.UseVisualStyleBackColor = true;
//            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label4.Location = new System.Drawing.Point(3, 24);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(221, 25);
//            this.label4.TabIndex = 8;
//            this.label4.Text = "Thêm loại hàng hoá mới";
//            // 
//            // panel1
//            // 
//            this.panel1.Controls.Add(this.cancelbtn);
//            this.panel1.Controls.Add(this.label4);
//            this.panel1.Controls.Add(this.savebtn);
//            this.panel1.Controls.Add(this.label2);
//            this.panel1.Controls.Add(this.tenloaiHHtxt);
//            this.panel1.Controls.Add(this.label3);
//            this.panel1.Controls.Add(this.maloaiHHtxt);
//            this.panel1.Location = new System.Drawing.Point(345, 12);
//            this.panel1.Name = "panel1";
//            this.panel1.Size = new System.Drawing.Size(443, 310);
//            this.panel1.TabIndex = 9;
//            // 
//            // DanhSachLoaiHH
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(800, 425);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.dgvLoaiHH);
//            this.Controls.Add(this.panel1);
//            this.Name = "DanhSachLoaiHH";
//            this.Text = "DanhSachLoaiHH";
//            this.Load += new System.EventHandler(this.DanhSachLoaiHH_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiHH)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.loaiHHBindingSource)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.quanLySanDataSet)).EndInit();
//            this.panel1.ResumeLayout(false);
//            this.panel1.PerformLayout();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.DataGridView dgvLoaiHH;
//        private System.Windows.Forms.Label label1;
//        //private QuanLySanDataSet quanLySanDataSet;
//        private System.Windows.Forms.BindingSource loaiHHBindingSource;
//        private QuanLySanDataSetTableAdapters.LoaiHHTableAdapter loaiHHTableAdapter;
//        private System.Windows.Forms.DataGridViewTextBoxColumn maLoaiHHDataGridViewTextBoxColumn;
//        private System.Windows.Forms.DataGridViewTextBoxColumn tenLoaiHHDataGridViewTextBoxColumn;
//        private System.Windows.Forms.TextBox maloaiHHtxt;
//        private System.Windows.Forms.TextBox tenloaiHHtxt;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.Button savebtn;
//        private System.Windows.Forms.Button cancelbtn;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.Panel panel1;
//    }
//}