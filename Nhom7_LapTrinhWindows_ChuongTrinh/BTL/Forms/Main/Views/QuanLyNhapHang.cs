using BTL.Forms.Main.NhapHang;
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

namespace BTL.Forms.Main.Views
{
    public partial class QuanLyNhapHang : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        TaiKhoan user;
        public QuanLyNhapHang(TaiKhoan x)
        {
            InitializeComponent();
            user = x;
        }

        private void QuanLyNhapHang_Load(object sender, EventArgs e)
        {
            hienthi();
            // Phan quyen 
            if (!user.ChucVu)
            {
                btnDelete.Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemPhieuNhap a = new ThemPhieuNhap(user);
            a.ShowDialog();
            hienthi();
        }
        private void hienthi()
        {
            var dsnhacc = (from pn in db.PhieuNhaps join
                           pd in db.PhieuDatHangs on
                           pn.MaPhieuDat equals pd.MaPhieuDat
                           join nv in db.NhanViens on
                           pn.MaNv equals nv.MaNv
                           select new 
                           {
                                mapn = pn.MaPhieuNhap,
                                mach = pd.MaCuaHang,
                                mancc = pd.MaNcc,
                                ngaynhap = pn.NgayNhap,
                                tt = pn.ThanhToan,
                                nn = nv.TenNv
                           }).ToList();

            dataViewNV.Rows.Clear();
            foreach (var item in dsnhacc)
            {
                dataViewNV.Rows.Add(item.mapn, item.mach, item.mancc, item.ngaynhap.ToString("dd-MM-yyyy HH:mm:ss"), item.tt, item.nn);
            }

            
        }

       

        private void dataViewNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            string maphieunhap = dataViewNV.Rows[e.RowIndex].Cells[0].Value.ToString();
            var pn = (from pn1 in db.PhieuNhaps
                      join
                        pd in db.PhieuDatHangs on
                        pn1.MaPhieuDat equals pd.MaPhieuDat
                      join nv in db.NhanViens on
                      pn1.MaNv equals nv.MaNv
                      where pn1.MaPhieuNhap.Equals(maphieunhap)
                      select new
                      {
                          mapn = pn1.MaPhieuNhap,
                          mach = pd.MaCuaHang,
                          mancc = pd.MaNcc,
                          ngaynhap = pn1.NgayNhap,
                          tt = pn1.ThanhToan,
                          nn = nv.TenNv,
                          mapd = pd.MaPhieuDat
                      }).ToList();
            var ctpn = (from ct in db.DongPhieuNhaps
                        join pn2 in db.PhieuNhaps on
                        ct.MaPhieuNhap equals pn2.MaPhieuNhap
                        join sp in db.SanPhams on
                        ct.MaSp equals sp.MaSp
                        where pn2.MaPhieuNhap.Equals(maphieunhap)
                        select new
                        {
                            msp = sp.MaSp,
                            tsp = sp.TenSp,
                            sl = ct.SoLuong,
                            gia = ct.GiaNhap
                        }
            ).ToList();
         
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int indexOfRow = dataViewNV.SelectedCells[0].RowIndex;
                DataGridViewRow row = dataViewNV.Rows[indexOfRow];
                if (MessageBox.Show("Bạn chắc chắn muốn xóa phiếu " + row.Cells[0].Value, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string maPhieu = Convert.ToString(row.Cells[0].Value);
                    var pnh = db.PhieuNhaps.Find(maPhieu);
                    var dpnh = db.DongPhieuNhaps.Where(s => s.MaPhieuNhap == maPhieu);
                    if (dpnh.Count() != 0)
                    {
                        db.RemoveRange(dpnh);
                        db.PhieuNhaps.Remove(pnh);
                        db.SaveChanges();
                        hienthi();
                        MessageBox.Show("Xóa thành công!");
                    }
                    else
                    {
                        db.PhieuNhaps.Remove(pnh);
                        db.SaveChanges();
                        hienthi();
                        MessageBox.Show("Xóa thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            hienthi();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var dsnhacc = (from pn in db.PhieuNhaps
                                join
                                pd in db.PhieuDatHangs on
                                pn.MaPhieuDat equals pd.MaPhieuDat
                                join nv in db.NhanViens on
                                pn.MaNv equals nv.MaNv
                                where pn.MaPhieuNhap.Contains(txtTimKiem.Text) || pn.MaPhieuDatNavigation.MaCuaHang.Contains(txtTimKiem.Text)
                           select new
                           {
                               mapn = pn.MaPhieuNhap,
                               mach = pd.MaCuaHang,
                               mancc = pd.MaNcc,
                               ngaynhap = pn.NgayNhap,
                               tt = pn.ThanhToan,
                               nn = nv.TenNv
                           }).ToList();

            dataViewNV.Rows.Clear();
            if(dsnhacc.ToList().Count == 0)
            {
                MessageBox.Show("Không tìm thấy!");
            }
            else
            {
                foreach (var item in dsnhacc)
                {
                    dataViewNV.Rows.Add(item.mapn, item.mach, item.mancc, item.ngaynhap.ToString("dd-MM-yyyy HH:mm:ss"), item.tt, item.nn);
                }
            }

        }

        private void dataViewNV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            string ma = dataViewNV.Rows[row].Cells[0].Value.ToString().Trim();
            PhieuNhap phNhap = (from pn1 in db.PhieuNhaps
                                join
                                  pd in db.PhieuDatHangs on
                                  pn1.MaPhieuDat equals pd.MaPhieuDat
                                join nv in db.NhanViens on
                                pn1.MaNv equals nv.MaNv
                                where pn1.MaPhieuNhap.Equals(ma)
                                select pn1).FirstOrDefault();
            XemPhieuNhapHang xemPhNhap = new XemPhieuNhapHang(phNhap);
            xemPhNhap.ShowDialog();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            int row = dataViewNV.CurrentRow.Index;
            string ma = dataViewNV.Rows[row].Cells[0].Value.ToString().Trim();
            PhieuNhap phNhap = (from pn1 in db.PhieuNhaps
                                join
                                  pd in db.PhieuDatHangs on
                                  pn1.MaPhieuDat equals pd.MaPhieuDat
                                join nv in db.NhanViens on
                                pn1.MaNv equals nv.MaNv
                                where pn1.MaPhieuNhap.Equals(ma)
                                select pn1).FirstOrDefault();
            XemPhieuNhapHang xemPhNhap = new XemPhieuNhapHang(phNhap);
            xemPhNhap.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataViewSpCanDoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
