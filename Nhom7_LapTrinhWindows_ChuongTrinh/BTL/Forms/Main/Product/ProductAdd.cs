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

namespace BTL.Forms.Main.Product
{
    public partial class ProductAdd : Form
    {
        QLBanMyPhamContext db ;
        public ProductAdd()
        {
            InitializeComponent();
        }
        public ProductAdd(QLBanMyPhamContext dt)
        {
            db = dt;
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductAdd_Load(object sender, EventArgs e)
        {
            labelMaSP.Text = Ultility.generateId("SP");
            List<DanhMuc> dsDM = new List<DanhMuc>();
            dsDM = db.DanhMucs.Select(s => s).ToList();
            foreach (var item in dsDM)
            {
                comboBoxTenDanhMuc.Items.Add(item.TenDm);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenSanPham.Text.Trim() == "") throw new Exception("Tên sản phẩm không được để trống!");
                if (comboBoxDVT.Text.Trim() == "") throw new Exception("Đơn vị tính không được để trống!");
                if (txtDonGia.Text.Trim() == "") throw new Exception("Đơn giá không được để trống!");
                if (decimal.Parse(txtDonGia.Text.Trim())<0) throw new Exception("Đơn giá > 0");
                if (comboBoxXuatXu.Text.Trim() == "") throw new Exception("Xuất xứ không được để trống!");
                if (txtThuongHieu.Text.Trim() == "") throw new Exception("Thương hiệu không được để trống!");
                if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal check)) throw new Exception("Đơn giá phải là số");
                if (comboBoxTenDanhMuc.Text.Trim() == "") throw new Exception("Vui lòng chọn danh mục!");
                if (txtDinhMucDatHang.Text == "") throw new Exception("Định mức đặt hàng không được để trống!");
                if (int.Parse(txtDinhMucDatHang.Text) < 0) throw new Exception("Định mức đặt hàng >= 0");

                string tenCheck = txtTenSanPham.Text.Trim();
                var check1 = db.SanPhams.Where(s => s.TenSp == tenCheck).FirstOrDefault();
                if (check1 != null) throw new Exception("Tên sản phẩm này đã tồn tại");

                SanPham sp = new SanPham();
                sp.MaSp = labelMaSP.Text;
                sp.TenSp = txtTenSanPham.Text.Trim();
                sp.DonViTinh = comboBoxDVT.Text.Trim();
                sp.DonGia = decimal.Parse(txtDonGia.Text);
                sp.XuatXu = comboBoxXuatXu.Text.Trim();
                sp.ThuongHieu = txtThuongHieu.Text.Trim();
                sp.DinhMucHetHang = int.Parse(txtDinhMucDatHang.Text);

                string selectedItem = comboBoxTenDanhMuc.SelectedItem.ToString();
                var ten = db.DanhMucs.Where(s => s.TenDm == selectedItem).FirstOrDefault();
                sp.MaDm = ten.MaDm;

                int slton = 0;
                sp.Slton = slton;

                db.SanPhams.Add(sp);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                xoaTrang();
            }
            catch (FormatException)
            {
                MessageBox.Show("Lỗi nhập số liệu là kí tự");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void xoaTrang()
        {
            txtTenSanPham.Clear();
            txtDonGia.Clear();
            comboBoxDVT.Text="";
            txtThuongHieu.Clear();
            comboBoxXuatXu.Text="";
            comboBoxTenDanhMuc.SelectedIndex = -1;
        }
    }
}
