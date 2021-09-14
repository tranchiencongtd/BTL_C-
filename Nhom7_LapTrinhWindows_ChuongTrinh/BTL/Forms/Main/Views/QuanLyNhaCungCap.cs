using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL.Models;
using BTL.Forms.Main.NhaCungCap;
namespace BTL.Forms.Main.Views
{
    public partial class QuanLyNhaCungCap : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        TaiKhoan user;
        public QuanLyNhaCungCap()
        {
            InitializeComponent();
        }

        public QuanLyNhaCungCap(TaiKhoan currentUser)
        {
            user = currentUser;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemNhaCC a = new ThemNhaCC();
            a.ShowDialog();
            hienthi();
        }
        private void hienthi()
        {
            List<NhaCc> dsnhacc = db.NhaCcs.ToList();
            dataViewNCC.Rows.Clear();
            foreach(var item in dsnhacc)
            {
                dataViewNCC.Rows.Add(item.MaNcc, item.TenNcc, item.DienThoai, item.DiaChi, item.Fax, item.SoTaiKhoan);
            }
        }

        private void QuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            hienthi();

            // Phan quyen 
            if (!user.ChucVu)
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void dataViewNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int row = dataViewNCC.CurrentCell.RowIndex;
            string mancc = dataViewNCC.Rows[row].Cells[0].Value.ToString();
            SuaNhaCC sua = new SuaNhaCC(mancc,db);
            sua.ShowDialog();
            hienthi();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            hienthi();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<NhaCc> a = db.NhaCcs.Where(x => x.TenNcc.Contains(txtTimKiem.Text)).ToList();
            dataViewNCC.Rows.Clear();
            foreach (var item in a)
            {
                dataViewNCC.Rows.Add(item.MaNcc, item.TenNcc, item.DienThoai, item.DiaChi, item.Fax, item.SoTaiKhoan);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int indexOfRow = dataViewNCC.SelectedCells[0].RowIndex;
                DataGridViewRow row = dataViewNCC.Rows[indexOfRow];
                if (MessageBox.Show("Bạn chắc chắn muốn xóa nhà cung cấp " + row.Cells[0].Value, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string maNCC = row.Cells[0].Value.ToString();
                    Models.NhaCc ncc = db.NhaCcs.Find(maNCC);
                    var tthd = db.NhaCcs.Where(x => x.MaNcc == ncc.MaNcc);
                    if (tthd.Count() != 0)
                    {
                        db.RemoveRange(tthd);
                        db.NhaCcs.Remove(ncc);
                        db.SaveChanges();
                        hienthi();
                        MessageBox.Show("Xóa thành công!");
                    }
                    else
                    {
                        db.NhaCcs.Remove(ncc);
                        db.SaveChanges();
                        hienthi();
                        MessageBox.Show("Xóa thành công!");
                    }
                }
            }
            catch (Exception Ex)
            {
                if(Ex.InnerException.ToString().Contains("conflicted with the REFERENCE"))
                {
                    MessageBox.Show("Nhà cung cấp này đang được gắn ở phiếu đặt hàng");
                }    
                else
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
