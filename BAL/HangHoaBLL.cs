using BadmintonManager.DAL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BadmintonManager.BAL
{
    /// <summary>
    /// Business Logic Layer for Product Management
    /// </summary>
    public class HangHoaBLL
    {
        private HangHoaDAL _hangHoaDAL;
        private LoaiHHDAL _loaiHHDAL;
        private NhapHangDAL nhapHangDAL;
        private ChiTietNhapHangDAL chiTietNhapHangDAL;

        public HangHoaBLL()
        {
            _hangHoaDAL = new HangHoaDAL();
            _loaiHHDAL = new LoaiHHDAL();
            chiTietNhapHangDAL = new ChiTietNhapHangDAL();
            nhapHangDAL = new NhapHangDAL();
        }

        /// <summary>
        /// Gets all products with business logic applied
        /// </summary>
        public List<HangHoa> GetAllProducts()
        {
            try
            {
                // Fetch all products from DAL
                var products = _hangHoaDAL.GetAllProducts();

                //
                return products;

            }
            catch (Exception ex)
            {
                // Log or handle the error
                throw new ApplicationException("Error retrieving products", ex);
            }
        }

        public DataTable GetTable()
        {
            HangHoaDAL dal = new HangHoaDAL();
            return dal.GetTableProduct();  
        }

        public DataTable GetProducts(string searchTerm = null)
        {
            return _hangHoaDAL.GetProducts(searchTerm);
        }

        public HangHoa GetProductById(int productId)
        {
            if (productId <= 0)
            {
                throw new ArgumentException("Mã sản phẩm không hợp lệ!");
            }

            return _hangHoaDAL.GetProductById(productId);
        }


        /// <summary>
        /// Retrieves all product categories from business logic
        /// </summary>
        public List<LoaiHHDTO> GetProductCategories()
        {
            try
            {
                return _hangHoaDAL.GetProductCategories();
            }
            catch (Exception ex)
            {
                // Log or handle the error
                throw new ApplicationException("Error retrieving product categories", ex);
            }
        }



        /// <summary>
        /// Adds a new product to the system after validating its data
        /// </summary>
        public void AddProduct(HangHoa product)
        {
            // Kiểm tra thông tin cơ bản
            if (string.IsNullOrWhiteSpace(product.TenHH))
            {
                throw new ArgumentException("Tên hàng hoá không được để trống.");
            }

            if (product.MaLoaiHH <= 0)
            {
                throw new ArgumentException("Loại hàng hoá không hợp lệ.");
            }

            if (product.HeSoQuyDoi <= 0)
            {
                throw new ArgumentException("Hệ số quy đổi phải lớn hơn 0.");
            }

            if (product.GiaNhapLon <= 0 || product.GiaNhapNho <= 0 || product.GiaBanLon <= 0 || product.GiaBanNho <= 0)
            {
                throw new ArgumentException("Giá nhập và giá bán phải là số dương.");
            }

            if (product.GiaBanLon < product.GiaNhapLon || product.GiaBanNho < product.GiaNhapNho)
            {
                throw new ArgumentException("Giá bán không được nhỏ hơn giá nhập.");
            }

            if (product.SoLuongTonLon < 0 || product.SoLuongTonNho < 0)
            {
                throw new ArgumentException("Số lượng tồn kho phải là số không âm.");
            }

            // Kiểm tra xem loại hàng hoá có tồn tại trong cơ sở dữ liệu không
            var categoryExists = _loaiHHDAL.GetAllCategories().Any(c => c.MaLoaiHH == product.MaLoaiHH);
            if (!categoryExists)
            {
                throw new ArgumentException("Loại hàng hoá không tồn tại.");
            }

            // Sau khi kiểm tra, gửi đến DAL để lưu trữ
            _hangHoaDAL.AddProduct(product);
        }

        public void DeleteProduct(int maHH)
        {
            _hangHoaDAL.DeleteProduct(maHH);
        }


        public void UpdateProduct(HangHoa product)
        {
            // Kiểm tra dữ liệu trước khi gửi đến DAL (Validation)
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Sản phẩm không được null!");
            }

            if (string.IsNullOrWhiteSpace(product.TenHH))
            {
                throw new ArgumentException("Tên hàng hoá không được để trống!");
            }

            if (product.MaLoaiHH <= 0)
            {
                throw new ArgumentException("Loại hàng hoá không hợp lệ!");
            }

            if (product.HeSoQuyDoi <= 0)
            {
                throw new ArgumentException("Hệ số quy đổi phải là số dương!");
            }

            if (product.GiaNhapLon <= 0 || product.GiaNhapNho <= 0 ||
                product.GiaBanLon <= 0 || product.GiaBanNho <= 0)
            {
                throw new ArgumentException("Giá nhập và giá bán phải là số dương!");
            }

            // Gọi DAL để thực hiện cập nhật
            _hangHoaDAL.UpdateProduct(product);
        }


        public decimal GetHeSoQuyDoiForProduct(int maHH)
        {
            if (maHH <= 0)
            {
                throw new ArgumentException("Mã sản phẩm không hợp lệ!");
            }

            return _hangHoaDAL.GetHeSoQuyDoiForProduct(maHH);
        }

        public int SaveNhapHang(NhapHangDTO nhapHang)
        {
            // Gọi đến DAL để lưu phiếu nhập
            return nhapHangDAL.InsertNhapHang(nhapHang);
        }

        public void SaveChiTietNhapHang(ChiTietNhapHangDTO CTNhapHang)
        {
            try
            {
                // Gọi DAL để lưu chi tiết nhập hàng
                chiTietNhapHangDAL.InsertChiTietNhapHang(CTNhapHang);

                // Lấy thông tin hàng hóa hiện tại
                HangHoa hangHoa = _hangHoaDAL.GetProductById(CTNhapHang.MaHH);

                if (hangHoa != null)
                {
                    // Cộng số lượng nhập vào số lượng tồn
                    hangHoa.SoLuongTonLon += CTNhapHang.SoLuongNhapLon;
                    hangHoa.SoLuongTonNho += CTNhapHang.SoLuongNhapNho;

                    // Cập nhật số lượng tồn trong cơ sở dữ liệu
                    _hangHoaDAL.ImportHangHoa(hangHoa, isAdd: true); // Truyền thêm tham số để biết đây là thao tác cộng
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lưu chi tiết nhập hàng: " + ex.Message);
            }
        }






    }
}
