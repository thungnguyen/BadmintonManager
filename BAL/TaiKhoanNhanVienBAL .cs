using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadmintonManager.DAL;
using BadmintonManager.DTO;


namespace BadmintonManager.BAL
    {
        public class TaiKhoanNhanVienBAL
        {
            private TaiKhoanNhanVienDAL taiKhoanDAL;

            public TaiKhoanNhanVienBAL()
            {
                taiKhoanDAL = new TaiKhoanNhanVienDAL();
            }

            public TaiKhoanNhanVienDTO DangNhap(string tenDangNhap, string matKhau)
            {
                return taiKhoanDAL.DangNhap(tenDangNhap, matKhau);
            }

            public int LayMaNV(string tenDangNhap, string matKhau)
            {
                return taiKhoanDAL.LayMaNV(tenDangNhap, matKhau);
            }
        }
    }
