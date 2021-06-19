using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL.Forms.Main.Views;
using FontAwesome.Sharp;

namespace BTL.Forms.Main
{
    public partial class MainForm : Form
    {
        // Cac truong
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentViewForm;

        // Khoi tao
        public MainForm()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            // Tat control text string
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        // 
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(255, 255, 255); // Trang
        }
        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                //Cho button cu tro lai trang thai ban dau
                DisableButton();
                // Tao button 
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(78, 115, 223); // Nen xanh dam
                currentBtn.ForeColor = Color.FromArgb(255,255,255); // Chu trang
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Tao border left
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                // Icon cua form dang mo
                iconCurrentForm.IconChar = currentBtn.IconChar;
                iconCurrentForm.IconColor = Color.MidnightBlue;
                labelCurrentForm.Text = currentBtn.Text;
            }
        }


        // Button ban dau
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.DodgerBlue;
                currentBtn.ForeColor = Color.WhiteSmoke;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.WhiteSmoke;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            // Neu co form mo dong form do va mo form moi
            if (currentViewForm != null)
            {
                currentViewForm.Close();
            }
            currentViewForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelView.Controls.Add(childForm);
            panelView.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //labelCurrentForm.Text = childForm.Text;
        }

            // Begin button event click
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new ThongKe());
        }


        private void btnQuanLySanPham_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLySanPham());
        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyKhachHang());
        }

        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyHoaDon());
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyNhanVien());
        }

        private void btnQuanLyNhaCungCap_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyNhaCungCap());
        }

        private void btnQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyDanhMuc());
        }

        private void btnQuanLyKhuyenMai_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyKhuyenMai());
        }

        private void btnQuanLyNhapHang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyNhapHang());
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyTaiKhoan());
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            currentViewForm.Close();
            Reset();
        }

        // End button event click


        // Reset
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentForm.IconChar = IconChar.Home;
            iconCurrentForm.IconColor = Color.MidnightBlue;
            labelCurrentForm.Text = "Home";
        }

        // Keo tha form
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelView_Paint(object sender, PaintEventArgs e)
        {

        }


        // Control form
        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnPhongTo_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnThuNho_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        // Hover button 
        private void btnDong_MouseHover(object sender, EventArgs e)
        {
            btnDong.BackColor = Color.HotPink;
            btnDong.ForeColor = Color.White;
        }

        private void btnDong_MouseLeave(object sender, EventArgs e)
        {

            btnDong.BackColor = Color.Transparent;
            btnDong.ForeColor = Color.Gray;
        }

        private void btnPhongTo_MouseHover(object sender, EventArgs e)
        {
            btnPhongTo.BackColor = Color.Purple;
            btnPhongTo.ForeColor = Color.White;
        }

        private void btnPhongTo_MouseLeave(object sender, EventArgs e)
        {
            btnPhongTo.BackColor = Color.Transparent;
            btnPhongTo.ForeColor = Color.Gray;
        }

        private void btnThuNho_MouseHover(object sender, EventArgs e)
        {
            btnThuNho.BackColor = Color.Chocolate;
            btnThuNho.ForeColor = Color.White;
        }

        private void btnThuNho_MouseLeave(object sender, EventArgs e)
        {
            btnThuNho.BackColor = Color.Transparent;
            btnThuNho.ForeColor = Color.Gray;
        }


    }
}
