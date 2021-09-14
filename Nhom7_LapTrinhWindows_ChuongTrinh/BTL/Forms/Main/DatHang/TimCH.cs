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

namespace BTL.Forms.Main.DatHang
{
    public partial class TimCH : Form
    {
        QLBanMyPhamContext db;
        string ten;
        public delegate void TimCh(string maCH);
        public event TimCh TimCHEvent;
        public TimCH()
        {
            InitializeComponent();
        }
        public TimCH(QLBanMyPhamContext currentDb, string t)
        {
            db = currentDb;
            ten = t;
            InitializeComponent();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            try
            {
                int indexOfRow = dgvCH.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvCH.Rows[indexOfRow];
                string maCH = Convert.ToString(row.Cells["maCH"].Value);
                if (TimCHEvent != null)
                {
                    TimCHEvent(maCH);
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn cửa hàng cần tìm!");
            }
            
        }

        private void TimCH_Load(object sender, EventArgs e)
        {
            var check = db.CuaHangs.Where(s => s.TenCuaHang.Contains(ten)).ToList();
            dgvCH.Rows.Clear();
            foreach (var item in check)
            {
                dgvCH.Rows.Add(item.MaCuaHang, item.TenCuaHang, item.DiaChi, item.DienThoai);
            }
        }
    }
}
