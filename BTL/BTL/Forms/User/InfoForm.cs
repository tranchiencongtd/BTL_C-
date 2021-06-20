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

namespace BTL.Forms.User
{
    public partial class InfoForm : Form
    {
        TaiKhoan user;
        public InfoForm()
        {
            InitializeComponent();
        }

        public InfoForm(TaiKhoan x)
        {
            user = x;
            InitializeComponent();  
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            labelHoTen.Text = user.MaNvNavigation.TenNv;
            labelChucVu.Text = user.ChucVu ? "Admin" : "Nhân viên";
            labelGioiTinh.Text = (bool)user.MaNvNavigation.GioiTinh ? "Nam":"Nữ";
            labelSDT.Text = user.MaNvNavigation.Sdt;

            // Image ..\ALL_IN_BTL\BTL\BTL\images\
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length)-26); // - 26 = path toi images
            anhAvatar.Image = Image.FromFile($"{paths}{user.MaNvNavigation.Anh}");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
