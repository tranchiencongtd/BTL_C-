using BTL.Forms.Main.DatHang;
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
    public partial class QuanLyDatHang : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        TaiKhoan user;
        Form parent;
        public QuanLyDatHang()
        {
            InitializeComponent();
        }
        public QuanLyDatHang(Form p, TaiKhoan x)
        {
            user = x;
            parent = p;
            InitializeComponent();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            hienThi();
        }

        private void QuanLyDatHang_Load(object sender, EventArgs e)
        {
            hienThi();
            // Phan quyen 
            if (!user.ChucVu)
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
            }
        }
        private void hienThi()
        {
            dgvDatHang.Rows.Clear();
            var ds = from s in db.PhieuDatHangs
                     select new
                     {
                         s.MaPhieuDat,
                         s.NgayDat,
                         s.MaNvNavigation.TenNv,
                         s.MaNccNavigation.TenNcc
                     };
            foreach (var item in ds)
            {
                dgvDatHang.Rows.Add(item.MaPhieuDat, item.NgayDat.ToString("dd-MM-yyyy HH:mm:ss"), item.TenNv, item.TenNcc);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDatHangForm addForm = new AddDatHangForm(db, user);
            Ultility.modal(parent, addForm);
            hienThi();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            int indexOfRow = dgvDatHang.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvDatHang.Rows[indexOfRow];

            XemPhieuDatHang detailsForm = new XemPhieuDatHang(db);
            detailsForm.Tag = row.Cells[0].Value.ToString();
            detailsForm.StartPosition = FormStartPosition.CenterScreen;
            detailsForm.ShowDialog();
            detailsForm.TopMost = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int indexOfRow = dgvDatHang.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvDatHang.Rows[indexOfRow];
                if (MessageBox.Show("Bạn chắc chắn muốn xóa phiếu " + row.Cells[0].Value, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string maPhieu = Convert.ToString(row.Cells["maDatHang"].Value);
                    var pdh = db.PhieuDatHangs.Find(maPhieu);
                    var pnh = db.PhieuNhaps.Where(s => s.MaPhieuDat == maPhieu).FirstOrDefault();
                    if (pnh != null) throw new Exception("Phiếu đặt hàng này đã có phiếu nhập nên không thể xóa!");
                    var dpdh = db.DongPhieuDats.Where(s => s.MaPhieuDat == maPhieu);
                    if (dpdh.Count() != 0)
                    {
                        db.RemoveRange(dpdh);
                        db.PhieuDatHangs.Remove(pdh);
                        db.SaveChanges();
                        hienThi();
                        MessageBox.Show("Xóa thành công!");
                    }
                    else
                    {
                        db.PhieuDatHangs.Remove(pdh);
                        db.SaveChanges();
                        hienThi();
                        MessageBox.Show("Xóa thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateBD.Value > dateKT.Value) throw new Exception("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!");
                if (txtTimKiem.Text.Trim() == "")
                {
                    var dh = from s in db.PhieuDatHangs
                             where s.NgayDat >= dateBD.Value && s.NgayDat < dateKT.Value
                             select new
                             {
                                 maPhieuDat = s.MaPhieuDat,
                                 ngaylap = s.NgayDat,
                                 tennv = s.MaNvNavigation.TenNv,
                                 tenncc = s.MaNccNavigation.TenNcc
                             };
                    dgvDatHang.Rows.Clear();
                    foreach (var item in dh)
                    {
                        dgvDatHang.Rows.Add(item.maPhieuDat, item.ngaylap.ToString("dd-MM-yyyy HH:mm:ss"), item.tennv, item.tenncc);
                    }
                }
                else
                {
                    var dh = db.PhieuDatHangs.Find(txtTimKiem.Text.Trim());
                    if (dh != null)
                    {
                        dgvDatHang.Rows.Clear();
                        NhanVien a = db.NhanViens.Find(dh.MaNv);
                        NhaCc b = db.NhaCcs.Find(dh.MaNcc);
                        dgvDatHang.Rows.Add(dh.MaPhieuDat, dh.NgayDat.ToString("dd-MM-yyyy HH:mm:ss"), a.TenNv, b.TenNcc);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phiếu đặt!");
                        btnRefresh_Click(sender, e);
                    }
                }
                if (dgvDatHang.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy phiếu đặt!");
                txtTimKiem.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            hienThi();
        }

        private void btnSPSapHet_Click(object sender, EventArgs e)
        {
            SanPhamSapHet detailsForm = new SanPhamSapHet(db);
            detailsForm.StartPosition = FormStartPosition.CenterScreen;
            detailsForm.ShowDialog();
            detailsForm.TopMost = true;
        }
    }
}
