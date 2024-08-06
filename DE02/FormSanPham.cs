using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DE02
{
    public partial class FormSanPham : Form
    {
        public FormSanPham()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn tắt?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDanhmuc.SelectedItems.Count > 0)
            {
                // Xác nhận với người dùng
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa các mục đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Xóa các mục đã chọn
                    foreach (ListViewItem item in lvDanhmuc.SelectedItems)
                    {
                        lvDanhmuc.Items.Remove(item);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một mục để xóa!");
            }
            MessageBox.Show("Xóa thành công");
        }
        private void btnSua_Click(object sender, EventArgs e) 
        {
            if (lvDanhmuc.SelectedItems.Count > 0)
            {
                ListViewItem item = lvDanhmuc.SelectedItems[0];
                tbxMASP.Text = item.Text;
                tbxTenSP.Text = item.SubItems[1].Text;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để sửa!");
            }
            lvDanhmuc.Refresh();
            MessageBox.Show("Sửa thành công");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(tbxMASP.Text)))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }
            else
            {
                ListViewItem item = new ListViewItem();
                item.Text = tbxMASP.Text;
                lvDanhmuc.Items.Add(item);
               
                ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem(item, (tbxTenSP.Text));
               
                item.SubItems.Add(subitem);
                item.SubItems.Add(dtNgayNhap.Value.ToShortDateString());
                tbxMASP.Clear();
                tbxTenSP.Clear();
                tbxMASP.Focus();
                MessageBox.Show("Thêm thành công");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = tbxTim.Text.ToLower(); 
        
            foreach (ListViewItem item in lvDanhmuc.Items)
            {
                bool found = false;
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text.ToLower().Contains(tuKhoa))
                    {
                        found = true;
                        break;
                    }
                }
            }
        }
        private void lvDanhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhmuc.SelectedItems.Count > 0)
            {
                ListViewItem item = lvDanhmuc.SelectedItems[0];
                tbx.MASP = item.Text; 
                tbx.TenSP = item.SubItems[1].Text; 
                                                       
            }
        }
    }
}
