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
using BTL.Ultilities;

namespace BTL.Forms.Main.NhaCungCap
{
    public partial class ThemNhaCC : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        public ThemNhaCC()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                NhaCc a = new NhaCc();
                //var x = db.NhaCcs.SingleOrDefault(nh => nh.MaNcc == txtmaNhaCC.Text);
                //if (x != null) throw new Exception("mã nhà cung cấp bị trùng");
                
               
                if (txtTenNhaCC.Text.Trim() == "") throw new Exception("Tên nhà cung cấp không được để trống!");
                if (txtDienThoai.Text.Trim().Length != 11) throw new Exception("SĐT phải có 11 số !");
                if (txtDiaChi.Text.Trim() == "") throw new Exception("Địa chỉ không được để trống!");
                if (txtFax.Text.Trim()=="") throw new Exception("Số Fax không được để trống!");
                if (txtSoTK.Text.Trim() == "") throw new Exception("Số Tk không được để trống!");
                //a.MaNcc = txtmaNhaCC.Text;
                a.MaNcc = Ultility.generateId("NCC");
                a.TenNcc = txtTenNhaCC.Text;
                a.Fax = txtFax.Text;
                a.DienThoai = txtDienThoai.Text;
                a.DiaChi = txtDiaChi.Text;
                a.SoTaiKhoan = txtSoTK.Text;
                db.NhaCcs.Add(a);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            };

        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemNhaCC_Load(object sender, EventArgs e)
        {

        }
    }
}
