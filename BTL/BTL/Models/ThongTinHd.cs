using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class ThongTinHd
    {
        public int MaHd { get; set; }
        public int MaSp { get; set; }
        public int SoLuongMua { get; set; }

        public virtual HoaDon MaHdNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
