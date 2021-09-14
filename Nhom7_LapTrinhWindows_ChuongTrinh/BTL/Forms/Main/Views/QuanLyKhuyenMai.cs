using BTL.Forms.Main.Khuyenmais;
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
    public partial class QuanLyKhuyenMai : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        TaiKhoan user;
        Form parent;
        
        public QuanLyKhuyenMai(Form p, TaiKhoan x)
        {

            user = x;
            parent = p;
            InitializeComponent();
        }

        private void hienthiData()
        {
            try
            {
                var dskm = from s in db.KhuyenMais
                           select new
                           {
                               maKM = s.MaKm,
                               giamGia = s.GiamGia,
                               ngaybd = s.NgayBd,
                               ngaykt = s.NgayKt
                           };
                dataViewKM.Rows.Clear();
                foreach (var item in dskm)
                {
                    dataViewKM.Rows.Add(item.maKM, item.giamGia, item.ngaybd, item.ngaykt);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi không lấy được dữ liệu! " + e.Message);
            }

           
        }
        private void QuanLyKhuyenMai_Load(object sender, EventArgs e)
        {
            hienthiData();
            // Phan quyen 
            if (!user.ChucVu)
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            hienthiData();
            textBox2.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddKM addKMform;
            addKMform = new AddKM(db, user);
            Ultility.modal(parent, addKMform);
            hienthiData();
        }

        private void xemTTKM()
        {
            int indexOfRow = dataViewKM.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataViewKM.Rows[indexOfRow];
            XemTTKM TTKMForm = new XemTTKM(db);
            TTKMForm.Tag = row.Cells[0].Value.ToString();
            Ultility.modal(parent, TTKMForm);
            hienthiData();
            TTKMForm.TopMost = true;
        }
        private void iBtnXem_Click(object sender, EventArgs e)
        {
            xemTTKM();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int indexOfRow = dataViewKM.SelectedCells[0].RowIndex;
                DataGridViewRow row = dataViewKM.Rows[indexOfRow];
                if (MessageBox.Show("Bạn chắc chắn muốn xóa khuyến mại này! " + row.Cells[0].Value, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string maKM = row.Cells[0].Value.ToString();
                    Models.KhuyenMai km = db.KhuyenMais.Find(maKM);
                    var ttkm = db.SanPhamKms.Where(x => x.MaKm == km.MaKm);
                    if (ttkm.Count() != 0)
                    {
                        db.RemoveRange(ttkm);
                        db.KhuyenMais.Remove(km);
                        db.SaveChanges();
                        hienthiData();
                        MessageBox.Show("Xóa thành công!");
                    }
                    else
                    {
                        db.KhuyenMais.Remove(km);
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

        private void iconButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text.Trim() == "") throw new Exception("Không được để trống thông tin tìm kiếm");
                else
                {
                    var km = db.KhuyenMais.Find(textBox3.Text.Trim());
                    if (km != null)
                    {
                        dataViewKM.Rows.Clear();
                        KhuyenMai a = db.KhuyenMais.Find(km.MaKm);

                        dataViewKM.Rows.Add(km.MaKm, km.GiamGia, km.NgayBd, km.NgayKt);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khuyến mãi!");
                        btnRefresh_Click(sender, e);
                    }
                }
                if (dataViewKM.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy hóa đơn!");
                txtTimKiem.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
