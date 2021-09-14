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

namespace BTL.Forms.Main.DoiTra
{
    public partial class ThemDoiTraForm : Form
    {
        QLBanMyPhamContext db;
        TaiKhoan currentUser;
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        List<SanPham> lsSanPhamDoi = new List<SanPham>();
        List<SanPham> lsSanPhamCanDoi = new List<SanPham>();

        public ThemDoiTraForm()
        {
            InitializeComponent();
        }

        public ThemDoiTraForm(QLBanMyPhamContext currentDb, TaiKhoan user)
        {
            InitializeComponent();
            db = currentDb;
            currentUser = user;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void timKiemHD()
        {
            try
            {

                txtSLDoi.Text = "";
                string maHD = txtMaHD.Text.Trim();
                if (db.HoaDons.Find(maHD) == null) throw new Exception("Không tìm thấy hóa đơn có mã: " + maHD);
                if (db.PhieuDoiTras.Where(s => maHD == s.MaHd).ToList().Count > 0)
                {
                    throw new Exception("Hóa đơn có mã: " + maHD + " đã được sử dụng đổi trả");
                }
                if ((DateTime.Now - db.HoaDons.Find(maHD).NgayLap).TotalDays > 7)
                {
                    throw new Exception("Bạn chỉ có thể đổi trả trong 7 ngày sau khi mua hàng");
                }
                var dsTtHd = db.ThongTinHds.Where(s => s.MaHd == maHD).ToList();
                //if (dsTtHd.Count <= 0 || dsTtHd==null) throw new Exception("Không tìm thấy hóa đơn có mã: " + maHD);
                foreach (var item in dsTtHd)
                {
                    cbMaSP.Items.Add(item.MaSp);
                }
                cbMaSP.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            timKiemHD();   
        }

        private void cbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = cbMaSP.SelectedIndex;
            if (index == -1)
            {
                labelTenSP.Text = "";
            }
            else
            {
                string selectedItem = cbMaSP.Items[index].ToString();
                string maHD = txtMaHD.Text.Trim();
                var sp = db.ThongTinHds.Find(maHD, selectedItem);
                labelTenSP.Text = db.SanPhams.Find(selectedItem).TenSp.ToString();
                txtSLDoi.Text = sp.SoLuongMua.ToString();

                decimal tien = ((decimal)(sp.SoLuongMua * sp.DonGiaHt));
                string tongTien = tien.ToString("#,###", cul.NumberFormat);
                labelTongTien.Text = tongTien + " VND";
            }
        }


        void timKiemSP()
        {
            try
            {
                txtSL.Text = "";
                if (txtMaSP.Text == "") throw new Exception("Hãy nhập mã sản phẩm");

                for (int i = 0; i < dataViewSpDoi.Rows.Count; i++)
                {
                    if (txtMaSP.Text == (dataViewSpDoi.Rows[i].Cells[0].Value.ToString())) throw new Exception("Bạn không được đổi lại sản phẩm này!");
                }

                var sp = db.SanPhams.Find(txtMaSP.Text.Trim());
                if (sp == null) throw new Exception("Không tìm thấy sản phẩm có mã " + txtMaSP.Text);
                labelTenSpCanDoi.Text = sp.TenSp;
                SanPhamKm spkm = db.SanPhamKms.Where(s => s.MaSp == sp.MaSp).FirstOrDefault();
                if (spkm == null)
                {
                    labelDonGiaHienTai.Text = sp.DonGia.ToString("#,###", cul.NumberFormat) + " VND";
                    labelTongTienCanDoi.Text = sp.DonGia.ToString("#,###", cul.NumberFormat) + " VND";
                }
                else
                {
                    KhuyenMai km = db.KhuyenMais.Find(spkm.MaKm);
                    spkm.GiaKm = (sp.DonGia - km.GiamGia * sp.DonGia / 100);
                    labelDonGiaHienTai.Text = ((decimal)spkm.GiaKm).ToString("#,###", cul.NumberFormat) + " VND";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTimKiemCanDoi_Click(object sender, EventArgs e)
        {
            timKiemSP();
        }
        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtSL.Text.Trim()!="")
                {
                    if (!int.TryParse(txtSL.Text.Trim(), out int soLuong)) throw new Exception("Vui lòng nhập số!");
               
                    var sp = db.SanPhams.Find(txtMaSP.Text);
                    if (soLuong > sp.Slton) 
                    {
                        throw new Exception("Xin lỗi sản phẩm này chỉ còn " + sp.Slton + " sản phẩm!");
                    }
                    decimal donGiaht = decimal.Parse(labelDonGiaHienTai.Text.Substring(0, (labelDonGiaHienTai.Text.Length - 3)).Trim(), cul);
                    labelTongTienCanDoi.Text = (donGiaht * soLuong).ToString("#,###", cul.NumberFormat) + " VND";
                }
                else
                {
                    labelTongTienCanDoi.Text = "0 VND";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemDoi_Click(object sender, EventArgs e)
        {
            try
            {
                string maHD = txtMaHD.Text.Trim();
                var dsTtHd = db.ThongTinHds.Where(s => s.MaHd == maHD).ToList();
                if (dsTtHd.Count <= 0) throw new Exception("Không tìm thấy hóa đơn có mã: " + maHD);
                string maSp = cbMaSP.Text;
                var sp = db.ThongTinHds.Find(maHD, maSp);
                int slDoi = int.Parse(txtSLDoi.Text);
                decimal tien = ((decimal)(slDoi * sp.DonGiaHt));
                string tongTien = tien.ToString("#,###", cul.NumberFormat);
                string donGia = ((decimal)sp.DonGiaHt).ToString("#,###", cul.NumberFormat);
                string tenSp = db.SanPhams.Find(maSp).TenSp.ToString();
                int tongSl1Sp = 0;

                for (int i = 0; i < dataViewSpDoi.Rows.Count; i++)
                {
                    if (dataViewSpDoi.Rows[i].Cells[0].Value.ToString() == maSp)
                    {
                        tongSl1Sp += int.Parse(dataViewSpDoi.Rows[i].Cells[2].Value.ToString());
                    }
                }
                if (tongSl1Sp + slDoi > sp.SoLuongMua) throw new Exception("Bạn chỉ mua " + sp.SoLuongMua + " sản phẩm này!");

                int index = 0;
                for (int i = 0; i < dataViewSpDoi.Rows.Count; i++)
                {
                    if (dataViewSpDoi.Rows[i].Cells[0].Value.ToString() == sp.MaSp)
                    {
                        index++;
                        dataViewSpDoi.Rows[i].Cells[2].Value = int.Parse(dataViewSpDoi.Rows[i].Cells[2].Value.ToString()) + slDoi; 
                        dataViewSpDoi.Rows[i].Cells[4].Value = (int.Parse(dataViewSpDoi.Rows[i].Cells[2].Value.ToString()) * decimal.Parse(dataViewSpDoi.Rows[i].Cells[3].Value.ToString(),cul)).ToString("#,###", cul.NumberFormat);
                        break;
                    }
                }

                if(index==0)
                {
                    dataViewSpDoi.Rows.Add(maSp, tenSp, txtSLDoi.Text, donGia, tongTien);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaDoi_Click(object sender, EventArgs e)
        {
            int indexOfRow = dataViewSpDoi.SelectedCells[0].RowIndex;

            dataViewSpDoi.Rows.RemoveAt(indexOfRow);
        }

        private void txtSLDoi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSLDoi.Text.Trim() != "")
                {
                    if (!int.TryParse(txtSLDoi.Text.Trim(), out int soLuong)) throw new Exception("Số lượng muốn đổi phải là số!");
                    var sp = db.ThongTinHds.Find(txtMaHD.Text, cbMaSP.Text);
                    if (soLuong > sp.SoLuongMua)
                    {
                        txtSLDoi.Text = "";
                        throw new Exception("Số không thể lớn hơn " + sp.SoLuongMua + " số lượng sản phẩm đã mua ");
                    }
                    labelTongTien.Text = ((decimal)(soLuong * sp.DonGiaHt)).ToString("#,###", cul.NumberFormat) + " VND"; 
                } else
                {
                    labelTongTien.Text = "0 VND";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemCanDoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaSP.Text == "") throw new Exception("Hãy nhập mã sản phẩm");
                var sp = db.SanPhams.Find(txtMaSP.Text);
                if (sp == null) throw new Exception("Không tìm thấy sản phẩm có mã " + txtMaSP.Text);
                if (!int.TryParse(txtSL.Text.Trim(), out int soLuong)) throw new Exception("Số lượng phải là số và không được để trống!");
                if (soLuong > sp.Slton)
                {
                    throw new Exception("Xin lỗi sản phẩm này chỉ còn " + sp.Slton + " sản phẩm!");
                }

                string maSp = txtMaSP.Text;
                string tenSp = labelTenSpCanDoi.Text;
                string donGiaHT = labelDonGiaHienTai.Text.Substring(0, (labelDonGiaHienTai.Text.Length - 3)).Trim(); 
                string thanhTien = labelTongTienCanDoi.Text.Substring(0, (labelTongTienCanDoi.Text.Length - 3)).Trim();


                int index = 0;
                for (int i = 0; i < dataViewSpCanDoi.Rows.Count; i++)
                {
                    if (dataViewSpCanDoi.Rows[i].Cells[0].Value.ToString() == sp.MaSp)
                    {
                        index++;
                        dataViewSpCanDoi.Rows[i].Cells[2].Value = int.Parse(dataViewSpCanDoi.Rows[i].Cells[2].Value.ToString()) + soLuong;
                        dataViewSpCanDoi.Rows[i].Cells[4].Value = (int.Parse(dataViewSpCanDoi.Rows[i].Cells[2].Value.ToString()) * decimal.Parse(dataViewSpCanDoi.Rows[i].Cells[3].Value.ToString(), cul)).ToString("#,###", cul.NumberFormat);
                        break;
                    }
                }

                if (index == 0)
                {
                    dataViewSpCanDoi.Rows.Add(maSp, tenSp, soLuong, donGiaHT, thanhTien);
                }

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaCanDoi_Click(object sender, EventArgs e)
        {
            int indexOfRow = dataViewSpCanDoi.SelectedCells[0].RowIndex;
            dataViewSpCanDoi.Rows.RemoveAt(indexOfRow);
        }

        private void tinhTienKhachTra()
        {
            decimal tongTienDoi = 0m;
            for (int i = 0; i < dataViewSpDoi.Rows.Count; i++)
            {
                tongTienDoi += decimal.Parse(dataViewSpDoi.Rows[i].Cells[4].Value.ToString(), cul);
            }

            decimal tongTienCanDoi = 0m;
            for (int i = 0; i < dataViewSpCanDoi.Rows.Count; i++)
            {
                tongTienCanDoi += decimal.Parse(dataViewSpCanDoi.Rows[i].Cells[4].Value.ToString(), cul);
            }

            if(tongTienDoi>=tongTienCanDoi)
            {
                labelTienKhachTra.Text = "0 VND";
            } else
            {
                labelTienKhachTra.Text = (tongTienCanDoi - tongTienDoi).ToString("#,###", cul.NumberFormat) + " VND";
            }
        }

        private void dataViewSpDoi_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            tinhTienKhachTra();
        }

        private void dataViewSpDoi_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            tinhTienKhachTra();
        }

        private void dataViewSpCanDoi_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            tinhTienKhachTra();
        }

        private void dataViewSpCanDoi_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            tinhTienKhachTra();
        }
        private void btnLapPhieu_Click(object sender, EventArgs e)
        {   
            try
            {
                if (dataViewSpDoi.Rows.Count == 0) throw new Exception("Bạn chưa chọn hàng đổi");
                if (dataViewSpCanDoi.Rows.Count == 0) throw new Exception("Bạn chưa chọn hàng cần đổi");
                if(db.HoaDons.Find(txtMaHD.Text.Trim())==null) throw new Exception("Không tìm thấy hóa đơn có mã: " + txtMaHD.Text.Trim());

                PhieuDoiTra pdt = new PhieuDoiTra();
                //pdt.MaPhieuDt = Ultility.generateId("PDT");
                pdt.MaPhieuDt = labelMaPhieu.Text;
                pdt.LyDoDt = txtLyDo.Text.Trim();
                pdt.MaHd = txtMaHD.Text.Trim();
                pdt.TongTien = decimal.Parse(labelTienKhachTra.Text.Substring(0, (labelTienKhachTra.Text.Length - 3)).Trim(),cul);
                pdt.NgayLap = DateTime.Now;
                pdt.MaNv = currentUser.MaNv;
                db.PhieuDoiTras.Add(pdt);

                for (int i = 0; i < dataViewSpDoi.Rows.Count; i++)
                {
                    ThongTinSpdt spdt = new ThongTinSpdt();
                    spdt.MaPhieuDt = pdt.MaPhieuDt;
                    spdt.MaSp = dataViewSpDoi.Rows[i].Cells[0].Value.ToString();
                    spdt.SoLuongDt = int.Parse(dataViewSpDoi.Rows[i].Cells[2].Value.ToString());
                    spdt.PhanLoai = false;
                    spdt.DonGiaHt = decimal.Parse(dataViewSpDoi.Rows[i].Cells[3].Value.ToString(), cul);

                    // Add them cho nay
                    var sp = db.SanPhams.Find(spdt.MaSp);
                    sp.Slton += (int)spdt.SoLuongDt;
                    db.ThongTinSpdts.Add(spdt);
                }

                for (int i = 0; i < dataViewSpCanDoi.Rows.Count; i++)
                {
                    ThongTinSpdt spdt = new ThongTinSpdt();
                    spdt.MaPhieuDt = pdt.MaPhieuDt;
                    spdt.MaSp = dataViewSpCanDoi.Rows[i].Cells[0].Value.ToString();
                    spdt.SoLuongDt = int.Parse(dataViewSpCanDoi.Rows[i].Cells[2].Value.ToString());
                    spdt.PhanLoai = true;
                    spdt.DonGiaHt = decimal.Parse(dataViewSpCanDoi.Rows[i].Cells[3].Value.ToString(), cul);

                    // Add them cho nay
                    var sp = db.SanPhams.Find(spdt.MaSp);
                    sp.Slton -= (int)spdt.SoLuongDt;
                    db.ThongTinSpdts.Add(spdt);
                }
                db.SaveChanges();
                Close();
                XemDoiTraForm xem = new XemDoiTraForm(db);
                xem.Tag = pdt.MaPhieuDt;
                xem.StartPosition = FormStartPosition.CenterScreen;
                xem.TopMost = true;
                xem.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMaHD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timKiemHD();
            }   
        }

        private void txtMaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timKiemSP();
            }
        }

        private void ThemDoiTraForm_Load(object sender, EventArgs e)
        {
            labelMaPhieu.Text = Ultility.generateId("PDT");
            labelTenNguoiLap.Text = currentUser.MaNvNavigation.TenNv;
            labelNgayLap.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }
    }
}
