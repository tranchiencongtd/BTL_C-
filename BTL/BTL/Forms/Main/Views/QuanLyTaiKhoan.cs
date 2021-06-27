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


namespace BTL.Forms.Main.Views
{
    public partial class QuanLyTaiKhoan : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
       
        
        public QuanLyTaiKhoan()
        {
            InitializeComponent();
        }


        private void hienThiData()
        {
            List<TaiKhoan> ds = new List<TaiKhoan>();
            ds = db.TaiKhoans.Select(s => s).ToList();
            dataViewAccount.Rows.Clear();
            foreach (var item in ds)
            {
                dataViewAccount.Rows.Add(item.TenTk, item.MatKhau, item.ChucVu ? "Admin":"Nhân viên", item.MaNv);
            }
        }

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            // Hien thi Data
            hienThiData();

            // Ds tai khoan + Ten nv
            var dsNV = db.NhanViens.Select(s => new { 
                maNv = s.MaNv,
                tenNV = s.TenNv,
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
                comboBox1.Items.Add(item.maNv);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hien thi ten tuong ung voi ma
            int index = comboBox1.SelectedIndex;
            if (index == -1)
            {
                labelHoTen.Text = "";
            }
            else
            {
                string selectedItem = comboBox1.Items[index].ToString();
                string ten = db.NhanViens.Find(selectedItem).TenNv;
                labelHoTen.Text = ten;
            }
        }

        private void dataViewAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexOfRow = dataViewAccount.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataViewAccount.Rows[indexOfRow];
            textBox1.Text = Convert.ToString(row.Cells["tk"].Value);
            textBox2.Text = Convert.ToString(row.Cells["mk"].Value);
            comboBox1.Text = Convert.ToString(row.Cells["mnv"].Value);
            comboBox2.Text = Convert.ToString(row.Cells["cv"].Value);
        }

        private void xoaTrang()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tenTK = textBox1.Text.Trim();
            try
            {
                if (tenTK == "") throw new Exception("Tên tài khoản không được trống");
                var tk = db.TaiKhoans.Find(tenTK);
                if (tk == null) throw new Exception("Không tìm thấy tài khoản có tên " + tenTK);

                // Cập nhật database
                db.TaiKhoans.Remove(tk);
                db.SaveChanges();
                hienThiData();
                xoaTrang();
                MessageBox.Show("Xóa tài khoản thành công!");
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
                if (textBox1.Text == "") throw new Exception("Tên tài khoản không được để trống");
                if (textBox2.Text == "") throw new Exception("Mật khẩu không được để trống");
                if (comboBox1.Text == "") throw new Exception("Vui lòng chọn mã nhân viên");
                if (comboBox1.Text == "") throw new Exception("Vui lòng chọn chức vụ");

                // Kiem tra xem tk da ton tai chua;
                string tenCheck = textBox1.Text.Trim();
                TaiKhoan checkTK = db.TaiKhoans.Find(tenCheck);
                if(checkTK!=null) throw new Exception("Tên tài khoản này đã tồn tại");

                // Add tài khoản vào csdl
                TaiKhoan tk = new TaiKhoan()
                {
                    TenTk = textBox1.Text.Trim(),
                    ChucVu = comboBox2.Text.Trim() == "Admin" ? true : false,
                    MaNv = comboBox1.Text.Trim(),
                    MatKhau = textBox2.Text.Trim()
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
                if (textBox1.Text == "") throw new Exception("Tên tài khoản không được để trống");
                if (textBox2.Text == "") throw new Exception("Mật khẩu không được để trống");
                if (comboBox1.Text == "") throw new Exception("Vui lòng chọn mã nhân viên");
                if (comboBox1.Text == "") throw new Exception("Vui lòng chọn chức vụ");

                // Kiem tra xem tk da ton tai chua;
                string tenCheck = textBox1.Text.Trim();
                TaiKhoan checkTK = db.TaiKhoans.Find(tenCheck);
                if (checkTK == null) throw new Exception("Không được sửa tên tài khoản");

                // Sửa tài khoản
                TaiKhoan tk = db.TaiKhoans.Find(tenCheck);
                tk.MatKhau = textBox2.Text.Trim();
                tk.ChucVu = comboBox2.Text.Trim() == "Admin" ? true:false ;
                tk.MaNv = comboBox1.Text.Trim();

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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenTK = textBox3.Text.Trim();
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

        private void btnXoaTrang_Click(object sender, EventArgs e)
        {
            xoaTrang();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            hienThiData();
        }
    }
}
