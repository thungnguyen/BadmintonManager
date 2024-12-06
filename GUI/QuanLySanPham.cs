using BadmintonManager.BLL;
using BadmintonManager.DTO;
using System;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class QuanLySanPham : Form
    {
        private HangHoaBLL _hangHoaBLL;
        private LoaiHHBLL _loaiHHBLL; // We'll create this BLL class

        public QuanLySanPham()
        {
            InitializeComponent();
            _hangHoaBLL = new HangHoaBLL();
            _loaiHHBLL = new LoaiHHBLL();

            InitializeForm();
        }

        private void InitializeForm()
        {
            // Setup form controls
            this.Text = "Quản Lý Sản Phẩm";

            // Product Name
            Label lblTenHH = new Label
            {
                Text = "Tên Sản Phẩm:",
                Location = new System.Drawing.Point(10, 20),
                AutoSize = true
            };
            TextBox txtTenHH = new TextBox
            {
                Location = new System.Drawing.Point(150, 20),
                Width = 200
            };

            // Product Description
            Label lblMoTa = new Label
            {
                Text = "Mô Tả:",
                Location = new System.Drawing.Point(10, 50),
                AutoSize = true
            };
            TextBox txtMoTa = new TextBox
            {
                Location = new System.Drawing.Point(150, 50),
                Width = 200,
                Multiline = true,
                Height = 50
            };

            // Price
            Label lblGiaBan = new Label
            {
                Text = "Giá Bán:",
                Location = new System.Drawing.Point(10, 110),
                AutoSize = true
            };
            NumericUpDown nudGiaBan = new NumericUpDown
            {
                Location = new System.Drawing.Point(150, 110),
                Minimum = 0,
                Maximum = 1000000,
                DecimalPlaces = 2,
                Increment = 1000
            };

            // Product Category
            Label lblLoaiHH = new Label
            {
                Text = "Loại Sản Phẩm:",
                Location = new System.Drawing.Point(10, 140),
                AutoSize = true
            };
            ComboBox cboLoaiHH = new ComboBox
            {
                Location = new System.Drawing.Point(150, 140),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Populate Categories
            try
            {
                var categories = _loaiHHBLL.GetAllCategories();
                cboLoaiHH.DataSource = categories;
                cboLoaiHH.DisplayMember = "TenLoaiHH";
                cboLoaiHH.ValueMember = "MaLoaiHH";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh mục: {ex.Message}");
            }

            // Add Product Button
            Button btnAddProduct = new Button
            {
                Text = "Thêm Sản Phẩm",
                Location = new System.Drawing.Point(10, 180),
                Width = 150
            };

            // DataGridView for Products
            DataGridView dgvProducts = new DataGridView
            {
                Location = new System.Drawing.Point(10, 220),
                Width = 500,
                Height = 200,
                AutoGenerateColumns = true
            };

            // Button Click Event
            btnAddProduct.Click += (sender, e) =>
            {
                try
                {
                    // Validate inputs
                    if (string.IsNullOrWhiteSpace(txtTenHH.Text))
                    {
                        MessageBox.Show("Vui lòng nhập tên sản phẩm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Create new product
                    var newProduct = new HangHoa
                    {
                        TenHH = txtTenHH.Text,
                        MoTa = txtMoTa.Text,
                        GiaBanLon = nudGiaBan.Value,
                        MaLoaiHH = (int)cboLoaiHH.SelectedValue
                    };

                    // Add product
                    int newProductId = _hangHoaBLL.AddProduct(newProduct);

                    // Refresh product list
                    dgvProducts.DataSource = _hangHoaBLL.GetAllProducts();

                    // Clear inputs
                    txtTenHH.Clear();
                    txtMoTa.Clear();
                    nudGiaBan.Value = 0;

                    MessageBox.Show($"Sản phẩm đã được thêm. Mã sản phẩm: {newProductId}", "Thành Công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi thêm sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                lblTenHH, txtTenHH,
                lblMoTa, txtMoTa,
                lblGiaBan, nudGiaBan,
                lblLoaiHH, cboLoaiHH,
                btnAddProduct,
                dgvProducts
            });

            // Initial load of products
            dgvProducts.DataSource = _hangHoaBLL.GetAllProducts();
        }
    }
}
