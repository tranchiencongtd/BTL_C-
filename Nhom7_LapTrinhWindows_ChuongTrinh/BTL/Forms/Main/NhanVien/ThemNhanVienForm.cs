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

namespace BTL.Forms.Main.Employee
{
    public partial class ThemNhanVienForm : Form
    {

        QLBanMyPhamContext db;

        string imageName = "noavt.png";
        public ThemNhanVienForm()
        {
            InitializeComponent();
        }

        public ThemNhanVienForm(QLBanMyPhamContext dt)
        {
            db = dt;
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            List<CuaHang> dsCH = new List<CuaHang>();
            dsCH = db.CuaHangs.Select(s => s).ToList();
            foreach (var item in dsCH)
            {
                cbMaCH.Items.Add(item.MaCuaHang);
            }
        }

        private void xoaTrang()
        {
            txtHoTen.Clear();
            txtSDT.Clear();
            cbGioiTinh.Text = "";
            cbMaCH.SelectedIndex = -1;
            cbMaCH.Text = "";
            txtChucVu.Clear();
            //anhAvatar.Image = Image.FromFile(Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 26) + "\\images\\noavt.png"); 
            //anhAvatar.Image.Dispose();
            anhAvatar.Image = anhAvatar.InitialImage;    
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        { 
            try
            {
                if (txtHoTen.Text.Trim() == "") throw new Exception("Họ tên không được để trống!");
                if (txtSDT.Text.Trim() == "") throw new Exception("SĐT không được để trống!");
                if (txtSDT.Text.Trim().Length != 10 ) throw new Exception("SĐT phải có 10 số ");
                if(!long.TryParse(txtSDT.Text.Trim(),out long check)) throw new Exception("SĐT phải là số");
                if (cbGioiTinh.Text.Trim() == "") throw new Exception("Vui lòng chọn giới tính!");
                if (cbMaCH.Text.Trim() == "") throw new Exception("Vui lòng chọn mã cửa hàng!");
                if(txtChucVu.Text.Trim() =="") throw new Exception("Vui lòng nhập chức vụ!");

                NhanVien nv = new NhanVien();
                nv.MaNv = Ultility.generateId("NV");
                nv.TenNv = txtHoTen.Text.Trim();
                nv.GioiTinh = cbGioiTinh.Text == "Nam" ? true : false;
                nv.Sdt = txtSDT.Text.Trim();
                nv.MaCuaHang = cbMaCH.Text;
                nv.ChucVuNv = txtChucVu.Text.Trim();
                nv.Anh = "\\images\\" + imageName;
                imageName = "noavt.png";

                db.NhanViens.Add(nv);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                xoaTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            // Image ..\ALL_IN_BTL\BTL\BTL\images\
            string paths =  Application.StartupPath.Substring(0, (Application.StartupPath.Length) - 26) + "\\images\\" ; // - 26 = path toi images
            string fileName = "";
            try
            {
                // Mo va luu file da mo vao thu muc images
                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (open.CheckFileExists)
                    {
                        fileName = System.IO.Path.GetFileName(open.FileName);
                        if (File.Exists(paths + fileName))
                        {
                            throw new Exception("Tên ảnh đã tồn tại, vui lòng đổi tên khác");
                        }
                        else
                        {
                            imageName = fileName; // Gan cho imageName de gan vao object nv
                            System.IO.File.Copy(open.FileName, paths + imageName);
                            //anhAvatar.Image = Image.FromFile(paths + imageName);
                            Image image;
                            using (Stream stream = File.OpenRead(paths + fileName))
                            {
                                image = System.Drawing.Image.FromStream(stream);
                            }
                            anhAvatar.Image = image;
                        }
                    }
                    else
                    {
                        throw new Exception("Tên ảnh không tồn tại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbMaCH.SelectedIndex;
            if (index == -1)
            {
                labelTenCH.Text = "";
            }
            else
            {
                string selectedItem = cbMaCH.Items[index].ToString();
                var ch = db.CuaHangs.Find(selectedItem);
                labelTenCH.Text = ch.TenCuaHang;
            }
        }
    }
}
