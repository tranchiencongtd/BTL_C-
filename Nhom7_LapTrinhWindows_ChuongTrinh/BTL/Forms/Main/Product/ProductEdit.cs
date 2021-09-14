using BTL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace BTL.Forms.Main.Product
{
    public partial class ProductEdit : Form
    {
        QLBanMyPhamContext db;
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        SanPham sp = new SanPham();
        string maSP;
        public ProductEdit()
        {
            InitializeComponent();
        }
        public ProductEdit(string s, QLBanMyPhamContext dt)
        {
            maSP = s;
            db = dt;
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductEdit_Load(object sender, EventArgs e)
        {
            sp = db.SanPhams.Find(maSP);
            labelMaSP.Text = sp.MaSp;

            //load thông tin san pham
            txtDonGia.Text = sp.DonGia.ToString("#,###", cul.NumberFormat);
            comboBoxDVT.Text = sp.DonViTinh.ToString();
            txtTenSanPham.Text = sp.TenSp;
            txtThuongHieu.Text = sp.ThuongHieu;
            comboBoxXuatXu.Text = sp.XuatXu;
            
            var DM = db.DanhMucs.Where(s => s.MaDm == sp.MaDm).FirstOrDefault();
            comboBoxTenDanhMuc.Text = DM.TenDm;
            txtDinhMucDatHang.Text = sp.DinhMucHetHang.ToString();

            //load ten danh muc
            List<DanhMuc> dsDM = new List<DanhMuc>();
            dsDM = db.DanhMucs.Select(s => s).ToList();
            foreach (var item in dsDM)
            {
                comboBoxTenDanhMuc.Items.Add(item.TenDm);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenSanPham.Text.Trim() == "") throw new Exception("Tên sản phẩm không được để trống!");
                if (comboBoxDVT.Text.Trim() == "") throw new Exception("Đơn vị tính không được để trống!");
                if (txtDonGia.Text.Trim() == "") throw new Exception("Đơn giá không được để trống!");
                if (decimal.Parse(txtDonGia.Text.Trim()) < 0) throw new Exception("Đơn giá > 0");
                if (comboBoxXuatXu.Text.Trim() == "") throw new Exception("Xuất xứ không được để trống!");
                if (txtThuongHieu.Text.Trim() == "") throw new Exception("Thương hiệu không được để trống!");
                if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal check)) throw new Exception("Đơn giá phải là số");
                if (comboBoxTenDanhMuc.Text.Trim() == "") throw new Exception("Vui lòng chọn danh mục!");
                if (txtDinhMucDatHang.Text == "") throw new Exception("Định mức đặt hàng không được để trống!");
                if (int.Parse(txtDinhMucDatHang.Text) < 0) throw new Exception("Định mức đặt hàng >= 0");

                string tenCheck = txtTenSanPham.Text.Trim();
                var check1 = db.SanPhams.Where(s => s.TenSp == tenCheck).FirstOrDefault();
                if (check1 != null)
                {
                    if (check1.TenSp == sp.TenSp)
                    {
                        sp.TenSp = txtTenSanPham.Text.Trim();
                        sp.DonGia = decimal.Parse(txtDonGia.Text.Trim());
                        sp.DonViTinh = comboBoxDVT.Text.Trim();
                        sp.XuatXu = comboBoxXuatXu.Text.Trim();
                        sp.ThuongHieu = txtThuongHieu.Text.Trim();
                        sp.DinhMucHetHang = int.Parse(txtDinhMucDatHang.Text);

                        var selectedItem = comboBoxTenDanhMuc.Text;
                        var ten = db.DanhMucs.Where(s => s.TenDm == selectedItem).FirstOrDefault();
                        sp.MaDm = ten.MaDm;
                        //Lưu db
                        db.SaveChanges();
                        MessageBox.Show("Sửa thành công");
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Tên sản phẩm này đã tồn tại");
                    }

                }
                else
                {
                    sp.TenSp = txtTenSanPham.Text.Trim();
                    sp.DonGia = decimal.Parse(txtDonGia.Text.Trim());
                    sp.DonViTinh = comboBoxDVT.Text.Trim();
                    sp.XuatXu = comboBoxXuatXu.Text.Trim();
                    sp.ThuongHieu = txtThuongHieu.Text.Trim();
                    sp.DinhMucHetHang = int.Parse(txtDinhMucDatHang.Text);

                    string selectedItem = comboBoxTenDanhMuc.Text;
                    var ten = db.DanhMucs.Where(s => s.TenDm == selectedItem).FirstOrDefault();
                    sp.MaDm = ten.MaDm;
                    //Lưu db
                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công");
                    this.Close();
                }

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
    }
}
