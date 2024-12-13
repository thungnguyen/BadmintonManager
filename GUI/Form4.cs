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
  
    public partial class Form4 : Form
    {
        private BaoCaoDoanhThuBAL bal = new BaoCaoDoanhThuBAL();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadBaoCaoDoanhThu();
        }

        private void LoadBaoCaoDoanhThu()
        {
            List<BaoCaoDoanhThuDTO> danhSachBaoCao = bal.LayDanhSachBaoCao();
            dataGridView1.DataSource = danhSachBaoCao;
        }

        private void Form4_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLySanDataSet.BaoCaoDoanhThu' table. You can move, or remove it, as needed.
            this.baoCaoDoanhThuTableAdapter.Fill(this.quanLySanDataSet.BaoCaoDoanhThu);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
