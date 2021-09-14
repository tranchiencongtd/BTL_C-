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
using System.Windows.Documents;
using System.Windows.Forms;

namespace BTL.Forms.Main.NhapHang
{
    public partial class ThemPhieuNhap : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        TaiKhoan currentUser;
        int rowIndex;
        int index;
        public ThemPhieuNhap(TaiKhoan user)
        {
            InitializeComponent();
            currentUser = user;
            hienThi();
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }


        decimal giaTemp = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            txtMaSP.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txtSL.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            slNhapCu = int.Parse(dataGridView1.Rows[rowIndex].Cells[2].Value.ToString().Trim());
            giaTemp = decimal.Parse(dataGridView1.Rows[rowIndex].Cells[4].Value.ToString(), cul);
        }



        private void ThemPhieuNhap_Load(object sender, EventArgs e)
        {

            //cbxNguoiNhap.DataSource = (from em in db.NhanViens
            //                           select new { em.MaNv, em.TenNv }).ToList();
            //cbxNguoiNhap.ValueMember = "MaNV";
            //cbxNguoiNhap.DisplayMember = "TenNV";
        }



        private void dgvDatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void hienThi()
        {
            dgvDatHang.Rows.Clear();
            var ds = from s in db.PhieuDatHangs
                     select new
                     {
                         s.MaPhieuDat,
                         s.NgayDat,
                         s.MaNvNavigation.TenNv,
                         s.MaNccNavigation.TenNcc
                     };



            foreach (var item in ds)
            {
                int kiemTraSoLuongDat = 0;
                int kiemTraSoLuongNhap = 0;
                List<DongPhieuDat> dongPhieuDats = db.DongPhieuDats.Where(x => x.MaPhieuDat.Equals(item.MaPhieuDat)).ToList();
                foreach (var dongPhieuDat in dongPhieuDats)
                {
                    kiemTraSoLuongDat += dongPhieuDat.SoLuongDat;
                }
                var phieuNhaps = db.PhieuNhaps.Where(x => x.MaPhieuDat.Equals(item.MaPhieuDat));
                foreach (var phieuNhap in phieuNhaps)
                {
                    var dongPhieuNhaps = db.DongPhieuNhaps.Where(x => x.MaPhieuNhap.Equals(phieuNhap.MaPhieuNhap));
                    foreach (var dongPhieuNhap in dongPhieuNhaps)
                    {
                        kiemTraSoLuongNhap += (int)dongPhieuNhap.SoLuong;
                    }
                }

                if (kiemTraSoLuongDat > kiemTraSoLuongNhap)
                    dgvDatHang.Rows.Add(item.MaPhieuDat, item.NgayDat.ToString("dd-MM-yyyy HH:mm:ss"), item.TenNv, item.TenNcc);
            }
        }

        private int slNhapCu = 0;

        private void dgvDatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dgvDatHang.CurrentCell.RowIndex;
            txtMaPhieuDat.Text = dgvDatHang.Rows[index].Cells[0].Value.ToString();
            PhieuDatHang pdh = db.PhieuDatHangs.Single(x => x.MaPhieuDat == txtMaPhieuDat.Text);
            dataGridView1.Rows.Clear();
            var dpdh = db.DongPhieuDats.Where(s => s.MaPhieuDat == txtMaPhieuDat.Text.Trim()).ToList();
            foreach (var item in dpdh)
            {
                SanPham sp = db.SanPhams.Find(item.MaSp);
                dataGridView1.Rows.Add(item.MaSp, sp.TenSp, item.SoLuongDat, 0, ((decimal)item.GiaDat).ToString("#,###", cul.NumberFormat));
            }
        }

        private void btnsuasln_Click(object sender, EventArgs e)
        {
            try
            {
                //DongPhieuDat dpd = db.DongPhieuDats.FirstOrDefault(s => s.MaSp == txtMaSP.Text.Trim() && s.MaPhieuDat == txtTimKiem.Text.Trim());
                //dpd.SoLuongDat = Int32.Parse(txtSL.Text);
                //db.SaveChanges();
                //dataGridView1.Rows.Clear();
                //var dpdh = db.DongPhieuDats.Where(s => s.MaPhieuDat == txtTimKiem.Text.Trim()).ToList();
                //foreach (var item in dpdh)
                //{
                //    SanPham sp = db.SanPhams.Find(item.MaSp);
                //    dataGridView1.Rows.Add(item.MaSp, sp.TenSp, item.SoLuongDat, item.SoLuongDat, ((decimal)item.GiaDat).ToString("#,###", cul.NumberFormat));
                //}
                String maSp = txtMaSP.Text;
                int slSP = int.Parse(txtSL.Text);
                if (maSp == "")
                    throw new Exception("Mã sản phẩm không được để trống!");
                if (slSP < 0)
                    throw new Exception("Số lượng sản phẩm phải lớn hơn 0!");
              
                    int ktSL = 0;
                    var listDongPhieuNhap = new List<DongPhieuNhap>();
                    var phieuNhaps = db.PhieuNhaps.Where(x => x.MaPhieuDat.Equals(txtMaPhieuDat.Text.Trim()));
                    foreach (var item in phieuNhaps)
                    {
                        DongPhieuNhap dongPhieuNhap = db.DongPhieuNhaps.Where(dpn => dpn.MaPhieuNhap.Equals(item.MaPhieuNhap)).SingleOrDefault(X => X.MaSp == maSp);
                        listDongPhieuNhap.Add(dongPhieuNhap);
                    }
                    foreach (var item in listDongPhieuNhap)
                    {
                        ktSL += (int)item.SoLuong;
                    }

                    if (slSP > (slNhapCu - ktSL))
                    {
                        
                        if(currentUser.ChucVu != true)
                        {
                            throw new Exception("Số lượng vượt quá số lượng đặt! Bạn chỉ có thể nhận tối đa " + (slNhapCu - ktSL));
                        }
                        else
                        {
                        MessageBox.Show("Bạn đang nhập vượt quá số lượng đặt!","Thông báo",MessageBoxButtons.OK);
                        }
                        
                    } 
                dataGridView1.Rows[rowIndex].Cells[3].Value = txtSL.Text.Trim();


            }
            catch (FormatException ex2)
            {
                MessageBox.Show("Số lượng không đúng định dạng!");
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
                /*// var dsPhieuNhap = db.PhieuNhaps.Where(s => s.MaPhieuDat == txtMaPhieuDat.Text.Trim()).ToList();
                 var dsmaPhieuNhap = from s in dsPhieuNhap
                          select new
                          {
                              s.MaPhieuNhap
                          };
                 int amount = 0;
                 foreach (var item in dsmaPhieuNhap)
                 {
                     var dsDongPhieuNhap = db.DongPhieuNhaps.Where(s => s.MaPhieuNhap == item.MaPhieuNhap).ToList();
                     foreach (var item2 in dsDongPhieuNhap)
                     {
                         amount += 
                     }

               //  }*/

                //foreach (var item in dsDongPhieuNhap)
                //{

                //}

                //PhieuNhap phieuNhap = db.PhieuNhaps.Where(x => x.MaPhieuDat.Equals(txtMaPhieuDat.Text.Trim())).FirstOrDefault();
                var phieuNhaps = db.PhieuNhaps.Where(x => x.MaPhieuDat.Equals(txtMaPhieuDat.Text.Trim()));



                /*if (txtMaPhieuDat.Text == "") throw new Exception("Bạn cần tìm phiếu đặt trước");
                if (txtMaSP.Text == "") throw new Exception("Bạn chưa nhập mã sản phẩm");
                else if (txtSL.Text == "") throw new Exception("Bạn chưa nhập số lượng");
                else if (int.Parse(txtSL.Text) < 0)
                    throw new Exception("Số lượng phải >0");
*/

                if (txtMaPhieuDat.Text == "") throw new Exception("Bạn cần tìm phiếu đặt trước");
                if (txtMaSP.Text == "") throw new Exception("Bạn chưa nhập mã sản phẩm");
                int slSP = int.Parse(txtSL.Text);
                if (string.IsNullOrEmpty(cbthanhtoan.Text.Trim())) throw new Exception("Bạn chưa nhập thanh toán");
                PhieuNhap phieuNhapMoi = new PhieuNhap();
                phieuNhapMoi.MaPhieuNhap = Ultility.generateId("PN");
                phieuNhapMoi.ThanhToan = cbthanhtoan.Text;
                phieuNhapMoi.NgayNhap = DateTime.Now;
                phieuNhapMoi.MaNv = currentUser.MaNv;
                phieuNhapMoi.MaPhieuDat = txtMaPhieuDat.Text.Trim();
                db.PhieuNhaps.Add(phieuNhapMoi);

                foreach (DataGridViewRow i in dataGridView1.Rows)
                {
                    if (int.Parse(i.Cells[3].Value.ToString()) != 0)
                    {
                        DongPhieuNhap dpnh = new DongPhieuNhap();
                        dpnh.MaPhieuNhap = phieuNhapMoi.MaPhieuNhap;
                        dpnh.MaSp = i.Cells[0].Value.ToString();
                        dpnh.SoLuong = int.Parse(i.Cells[3].Value.ToString());
                        dpnh.GiaNhap = decimal.Parse(i.Cells[4].Value.ToString(), cul);

                        var sp = db.SanPhams.Find(dpnh.MaSp);
                        sp.Slton += (int)dpnh.SoLuong;

                        db.DongPhieuNhaps.Add(dpnh);
                    }
                }
                db.SaveChanges();
                XemPhieuNhapHang abc = new XemPhieuNhapHang(phieuNhapMoi);
                Close();
                abc.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(/*ex.InnerException.ToString()*/ex.Message);
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
