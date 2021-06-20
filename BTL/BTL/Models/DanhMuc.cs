using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public string MaDm { get; set; }
        public string TenDm { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
