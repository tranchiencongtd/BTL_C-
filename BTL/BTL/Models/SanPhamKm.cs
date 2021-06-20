using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class SanPhamKm
    {
        public int MaKm { get; set; }
        public int MaSp { get; set; }
        public int? GiaKm { get; set; }

        public virtual KhuyenMai MaKmNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
