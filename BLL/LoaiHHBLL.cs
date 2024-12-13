using BadmintonManager.DAL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

    namespace BadmintonManager.BLL
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
            public List<LoaiHH> GetAllCategories()
            {
                return _loaiHHDAL.GetAllCategories()
                    .OrderBy(c => c.TenLoaiHH)
                    .ToList();
            }

            public void AddCategory(LoaiHH category)
            {
            if (category.MaLoaiHH <= 0)
            {
                throw new ArgumentException("Mã Loại HH phải là số dương.");
            }

            if (string.IsNullOrWhiteSpace(category.TenLoaiHH))
            {
                throw new ArgumentException("Tên Loại HH không được để trống.");
            }

            _loaiHHDAL.InsertCategory(category);
            }


        public bool IsCategoryExists(int maLoaiHH)
        {
            return _loaiHHDAL.GetAllCategories().Any(c => c.MaLoaiHH == maLoaiHH);
        }

        public void UpdateCategory(LoaiHH category)
        {
            _loaiHHDAL.UpdateCategory(category);
        }

        public void DeleteCategory(int maLoaiHH)
        {
            _loaiHHDAL.DeleteCategory(maLoaiHH);
        }

    }
}
