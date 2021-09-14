﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class ThongTinHd
    {
        public string MaHd { get; set; }
        public string MaSp { get; set; }
        public int SoLuongMua { get; set; }
        public decimal? DonGiaHt { get; set; }

        public virtual HoaDon MaHdNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
