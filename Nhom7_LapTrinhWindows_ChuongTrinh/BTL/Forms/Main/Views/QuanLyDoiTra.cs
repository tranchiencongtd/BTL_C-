using BTL.Forms.Main.DoiTra;
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

namespace BTL.Forms.Main.Views
{
    public partial class QuanLyDoiTra : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        TaiKhoan user;
        Form parent;
        public QuanLyDoiTra()
        {
            InitializeComponent();
        }

        public QuanLyDoiTra(Form p, TaiKhoan currentUser)
        {
            InitializeComponent();
            parent = p;
            user = currentUser;
        }
        private void hienThiData()
        {
           
            var ds = db.PhieuDoiTras.Select(s => s).ToList();

            dataViewPDT.Rows.Clear();
            int dem = 0;
            foreach (var item in ds)
            {
                
                NhanVien nv = db.NhanViens.Find(item.MaNv);
                string maKH = db.HoaDons.Find(item.MaHd).MaKh;
                var kh = db.KhachHangs.Find(maKH);
                dataViewPDT.Rows.Add(item.MaPhieuDt, item.NgayLap.Value.ToString("dd-MM-yyyy HH:mm:ss"), nv.TenNv, kh.TenKh);
                dem++;
                if (dem == 5) break;
            }

           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemDoiTraForm addForm = new ThemDoiTraForm(db, user);
            Ultility.modal(parent, addForm);
            hienThiData();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            int indexOfRow = dataViewPDT.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataViewPDT.Rows[indexOfRow];

            XemDoiTraForm detailsForm = new XemDoiTraForm(db);
            detailsForm.Tag = row.Cells[0].Value.ToString();
            detailsForm.StartPosition = FormStartPosition.CenterScreen;
            detailsForm.ShowDialog();
            detailsForm.TopMost = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
                try
                {
                    int indexOfRow = dataViewPDT.SelectedCells[0].RowIndex;
                    DataGridViewRow row = dataViewPDT.Rows[indexOfRow];
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa phiếu " + row.Cells[0].Value, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string maPhieu = Convert.ToString(row.Cells["mpdt"].Value);
                        var pdt = db.PhieuDoiTras.Find(maPhieu);
                        var ttpdt = db.ThongTinSpdts.Where(s => s.MaPhieuDt == maPhieu);
                        if (ttpdt.Count() != 0)
                        {
                            db.RemoveRange(ttpdt);
                            db.PhieuDoiTras.Remove(pdt);
                            db.SaveChanges();
                            hienThiData();
                            MessageBox.Show("Xóa thành công!");
                        }
                        else
                        {
                            db.PhieuDoiTras.Remove(pdt);
                            db.SaveChanges();
                            hienThiData();
                            MessageBox.Show("Xóa thành công!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            hienThiData();
        }

        private void QuanLyDoiTra_Load(object sender, EventArgs e)
        {
            hienThiData();
            // Phan quyen 
            if (!user.ChucVu)
            {
                btnDelete.Visible = false;
            }
        }

        
        void timKiem(object sender, EventArgs e)
        {
            try
            {
                var pdt = db.PhieuDoiTras.Find(txtTimKiem.Text.Trim());
                if (pdt != null)
                {
                    dataViewPDT.Rows.Clear();
                    NhanVien a = db.NhanViens.Find(pdt.MaNv);
                    var hd = db.HoaDons.Find(pdt.MaHd);
                    KhachHang b = db.KhachHangs.Find(hd.MaKh);
                    dataViewPDT.Rows.Add(pdt.MaPhieuDt, pdt.NgayLap.Value.ToString("dd-MM-yyyy HH:mm:ss"), a.TenNv, b.TenKh);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu đổi trả!");
                    btnRefresh_Click(sender, e);
                }
                if (dataViewPDT.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy phiếu đổi trả!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            timKiem(sender,e);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timKiem(sender,e);
            }
        }
    }
}
