﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            DongPhieuNhaps = new HashSet<DongPhieuNhap>();
            SanPhamKms = new HashSet<SanPhamKm>();
            ThongTinHds = new HashSet<ThongTinHd>();
        }

        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public int Slton { get; set; }
        public decimal DonGia { get; set; }
        public string XuatXu { get; set; }
        public string ThuongHieu { get; set; }
        public string MaDm { get; set; }
        public string DonViTinh { get; set; }

        public virtual DanhMuc MaDmNavigation { get; set; }
        public virtual ICollection<DongPhieuNhap> DongPhieuNhaps { get; set; }
        public virtual ICollection<SanPhamKm> SanPhamKms { get; set; }
        public virtual ICollection<ThongTinHd> ThongTinHds { get; set; }
    }
}
