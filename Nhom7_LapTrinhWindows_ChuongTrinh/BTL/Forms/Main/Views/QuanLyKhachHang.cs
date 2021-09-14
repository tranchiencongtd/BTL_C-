using BTL.Forms.Main.Customer;
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
    public partial class QuanLyKhachHang : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        Form parent;
        TaiKhoan user;
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }
        public QuanLyKhachHang(Form p, TaiKhoan currentUser)
        {
            parent = p;
            user = currentUser;
            InitializeComponent();
        }
        private void hienThiData()
        {
            List<KhachHang> ds = new List<KhachHang>();
            ds = db.KhachHangs.Select(s => s).ToList();
            dataViewKH.Rows.Clear();
            foreach (var item in ds)
            {
                dataViewKH.Rows.Add(item.MaKh,item.TenKh,item.Sdt,item.TichDiem);
            }

           
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            hienThiData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Ultility.modal(parent, new AddFormKH(db));
            hienThiData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int indexOfRow = dataViewKH.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataViewKH.Rows[indexOfRow];
            var kh=db.KhachHangs.Find(row.Cells["MaKh"].Value.ToString());
            UpdateFormKH update = new UpdateFormKH(db);
            update.Tag = kh;
            Ultility.modal(parent,update);
            hienThiData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int indexOfRow = dataViewKH.SelectedCells[0].RowIndex;
                DataGridViewRow row = dataViewKH.Rows[indexOfRow];
                if (row.Cells[0].Value.ToString() == "KH01") throw new Exception("Không thể xóa trường này!!!");
                if (MessageBox.Show("Bạn chắc chắn muốn xóa khách hàng " + row.Cells[1].Value, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string maKH = row.Cells[0].Value.ToString();
                    KhachHang kh = db.KhachHangs.Find(maKH);
                    #region Delete tat ca hoa don
                    var hdkh = db.HoaDons.Where(x => x.MaKh == kh.MaKh).ToList();
                    if (hdkh.Count() != 0)
                    {
                        if (MessageBox.Show("Khách hàng này còn hóa đơn trong cửa hàng!!! Bạn thật sự muốn xóa tất cả các hóa đơn này???", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            foreach (var item in hdkh)
                            {
                                var tthdk = db.ThongTinHds.Where(x => x.MaHd == item.MaHd).ToList();
                                db.RemoveRange(tthdk);
                                db.HoaDons.Remove(item);
                            }
                            db.KhachHangs.Remove(kh);
                            db.SaveChanges();
                            MessageBox.Show("Xóa thành công!");
                            hienThiData();
                        }    
                    }
                    #endregion
                    else
                    {
                        db.KhachHangs.Remove(kh);
                        db.SaveChanges();
                        MessageBox.Show("Xóa thành công!");
                        hienThiData();
                    }
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }

        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {     
            hienThiData();
            // Phan quyen 
            if (!user.ChucVu)
            {
                btnDelete.Visible = false;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string Timkiem = txtTimKiem.Text.Trim();
                var kh = db.KhachHangs.Where(s => s.Sdt.Contains(Timkiem));
                if (Timkiem == "") throw new Exception("Vui lòng nhập số điện thoại của khách hàng cần tìm!");
                dataViewKH.Rows.Clear();
                foreach (var item in kh)
                {
                    dataViewKH.Rows.Add(item.MaKh, item.TenKh, item.Sdt, item.TichDiem);
                }
                if (dataViewKH.Rows.Count == 0) throw new Exception("Không tìm thấy khách hàng có số điện thoại " + Timkiem);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtTimKiem.Clear();
        }


    }
}
