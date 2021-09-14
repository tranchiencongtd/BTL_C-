using BTL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.Forms.Main.DatHang
{
    public partial class AddSanPhamDat : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        TaiKhoan currentUser;
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        public delegate void ThemSanPhamDat(string maSP, string tenSanPham, int soLuongDat, decimal giaDat);
        public event ThemSanPhamDat ThemSPEvent;

        public AddSanPhamDat()
        {
            InitializeComponent();
        }
        public AddSanPhamDat(QLBanMyPhamContext currentDb, TaiKhoan user)
        {
            InitializeComponent();
            db = currentDb;
            currentUser = user;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddSanPhamDat_Load(object sender, EventArgs e)
        {
            ActiveControl = comboBoxMaSP;
            List<SanPham> dsSP = new List<SanPham>();
            dsSP = db.SanPhams.Select(s => s).ToList();
            foreach (var item in dsSP)
            {
                comboBoxMaSP.Items.Add(item.MaSp);
            }
            hienThi();
        }
        private void hienThi()
        {
            var sp = db.SanPhams.Where(s => s.Slton <= s.DinhMucHetHang).ToList();
            dgvSP.Rows.Clear();
            foreach (var item in sp)
            {
                dgvSP.Rows.Add(item.MaSp, item.TenSp, item.Slton, item.DinhMucHetHang);
            }
        }

        private void comboBoxMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxMaSP.SelectedIndex;
            if (index == -1)
            {
                txtTenSP.Text = "";
                txtDonGia.Text = "";
                txtSoLuongDat.Text = "";
            }
            else
            {
                string selectedItem = comboBoxMaSP.Items[index].ToString();
                var sp = db.SanPhams.Where(s => s.MaSp == selectedItem).FirstOrDefault();
                txtTenSP.Text = sp.TenSp;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tenSP = txtTenSP.Text.ToLower().Trim();
            try
            {
                if (tenSP == "") throw new Exception("Vui lòng nhập tên sản phẩm cần tìm!");
                var check = db.SanPhams.Where(s => s.TenSp.Contains(tenSP)).ToList();
                if (check.Count == 0) throw new Exception("Không tìm thấy sản phẩm có tên " + tenSP);
                else if (check.Count == 1)
                {
                    foreach (var item in check)
                    {
                        comboBoxMaSP.Text = item.MaSp;
                    }
                }
                else
                {
                    dgvSP.Rows.Clear();
                    foreach (var item in check)
                    {
                        dgvSP.Rows.Add(item.MaSp, item.TenSp, item.Slton, item.DinhMucHetHang);
                    }
                    labelTieuDe.Text = "Danh sách sản phẩm có tên gần giống " + txtTenSP.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxMaSP.Text == "") throw new Exception("Vui lòng chọn mã sản phẩm");
                if (txtTenSP.Text == "") throw new Exception("Tên sản phẩm không để trống");
                if (txtSoLuongDat.Text == "") throw new Exception("Số lượng đặt không để trống");
                if (txtDonGia.Text == "") throw new Exception("Đơn giá không để trống");
                if (decimal.Parse(txtDonGia.Text, CultureInfo.InvariantCulture) < 0) throw new Exception("Đơn giá > 0");
                if (int.Parse(txtSoLuongDat.Text.Trim()) < 0) throw new Exception("Số lượng đặt > 0");
                string maSP = comboBoxMaSP.Text.Trim();
                string tenSP = txtTenSP.Text.Trim();
                int slDat = int.Parse(txtSoLuongDat.Text);
                decimal donGiaDat = Convert.ToDecimal(txtDonGia.Text);

                if (ThemSPEvent != null)
                {
                    ThemSPEvent(maSP, tenSP, slDat, donGiaDat);
                    xoaTrang();
                }
                else
                {
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lỗi nhập số liệu là kí tự!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnTimSPTonDuoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSLTonDuoi.Text == "") throw new Exception("Vui lòng nhập số lượng để tìm");
                if (int.Parse(txtSLTonDuoi.Text) < 0) throw new Exception("Nhập số >= 0");
                var sp = db.SanPhams.Where(s => s.Slton <= int.Parse(txtSLTonDuoi.Text)).ToList();
                dgvSP.Rows.Clear();
                foreach (var item in sp)
                {
                    dgvSP.Rows.Add(item.MaSp, item.TenSp, item.Slton, item.DinhMucHetHang);
                }
                labelTieuDe.Text = "Danh sách sản phẩm có số lượng tồn dưới " + txtSLTonDuoi.Text;
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập số");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSP_DoubleClick(object sender, EventArgs e)
        {
            int indexOfRow = dgvSP.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvSP.Rows[indexOfRow];
            string maSP = Convert.ToString(row.Cells["maSanPham"].Value);
            comboBoxMaSP.Text = maSP;
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            hienThi();
            labelTieuDe.Text = "Danh sách sản phẩm sắp hết";
        }
        private void xoaTrang()
        {
            comboBoxMaSP.SelectedIndex = -1;
            txtDonGia.Clear();
            txtSLTonDuoi.Clear();
            txtSoLuongDat.Clear();
            txtTenSP.Clear();
        }
    }
}
