using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL.Forms.Main.Views;
using BTL.Forms.User;
using BTL.Models;
using BTL.Ultilities;
using FontAwesome.Sharp;

namespace BTL.Forms.Main
{
    public partial class MainForm : Form
    {
        // Db, TaiKhoan
        public TaiKhoan user;
        QLBanMyPhamContext db = new QLBanMyPhamContext();

        // Cac truong
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentViewForm;

        ArrayList listHomeCauNoi = new ArrayList()
                {
                    "Tin rằng bạn có thể làm một điều gì đó đồng nghĩa với việc bạn đã đi được nửa đường đến đó",
                    "Đừng so sánh mình với bất cứ ai trong thế giới này. Nếu bạn làm như vậy có nghĩa bạn đang sỉ nhục chính bản thân mình.",
                    "Không có hoàn cảnh nào tuyệt vọng, chỉ có người tuyệt vọng vì hoàn cảnh.",
                    "Bắt đầu từ nơi bạn đứng. Sử dụng những gì bạn có. Làm những gì bạn có thể.",
                    "Cuộc sống chỉ mang lại cho chúng ta 10% cơ hội, 90% còn lại là do chúng ta trải nghiệm thế nào với nó.",
                    "Chúng ta không nên bỏ cuộc, chúng ta không nên đề những khó khăn đánh bại mình.",
                    "Đừng ngại thay đổi. Bạn có thể mất một cái gì đó tốt nhưng bạn có thể đạt được một cái gì đó còn tốt hơn.",
                    "Chúng ta phải lựa chọn: nỗi đau của sự kỷ luật hay nỗi đau của sự hối hận.",
                    "Nếu nghĩ tới ước mơ không đủ làm bạn sợ hãi, nó quá nhỏ đối với bạn.",
                    "Bạn không bao giờ là kẻ thua cuộc cho đến khi bạn bỏ cuộc.",
                    "Hãy xây nên giấc mơ của bạn, nếu không thì người khác sẽ thuê bạn xây giấc mơ của họ.",
                    "Thà làm một bông hoa sen nở khi thấy mặt trời bị mất hết nhụy còn hơn giữ nguyên hình nụ búp trong sương lạnh vĩnh cửu của mùa đông.",
                    "Giấc mơ không phải là thứ bạn nhìn thấy khi ngủ, giấc mơ là những điều mà không cho phép bạn ngủ",
                    "Cuộc đời ngắn ngủi, hãy sống trọn từng phút giây. Tình yêu khan hiếm, hãy biết nắm lấy. Giận dữ là không tốt, hãy loại bỏ nó. Những kỉ niệm luôn ngọt ngào, hãy trân trọng chúng.",
                    "Mẹ cha cho bạc cho vàng không bằng lấy được một chàng Bắc Giang",
                    "Nếu như bạn bị rớt lại phía sau, hãy chạy nhanh hơn. Không bao giờ bỏ cuộc, không bao giờ đầu hàng, hãy chống lại nghịch cảnh.",
                    "Cuộc sống luôn có nhiều việc xảy ra không như ý, chúng ta không thể né tránh, điều duy nhất bạn có thể làm là thay đổi góc nhìn về nó.",
                    "Vinh quang không phải là không bao giờ thất bại, mà là cách chúng ta đứng dậy sau mỗi lần gục ngã.",
                    "Hãy dừng để ý tới những khó khăn của bạn mà hãy biết ơn những gì bạn có."
                };

        // Khoi tao
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(TaiKhoan x)
        {
            // tài khoản đã đăng nhập
            InitializeComponent();
            user = x;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // them cac thong tin cho user ( TT nv)
            getInfoUser();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 55);
            panelMenu.Controls.Add(leftBorderBtn);
            // Tat control text string
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            // Thoi gian
            //timeClock.Enabled = true;
            labelTimeHhMm.Text = "";
            labelTimeSs.Text = "";
            labelHiTen.Text = user.MaNvNavigation.TenNv;

