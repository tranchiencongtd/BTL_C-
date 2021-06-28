using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class KhuyenMai
    {
        public KhuyenMai()
        {
            SanPhamKms = new HashSet<SanPhamKm>();
        }

        public string MaKm { get; set; }
        public int? GiamGia { get; set; }
        public DateTime? NgayBd { get; set; }
        public DateTime? NgayKt { get; set; }

        public virtual ICollection<SanPhamKm> SanPhamKms { get; set; }
    }
}
