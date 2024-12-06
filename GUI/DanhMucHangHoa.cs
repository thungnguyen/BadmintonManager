using BadmintonManager.BLL;
using BadmintonManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BadmintonManager.GUI
{
    public partial class DanhMucHangHoa : Form
    {
        private HangHoaBLL _hangHoaBLL;
        public DanhMucHangHoa()
        {
            InitializeComponent();
            _hangHoaBLL = new HangHoaBLL();
            LoadTable();
        }

        private void LoadTable()
        {
            try
            {
                var products = _hangHoaBLL.GetAllProducts();
                dgvHangHoa.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
