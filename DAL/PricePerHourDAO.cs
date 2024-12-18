using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DAO
{
    internal class PricePerHourDAO
    {
        private static PricePerHourDAO instance;

        public static PricePerHourDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PricePerHourDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private PricePerHourDAO() { }
        public int CheckFrameCount(TimeSpan gioBatDau, TimeSpan gioKetThuc)
        {
            int frameCount = 0;

            // Thêm các tham số cho thủ tục
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@gioBatDau", gioBatDau),
        new SqlParameter("@gioKetThuc", gioKetThuc),
        new SqlParameter("@frameCount", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            // Gọi phương thức ExecuteStoredProcedure của DataProvider
            DataProvider.Instance.ExecuteStoredProcedure("USP_CheckTimeFrameCount", parameters);

            // Lấy giá trị từ tham số OUTPUT
            frameCount = (int)parameters[2].Value;

            return frameCount;
        }
        public decimal GetPriceForTimeSlot(TimeSpan gioBatDau, TimeSpan gioKetThuc, string loaiKH)
        {
            decimal giaGioChoi = 0;

            // Khởi tạo các tham số cho thủ tục
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@gioBatDau", SqlDbType.Time) { Value = gioBatDau },
        new SqlParameter("@gioKetThuc", SqlDbType.Time) { Value = gioKetThuc },
        new SqlParameter("@loaiKH", SqlDbType.NVarChar, 50) { Value = loaiKH },
        new SqlParameter("@giaGioChoi", SqlDbType.Decimal)
        {
            Direction = ParameterDirection.Output,
            Precision = 18,
            Scale = 2
        }
            };

            // Gọi phương thức ExecuteStoredProcedure từ DataProvider
            DataProvider.Instance.ExecuteStoredProcedure("USP_GetPriceForTimeSlot", parameters);

            // Lấy giá trị từ tham số OUTPUT
            giaGioChoi = (decimal)parameters[3].Value;

            return giaGioChoi;
        }
        public decimal GetPriceBetweenTimeFrames(TimeSpan gioBatDau, TimeSpan gioKetThuc, string loaiKH)
        {
            decimal giaGioChoi = 0;

            // Khởi tạo các tham số cho thủ tục
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@gioBatDau", SqlDbType.Time) { Value = gioBatDau },
        new SqlParameter("@gioKetThuc", SqlDbType.Time) { Value = gioKetThuc },
        new SqlParameter("@loaiKH", SqlDbType.NVarChar, 50) { Value = loaiKH },
        new SqlParameter("@giaGioChoi", SqlDbType.Decimal)
        {
            Direction = ParameterDirection.Output,
            Precision = 18,
            Scale = 2
        }
            };

            // Gọi phương thức ExecuteStoredProcedure từ DataProvider
            DataProvider.Instance.ExecuteStoredProcedure("USP_GetPriceBetweenTimeFrames", parameters);

            // Lấy giá trị từ tham số OUTPUT
            giaGioChoi = (decimal)parameters[3].Value;

            return giaGioChoi;
        }
        public int GetFrameCount(TimeSpan gioBatDau, TimeSpan gioKetThuc)
        {
            int frameCount = 0;

            // Khởi tạo các tham số cho thủ tục
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@gioBatDau", SqlDbType.Time) { Value = gioBatDau },
        new SqlParameter("@gioKetThuc", SqlDbType.Time) { Value = gioKetThuc },
        new SqlParameter("@frameCount", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        }
            };

            // Gọi phương thức ExecuteStoredProcedure từ DataProvider để thực thi thủ tục
            DataProvider.Instance.ExecuteStoredProcedure("USP_CheckTimeFrameCount", parameters);

            // Lấy giá trị từ tham số OUTPUT
            frameCount = (int)parameters[2].Value;

            return frameCount;
        }
    }
}
