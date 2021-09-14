using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class DongPhieuDat
    {
        public string MaSp { get; set; }
        public string MaPhieuDat { get; set; }
        public int SoLuongDat { get; set; }
        public decimal? GiaDat { get; set; }

        public virtual PhieuDatHang MaPhieuDatNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
