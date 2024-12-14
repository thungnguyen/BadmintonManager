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
            this.cbHH = new System.Windows.Forms.ComboBox();
            this.lsvHangHoa = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbLoaiHH = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDonViTinh = new System.Windows.Forms.ComboBox();
            this.btnAddHH = new System.Windows.Forms.Button();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cbTenHH = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbLoaiKH = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.Button();
            this.btnTinhGiaSan = new System.Windows.Forms.Button();
            this.btnKhachMoi = new System.Windows.Forms.Button();
            this.btnChooseLichSan = new System.Windows.Forms.Button();
            this.nudSoGioThue = new System.Windows.Forms.NumericUpDown();
            this.dtpGioRa = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpGioVao = new System.Windows.Forms.DateTimePicker();
            this.cbKhachHang = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbTenSan = new System.Windows.Forms.Label();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.flpSan = new System.Windows.Forms.FlowLayoutPanel();
            this.lbListSan = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtGiaSan = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTienCuoi = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtKhachDua = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTienThua = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.nudGiamGia = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoGioThue)).BeginInit();
            this.panel6.SuspendLayout();
            this.flpSan.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiamGia)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbHH);
            this.panel1.Controls.Add(this.lsvHangHoa);
            this.panel1.Controls.Add(this.cbLoaiHH);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 593);
            this.panel1.TabIndex = 0;
            // 
            // cbHH
            // 
            this.cbHH.FormattingEnabled = true;
            this.cbHH.Location = new System.Drawing.Point(59, 57);
            this.cbHH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbHH.Name = "cbHH";
            this.cbHH.Size = new System.Drawing.Size(181, 24);
            this.cbHH.TabIndex = 9;
            this.cbHH.SelectedIndexChanged += new System.EventHandler(this.cbHH_SelectedIndexChanged);
            // 
            // lsvHangHoa
            // 
            this.lsvHangHoa.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lsvHangHoa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
            this.lsvHangHoa.FullRowSelect = true;
            this.lsvHangHoa.GridLines = true;
            this.lsvHangHoa.HideSelection = false;
            this.lsvHangHoa.Location = new System.Drawing.Point(8, 101);
            this.lsvHangHoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lsvHangHoa.Name = "lsvHangHoa";
            this.lsvHangHoa.Size = new System.Drawing.Size(232, 474);
            this.lsvHangHoa.TabIndex = 8;
            this.lsvHangHoa.UseCompatibleStateImageBehavior = false;
            this.lsvHangHoa.View = System.Windows.Forms.View.Details;
            this.lsvHangHoa.SelectedIndexChanged += new System.EventHandler(this.lsvHangHoa_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tên Hàng Hoá";
            this.columnHeader6.Width = 171;
            // 
            // cbLoaiHH
            // 
            this.cbLoaiHH.FormattingEnabled = true;
            this.cbLoaiHH.Location = new System.Drawing.Point(59, 21);
            this.cbLoaiHH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbLoaiHH.Name = "cbLoaiHH";
            this.cbLoaiHH.Size = new System.Drawing.Size(181, 24);
            this.cbLoaiHH.TabIndex = 2;
            this.cbLoaiHH.SelectedIndexChanged += new System.EventHandler(this.cbLoaiHH_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhóm";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtThanhTien);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbDonViTinh);
            this.panel2.Controls.Add(this.btnAddHH);
            this.panel2.Controls.Add(this.txtDonGia);
            this.panel2.Controls.Add(this.nudSoLuong);
            this.panel2.Controls.Add(this.cbTenHH);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(275, 245);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 271);
            this.panel2.TabIndex = 5;
            // 
            // lsvBill
            // 
            this.lsvBill.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lsvBill.FullRowSelect = true;
            this.lsvBill.GridLines = true;
            this.lsvBill.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(4, 111);
            this.lsvBill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(605, 155);
            this.lsvBill.TabIndex = 18;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            this.lsvBill.SelectedIndexChanged += new System.EventHandler(this.lsvBill_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sản phẩm";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 72;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ĐVT";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Đơn giá";
            this.columnHeader4.Width = 82;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Thành tiền";
            this.columnHeader5.Width = 90;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(489, 14);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Thành tiền";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(493, 34);
            this.txtThanhTien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(111, 22);
            this.txtThanhTien.TabIndex = 16;
            this.txtThanhTien.Text = "0";
            this.txtThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(255, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "ĐVT";
            // 
            // cbDonViTinh
            // 
            this.cbDonViTinh.FormattingEnabled = true;
            this.cbDonViTinh.Location = new System.Drawing.Point(259, 34);
            this.cbDonViTinh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDonViTinh.Name = "cbDonViTinh";
            this.cbDonViTinh.Size = new System.Drawing.Size(105, 24);
            this.cbDonViTinh.TabIndex = 13;
            this.cbDonViTinh.SelectedIndexChanged += new System.EventHandler(this.cbDonViTinh_SelectedIndexChanged);
            // 
            // btnAddHH
            // 
            this.btnAddHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHH.Location = new System.Drawing.Point(508, 68);
            this.btnAddHH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddHH.Name = "btnAddHH";
            this.btnAddHH.Size = new System.Drawing.Size(97, 36);
            this.btnAddHH.TabIndex = 11;
            this.btnAddHH.Text = "Thêm món";
            this.btnAddHH.UseVisualStyleBackColor = true;
            this.btnAddHH.Click += new System.EventHandler(this.btnAddHH_Click);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(373, 34);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(111, 22);
            this.txtDonGia.TabIndex = 10;
            this.txtDonGia.Text = "0";
            this.txtDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtDonGia_TextChanged);
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(165, 34);
            this.nudSoLuong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudSoLuong.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(85, 22);
            this.nudSoLuong.TabIndex = 7;
            this.nudSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.ValueChanged += new System.EventHandler(this.nudSoLuong_ValueChanged);
            // 
            // cbTenHH
            // 
            this.cbTenHH.FormattingEnabled = true;
            this.cbTenHH.Location = new System.Drawing.Point(4, 33);
            this.cbTenHH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbTenHH.Name = "cbTenHH";
            this.cbTenHH.Size = new System.Drawing.Size(152, 24);
            this.cbTenHH.TabIndex = 5;
            this.cbTenHH.SelectedIndexChanged += new System.EventHandler(this.cbTenHH_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(369, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Đơn giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số lượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mặt hàng";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbLoaiKH);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.BtnStart);
            this.panel4.Controls.Add(this.btnTinhGiaSan);
            this.panel4.Controls.Add(this.btnKhachMoi);
            this.panel4.Controls.Add(this.btnChooseLichSan);
            this.panel4.Controls.Add(this.nudSoGioThue);
            this.panel4.Controls.Add(this.dtpGioRa);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.dtpGioVao);
            this.panel4.Controls.Add(this.cbKhachHang);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Location = new System.Drawing.Point(275, 15);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(615, 223);
            this.panel4.TabIndex = 20;
            // 
            // cbLoaiKH
            // 
            this.cbLoaiKH.FormattingEnabled = true;
            this.cbLoaiKH.Location = new System.Drawing.Point(95, 81);
            this.cbLoaiKH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbLoaiKH.Name = "cbLoaiKH";
            this.cbLoaiKH.Size = new System.Drawing.Size(265, 24);
            this.cbLoaiKH.TabIndex = 14;
            this.cbLoaiKH.SelectedIndexChanged += new System.EventHandler(this.cbLoaiKH_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(5, 91);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 16);
            this.label18.TabIndex = 13;
            this.label18.Text = "Loại KH";
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(493, 150);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(112, 64);
            this.BtnStart.TabIndex = 12;
            this.BtnStart.Text = "Bắt đầu";
            this.BtnStart.UseVisualStyleBackColor = true;
            // 
            // btnTinhGiaSan
            // 
            this.btnTinhGiaSan.Location = new System.Drawing.Point(373, 150);
            this.btnTinhGiaSan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTinhGiaSan.Name = "btnTinhGiaSan";
            this.btnTinhGiaSan.Size = new System.Drawing.Size(112, 64);
            this.btnTinhGiaSan.TabIndex = 11;
            this.btnTinhGiaSan.Text = "Tính giá";
            this.btnTinhGiaSan.UseVisualStyleBackColor = true;
            this.btnTinhGiaSan.Click += new System.EventHandler(this.btnTinhGiaSan_Click);
            // 
            // btnKhachMoi
            // 
            this.btnKhachMoi.Location = new System.Drawing.Point(373, 75);
            this.btnKhachMoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKhachMoi.Name = "btnKhachMoi";
            this.btnKhachMoi.Size = new System.Drawing.Size(112, 64);
            this.btnKhachMoi.TabIndex = 9;
            this.btnKhachMoi.Text = "Khách mới";
            this.btnKhachMoi.UseVisualStyleBackColor = true;
            // 
            // btnChooseLichSan
            // 
            this.btnChooseLichSan.Location = new System.Drawing.Point(493, 75);
            this.btnChooseLichSan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChooseLichSan.Name = "btnChooseLichSan";
            this.btnChooseLichSan.Size = new System.Drawing.Size(112, 64);
            this.btnChooseLichSan.TabIndex = 8;
            this.btnChooseLichSan.Text = "Chọn từ lịch sân";
            this.btnChooseLichSan.UseVisualStyleBackColor = true;
            // 
            // nudSoGioThue
            // 
            this.nudSoGioThue.DecimalPlaces = 1;
            this.nudSoGioThue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudSoGioThue.Location = new System.Drawing.Point(95, 150);
            this.nudSoGioThue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudSoGioThue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoGioThue.Name = "nudSoGioThue";
            this.nudSoGioThue.Size = new System.Drawing.Size(267, 22);
            this.nudSoGioThue.TabIndex = 7;
            this.nudSoGioThue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoGioThue.ValueChanged += new System.EventHandler(this.nudSoGioThue_ValueChanged);
            // 
            // dtpGioRa
            // 
            this.dtpGioRa.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpGioRa.Location = new System.Drawing.Point(95, 182);
            this.dtpGioRa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpGioRa.Name = "dtpGioRa";
            this.dtpGioRa.Size = new System.Drawing.Size(265, 22);
            this.dtpGioRa.TabIndex = 6;
            this.dtpGioRa.ValueChanged += new System.EventHandler(this.dtpGioRa_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 191);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 16);
            this.label12.TabIndex = 5;
            this.label12.Text = "Giờ ra";
            // 
            // dtpGioVao
            // 
            this.dtpGioVao.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpGioVao.Location = new System.Drawing.Point(95, 114);
            this.dtpGioVao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpGioVao.Name = "dtpGioVao";
            this.dtpGioVao.Size = new System.Drawing.Size(265, 22);
            this.dtpGioVao.TabIndex = 4;
            this.dtpGioVao.ValueChanged += new System.EventHandler(this.dtpGioVao_ValueChanged);
            // 
            // cbKhachHang
            // 
            this.cbKhachHang.FormattingEnabled = true;
            this.cbKhachHang.Location = new System.Drawing.Point(95, 42);
            this.cbKhachHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbKhachHang.Name = "cbKhachHang";
            this.cbKhachHang.Size = new System.Drawing.Size(344, 24);
            this.cbKhachHang.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 159);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Số giờ thuê";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 122);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Giờ vào";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 52);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Khách hàng";
            // 
            // lbTenSan
            // 
            this.lbTenSan.AutoSize = true;
            this.lbTenSan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSan.Location = new System.Drawing.Point(496, 11);
            this.lbTenSan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTenSan.Name = "lbTenSan";
            this.lbTenSan.Size = new System.Drawing.Size(178, 24);
            this.lbTenSan.TabIndex = 0;
            this.lbTenSan.Text = "CHƯA CHỌN SÂN";
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(4, 4);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(153, 59);
            this.btnCheckOut.TabIndex = 22;
            this.btnCheckOut.Text = "Thanh toán";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(4, 66);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(153, 59);
            this.btnThoat.TabIndex = 24;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnCheckOut);
            this.panel6.Controls.Add(this.btnThoat);
            this.panel6.Location = new System.Drawing.Point(893, 479);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(161, 129);
            this.panel6.TabIndex = 25;
            // 
            // flpSan
            // 
            this.flpSan.AutoScroll = true;
            this.flpSan.Controls.Add(this.lbListSan);
            this.flpSan.Location = new System.Drawing.Point(893, 15);
            this.flpSan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpSan.Name = "flpSan";
            this.flpSan.Size = new System.Drawing.Size(161, 460);
            this.flpSan.TabIndex = 26;
            // 
            // lbListSan
            // 
            this.lbListSan.AutoSize = true;
            this.lbListSan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbListSan.Location = new System.Drawing.Point(4, 0);
            this.lbListSan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 15);
            this.lbListSan.Name = "lbListSan";
            this.lbListSan.Size = new System.Drawing.Size(146, 19);
            this.lbListSan.TabIndex = 27;
            this.lbListSan.Text = "DANH SÁCH SÂN";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(95, 43);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(111, 22);
            this.txtTongTien.TabIndex = 22;
            this.txtTongTien.Text = "0";
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTongTien.TextChanged += new System.EventHandler(this.txtTongTien_TextChanged);
            // 
            // txtGiaSan
            // 
            this.txtGiaSan.Location = new System.Drawing.Point(95, 14);
            this.txtGiaSan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGiaSan.Name = "txtGiaSan";
            this.txtGiaSan.ReadOnly = true;
            this.txtGiaSan.Size = new System.Drawing.Size(111, 22);
            this.txtGiaSan.TabIndex = 24;
            this.txtGiaSan.Text = "0";
            this.txtGiaSan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGiaSan.TextChanged += new System.EventHandler(this.txtGiaSan_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 22);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 25;
            this.label13.Text = "Tiền giờ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 52);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 16);
            this.label14.TabIndex = 26;
            this.label14.Text = "Tiền dịch vụ";
            // 
            // txtTienCuoi
            // 
            this.txtTienCuoi.Location = new System.Drawing.Point(296, 14);
            this.txtTienCuoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTienCuoi.Name = "txtTienCuoi";
            this.txtTienCuoi.ReadOnly = true;
            this.txtTienCuoi.Size = new System.Drawing.Size(111, 22);
            this.txtTienCuoi.TabIndex = 27;
            this.txtTienCuoi.Text = "0";
            this.txtTienCuoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTienCuoi.TextChanged += new System.EventHandler(this.txtTienCuoi_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(208, 22);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 16);
            this.label15.TabIndex = 28;
            this.label15.Text = "Tổng";
            // 
            // txtKhachDua
            // 
            this.txtKhachDua.Location = new System.Drawing.Point(296, 43);
            this.txtKhachDua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKhachDua.Name = "txtKhachDua";
            this.txtKhachDua.Size = new System.Drawing.Size(111, 22);
            this.txtKhachDua.TabIndex = 29;
            this.txtKhachDua.Text = "0";
            this.txtKhachDua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKhachDua.TextChanged += new System.EventHandler(this.txtKhachDua_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(208, 52);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 16);
            this.label16.TabIndex = 30;
            this.label16.Text = "Khách đưa";
            // 
            // txtTienThua
            // 
            this.txtTienThua.Location = new System.Drawing.Point(493, 43);
            this.txtTienThua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTienThua.Name = "txtTienThua";
            this.txtTienThua.Size = new System.Drawing.Size(111, 22);
            this.txtTienThua.TabIndex = 31;
            this.txtTienThua.Text = "0";
            this.txtTienThua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(416, 52);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 16);
            this.label17.TabIndex = 32;
            this.label17.Text = "Tiền thừa";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.nudGiamGia);
            this.panel5.Controls.Add(this.label19);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.txtTienThua);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.txtKhachDua);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.txtTienCuoi);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.txtGiaSan);
            this.panel5.Controls.Add(this.txtTongTien);
            this.panel5.Location = new System.Drawing.Point(275, 523);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(615, 85);
            this.panel5.TabIndex = 21;
            // 
            // nudGiamGia
            // 
            this.nudGiamGia.Location = new System.Drawing.Point(493, 15);
            this.nudGiamGia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudGiamGia.Name = "nudGiamGia";
            this.nudGiamGia.Size = new System.Drawing.Size(112, 22);
            this.nudGiamGia.TabIndex = 34;
            this.nudGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(416, 22);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 16);
            this.label19.TabIndex = 33;
            this.label19.Text = "Giảm giá";
            // 
            // FrmTinhTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 623);
            this.Controls.Add(this.flpSan);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.lbTenSan);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmTinhTien";
            this.Text = "Tính tiền";
            this.Load += new System.EventHandler(this.FrmTinhTien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoGioThue)).EndInit();
            this.panel6.ResumeLayout(false);
            this.flpSan.ResumeLayout(false);
            this.flpSan.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiamGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLoaiHH;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTenHH;
        private System.Windows.Forms.Button btnAddHH;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDonViTinh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbTenSan;
        private System.Windows.Forms.DateTimePicker dtpGioRa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpGioVao;
        private System.Windows.Forms.ComboBox cbKhachHang;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudSoGioThue;
        private System.Windows.Forms.Button btnChooseLichSan;
        private System.Windows.Forms.Button btnTinhGiaSan;
        private System.Windows.Forms.Button btnKhachMoi;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbLoaiKH;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.FlowLayoutPanel flpSan;
        private System.Windows.Forms.Label lbListSan;
        private System.Windows.Forms.ListView lsvHangHoa;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.ComboBox cbHH;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtGiaSan;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTienCuoi;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtKhachDua;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTienThua;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown nudGiamGia;
    }
}