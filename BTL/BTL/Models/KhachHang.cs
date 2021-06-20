using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public string TenKh { get; set; }
        public string Sdt { get; set; }
        public int? TichDiem { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
