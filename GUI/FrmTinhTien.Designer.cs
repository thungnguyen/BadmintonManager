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
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cbLoaiHH = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.dgvDanhSachHangHoa = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvSan = new System.Windows.Forms.DataGridView();
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachHangHoa)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSan)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoGioThue)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dgvHangHoa);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.cbLoaiHH);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 482);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(139, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(42, 20);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHangHoa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHangHoa.ColumnHeadersHeight = 20;
            this.dgvHangHoa.Location = new System.Drawing.Point(6, 69);
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.Size = new System.Drawing.Size(175, 410);
            this.dgvHangHoa.TabIndex = 6;
            this.dgvHangHoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHangHoa_CellClick);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(44, 43);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(93, 20);
            this.txtTimKiem.TabIndex = 3;
            // 
            // cbLoaiHH
            // 
            this.cbLoaiHH.FormattingEnabled = true;
            this.cbLoaiHH.Location = new System.Drawing.Point(44, 17);
            this.cbLoaiHH.Name = "cbLoaiHH";
            this.cbLoaiHH.Size = new System.Drawing.Size(137, 21);
            this.cbLoaiHH.TabIndex = 2;
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
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Controls.Add(this.dataGridView1);
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
            this.panel2.Controls.Add(this.dgvDanhSachHangHoa);
            this.panel2.Location = new System.Drawing.Point(206, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(461, 220);
            this.panel2.TabIndex = 5;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(500, 68);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(185, 135);
            this.dataGridView2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(464, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(115, 178);
            this.dataGridView1.TabIndex = 0;
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
            this.txtGiamGia.Size = new System.Drawing.Size(63, 20);
            this.txtGiamGia.TabIndex = 15;
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
            this.btnAddHH.Location = new System.Drawing.Point(339, 53);
            this.btnAddHH.Name = "btnAddHH";
            this.btnAddHH.Size = new System.Drawing.Size(42, 29);
            this.btnAddHH.TabIndex = 11;
            this.btnAddHH.Text = "Thêm";
            this.btnAddHH.UseVisualStyleBackColor = true;
            this.btnAddHH.Click += new System.EventHandler(this.btnAddHH_Click);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(255, 28);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(57, 20);
            this.txtDonGia.TabIndex = 10;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(124, 28);
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(64, 20);
            this.nudSoLuong.TabIndex = 7;
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
            // dgvDanhSachHangHoa
            // 
            this.dgvDanhSachHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachHangHoa.Location = new System.Drawing.Point(3, 88);
            this.dgvDanhSachHangHoa.Name = "dgvDanhSachHangHoa";
            this.dgvDanhSachHangHoa.Size = new System.Drawing.Size(455, 129);
            this.dgvDanhSachHangHoa.TabIndex = 0;
            this.dgvDanhSachHangHoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachHangHoa_CellClick);
            this.dgvDanhSachHangHoa.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachHangHoa_CellValueChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvSan);
            this.panel3.Location = new System.Drawing.Point(673, 125);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(121, 294);
            this.panel3.TabIndex = 19;
            // 
            // dgvSan
            // 
            this.dgvSan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSan.Location = new System.Drawing.Point(3, 42);
            this.dgvSan.Name = "dgvSan";
            this.dgvSan.Size = new System.Drawing.Size(115, 249);
            this.dgvSan.TabIndex = 0;
            this.dgvSan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSan_CellClick);
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
            this.BtnStart.Location = new System.Drawing.Point(370, 130);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(88, 38);
            this.BtnStart.TabIndex = 12;
            this.BtnStart.Text = "Bắt đầu";
            this.BtnStart.UseVisualStyleBackColor = true;
            // 
            // btnDoiGio
            // 
            this.btnDoiGio.Location = new System.Drawing.Point(277, 130);
            this.btnDoiGio.Name = "btnDoiGio";
            this.btnDoiGio.Size = new System.Drawing.Size(84, 38);
            this.btnDoiGio.TabIndex = 11;
            this.btnDoiGio.Text = "Đổi giờ";
            this.btnDoiGio.UseVisualStyleBackColor = true;
            // 
            // btnTimKhach
            // 
            this.btnTimKhach.Location = new System.Drawing.Point(370, 77);
            this.btnTimKhach.Name = "btnTimKhach";
            this.btnTimKhach.Size = new System.Drawing.Size(88, 36);
            this.btnTimKhach.TabIndex = 10;
            this.btnTimKhach.Text = "Tìm tên";
            this.btnTimKhach.UseVisualStyleBackColor = true;
            // 
            // btnKhachMoi
            // 
            this.btnKhachMoi.Location = new System.Drawing.Point(277, 77);
            this.btnKhachMoi.Name = "btnKhachMoi";
            this.btnKhachMoi.Size = new System.Drawing.Size(84, 38);
            this.btnKhachMoi.TabIndex = 9;
            this.btnKhachMoi.Text = "Khách mới";
            this.btnKhachMoi.UseVisualStyleBackColor = true;
            // 
            // btnChooseLichSan
            // 
            this.btnChooseLichSan.Location = new System.Drawing.Point(339, 29);
            this.btnChooseLichSan.Name = "btnChooseLichSan";
            this.btnChooseLichSan.Size = new System.Drawing.Size(119, 23);
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
            this.nudSoGioThue.Name = "nudSoGioThue";
            this.nudSoGioThue.Size = new System.Drawing.Size(200, 20);
            this.nudSoGioThue.TabIndex = 7;
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
            this.label17.Location = new System.Drawing.Point(302, 14);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Tiền thừa";
            // 
            // txtTienThua
            // 
            this.txtTienThua.Location = new System.Drawing.Point(360, 7);
            this.txtTienThua.Name = "txtTienThua";
            this.txtTienThua.Size = new System.Drawing.Size(84, 20);
            this.txtTienThua.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(156, 38);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Khách đưa";
            // 
            // txtKhachDua
            // 
            this.txtKhachDua.Location = new System.Drawing.Point(212, 31);
            this.txtKhachDua.Name = "txtKhachDua";
            this.txtKhachDua.Size = new System.Drawing.Size(84, 20);
            this.txtKhachDua.TabIndex = 29;
            this.txtKhachDua.TextChanged += new System.EventHandler(this.txtKhachDua_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(156, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Tổng";
            // 
            // txtTienCuoi
            // 
            this.txtTienCuoi.Location = new System.Drawing.Point(212, 7);
            this.txtTienCuoi.Name = "txtTienCuoi";
            this.txtTienCuoi.Size = new System.Drawing.Size(84, 20);
            this.txtTienCuoi.TabIndex = 27;
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
            this.label13.Location = new System.Drawing.Point(3, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Tiền giờ";
            // 
            // txtGiaSan
            // 
            this.txtGiaSan.Location = new System.Drawing.Point(71, 7);
            this.txtGiaSan.Name = "txtGiaSan";
            this.txtGiaSan.Size = new System.Drawing.Size(84, 20);
            this.txtGiaSan.TabIndex = 24;
            this.txtGiaSan.TextChanged += new System.EventHandler(this.txtGiaSan_TextChanged);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(71, 31);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(84, 20);
            this.txtTongTien.TabIndex = 22;
            this.txtTongTien.TextChanged += new System.EventHandler(this.txtTongTien_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(673, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 48);
            this.button1.TabIndex = 22;
            this.button1.Text = "Thanh toán";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Location = new System.Drawing.Point(739, 445);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(55, 48);
            this.btnInPhieu.TabIndex = 23;
            this.btnInPhieu.Text = "In phiếu";
            this.btnInPhieu.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(739, 14);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(55, 48);
            this.btnThoat.TabIndex = 24;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // FrmTinhTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 506);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnInPhieu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.lbTenSan);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTinhTien";
            this.Text = "Tính tiền";
            this.Load += new System.EventHandler(this.FrmTinhTien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachHangHoa)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSan)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoGioThue)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cbLoaiHH;
        private System.Windows.Forms.DataGridView dgvHangHoa;
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
        private System.Windows.Forms.DataGridView dgvDanhSachHangHoa;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvSan;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnInPhieu;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbLoaiKH;
    }
}