using System.Data;
using System.Data.SqlClient; // Thêm namespace này
using BadmintonManager.DTO;
using BadmintonManager.DAO;

namespace BadmintonManager.DAL
{
    public class PhieuChiDAL
    {
        private static PhieuChiDAL instance;

        public static PhieuChiDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PhieuChiDAL();
                }
                return instance;
            }
            private set => instance = value;
        }


        public bool ThemPhieuChi(PhieuChiDTO phieuChi)
        {
            // Câu truy vấn SQL
            string query = "INSERT INTO PhieuChi (MaDatSan, MaSan, MaKH, TuNgay, DaTra, NgayLap) " +
                           "VALUES (@MaDatSan, @MaSan, @MaKH, @TuNgay, @DaTra, @NgayLap)";

            // Thêm tham số cho truy vấn
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaDatSan", phieuChi.MaDatSan),
                new SqlParameter("@MaSan", phieuChi.MaSan),
                new SqlParameter("@MaKH", phieuChi.MaKH),
                new SqlParameter("@TuNgay", phieuChi.TuNgay),
                new SqlParameter("@DaTra", phieuChi.DaTra),
                new SqlParameter("@NgayLap", phieuChi.NgayLap)
            };

            // Thực thi câu lệnh
            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
