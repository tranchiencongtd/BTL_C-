using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class DongPhieuNhap
    {
        public string MaPhieuNhap { get; set; }
        public string MaSp { get; set; }
        public int? SoLuong { get; set; }
        public decimal? GiaNhap { get; set; }

        public virtual PhieuNhap MaPhieuNhapNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
