using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class PhieuDoiTra
    {
        public PhieuDoiTra()
        {
            ThongTinSpdts = new HashSet<ThongTinSpdt>();
        }

        public string MaPhieuDt { get; set; }
        public string LyDoDt { get; set; }
        public string MaHd { get; set; }
        public decimal? TongTien { get; set; }
        public DateTime? NgayLap { get; set; }
        public string MaNv { get; set; }

        public virtual HoaDon MaHdNavigation { get; set; }
        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual ICollection<ThongTinSpdt> ThongTinSpdts { get; set; }
    }
}
