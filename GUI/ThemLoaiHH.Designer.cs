namespace BadmintonManager.GUI
{
    partial class ThemLoaiHH
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maLoaiHHtxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tenLoaiHHtxt = new System.Windows.Forms.TextBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm loại hàng hoá mới";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Loại HH";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // maLoaiHHtxt
            // 
            this.maLoaiHHtxt.Location = new System.Drawing.Point(104, 47);
            this.maLoaiHHtxt.Name = "maLoaiHHtxt";
            this.maLoaiHHtxt.Size = new System.Drawing.Size(358, 22);
            this.maLoaiHHtxt.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên Loại HH";
            // 
            // tenLoaiHHtxt
            // 
            this.tenLoaiHHtxt.Location = new System.Drawing.Point(104, 99);
            this.tenLoaiHHtxt.Name = "tenLoaiHHtxt";
            this.tenLoaiHHtxt.Size = new System.Drawing.Size(358, 22);
            this.tenLoaiHHtxt.TabIndex = 4;
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(387, 202);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 23);
            this.savebtn.TabIndex = 5;
            this.savebtn.Text = "Lưu";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(482, 202);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.cancelbtn.TabIndex = 6;
            this.cancelbtn.Text = "Huỷ";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // ThemLoaiHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 288);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.tenLoaiHHtxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maLoaiHHtxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ThemLoaiHH";
            this.Text = "ThemLoaiHH";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox maLoaiHHtxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tenLoaiHHtxt;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button cancelbtn;
    }
}