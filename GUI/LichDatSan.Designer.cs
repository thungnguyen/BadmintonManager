namespace BadmintonManager.GUI
{
    partial class LichDatSan
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
            this.dgvDatSan = new System.Windows.Forms.DataGridView();
            this.Addbookingbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LichtheoNgaypicker = new System.Windows.Forms.DateTimePicker();
            this.refreshbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatSan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatSan
            // 
            this.dgvDatSan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatSan.Location = new System.Drawing.Point(12, 116);
            this.dgvDatSan.Name = "dgvDatSan";
            this.dgvDatSan.ReadOnly = true;
            this.dgvDatSan.RowHeadersWidth = 51;
            this.dgvDatSan.RowTemplate.Height = 24;
            this.dgvDatSan.Size = new System.Drawing.Size(776, 257);
            this.dgvDatSan.TabIndex = 0;
            this.dgvDatSan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Addbookingbtn
            // 
            this.Addbookingbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addbookingbtn.Location = new System.Drawing.Point(403, 389);
            this.Addbookingbtn.Name = "Addbookingbtn";
            this.Addbookingbtn.Size = new System.Drawing.Size(113, 49);
            this.Addbookingbtn.TabIndex = 1;
            this.Addbookingbtn.Text = "Đặt Sân";
            this.Addbookingbtn.UseVisualStyleBackColor = true;
            this.Addbookingbtn.Click += new System.EventHandler(this.Addbookingbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(179, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(434, 54);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh Sách Đặt Sân";
            // 
            // LichtheoNgaypicker
            // 
            this.LichtheoNgaypicker.Location = new System.Drawing.Point(12, 88);
            this.LichtheoNgaypicker.Name = "LichtheoNgaypicker";
            this.LichtheoNgaypicker.Size = new System.Drawing.Size(200, 22);
            this.LichtheoNgaypicker.TabIndex = 3;
            this.LichtheoNgaypicker.ValueChanged += new System.EventHandler(this.LichtheoNgaypicker_ValueChanged);
            // 
            // refreshbtn
            // 
            this.refreshbtn.Location = new System.Drawing.Point(218, 87);
            this.refreshbtn.Name = "refreshbtn";
            this.refreshbtn.Size = new System.Drawing.Size(75, 23);
            this.refreshbtn.TabIndex = 4;
            this.refreshbtn.Text = "Refresh";
            this.refreshbtn.UseVisualStyleBackColor = true;
            this.refreshbtn.Click += new System.EventHandler(this.refreshbtn_Click);
            // 
            // LichDatSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.refreshbtn);
            this.Controls.Add(this.LichtheoNgaypicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Addbookingbtn);
            this.Controls.Add(this.dgvDatSan);
            this.Name = "LichDatSan";
            this.Text = "LichDatSan";
            this.Load += new System.EventHandler(this.LichDatSan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatSan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatSan;
        private System.Windows.Forms.Button Addbookingbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker LichtheoNgaypicker;
        private System.Windows.Forms.Button refreshbtn;
    }
}