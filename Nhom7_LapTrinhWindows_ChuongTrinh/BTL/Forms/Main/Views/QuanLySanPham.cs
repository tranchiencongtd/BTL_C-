using BTL.Forms.Main.Product;
using BTL.Models;
using BTL.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.Forms.Main.Views
{
    public partial class QuanLySanPham : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        Form parent;
        TaiKhoan user;
        public QuanLySanPham()
        {
            InitializeComponent();
        }
        public QuanLySanPham(Form p, TaiKhoan currentUser)
        {
            parent = p;
            user = currentUser;
            InitializeComponent();
        }

        private void hienThiData()
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            dgvSP.Rows.Clear();
            var ds = from s in db.SanPhams
                     select new
                     {
                         s.MaSp,s.TenSp,s.XuatXu,s.ThuongHieu,s.DonViTinh,s.Slton,s.DonGia,s.MaDmNavigation.TenDm,s.DinhMucHetHang
                     };
            foreach (var item in ds)
            {
                dgvSP.Rows.Add(item.MaSp, item.TenSp, item.XuatXu, item.ThuongHieu, item.DonViTinh, item.Slton, item.DonGia.ToString("#,###", cul.NumberFormat), item.TenDm,item.DinhMucHetHang);
            }

          
        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            hienThiData();
            // Phan quyen 
            if (!user.ChucVu)
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            hienThiData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Ultility.modal(parent, new ProductAdd(db));
            hienThiData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int indexOfRow = dgvSP.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvSP.Rows[indexOfRow];
            string maSP = Convert.ToString(row.Cells["maSanPham"].Value);

            Ultility.modal(parent, new ProductEdit(maSP, db));
            hienThiData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int indexOfRow = dgvSP.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvSP.Rows[indexOfRow];
                if (MessageBox.Show("Bạn chắc chắn muốn xóa sản phẩm " + row.Cells[1].Value, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string maSP = Convert.ToString(row.Cells["maSanPham"].Value);
                    SanPham sp = db.SanPhams.Find(maSP);
                    // Delete san pham
                    db.SanPhams.Remove(sp);
                    db.SaveChanges();

                    hienThiData();
                    MessageBox.Show("Xóa sản phẩm thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSP = txtTim.Text.ToLower();
                var sp = db.SanPhams.Where(s => s.TenSp.Contains(tenSP)).Select(s => new
                {
                    s.MaSp,
                    s.TenSp,
                    s.XuatXu,
                    s.ThuongHieu,
                    s.DonViTinh,
                    s.Slton,
                    s.DonGia,
                    s.MaDmNavigation.TenDm
                });
                if (tenSP == "") throw new Exception("Vui lòng nhập tên sản phẩm cần tìm!");

                dgvSP.Rows.Clear();
                foreach (var item in sp)
                {
                    dgvSP.Rows.Add(item.MaSp, item.TenSp, item.XuatXu, item.ThuongHieu, item.DonViTinh, item.Slton, item.DonGia, item.TenDm);
                }
                if(dgvSP.RowCount==0) throw new Exception("Không tìm thấy sản phẩm: " + tenSP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
