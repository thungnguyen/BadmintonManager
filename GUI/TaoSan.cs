using BadmintonManager.DAO;
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
    public partial class TaoSan : Form
    {
        public TaoSan()
        {
            InitializeComponent();
        }
       private void TaoSan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            lsvSan.Items.Clear();
            List<San> listSan = SanDAO.Instance.LoadSanList();

            foreach (San item in listSan)
            {
                ListViewItem lsvItem = new ListViewItem(item.MaSan.ToString());  
                lsvItem.SubItems.Add(item.TenSan.ToString());  
                lsvItem.SubItems.Add(item.Status.ToString());  
                lsvSan.Items.Add(lsvItem);
            }
        }
        private void lsvSan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSan.SelectedItems.Count > 0)
            {
                
                int maSan = int.Parse(lsvSan.SelectedItems[0].SubItems[0].Text);
                string tenSan = lsvSan.SelectedItems[0].SubItems[1].Text;
                txtTenSan.Text = tenSan;
                txtMaSan.Text = maSan.ToString();
                txtMaSan.Enabled = false;
            }
            else
            {
                txtTenSan.Clear();               
                txtMaSan.Enabled = true;
            }
        }

       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int maSan = Convert.ToInt32(txtMaSan.Text);
            string tenSan = txtTenSan.Text;
            if (tenSan == "")
            {
                MessageBox.Show("Vui lòng nhập tên sân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (maSan == 0)
            {
                MessageBox.Show("Vui lòng nhập mã sân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SanDAO.Instance.InsertSan(tenSan, maSan);
            MessageBox.Show("Thêm sân thành công!");
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lsvSan.SelectedItems.Count > 0)
            {
                int maSan = int.Parse(lsvSan.SelectedItems[0].SubItems[0].Text);
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sân này?", "Xóa sân", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    SanDAO.Instance.DeleteSan(maSan); 
                    LoadData(); 
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sân để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lsvSan.SelectedItems.Count > 0)
            {
                int maSan = int.Parse(lsvSan.SelectedItems[0].SubItems[0].Text);
                string tenSan = txtTenSan.Text.Trim();

                if (!string.IsNullOrEmpty(tenSan))
                {
                    SanDAO.Instance.UpdateSan(maSan, tenSan);
                    LoadData();  
                }
                else
                {
                    MessageBox.Show("Tên sân không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sân để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrices_Click(object sender, EventArgs e)
        {
            BangGiaSan bangGiaSanForm = new BangGiaSan();
            bangGiaSanForm.ShowDialog();
        }

        private void txtTenSan_TextChanged(object sender, EventArgs e)
        {

        }

        private void tenSan_Click(object sender, EventArgs e)
        {

        }
    }
}
