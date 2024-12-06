using BadmintonManager.DTO;
using BadmintonManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
