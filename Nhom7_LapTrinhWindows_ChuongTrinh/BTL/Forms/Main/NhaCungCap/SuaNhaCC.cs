using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL.Models;
namespace BTL.Forms.Main.NhaCungCap
{
    public partial class SuaNhaCC : Form
    {
        QLBanMyPhamContext db;
        NhaCc a = new NhaCc();
        public SuaNhaCC()
        {
            InitializeComponent();
        }
        public SuaNhaCC(string mancc, QLBanMyPhamContext d)
        {
            InitializeComponent();
            db = d;
            a = db.NhaCcs.SingleOrDefault(x => x.MaNcc == mancc);
            txtmaNhaCC.Text = a.MaNcc;
            txtTenNhaCC.Text = a.TenNcc;
            txtDienThoai.Text = a.DienThoai;
            txtDiaChi.Text = a.DiaChi;
            txtFax.Text = a.TenNcc;
            txtSoTK.Text = a.SoTaiKhoan;
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenNhaCC.Text.Trim() == "") throw new Exception("Tên nhà cung cấp không được để trống!");
                if (txtDienThoai.Text.Trim().Length != 11) throw new Exception("SĐT phải có 11 số !");
                if (txtDiaChi.Text.Trim() == "") throw new Exception("Địa chỉ không được để trống!");
                if (txtFax.Text.Trim() == "") throw new Exception("Số Fax không được để trống!");
                if (txtSoTK.Text.Trim() == "") throw new Exception("Số Tk không được để trống!");
                a.MaNcc = txtmaNhaCC.Text;
                a.TenNcc = txtTenNhaCC.Text;
                a.Fax = txtFax.Text;
                a.DienThoai = txtDienThoai.Text;
                a.DiaChi = txtDiaChi.Text;
                a.SoTaiKhoan = txtSoTK.Text;
                db.SaveChanges();
                MessageBox.Show("Sửa thành công");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
