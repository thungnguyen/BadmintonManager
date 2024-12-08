using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonManager.DTO
{
    internal class Menu
    {
        public Menu(string tenHangHoa, int count, decimal price, decimal totalPrices, string unit)
        {
            this.TenHangHoa = tenHangHoa;
            this.Count = count;
            this.Price = price;
            this.TotalPrices = totalPrices;
            this.Unit = unit;
        }
        public Menu (DataRow row)
        {
            this.TenHangHoa = row["tenHH"].ToString();
            this.Count = (int)row["soLuong"];
            this.Price = (decimal)row["donGia"];
            this.TotalPrices = (decimal)row["thanhTien"];
            this.Unit = row["donViTinh"].ToString();

        }
        private string tenHangHoa;
        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }
        
        private int count; // so luong
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private decimal price; // gia
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        private decimal totalPrices;
        public decimal TotalPrices
        {
            get { return totalPrices; }
            set { totalPrices = value; }
        }
        private string unit; // donvitinh
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
    }
}
