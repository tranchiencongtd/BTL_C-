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
    public partial class TimNCC : Form
    {
        QLBanMyPhamContext db;
        string ten;
        public delegate void TimNcc(string maNCC);
        public event TimNcc TimNCCEvent;
        public TimNCC()
        {
            InitializeComponent();
        }
        public TimNCC(QLBanMyPhamContext currentDb, string t)
        {
            db = currentDb;
            ten =t;
            InitializeComponent();
        }

        private void TimNCC_Load(object sender, EventArgs e)
        {
            var check = db.NhaCcs.Where(s => s.TenNcc.Contains(ten)).ToList();
            dgvNCC.Rows.Clear();
            foreach (var item in check)
            {
                dgvNCC.Rows.Add(item.MaNcc, item.TenNcc, item.DiaChi, item.DienThoai);
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int indexOfRow = dgvNCC.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvNCC.Rows[indexOfRow];
            string maNCC = Convert.ToString(row.Cells["maNCC"].Value);
            if (TimNCCEvent != null)
            {
                TimNCCEvent(maNCC);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
