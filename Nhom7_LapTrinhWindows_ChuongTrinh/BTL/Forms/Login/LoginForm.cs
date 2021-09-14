using BTL.Forms.Login;
using BTL.Forms.Main;
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
using Microsoft.EntityFrameworkCore;
using BTL.Ultilities;

namespace BTL
{
    public partial class LoginForm : Form
    {

        QLBanMyPhamContext db = new QLBanMyPhamContext();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void checkHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHienThiMatKhau.Checked == true)
            {
                checkBoxHienThiMatKhau.Text = "Ẩn mật khẩu";
                txtMatKhau.PasswordChar = '\0';
                //txtMatKhau.UseSystemPasswordChar = true;
            }
            else
            {
                checkBoxHienThiMatKhau.Text = "Hiển thị mật khẩu";
                txtMatKhau.PasswordChar = '•';
                // txtMatKhau.UseSystemPasswordChar = false;
            }
        }

        private void dangNhap()
        {
            string taikhoan = txtTaiKhoan.Text.Trim();
            string matkhau = txtMatKhau.Text.Trim();
            string matKhauMaHoa = Ultility.Encrypt(matkhau);
            try
            {
                if (taikhoan.Equals("")) throw new Exception("Tài khoản không được để trống!");
                if (matkhau.Equals("")) throw new Exception("Mật khẩu không được để trống!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            // Lay tai khoan tu db
            TaiKhoan user;
            user = db.TaiKhoans.Find(taikhoan);

            // Check xem ton tai tk mk do hay khong
            if (user == null)
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác");
            }
            else
            {
                if (user.MatKhau != matKhauMaHoa && user.MatKhau != matkhau)
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Loading load = new Loading(user);
                this.Hide();
                load.ShowDialog();
            }
        }

        //Enter de dang nhap
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dangNhap();
            }
        }

        // Click dang nhap
        private void button1_Click(object sender, EventArgs e)
        {
            dangNhap();
        }

        //Keo tha duoc form
       [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Truoc khi load form
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            
        }


        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
