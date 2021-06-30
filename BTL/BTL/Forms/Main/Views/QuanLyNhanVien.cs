using BTL.Forms.Main.Employee;
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
    public partial class QuanLyNhanVien : Form
    {

        QLBanMyPhamContext db = new QLBanMyPhamContext();
        Form parent;

        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        public QuanLyNhanVien(Form p)
        {
            parent = p;
            InitializeComponent();
        }

        private void hienThiData()
        {
            List<NhanVien> ds = new List<NhanVien>();
            ds = db.NhanViens.Select(s => s).ToList();
            dataViewNV.Rows.Clear();
            foreach (var item in ds)
            {
                dataViewNV.Rows.Add(item.MaNv,item.TenNv,item.Anh,item.GioiTinh==true?"Nam":"Nữ",item.Sdt,item.MaCuaHang);
            }
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            hienThiData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            hienThiData();
        }

        // THEM
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Ultility.modal(parent, new AddForm(db));
            hienThiData();
        }

        // XOA
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int indexOfRow = dataViewNV.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataViewNV.Rows[indexOfRow];
            string maNV = Convert.ToString(row.Cells["mnv"].Value);

            NhanVien nv = db.NhanViens.Find(maNV);

            // Delete all accounts have maNV
            var accounts = db.TaiKhoans.Where(x => x.MaNv == nv.MaNv);
            db.RemoveRange(accounts);

            // Delete nhan vien
            db.NhanViens.Remove(nv);
            db.SaveChanges();

            hienThiData();
            MessageBox.Show("Xóa tài thành công!");
        }


        // TIM KIEM
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtTimKiem.Text;
                NhanVien nv = db.NhanViens.Find(maNV);
                if (nv == null) throw new Exception("Không tìm thấy nhân viên có mã: " + maNV);
                if (maNV == "") throw new Exception("Vui lòng nhập mã nhân viên cần tìm!");

                dataViewNV.Rows.Clear();
                dataViewNV.Rows.Add(nv.MaNv, nv.TenNv, nv.Anh, nv.GioiTinh==true?"Nam":"Nữ", nv.Sdt, nv.MaCuaHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }


        // SUA
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int indexOfRow = dataViewNV.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataViewNV.Rows[indexOfRow];
            string maNV = Convert.ToString(row.Cells["mnv"].Value);

            Ultility.modal(parent, new EditForm(maNV,db));
            hienThiData();
        }
    }
}
