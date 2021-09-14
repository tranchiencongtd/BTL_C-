using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class ThongTinSpdt
    {
        public string MaSp { get; set; }
        public string MaPhieuDt { get; set; }
        public int? SoLuongDt { get; set; }
        public bool? PhanLoai { get; set; }

        public decimal? DonGiaHt { get; set; }

        public virtual PhieuDoiTra MaPhieuDtNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
