using BTL.Forms.Main.HoaDon;
using BTL.Models;
using BTL.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.Forms.Main.Customer
{
    public partial class AddFormKH : Form
    {
        QLBanMyPhamContext db;
        KhachHang kh = new KhachHang();
        public AddFormKH(QLBanMyPhamContext dt)
        {
            db=dt;
            InitializeComponent();
        }


        public void them()
        {
            try
            {
                if (txtHoTen.Text.Trim() == "") throw new Exception("Họ tên không được để trống!");
                if (txtSDT.Text.Trim() == "") throw new Exception("SĐT không được để trống!");
                var ds = db.KhachHangs.Where(s => s.Sdt == txtSDT.Text).FirstOrDefault();
                if (ds!=null)
                    throw new Exception("Đã tồn tại một khách hàng có số điện thoại " + txtSDT.Text);
                kh.MaKh = Ultility.generateId("KH");
                kh.TenKh = txtHoTen.Text.Trim();
                kh.Sdt = txtSDT.Text.Trim();
                kh.TichDiem = int.Parse(txtTichDiem.Text.Trim());
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                this.Tag = kh;
                MessageBox.Show("Thêm thành công");
                txtHoTen.Clear();
                txtSDT.Clear();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ibtnAdd_Click(object sender, EventArgs e)
        {
            them();
        }

        private void ibtnThoat_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Close();
                }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void AddFormKH_Load(object sender, EventArgs e)
        {
            txtSDT.Text = (string)this.Tag;
            this.Tag = null;
        }
    }
}
