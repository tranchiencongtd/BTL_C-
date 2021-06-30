using BTL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BTL.Forms.User
{
    public partial class ChangePassForm : Form
    {
        string tenTK;
        public ChangePassForm()
        {
            InitializeComponent();
        }

        public ChangePassForm(String x)
        {
            InitializeComponent();
            tenTK = x;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string oldMK = txtMatKhauCu.Text.Trim();
            string newMK = txtMatKhauMoi.Text.Trim();
            string confirmMK = txtNhapLaiMK.Text.Trim();
            try
            {
                if (oldMK.Equals("")) throw new Exception("Mật khẩu cũ không được để trống");
                if (newMK.Equals("")) throw new Exception("Mật khẩu mới không được để trống");
                if (confirmMK.Equals("")) throw new Exception("Bạn chưa nhập lại nhập khẩu mới");
                string regex = "^(?=.*?[A-Z])(?=.*?[0-9]).{8,}$";
                if (!Regex.IsMatch(newMK, regex)) throw new Exception("Mật khẩu không đúng định dạng");
                if (!newMK.Equals(confirmMK)) throw new Exception("Mật khẩu nhập lại chưa khớp");

                using (QLBanMyPhamContext db = new QLBanMyPhamContext())
                {
                    TaiKhoan tk = db.TaiKhoans.Find(tenTK);
                    tk.MatKhau = txtMatKhauMoi.Text;
                    db.SaveChanges();
                    xoaTrang();
                    MessageBox.Show("Đổi mật khẩu thành công");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  

        private void xoaTrang()
        {
            txtMatKhauCu.Clear();
            txtMatKhauMoi.Clear();
            txtNhapLaiMK.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHienThiMatKhau.Checked == true)
            {
                checkBoxHienThiMatKhau.Text = "Ẩn mật khẩu";
                txtMatKhauCu.PasswordChar = '\0';
                txtMatKhauMoi.PasswordChar = '\0';
                txtNhapLaiMK.PasswordChar = '\0';
            }
            else
            {
                checkBoxHienThiMatKhau.Text = "Hiển thị mật khẩu";
                txtMatKhauCu.PasswordChar = '•';
                txtMatKhauMoi.PasswordChar = '•';
                txtNhapLaiMK.PasswordChar = '•';
            }
        }
    }
}
