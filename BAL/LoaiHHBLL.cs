using BadmintonManager.DAL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

    namespace BadmintonManager.BAL
    {
        internal class LoaiHHBLL
        {
            private LoaiHHDAL _loaiHHDAL;

            public LoaiHHBLL()
            {
                _loaiHHDAL = new LoaiHHDAL();
            }

            /// <summary>
            /// Gets all product categories
            /// </summary>
            public List<LoaiHHDTO> GetAllCategories()
            {
                return _loaiHHDAL.GetAllCategories()
                    .OrderBy(c => c.TenLoaiHH)
                    .ToList();
            }

            public void AddCategory(LoaiHHDTO category)
            {
            if (string.IsNullOrWhiteSpace(category.TenLoaiHH))
                throw new ArgumentException("Tên Loại HH không được để trống.");

            LoaiHHDAL loaiHHDAL = new LoaiHHDAL();
            loaiHHDAL.InsertCategory(category);
        }


        public bool IsCategoryExists(int maLoaiHH)
        {
            return _loaiHHDAL.GetAllCategories().Any(c => c.MaLoaiHH == maLoaiHH);
        }

        public void UpdateCategory(LoaiHH category)
        {
            
        }

        public void DeleteCategory(int maLoaiHH)
        {
            if (!IsCategoryExists(maLoaiHH))
                throw new ArgumentException("Loại HH không tồn tại.");

            _loaiHHDAL.DeleteCategory(maLoaiHH); // Cần thêm hàm trong DAL.
        }

    }
}
