using BTL.Models;
using BTL.Ultilities;
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
    public partial class AddDatHangForm : Form
    {
        QLBanMyPhamContext db;
        TaiKhoan currentUser;
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        public AddDatHangForm()
        {
            InitializeComponent();
        }
        public AddDatHangForm(QLBanMyPhamContext currentDb, TaiKhoan user)
        {
            InitializeComponent();
            db = currentDb;
            currentUser = user;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxMaNCC.SelectedIndex;
            if (index == -1)
            {
                txtTenNCC.Text = "";
                labelDiaChiNCC.Text = "";
                labelSDTNCC.Text = "";
            }
            else
            {
                string selectedItem = comboBoxMaNCC.Items[index].ToString();
                var ncc = db.NhaCcs.Where(s => s.MaNcc == selectedItem).FirstOrDefault();
                txtTenNCC.Text = ncc.TenNcc;
                labelDiaChiNCC.Text = ncc.DiaChi;
                labelSDTNCC.Text = ncc.DienThoai;
            }
        }

        private void comboBoxMaCH_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxMaCH.SelectedIndex;
            if (index == -1)
            {
                txtTenCH.Text = "";
                labelDiaChiCH.Text = "";
                labelSDTCH.Text = "";
            }
            else
            {
                string selectedItem = comboBoxMaCH.Items[index].ToString();
                var ch = db.CuaHangs.Where(s => s.MaCuaHang == selectedItem).FirstOrDefault();
                txtTenCH.Text = ch.TenCuaHang;
                labelDiaChiCH.Text = ch.DiaChi;
                labelSDTCH.Text = ch.DienThoai;
            }
        }

        private void AddDatHangForm_Load(object sender, EventArgs e)
        {
            List<NhaCc> dsNCC = new List<NhaCc>();
            dsNCC = db.NhaCcs.Select(s => s).ToList();
            foreach (var item in dsNCC)
            {
                comboBoxMaNCC.Items.Add(item.MaNcc);
            }

            List<CuaHang> dsCH = new List<CuaHang>();
            dsCH = db.CuaHangs.Select(s => s).ToList();
            foreach (var item in dsCH)
            {
                comboBoxMaCH.Items.Add(item.MaCuaHang);
            }
            labelMaPDH.Text = Ultility.generateId("PDH");
            labelNgayLap.Text = DateTime.Now.ToString("dd-MM-yyyy");
            labelNguoiLap.Text = currentUser.MaNvNavigation.TenNv;
        }

        private void btnTimNCC_Click(object sender, EventArgs e)
        {
            string tenNCC = txtTenNCC.Text.ToLower().Trim();
            try
            {
                if (tenNCC == "") throw new Exception("Vui lòng nhập tên nhà cung cấp cần tìm!");
                var check = db.NhaCcs.Where(s => s.TenNcc.Contains(tenNCC)).ToList();
                if (check.Count == 0) throw new Exception("Không tìm thấy nhà cung cấp có tên " + tenNCC);
                if (check.Count == 1)
                {
                    foreach (var item in check)
                    {
                        comboBoxMaNCC.Text = item.MaNcc;
                        txtTenNCC.Text = item.TenNcc;
                        labelDiaChiNCC.Text = item.DiaChi;
                        labelSDTNCC.Text = item.DienThoai;
                    }
                }
                else
                {
                    TimNCC timNcc = new TimNCC(db, tenNCC);
                    timNcc.TopMost = true;
                    timNcc.TimNCCEvent += TimNcc_TimNCCEvent;
                    timNcc.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TimNcc_TimNCCEvent(string maNCC)
        {
            comboBoxMaNCC.Text = maNCC;
        }

        private void btnTimCH_Click(object sender, EventArgs e)
        {
            string tenCH = txtTenCH.Text.ToLower();
            try
            {
                if (tenCH == "") throw new Exception("Vui lòng nhập tên cửa hàng cần tìm!");
                var check = db.CuaHangs.Where(s => s.TenCuaHang.Contains(tenCH)).ToList();
                if (check.Count == 0) throw new Exception("Không tìm thấy cửa hàng có tên " + tenCH);
                if (check.Count == 1)
                {
                    foreach (var item in check)
                    {
                        comboBoxMaCH.Text = item.MaCuaHang;
                        txtTenCH.Text = item.TenCuaHang;
                        labelDiaChiCH.Text = item.DiaChi;
                        labelSDTCH.Text = item.DienThoai;
                    }
                }
                else
                {
                    TimCH timCh = new TimCH(db, tenCH);
                    timCh.TopMost = true;
                    timCh.TimCHEvent += TimCh_TimCHEvent;
                    timCh.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TimCh_TimCHEvent(string maCH)
        {
            comboBoxMaCH.Text = maCH;
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            AddSanPhamDat them = new AddSanPhamDat();
            them.TopMost = true;
            them.ThemSPEvent += Them_ThemSPEvent;   
            them.ShowDialog();
        }

        private void Them_ThemSPEvent(string maSP, string tenSanPham, int soLuongDat, decimal giaDat)
        {
            string maSp = maSP;
            string tenSp = tenSanPham;
            int sld = soLuongDat;
            decimal gd = giaDat;
            int d = 0;
            for (int i = 0; i < dgvSPDH.Rows.Count; i++)
            {
                if (dgvSPDH.Rows[i].Cells[0].Value.ToString() == maSp)
                {
                    MessageBox.Show("Đã có sản phẩm trong danh sách đặt");
                    d++;
                    break;
                }
            }
            if (d == 0)
            {
                dgvSPDH.Rows.Add(maSp, tenSp, sld.ToString(), gd.ToString("#,###", cul.NumberFormat), (sld*gd).ToString("#,###", cul.NumberFormat));
                MessageBox.Show("Thêm thành công");
                decimal Tong = 0;
                for (int i = 0; i < dgvSPDH.Rows.Count; i++)
                {
                    Tong += decimal.Parse(dgvSPDH.Rows[i].Cells[4].Value.ToString(), cul);
                }
                labelTongTien.Text = Tong.ToString("#,###", cul.NumberFormat);
            }
        }

        private void btnTaoPDH_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxMaCH.Text == "") throw new Exception("Bạn cần chọn cửa hàng cần đặt hàng");
                if (comboBoxMaNCC.Text == "") throw new Exception("Bạn cần chọn nhà cung cấp để đặt hàng");
                if (dgvSPDH.Rows.Count == 0) throw new Exception("Bạn chưa chọn hàng cần đặt hàng");

                PhieuDatHang pdh = new PhieuDatHang();
                pdh.MaPhieuDat = labelMaPDH.Text;
                pdh.MaNcc = comboBoxMaNCC.Text.Trim();
                pdh.MaCuaHang = comboBoxMaCH.Text.Trim();
                pdh.NgayDat = DateTime.Now;
                pdh.MaNv = currentUser.MaNv;
                db.PhieuDatHangs.Add(pdh);

                for (int i = 0; i < dgvSPDH.Rows.Count; i++)
                {
                    DongPhieuDat dpdh = new DongPhieuDat();
                    dpdh.MaPhieuDat = pdh.MaPhieuDat;
                    dpdh.MaSp = dgvSPDH.Rows[i].Cells[0].Value.ToString();
                    dpdh.SoLuongDat = int.Parse(dgvSPDH.Rows[i].Cells[2].Value.ToString());
                    dpdh.GiaDat = decimal.Parse(dgvSPDH.Rows[i].Cells[3].Value.ToString(), cul);

                    db.DongPhieuDats.Add(dpdh);
                }

                db.SaveChanges();
                Close();
                XemPhieuDatHang xem = new XemPhieuDatHang(db);
                xem.Tag = pdh.MaPhieuDat;
                xem.StartPosition = FormStartPosition.CenterScreen;
                xem.TopMost = true;
                xem.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            int indexOfRow = dgvSPDH.SelectedCells[0].RowIndex;
            dgvSPDH.Rows.RemoveAt(indexOfRow);
            decimal Tong = 0;
            for (int i = 0; i < dgvSPDH.Rows.Count; i++)
            {
                Tong += Convert.ToDecimal(dgvSPDH.Rows[i].Cells[4].Value, cul);
            }
            labelTongTien.Text = Tong.ToString("#,###", cul.NumberFormat);
        }

        private void txtTenNCC_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string tenNCC = txtTenNCC.Text.ToLower().Trim();
                try
                {
                    if (tenNCC == "") throw new Exception("Vui lòng nhập tên nhà cung cấp cần tìm!");
                    var check = db.NhaCcs.Where(s => s.TenNcc.Contains(tenNCC)).ToList();
                    if (check.Count == 0) throw new Exception("Không tìm thấy nhà cung cấp có tên " + tenNCC);
                    if (check.Count == 1)
                    {
                        foreach (var item in check)
                        {
                            comboBoxMaNCC.Text = item.MaNcc;
                            txtTenNCC.Text = item.TenNcc;
                            labelDiaChiNCC.Text = item.DiaChi;
                            labelSDTNCC.Text = item.DienThoai;
                        }
                    }
                    else
                    {
                        TimNCC timNcc = new TimNCC(db, tenNCC);
                        timNcc.TopMost = true;
                        timNcc.TimNCCEvent += TimNcc_TimNCCEvent;
                        timNcc.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtTenCH_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string tenCH = txtTenCH.Text.ToLower();
                try
                {
                    if (tenCH == "") throw new Exception("Vui lòng nhập tên cửa hàng cần tìm!");
                    var check = db.CuaHangs.Where(s => s.TenCuaHang.Contains(tenCH)).ToList();
                    if (check.Count == 0) throw new Exception("Không tìm thấy cửa hàng có tên " + tenCH);
                    if (check.Count == 1)
                    {
                        foreach (var item in check)
                        {
                            comboBoxMaCH.Text = item.MaCuaHang;
                            txtTenCH.Text = item.TenCuaHang;
                            labelDiaChiCH.Text = item.DiaChi;
                            labelSDTCH.Text = item.DienThoai;
                        }
                    }
                    else
                    {
                        TimCH timCh = new TimCH(db, tenCH);
                        timCh.TopMost = true;
                        timCh.TimCHEvent += TimCh_TimCHEvent;
                        timCh.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
