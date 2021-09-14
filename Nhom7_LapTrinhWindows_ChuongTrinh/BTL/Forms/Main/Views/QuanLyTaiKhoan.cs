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

namespace BTL.Forms.Main.Views
{
    public partial class QuanLyTaiKhoan : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        TaiKhoan currentLogin;

        public QuanLyTaiKhoan()
        {
            InitializeComponent();
        }


        public QuanLyTaiKhoan(TaiKhoan user)
        {
            InitializeComponent();
            currentLogin = user;
        }


        private void hienThiData()
        {
            List<TaiKhoan> ds = new List<TaiKhoan>();
            ds = db.TaiKhoans.Select(s => s).ToList();
            dataViewAccount.Rows.Clear();
            foreach (var item in ds)
            {
                dataViewAccount.Rows.Add(item.TenTk, item.MatKhau, item.ChucVu ? "Quản lý":"Nhân viên", item.MaNv);
            }
        }

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            // Hien thi Data
            hienThiData();

            // Ds tai khoan + Ten nv + gioi tinh
            var dsNV = db.NhanViens.Select(s => new { 
                maNv = s.MaNv,
                tenNV = s.TenNv,
                gioiTinh = s.GioiTinh,
            }).ToList();

            // Show data vao grid view
            hienThiData();


            // Binding data
            //textBox1.DataBindings.Add(new Binding("Text", dataViewAccount.DataSource, "taikhoan", true, DataSourceUpdateMode.Never));
           // textBox2.DataBindings.Add(new Binding("Text", dataViewAccount.DataSource, "matkhau", true, DataSourceUpdateMode.Never));


            // Add du lieu ma nv cho combobox
            // Ma nhan vien
            foreach (var item in dsNV)
            {
                cbMaNv.Items.Add(item.maNv);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hien thi ten tuong ung voi ma
            int index = cbMaNv.SelectedIndex;
            if (index == -1)
            {
                labelHoTen.Text = "";
                labelGioiTinh.Text = "";
            }
            else
            {
                string selectedItem = cbMaNv.Items[index].ToString();
                var nv = db.NhanViens.Find(selectedItem);
                labelHoTen.Text = nv.TenNv;
                labelGioiTinh.Text = nv.GioiTinh == true?"Nam":"Nữ";
            }
        }

        private void dataViewAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexOfRow = dataViewAccount.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataViewAccount.Rows[indexOfRow];
            txtTaiKhoan.Text = Convert.ToString(row.Cells["tk"].Value);
            txtMatKhau.Text = Convert.ToString(row.Cells["mk"].Value);
            cbMaNv.Text = Convert.ToString(row.Cells["mnv"].Value);
            cbChucVu.Text = Convert.ToString(row.Cells["cv"].Value);
        }

        private void xoaTrang()
        {
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtTimKiem.Clear();
            cbMaNv.Text = "";
            cbMaNv.SelectedIndex = -1;
            cbChucVu.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tenTK = txtTaiKhoan.Text.Trim();
            try
            {
                if (tenTK == "") throw new Exception("Tên tài khoản không được trống");
                var tk = db.TaiKhoans.Find(tenTK);
                if (tk == null) throw new Exception("Không tìm thấy tài khoản có tên " + tenTK);
                if (tenTK == currentLogin.TenTk) throw new Exception("Bạn đang đăng nhập tài khoản này, không thể xóa!");
                if (MessageBox.Show("Bạn chắc chắn muốn xóa tài khoản " + tenTK, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Cập nhật database
                    db.TaiKhoans.Remove(tk);
                    db.SaveChanges();
                    hienThiData();
                    xoaTrang();
                    MessageBox.Show("Xóa tài khoản thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTaiKhoan.Text == "") throw new Exception("Tên tài khoản không được để trống");
                if (txtMatKhau.Text == "") throw new Exception("Mật khẩu không được để trống");
                if (cbMaNv.Text == "") throw new Exception("Vui lòng chọn mã nhân viên");
                if (cbChucVu.Text == "") throw new Exception("Vui lòng chọn chức vụ");

                if(db.TaiKhoans.Where(s => s.MaNv == cbMaNv.Text.Trim()).ToList().Count>0)
                {
                    throw new Exception("Nhân viên này đã có tài khoản!");
                }

                // Kiem tra xem tk da ton tai chua;
                string tenCheck = txtTaiKhoan.Text.Trim();
                TaiKhoan checkTK = db.TaiKhoans.Find(tenCheck);
                if(checkTK!=null) throw new Exception("Tên tài khoản này đã tồn tại");

                string matKhauMaHoa = Ultility.Encrypt(txtMatKhau.Text.Trim());
                // Add tài khoản vào csdl
                TaiKhoan tk = new TaiKhoan()
                {
                    TenTk = txtTaiKhoan.Text.Trim(),
                    ChucVu = cbChucVu.Text.Trim() == "Quản lý" ? true : false,
                    MaNv = cbMaNv.Text.Trim(),
                    MatKhau = matKhauMaHoa,
                };

                // Lưu vào db
                db.TaiKhoans.Add(tk);
                db.SaveChanges();
                hienThiData();
                xoaTrang();
                MessageBox.Show("Thêm tài khoản thành công!");
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
                if (txtTaiKhoan.Text == "") throw new Exception("Tên tài khoản không được để trống");
                if (txtMatKhau.Text == "") throw new Exception("Mật khẩu không được để trống");
                if (cbMaNv.Text == "") throw new Exception("Vui lòng chọn mã nhân viên");
                if (cbMaNv.Text == "") throw new Exception("Vui lòng chọn chức vụ");

                // Kiem tra xem tk da ton tai chua;
                string tenCheck = txtTaiKhoan.Text.Trim();
                TaiKhoan checkTK = db.TaiKhoans.Find(tenCheck);
                if (checkTK == null) throw new Exception("Không tìm thấy tài khoản có tên: " + tenCheck);

                // Sửa tài khoản
                TaiKhoan tk = db.TaiKhoans.Find(tenCheck);
                tk.MatKhau = Ultility.Encrypt(txtMatKhau.Text.Trim());
                tk.ChucVu = cbChucVu.Text.Trim() == "Quản lý" ? true : false;

                tk.MaNv = cbMaNv.Text.Trim();

                // Lưu vào db
                db.SaveChanges();
                hienThiData();
                xoaTrang();
                MessageBox.Show("Sửa tài khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void timKiem()
        {
            string tenTK = txtTimKiem.Text.Trim();
            try
            {
                if (tenTK == "") throw new Exception("Vui lòng nhập tên tài khoản cần tìm!");
                var tk = db.TaiKhoans.Find(tenTK);
                if (tk == null) throw new Exception("Không tìm thấy tài khoản có tên " + tenTK);

                dataViewAccount.Rows.Clear();
                dataViewAccount.Rows.Add(tk.TenTk, tk.MatKhau, tk.ChucVu, tk.MaNv);
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

        private void btnXoaTrang_Click(object sender, EventArgs e)
        {
            xoaTrang();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
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
