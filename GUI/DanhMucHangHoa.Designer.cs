namespace BadmintonManager.GUI
{
    partial class DanhMucHangHoa
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
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.addbtn = new System.Windows.Forms.Button();
            this.refreshbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchbar = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.addnewLoaiHHbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangHoa.Location = new System.Drawing.Point(12, 112);
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.ReadOnly = true;
            this.dgvHangHoa.RowHeadersWidth = 51;
            this.dgvHangHoa.RowTemplate.Height = 24;
            this.dgvHangHoa.Size = new System.Drawing.Size(1083, 365);
            this.dgvHangHoa.TabIndex = 0;
            this.dgvHangHoa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHangHoa_CellContentClick);
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(624, 483);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(153, 65);
            this.addbtn.TabIndex = 1;
            this.addbtn.Text = "Thêm danh mục mới";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // refreshbtn
            // 
            this.refreshbtn.Location = new System.Drawing.Point(465, 483);
            this.refreshbtn.Name = "refreshbtn";
            this.refreshbtn.Size = new System.Drawing.Size(153, 65);
            this.refreshbtn.TabIndex = 2;
            this.refreshbtn.Text = "Làm mới danh mục ";
            this.refreshbtn.UseVisualStyleBackColor = true;
            this.refreshbtn.Click += new System.EventHandler(this.refreshbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Danh Mục Hàng Hoá";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tìm kiếm";
            // 
            // searchbar
            // 
            this.searchbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbar.Location = new System.Drawing.Point(109, 61);
            this.searchbar.Name = "searchbar";
            this.searchbar.Size = new System.Drawing.Size(325, 27);
            this.searchbar.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(440, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 28);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(783, 483);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(153, 65);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Xoá danh mục sản phẩm";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(942, 483);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(153, 65);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Sửa danh mục sản phẩm";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // addnewLoaiHHbtn
            // 
            this.addnewLoaiHHbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addnewLoaiHHbtn.Location = new System.Drawing.Point(819, 51);
            this.addnewLoaiHHbtn.Name = "addnewLoaiHHbtn";
            this.addnewLoaiHHbtn.Size = new System.Drawing.Size(276, 46);
            this.addnewLoaiHHbtn.TabIndex = 9;
            this.addnewLoaiHHbtn.Text = "Danh sách các loại hàng hoá";
            this.addnewLoaiHHbtn.UseVisualStyleBackColor = true;
            this.addnewLoaiHHbtn.Click += new System.EventHandler(this.addnewLoaiHHbtn_Click);
            // 
            // DanhMucHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 560);
            this.Controls.Add(this.addnewLoaiHHbtn);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.searchbar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshbtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.dgvHangHoa);
            this.Name = "DanhMucHangHoa";
            this.Text = "DanhMucHangHoa";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Button refreshbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchbar;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button addnewLoaiHHbtn;
    }
}