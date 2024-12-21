namespace BadmintonManager.GUI
{
    partial class TaoSan
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
            this.San = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lsvSan = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaSan = new System.Windows.Forms.TextBox();
            this.tenSan = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPrices = new System.Windows.Forms.Button();
            this.txtTenSan = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // San
            // 
            this.San.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.San.AutoSize = true;
            this.San.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.San.Location = new System.Drawing.Point(235, 11);
            this.San.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.San.Name = "San";
            this.San.Size = new System.Drawing.Size(215, 31);
            this.San.TabIndex = 16;
            this.San.Text = "THIẾT LẬP SÂN";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lsvSan);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 70);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(267, 417);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // lsvSan
            // 
            this.lsvSan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lsvSan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lsvSan.FullRowSelect = true;
            this.lsvSan.HideSelection = false;
            this.lsvSan.Location = new System.Drawing.Point(4, 4);
            this.lsvSan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lsvSan.Name = "lsvSan";
            this.lsvSan.Size = new System.Drawing.Size(261, 413);
            this.lsvSan.TabIndex = 14;
            this.lsvSan.UseCompatibleStateImageBehavior = false;
            this.lsvSan.View = System.Windows.Forms.View.Details;
            this.lsvSan.SelectedIndexChanged += new System.EventHandler(this.lsvSan_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã Sân";
            this.columnHeader1.Width = 55;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Sân";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Trạng thái";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 69;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMaSan);
            this.panel1.Controls.Add(this.tenSan);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnPrices);
            this.panel1.Controls.Add(this.txtTenSan);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(291, 70);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 203);
            this.panel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Mã sân:";
            // 
            // txtMaSan
            // 
            this.txtMaSan.Location = new System.Drawing.Point(5, 31);
            this.txtMaSan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaSan.Name = "txtMaSan";
            this.txtMaSan.Size = new System.Drawing.Size(295, 22);
            this.txtMaSan.TabIndex = 13;
            // 
            // tenSan
            // 
            this.tenSan.AutoSize = true;
            this.tenSan.Location = new System.Drawing.Point(4, 66);
            this.tenSan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tenSan.Name = "tenSan";
            this.tenSan.Size = new System.Drawing.Size(61, 16);
            this.tenSan.TabIndex = 12;
            this.tenSan.Text = "Tên Sân:";
            this.tenSan.Click += new System.EventHandler(this.tenSan_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(4, 118);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 37);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPrices
            // 
            this.btnPrices.Location = new System.Drawing.Point(4, 162);
            this.btnPrices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrices.Name = "btnPrices";
            this.btnPrices.Size = new System.Drawing.Size(93, 37);
            this.btnPrices.TabIndex = 9;
            this.btnPrices.Text = "Giá sân";
            this.btnPrices.UseVisualStyleBackColor = true;
            this.btnPrices.Click += new System.EventHandler(this.btnPrices_Click);
            // 
            // txtTenSan
            // 
            this.txtTenSan.Location = new System.Drawing.Point(5, 86);
            this.txtTenSan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenSan.Name = "txtTenSan";
            this.txtTenSan.Size = new System.Drawing.Size(295, 22);
            this.txtTenSan.TabIndex = 11;
            this.txtTenSan.TextChanged += new System.EventHandler(this.txtTenSan_TextChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(105, 118);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 37);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(207, 118);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 37);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // TaoSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 537);
            this.Controls.Add(this.San);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TaoSan";
            this.Text = "TaoSan";
            this.Load += new System.EventHandler(this.TaoSan_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label San;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ListView lsvSan;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label tenSan;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPrices;
        private System.Windows.Forms.TextBox txtTenSan;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaSan;
    }
}