using BTL.Forms.Login;
using BTL.Forms.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            }
            else
            {
                checkBoxHienThiMatKhau.Text = "Hiển thị mật khẩu";
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loading load = new Loading();
            this.Hide();
            load.ShowDialog();
        }

        // Keo tha duoc form
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

    }
}
