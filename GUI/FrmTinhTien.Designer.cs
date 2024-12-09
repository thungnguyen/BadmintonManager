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
            this.btnSearch = new System.Windows.Forms.Button();
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
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDonViTinh = new System.Windows.Forms.ComboBox();
            this.btnDelHH = new System.Windows.Forms.Button();
            this.btnAddHH = new System.Windows.Forms.Button();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cbTenHH = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbLoaiKH = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.Button();
            this.btnDoiGio = new System.Windows.Forms.Button();
            this.btnTimKhach = new System.Windows.Forms.Button();
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTienThua = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtKhachDua = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTienCuoi = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGiaSan = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.flpSan = new System.Windows.Forms.FlowLayoutPanel();
            this.lbListSan = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoGioThue)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.flpSan.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbHH);
            this.panel1.Controls.Add(this.lsvHangHoa);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cbLoaiHH);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 482);
            this.panel1.TabIndex = 0;
            // 
            // cbHH
            // 
            this.cbHH.FormattingEnabled = true;
            this.cbHH.Location = new System.Drawing.Point(44, 43);
            this.cbHH.Name = "cbHH";
            this.cbHH.Size = new System.Drawing.Size(89, 21);
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
            this.lsvHangHoa.Location = new System.Drawing.Point(6, 82);
            this.lsvHangHoa.Name = "lsvHangHoa";
            this.lsvHangHoa.Size = new System.Drawing.Size(175, 386);
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
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(139, 43);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(42, 21);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbLoaiHH
            // 
            this.cbLoaiHH.FormattingEnabled = true;
            this.cbLoaiHH.Location = new System.Drawing.Point(44, 17);
            this.cbLoaiHH.Name = "cbLoaiHH";
            this.cbLoaiHH.Size = new System.Drawing.Size(137, 21);
            this.cbLoaiHH.TabIndex = 2;
            this.cbLoaiHH.SelectedIndexChanged += new System.EventHandler(this.cbLoaiHH_SelectedIndexChanged);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtThanhTien);
            this.panel2.Controls.Add(this.txtGiamGia);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbDonViTinh);
            this.panel2.Controls.Add(this.btnDelHH);
            this.panel2.Controls.Add(this.btnAddHH);
            this.panel2.Controls.Add(this.txtDonGia);
            this.panel2.Controls.Add(this.nudSoLuong);
            this.panel2.Controls.Add(this.cbTenHH);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(206, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(461, 220);
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
            this.lsvBill.Location = new System.Drawing.Point(3, 90);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(455, 127);
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
            this.label8.Location = new System.Drawing.Point(315, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Thành tiền";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(315, 29);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(63, 20);
            this.txtThanhTien.TabIndex = 16;
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Location = new System.Drawing.Point(384, 29);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(74, 20);
            this.txtGiamGia.TabIndex = 15;
            this.txtGiamGia.Text = "0";
            this.txtGiamGia.TextChanged += new System.EventHandler(this.txtGiamGia_TextChanged);
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
            this.cbDonViTinh.SelectedIndexChanged += new System.EventHandler(this.cbDonViTinh_SelectedIndexChanged);
            // 
            // btnDelHH
            // 
            this.btnDelHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelHH.Location = new System.Drawing.Point(405, 55);
            this.btnDelHH.Name = "btnDelHH";
            this.btnDelHH.Size = new System.Drawing.Size(42, 29);
            this.btnDelHH.TabIndex = 12;
            this.btnDelHH.Text = "Xoá";
            this.btnDelHH.UseVisualStyleBackColor = true;
            this.btnDelHH.Click += new System.EventHandler(this.btnDelHH_Click);
            // 
            // btnAddHH
            // 
            this.btnAddHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHH.Location = new System.Drawing.Point(326, 55);
            this.btnAddHH.Name = "btnAddHH";
            this.btnAddHH.Size = new System.Drawing.Size(73, 29);
            this.btnAddHH.TabIndex = 11;
            this.btnAddHH.Text = "Thêm món";
            this.btnAddHH.UseVisualStyleBackColor = true;
            this.btnAddHH.Click += new System.EventHandler(this.btnAddHH_Click);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(255, 28);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(57, 20);
            this.txtDonGia.TabIndex = 10;
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtDonGia_TextChanged);
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(124, 28);
            this.nudSoLuong.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(64, 20);
            this.nudSoLuong.TabIndex = 7;
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
            this.cbTenHH.Location = new System.Drawing.Point(3, 27);
            this.cbTenHH.Name = "cbTenHH";
            this.cbTenHH.Size = new System.Drawing.Size(115, 21);
            this.cbTenHH.TabIndex = 5;
            this.cbTenHH.SelectedIndexChanged += new System.EventHandler(this.cbTenHH_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(384, 11);
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
            // panel4
            // 
            this.panel4.Controls.Add(this.cbLoaiKH);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.BtnStart);
            this.panel4.Controls.Add(this.btnDoiGio);
            this.panel4.Controls.Add(this.btnTimKhach);
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
            this.panel4.Location = new System.Drawing.Point(206, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(461, 181);
            this.panel4.TabIndex = 20;
            // 
            // cbLoaiKH
            // 
            this.cbLoaiKH.FormattingEnabled = true;
            this.cbLoaiKH.Location = new System.Drawing.Point(71, 61);
            this.cbLoaiKH.Name = "cbLoaiKH";
            this.cbLoaiKH.Size = new System.Drawing.Size(200, 21);
            this.cbLoaiKH.TabIndex = 14;
            this.cbLoaiKH.SelectedIndexChanged += new System.EventHandler(this.cbLoaiKH_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Loại KH";
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(370, 122);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(84, 46);
            this.BtnStart.TabIndex = 12;
            this.BtnStart.Text = "Bắt đầu";
            this.BtnStart.UseVisualStyleBackColor = true;
            // 
            // btnDoiGio
            // 
            this.btnDoiGio.Location = new System.Drawing.Point(280, 122);
            this.btnDoiGio.Name = "btnDoiGio";
            this.btnDoiGio.Size = new System.Drawing.Size(84, 46);
            this.btnDoiGio.TabIndex = 11;
            this.btnDoiGio.Text = "Đổi giờ";
            this.btnDoiGio.UseVisualStyleBackColor = true;
            // 
            // btnTimKhach
            // 
            this.btnTimKhach.Location = new System.Drawing.Point(370, 61);
            this.btnTimKhach.Name = "btnTimKhach";
            this.btnTimKhach.Size = new System.Drawing.Size(84, 46);
            this.btnTimKhach.TabIndex = 10;
            this.btnTimKhach.Text = "Tìm tên";
            this.btnTimKhach.UseVisualStyleBackColor = true;
            // 
            // btnKhachMoi
            // 
            this.btnKhachMoi.Location = new System.Drawing.Point(280, 61);
            this.btnKhachMoi.Name = "btnKhachMoi";
            this.btnKhachMoi.Size = new System.Drawing.Size(84, 46);
            this.btnKhachMoi.TabIndex = 9;
            this.btnKhachMoi.Text = "Khách mới";
            this.btnKhachMoi.UseVisualStyleBackColor = true;
            // 
            // btnChooseLichSan
            // 
            this.btnChooseLichSan.Location = new System.Drawing.Point(339, 29);
            this.btnChooseLichSan.Name = "btnChooseLichSan";
            this.btnChooseLichSan.Size = new System.Drawing.Size(115, 26);
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
            this.nudSoGioThue.Location = new System.Drawing.Point(71, 122);
            this.nudSoGioThue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoGioThue.Name = "nudSoGioThue";
            this.nudSoGioThue.Size = new System.Drawing.Size(200, 20);
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
            this.dtpGioRa.Location = new System.Drawing.Point(71, 148);
            this.dtpGioRa.Name = "dtpGioRa";
            this.dtpGioRa.Size = new System.Drawing.Size(200, 20);
            this.dtpGioRa.TabIndex = 6;
            this.dtpGioRa.ValueChanged += new System.EventHandler(this.dtpGioRa_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Giờ ra";
            // 
            // dtpGioVao
            // 
            this.dtpGioVao.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpGioVao.Location = new System.Drawing.Point(71, 93);
            this.dtpGioVao.Name = "dtpGioVao";
            this.dtpGioVao.Size = new System.Drawing.Size(200, 20);
            this.dtpGioVao.TabIndex = 4;
            this.dtpGioVao.ValueChanged += new System.EventHandler(this.dtpGioVao_ValueChanged);
            // 
            // cbKhachHang
            // 
            this.cbKhachHang.FormattingEnabled = true;
            this.cbKhachHang.Location = new System.Drawing.Point(71, 29);
            this.cbKhachHang.Name = "cbKhachHang";
            this.cbKhachHang.Size = new System.Drawing.Size(259, 21);
            this.cbKhachHang.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Số giờ thuê";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Giờ vào";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Khách hàng";
            // 
            // lbTenSan
            // 
            this.lbTenSan.AutoSize = true;
            this.lbTenSan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSan.Location = new System.Drawing.Point(372, 9);
            this.lbTenSan.Name = "lbTenSan";
            this.lbTenSan.Size = new System.Drawing.Size(146, 19);
            this.lbTenSan.TabIndex = 0;
            this.lbTenSan.Text = "CHƯA CHỌN SÂN";
            // 
            // panel5
            // 
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
            this.panel5.Location = new System.Drawing.Point(206, 425);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(461, 69);
            this.panel5.TabIndex = 21;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(309, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Tiền thừa";
            // 
            // txtTienThua
            // 
            this.txtTienThua.Location = new System.Drawing.Point(363, 11);
            this.txtTienThua.Name = "txtTienThua";
            this.txtTienThua.Size = new System.Drawing.Size(84, 20);
            this.txtTienThua.TabIndex = 31;
            this.txtTienThua.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(156, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Khách đưa";
            // 
            // txtKhachDua
            // 
            this.txtKhachDua.Location = new System.Drawing.Point(222, 35);
            this.txtKhachDua.Name = "txtKhachDua";
            this.txtKhachDua.Size = new System.Drawing.Size(84, 20);
            this.txtKhachDua.TabIndex = 29;
            this.txtKhachDua.Text = "0";
            this.txtKhachDua.TextChanged += new System.EventHandler(this.txtKhachDua_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(156, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Tổng";
            // 
            // txtTienCuoi
            // 
            this.txtTienCuoi.Location = new System.Drawing.Point(222, 11);
            this.txtTienCuoi.Name = "txtTienCuoi";
            this.txtTienCuoi.Size = new System.Drawing.Size(84, 20);
            this.txtTienCuoi.TabIndex = 27;
            this.txtTienCuoi.Text = "0";
            this.txtTienCuoi.TextChanged += new System.EventHandler(this.txtTienCuoi_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Tiền dịch vụ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Tiền giờ";
            // 
            // txtGiaSan
            // 
            this.txtGiaSan.Location = new System.Drawing.Point(71, 11);
            this.txtGiaSan.Name = "txtGiaSan";
            this.txtGiaSan.Size = new System.Drawing.Size(84, 20);
            this.txtGiaSan.TabIndex = 24;
            this.txtGiaSan.Text = "0";
            this.txtGiaSan.TextChanged += new System.EventHandler(this.txtGiaSan_TextChanged);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(71, 35);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(84, 20);
            this.txtTongTien.TabIndex = 22;
            this.txtTongTien.Text = "0";
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTongTien.TextChanged += new System.EventHandler(this.txtTongTien_TextChanged);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(3, 3);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(115, 48);
            this.btnCheckOut.TabIndex = 22;
            this.btnCheckOut.Text = "Thanh toán";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Location = new System.Drawing.Point(3, 54);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(55, 48);
            this.btnInPhieu.TabIndex = 23;
            this.btnInPhieu.Text = "In phiếu";
            this.btnInPhieu.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(63, 54);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(55, 48);
            this.btnThoat.TabIndex = 24;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnCheckOut);
            this.panel6.Controls.Add(this.btnInPhieu);
            this.panel6.Controls.Add(this.btnThoat);
            this.panel6.Location = new System.Drawing.Point(670, 389);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(121, 105);
            this.panel6.TabIndex = 25;
            // 
            // flpSan
            // 
            this.flpSan.AutoScroll = true;
            this.flpSan.Controls.Add(this.lbListSan);
            this.flpSan.Location = new System.Drawing.Point(670, 89);
            this.flpSan.Name = "flpSan";
            this.flpSan.Size = new System.Drawing.Size(121, 297);
            this.flpSan.TabIndex = 26;
            // 
            // lbListSan
            // 
            this.lbListSan.AutoSize = true;
            this.lbListSan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbListSan.Location = new System.Drawing.Point(3, 0);
            this.lbListSan.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.lbListSan.Name = "lbListSan";
            this.lbListSan.Size = new System.Drawing.Size(114, 16);
            this.lbListSan.TabIndex = 27;
            this.lbListSan.Text = "DANH SÁCH SÂN";
            // 
            // FrmTinhTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 506);
            this.Controls.Add(this.flpSan);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.lbTenSan);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
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
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.flpSan.ResumeLayout(false);
            this.flpSan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLoaiHH;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTenHH;
        private System.Windows.Forms.Button btnAddHH;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnDelHH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDonViTinh;
        private System.Windows.Forms.TextBox txtGiamGia;
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
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtGiaSan;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTienCuoi;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtKhachDua;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtTienThua;
        private System.Windows.Forms.Button btnDoiGio;
        private System.Windows.Forms.Button btnTimKhach;
        private System.Windows.Forms.Button btnKhachMoi;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnInPhieu;
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
    }
}