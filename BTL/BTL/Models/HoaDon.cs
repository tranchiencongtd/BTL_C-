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

        public string MaHd { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaNv { get; set; }
        public string MaKh { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual ICollection<ThongTinHd> ThongTinHds { get; set; }
    }
}
