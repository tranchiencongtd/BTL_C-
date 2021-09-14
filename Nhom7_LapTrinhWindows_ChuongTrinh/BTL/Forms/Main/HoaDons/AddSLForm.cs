using BTL.Forms.Main.HoaDon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.Forms.Main.HoaDons
{
    public partial class AddSLForm : Form
    {
        public AddSLForm()
        {
            InitializeComponent();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSLMua.Text == "") throw new Exception("Không được bỏ trống số lượng mua!");
                if (int.Parse(txtSLMua.Text) <= 0) throw new Exception("Số lượng mua phải lớn hơn 0!");
                this.Tag = int.Parse(txtSLMua.Text);
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Lỗi nhập số liệu là kí tự!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSLMua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}
