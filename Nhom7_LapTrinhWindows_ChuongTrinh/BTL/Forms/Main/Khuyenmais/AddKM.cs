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

namespace BTL.Forms.Main.Khuyenmais
{
    public partial class AddKM : Form
    {
        Models.QLBanMyPhamContext db;
        SanPham sp = new SanPham();
        SanPhamKm spkm = new SanPhamKm();
        Models.KhuyenMai km = new Models.KhuyenMai();
        TaiKhoan user;
        CultureInfo cul;
        public AddKM(QLBanMyPhamContext dt, TaiKhoan x)
        {
            db = dt;
            user = x;
            InitializeComponent();
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ibtnDong_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có huỷ thêm mới khuyến mãi không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ibtncheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaSP.Text.Trim() == "") throw new Exception("Mã Sản Phẩm không được bỏ trống!");
                sp = db.SanPhams.Find(txtMaSP.Text);
                if (sp == null) throw new Exception("Không tìm thấy sản phẩm có mã " + txtMaSP.Text);
                else
                {
                    txtMaSP.ReadOnly = true;
                    txtDongia.Text = ((double)sp.DonGia).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddKM_Load(object sender, EventArgs e)
        {
            sp = null;
            txtMaKM.Text = Ultility.generateId("KM");
        }

        private void loadSP()
        {
            txtMaSP.ReadOnly = false;
            txtMaSP.Clear();
            txtDongia.Clear();
            txtMaKM.Focus();
            sp = null;
        }

        private void iBtnaddsp_Click(object sender, EventArgs e)
        {
            try
            {
                if (sp == null) throw new Exception("Không được bỏ trống thông tin sản phẩm!");
                else
                {
                    int index = 0;
                    for (int i = 0; i < dataSP.Rows.Count; i++)
                    {
                        if (dataSP.Rows[i].Cells[0].Value.ToString() == sp.MaSp)
                        {
                            index++;
                            break;
                        }
                    }
                    if (index == 0)
                    {
                        double giaKM = double.Parse(txtDongia.Text) - (double.Parse(txtDongia.Text) * (double.Parse(txtGiamGia.Text) / 100));
                        dataSP.Rows.Add(sp.MaSp, giaKM);
                        loadSP();
                    }
                    else
                    {
                        loadSP();
                        throw new Exception("Sản phẩm đã được thêm!\n Vui lòng nhập lại!");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void xoaHang()
        {
            try
            {
                if (dataSP.Rows.Count == 0) throw new Exception("Không có sản phẩm trong danh sách!");
                int indexOfRow = dataSP.SelectedCells[0].RowIndex;
                DataGridViewRow row = dataSP.Rows[indexOfRow];
                if (MessageBox.Show("Bạn chắc chắn muốn xóa sản phẩm " + row.Cells[0].Value, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var sp1 = db.SanPhams.Find(row.Cells["MaSP"].Value.ToString());
                    dataSP.Rows.Remove(row);
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void ibtnDelete_Click(object sender, EventArgs e)
        {
            xoaHang();
        }

        private void ibtnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtGiamGia.Text.Trim() == "") throw new Exception("Phần trăm giảm giá không được bỏ trống!");
                if (dataSP.Rows.Count == 0) throw new Exception("Chưa có sản phẩm cần khuyến mãi trong danh sách!");
                KhuyenMai km = new KhuyenMai();
                km.MaKm = txtMaKM.Text;
                km.GiamGia = int.Parse(txtGiamGia.Text);
                km.NgayBd = DateTime.Parse(dateBD.Text);
                km.NgayKt = DateTime.Parse(dataKT.Text);
                db.KhuyenMais.Add(km);
                for (int i = 0; i < dataSP.Rows.Count; i++)
                {
                    SanPhamKm spkm = new SanPhamKm();
                    spkm.MaKm = km.MaKm;
                    spkm.MaSp = dataSP.Rows[i].Cells[0].Value.ToString();
                    spkm.GiaKm = int.Parse(dataSP.Rows[i].Cells[1].Value.ToString());

                    db.SanPhamKms.Add(spkm);
                }
                db.SaveChanges();
                Close();
                XemTTKM xem = new XemTTKM(db);
                xem.Tag = km.MaKm;
                xem.StartPosition = FormStartPosition.CenterScreen;
                xem.ControlBox = false;
                xem.ShowInTaskbar = false;
                xem.TopMost = true;
                xem.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtMaSP.Text.Trim() == "") throw new Exception("Mã Sản Phẩm không được bỏ trống!");
                    sp = db.SanPhams.Find(txtMaSP.Text);
                    if (sp == null) throw new Exception("Không tìm thấy sản phẩm có mã " + txtMaSP.Text);
                    else
                    {
                        txtMaSP.ReadOnly = true;
                        txtDongia.Text = ((double)sp.DonGia).ToString();
                    }
                    txtDongia.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtDongia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (sp == null) throw new Exception("Không được bỏ trống thông tin sản phẩm!");
                    else
                    {
                        int index = 0;
                        for (int i = 0; i < dataSP.Rows.Count; i++)
                        {
                            if (dataSP.Rows[i].Cells[0].Value.ToString() == sp.MaSp)
                            {
                                index++;
                                break;
                            }
                        }
                        if (index == 0)
                        {

                            double giaKM = double.Parse(txtDongia.Text) - (double.Parse(txtDongia.Text) * (double.Parse(txtGiamGia.Text) / 100));
                            dataSP.Rows.Add(sp.MaSp, giaKM);
                            loadSP();
                        }
                        else
                        {
                            loadSP();
                            throw new Exception("Sản phẩm đã được thêm!\n Vui lòng nhập lại!");
                        }

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