            //Lay mot cau quote bat ky trong list
            Random random = new Random();
            int so = random.Next(listHomeCauNoi.Count);
            textBox1.Text = listHomeCauNoi[so].ToString();


            // Gan ten cua user
            avt.Text = user.MaNvNavigation.TenNv;

            // Hien thi cac chuc nang phu hop voi user Admin va Nhan vien
            if (user.ChucVu)
            {
                //Cho admin
                btnQuanLyTaiKhoan.Visible = true;
                btnQuanLySanPham.Visible = true;
                btnQuanLyNhapHang.Visible = true;
                btnQuanLyNhanVien.Visible = true;
                btnQuanLyNhaCungCap.Visible = true;
                btnQuanLyKhuyenMai.Visible = true;
                btnQuanLyKhachHang.Visible = true;
                btnQuanLyHoaDon.Visible = true;
                btnQuanLyDanhMuc.Visible = true;
                btnThongKe.Visible = true;
                btnDatHang.Visible = true;
                btnDoiTra.Visible = true;
            }
            else
            {

                // Cho nhan vien
                btnQuanLySanPham.Visible = true;
                btnQuanLyDanhMuc.Visible = true;
                btnDatHang.Visible = true;
                btnQuanLyNhapHang.Visible = true;
                btnQuanLyHoaDon.Visible = true;
                btnDoiTra.Visible = true;
                btnQuanLyKhachHang.Visible = true;
                btnQuanLyKhuyenMai.Visible = true;
                btnQuanLyNhaCungCap.Visible = true;
                //-------------------------

                btnQuanLyTaiKhoan.Visible = false;
                btnQuanLyNhanVien.Visible = false;
                btnThongKe.Visible = false;
                
            }
        }

        // Lấy thong tin ve user
        private void getInfoUser()
        {
            string manv = user.MaNv;
            var nv = db.NhanViens.Find(manv);

            user.MaNvNavigation = nv;
        }


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
                currentBtn.ForeColor = Color.FromArgb(255, 255, 255); // Chu trang
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


        // Mo form moi trong panelView
        private void OpenChildForm(Form childForm)
        {
            // Bat form moi thi an drop menu di
            panelDropMenu.Visible = false;

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
            OpenChildForm(new ThongKe(this,user));

        }


        private void btnQuanLySanPham_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLySanPham(this,user));
        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyKhachHang(this,user));
        }

        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyHoaDon(this, user));
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyNhanVien(this));
        }

        private void btnQuanLyNhaCungCap_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyNhaCungCap(user));
        }

        private void btnQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyDanhMuc(user));
        }

        private void btnQuanLyKhuyenMai_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyKhuyenMai(this,user));
        }

        private void btnQuanLyNhapHang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyNhapHang(user));
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyTaiKhoan(user));
        }

        private void btnDoiTra_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyDoiTra(this,user));
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new QuanLyDatHang(this,user));
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            if (currentViewForm != null) currentViewForm.Close();
            Reset();
            panelDropMenu.Visible = false;

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

        // Control form
        private void btnDong_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
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

        // Drop menu
        private void avt_Click(object sender, EventArgs e)
        {
            if (panelDropMenu.Visible)
            {
                panelDropMenu.Visible = false;

            }
            else
            {
                panelView.Controls.Add(panelDropMenu);
                panelDropMenu.BringToFront();
                panelDropMenu.Visible = true;
            }
        }


        // Thoi gian thuc o trang chu
        private void timer_Tick(object sender, EventArgs e)
        {
            labelTimeHhMm.Text = DateTime.Now.ToString("HH:mm");
            labelTimeSs.Text = DateTime.Now.ToString("ss");
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }


        // Modal
        private void btnXemInfo_Click(object sender, EventArgs e)
        {
            Ultility.modal(this, new xemThongTinForm(user));
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            Ultility.modal(this, new doiMatKhauForm(user.TenTk));
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

        
    }
}
