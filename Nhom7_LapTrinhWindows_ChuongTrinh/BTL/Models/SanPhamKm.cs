using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class SanPhamKm
    {
        public string MaKm { get; set; }
        public string MaSp { get; set; }
        public decimal? GiaKm { get; set; }

        public virtual KhuyenMai MaKmNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
