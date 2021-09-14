using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class PhieuNhap
    {
        public PhieuNhap()
        {
            DongPhieuNhaps = new HashSet<DongPhieuNhap>();
        }

        public string MaPhieuNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        public string ThanhToan { get; set; }
        public string MaPhieuDat { get; set; }
        public string MaNv { get; set; }

        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual PhieuDatHang MaPhieuDatNavigation { get; set; }
        public virtual ICollection<DongPhieuNhap> DongPhieuNhaps { get; set; }
    }
}
