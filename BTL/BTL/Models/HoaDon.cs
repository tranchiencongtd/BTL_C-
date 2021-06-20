using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ThongTinHds = new HashSet<ThongTinHd>();
        }

        public int MaHd { get; set; }
        public DateTime NgayLap { get; set; }
        public string Sdt { get; set; }
        public string MaNv { get; set; }

        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual KhachHang SdtNavigation { get; set; }
        public virtual ICollection<ThongTinHd> ThongTinHds { get; set; }
    }
}
