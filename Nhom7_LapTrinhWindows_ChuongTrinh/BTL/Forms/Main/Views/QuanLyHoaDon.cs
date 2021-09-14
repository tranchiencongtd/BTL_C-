
using BTL.Forms.Main.HoaDon;
using BTL.Forms.Main.HoaDons;
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
    
    public partial class QuanLyHoaDon : Form
    {
        QLBanMyPhamContext db=new QLBanMyPhamContext();
        TaiKhoan user;
        Form parent;

        public QuanLyHoaDon(Form p, TaiKhoan x)
        {
            user = x;
            parent = p;
            InitializeComponent();
        }
        private void hienthiData()
        {
            try
            {
                var dshd = from s in db.HoaDons orderby s.NgayLap descending
                           select new
                           {
                               mahd = s.MaHd,
                               ngaylap = s.NgayLap,
                               tennv=s.MaNvNavigation.TenNv,
                               tenkh=s.MaKhNavigation.TenKh
                           };
                dataViewHD.Rows.Clear();

                int dem = 0;
                foreach (var item in dshd)
                {
                    dataViewHD.Rows.Add(item.mahd, item.ngaylap.ToString("dd-MM-yyyy HH:mm:ss"),item.tennv,item.tenkh);
                    dem++;
                    if (dem == 5)
                        break;
                }
            }
            catch(Exception e)
            { 
                MessageBox.Show("Lỗi không lấy được dữ liệu! " + e.Message);
            }

           
        }

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            hienthiData();
            // Phan quyen 
            if (!user.ChucVu)
            {
                btnDelete.Visible = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            hienthiData();
            txtTimKiem.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddHDForm hDForm;
            hDForm = new AddHDForm(db, user);
            Ultility.modal(parent, hDForm);
            hienthiData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int indexOfRow = dataViewHD.SelectedCells[0].RowIndex;
                DataGridViewRow row = dataViewHD.Rows[indexOfRow];
                if (MessageBox.Show("Bạn chắc chắn muốn xóa hóa đơn " + row.Cells[0].Value, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string maHD = row.Cells[0].Value.ToString();
                    Models.HoaDon hd = db.HoaDons.Find(maHD);
                    var tthd = db.ThongTinHds.Where(x => x.MaHd == hd.MaHd);
                    if (tthd.Count()!= 0)
                    {
                            db.RemoveRange(tthd);
                            db.HoaDons.Remove(hd);
                            db.SaveChanges();
                        hienthiData();
                        MessageBox.Show("Xóa thành công!");
                    }
                    else
                    {
                        db.HoaDons.Remove(hd);
                        db.SaveChanges(); 
                        hienthiData();
                        MessageBox.Show("Xóa thành công!");
                    }
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }
        private void xemTTHD()
        {
            int indexOfRow = dataViewHD.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataViewHD.Rows[indexOfRow];
            XemTTHDForm TTHDForm = new XemTTHDForm(db);
            TTHDForm.Tag = row.Cells[0].Value.ToString();
            TTHDForm.StartPosition = FormStartPosition.CenterScreen;
            TTHDForm.ShowDialog();
            TTHDForm.TopMost = true;
        }

        private void iBtnXem_Click(object sender, EventArgs e)
        {
            try { 
            xemTTHD();
                }
            catch (Exception)
            {

                MessageBox.Show("Chưa chọn hóa đơn");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateBD.Value > dateKT.Value) throw new Exception("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!");
                if (txtTimKiem.Text.Trim()=="")
                {
                    var hd = from s in db.HoaDons
                             where s.NgayLap >= dateBD.Value && s.NgayLap < dateKT.Value
                               select new
                               {
                                   mahd = s.MaHd,
                                   ngaylap = s.NgayLap,
                                   tennv = s.MaNvNavigation.TenNv,
                                   tenkh = s.MaKhNavigation.TenKh
                               };
                    dataViewHD.Rows.Clear();
                    foreach (var item in hd)
                    {
                        dataViewHD.Rows.Add(item.mahd, item.ngaylap.ToString("dd-MM-yyyy HH:mm:ss"), item.tennv, item.tenkh);
                    }
                }
                else
                {
                    var hd = db.HoaDons.Find(txtTimKiem.Text.Trim());
                    if(hd!=null)
                    {
                        dataViewHD.Rows.Clear();
                        NhanVien a = db.NhanViens.Find(hd.MaNv);
                        KhachHang b = db.KhachHangs.Find(hd.MaKh);
                        dataViewHD.Rows.Add(hd.MaHd, hd.NgayLap.ToString("dd-MM-yyyy HH:mm:ss"), a.TenNv, b.TenKh);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn!");
                        btnRefresh_Click(sender, e);
                    }
                }
                if (dataViewHD.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy hóa đơn!");
                txtTimKiem.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataViewHD_DoubleClick(object sender, EventArgs e)
        {
            xemTTHD();
        }
    }
}
