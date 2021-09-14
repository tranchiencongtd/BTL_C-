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
using Microsoft.EntityFrameworkCore;
using BTL.Ultilities;
using System.Globalization;

namespace BTL.Forms.Main.Views
{
    public partial class QuanLyDanhMuc : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
        TaiKhoan user;
        public QuanLyDanhMuc()
        {
            InitializeComponent();
        }

        public QuanLyDanhMuc(TaiKhoan currentUser)
        {
            user = currentUser;
            InitializeComponent();
        }


        private void hienThiData()
        {
            List<DanhMuc> ds = new List<DanhMuc>();
            ds = db.DanhMucs.Select(s => s).ToList();
            dgvDM.Rows.Clear();
            foreach (var item in ds)
            {
                dgvDM.Rows.Add(item.MaDm, item.TenDm);
            }
            comboBoxMaDM.Items.Clear();
            foreach (var item in ds)
            {
                comboBoxMaDM.Items.Add(item.MaDm);
            }
        }

        private void QuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            hienThiData();
            // Phan quyen 
            if (!user.ChucVu)
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            hienThiData();
        }

        private void dgvDM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexOfRow = dgvDM.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvDM.Rows[indexOfRow];
            comboBoxMaDM.Text = Convert.ToString(row.Cells["maDM"].Value);
            txtTenDM.Text = Convert.ToString(row.Cells["tenDM"].Value);
        }

        private void comboBoxMaDM_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxMaDM.SelectedIndex;
            if (index == -1)
            {
                comboBoxMaDM.Text = "";
                txtTenDM.Text = "";
            }
            else
            {
                string selectedItem = comboBoxMaDM.Items[index].ToString();
                var ten = db.DanhMucs.Where(s => s.MaDm == selectedItem).Select(s=>new { tenDM= s.TenDm, maDM = s.MaDm}).FirstOrDefault();
                txtTenDM.Text = ten.tenDM;
                List<SanPham> dssp = new List<SanPham>();
                dssp = db.SanPhams.Where(s => s.MaDm== selectedItem).ToList();
                dgvSP.Rows.Clear();
                foreach (var item in dssp)
                {
                    dgvSP.Rows.Add(item.MaSp, item.TenSp, item.DonGia.ToString("#,###", cul.NumberFormat), item.Slton);
                }
            }
        }
        private void xoaTrang()
        {
            comboBoxMaDM.SelectedIndex=-1;
            txtTenDM.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenDM.Text == "") throw new Exception("Tên danh mục không được để trống");

                // Kiem tra xem dm da ton tai chua;
                string tenCheck = txtTenDM.Text.Trim();
                var check = db.DanhMucs.Where(s => s.TenDm == tenCheck).FirstOrDefault();
                if (check != null) throw new Exception("Tên danh mục này đã tồn tại");

                // Add dm vào csdl
                DanhMuc dm = new DanhMuc();
                dm.MaDm = Ultility.generateId("DM");
                dm.TenDm = txtTenDM.Text.Trim();
                // Lưu vào db
                db.DanhMucs.Add(dm);
                db.SaveChanges();
                hienThiData();
                xoaTrang();
                MessageBox.Show("Thêm danh mục thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maDM = comboBoxMaDM.Text.Trim();
            try
            {
                if (maDM == "") throw new Exception("Vui lòng chọn mã danh mục cần xóa");
                if (MessageBox.Show("Bạn chắc chắn muốn xóa danh mục " + txtTenDM.Text, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var dm = db.DanhMucs.Find(maDM);
                    var sp = db.SanPhams.Where(s => s.MaDm == maDM).FirstOrDefault();
                    if (sp != null)
                    {
                        MessageBox.Show("Trong danh mục này có sản phẩm \nKhông thể xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Cập nhật database
                        db.DanhMucs.Remove(dm);
                        db.SaveChanges();
                        hienThiData();
                        xoaTrang();
                        MessageBox.Show("Xóa danh mục thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxMaDM.Text == "") throw new Exception("Vui lòng chọn mã danh mục cần sửa");
                if (txtTenDM.Text == "") throw new Exception("Tên danh mục không được để trống");

                //Kiem tra da co ten
                string tenCheck = txtTenDM.Text.Trim();
                var check = db.DanhMucs.Where(s => s.TenDm == tenCheck).FirstOrDefault();
                string maCheck = comboBoxMaDM.Text.Trim();
                // Tìm danh mục
                DanhMuc dm = db.DanhMucs.Find(maCheck);
                if (check != null)
                {
                    if (check.TenDm == dm.TenDm)
                    {
                        dm.TenDm = txtTenDM.Text.Trim();
                        // Lưu vào db
                        db.SaveChanges();
                        hienThiData();
                        xoaTrang();
                        MessageBox.Show("Sửa danh mục thành công!");
                    }
                    else
                    {
                        throw new Exception("Tên danh mục này đã tồn tại");
                    }

                }
                else
                {
                    dm.TenDm = txtTenDM.Text.Trim();
                    // Lưu vào db
                    db.SaveChanges();
                    hienThiData();
                    xoaTrang();
                    MessageBox.Show("Sửa danh mục thành công!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenDM = txtTenDM.Text.ToLower().Trim();
            try
            {
                if (tenDM == "") throw new Exception("Vui lòng nhập tên danh mục cần tìm!");
                var check = db.DanhMucs.Where(s => s.TenDm.Contains(tenDM));
                if (check == null) throw new Exception("Không tìm thấy danh mục có tên " + tenDM);

                dgvDM.Rows.Clear();
                foreach (var item in check)
                {
                    dgvDM.Rows.Add(item.MaDm, item.TenDm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnrf_Click(object sender, EventArgs e)
        {
            hienThiData();
        }
    }
}
