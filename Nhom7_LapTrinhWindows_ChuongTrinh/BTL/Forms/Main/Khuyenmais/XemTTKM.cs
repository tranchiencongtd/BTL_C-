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

namespace BTL.Forms.Main.Khuyenmais
{
    public partial class XemTTKM : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        public XemTTKM(QLBanMyPhamContext dt)
        {
            db = dt;
            InitializeComponent();
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void XemTTKM_Load(object sender, EventArgs e)
        {
            try
            {
                #region hien thi khuyến mãi
                string maKM = (string)this.Tag;
                var KM = (from km in db.KhuyenMais
                          where km.MaKm == maKM
                          select new
                          {
                              makm = km.MaKm,
                              giamgia = km.GiamGia,
                              ngaybd = km.NgayBd,
                              ngaykt = km.NgayKt
                          }).FirstOrDefault();

                lbmaKM.Text = KM.makm;
                lbGG.Text = KM.giamgia.ToString();
                lbngayBD.Text = KM.ngaybd.ToString();
                lbngayKT.Text = KM.ngaykt.ToString();
                #endregion
                var spkm = from s in db.SanPhamKms
                           where s.MaKm == maKM
                           select new
                           {
                               masp = s.MaSp,
                               giaKM = (int)s.GiaKm
                           };

                foreach (var item in spkm)
                {
                    dataviewSP.Rows.Add(item.masp, item.giaKM);

                }
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
