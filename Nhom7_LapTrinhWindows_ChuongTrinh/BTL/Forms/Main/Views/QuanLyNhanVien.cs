using BTL.Forms.Main.Employee;
using BTL.Models;
using BTL.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                Image image;
                using (Stream stream = File.OpenRead($"{Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 26)}{item.Anh}"))
                {
                    image = System.Drawing.Image.FromStream(stream).GetThumbnailImage(80, 80, null, IntPtr.Zero);
                }

                dataViewNV.Rows.Add(item.MaNv,item.TenNv, image,item.GioiTinh==true?"Nam":"Nữ",item.Sdt, item.ChucVuNv, item.MaCuaHang);
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
            Ultility.modal(parent, new ThemNhanVienForm(db));
            hienThiData();
        }

        // XOA
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int indexOfRow = dataViewNV.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataViewNV.Rows[indexOfRow];
            string maNV = Convert.ToString(row.Cells["mnv"].Value);

            NhanVien nv = db.NhanViens.Find(maNV);

            if (MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên " + nv.TenNv, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Delete all accounts have maNV
                var accounts = db.TaiKhoans.Where(x => x.MaNv == nv.MaNv);
                db.RemoveRange(accounts);

                // Delete nhan vien
                db.NhanViens.Remove(nv);
                db.SaveChanges();

                if(nv.Anh != "\\images\\noavt.png")
                {
                    var filePath = Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 26) + nv.Anh;
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
                hienThiData();
                MessageBox.Show("Xóa tài thành công!");
            } 
        }


        // TIM KIEM

        void timKiem()
        {
            try
            {
                string searchString = txtTimKiem.Text;
                var results = db.NhanViens.Where(s => s.TenNv.Contains(searchString)).ToList();
                if (results == null) throw new Exception("Không tìm thấy nhân viên phù hợp với: " + searchString);
                if (searchString == "") throw new Exception("Vui lòng nhập tên nhân viên cần tìm!");
                dataViewNV.Rows.Clear();
                foreach (var item in results)
                {
                    Image image;
                    using (Stream stream = File.OpenRead($"{Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 26)}{item.Anh}"))
                    {
                        image = System.Drawing.Image.FromStream(stream).GetThumbnailImage(80, 80, null, IntPtr.Zero);
                    }

                    dataViewNV.Rows.Add(item.MaNv, item.TenNv, image, item.GioiTinh == true ? "Nam" : "Nữ", item.Sdt, item.ChucVuNv, item.MaCuaHang);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            timKiem();
        }


        // SUA
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int indexOfRow = dataViewNV.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataViewNV.Rows[indexOfRow];
            string maNV = Convert.ToString(row.Cells["mnv"].Value);

            Ultility.modal(parent, new SuaNhanVienForm(maNV,db));
            hienThiData();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timKiem();
            }
        }
    }
}
