using BadmintonManager.DTO;
using BadmintonManager.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class ThietLapSan : Form
    {
        
        public ThietLapSan()
        {
            InitializeComponent();
        }
        private void ThietLapSan_Load(object sender, EventArgs e)
        {
            LoadData(); // Tải dữ liệu lên DataGridView khi form khởi động
        }

        private void LoadData()
        {
            lsvSan.Items.Clear();  // Xóa tất cả các mục hiện tại trong ListView
            List<San> listSan = SanDAO.Instance.LoadSanList();  // Lấy danh sách hàng hóa theo loại

            foreach (DTO.San item in listSan)
            {
                ListViewItem lsvItem = new ListViewItem(item.MaSan.ToString());  // Chỉ thêm tên hàng hóa vào cột đầu tiên
                lsvItem.SubItems.Add(item.TenSan.ToString());
                lsvItem.SubItems.Add(item.Status.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
         
        }

        private void dgvDanhSachSan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void btnPrices_Click(object sender, EventArgs e)
        {
           
        }


    }
}
