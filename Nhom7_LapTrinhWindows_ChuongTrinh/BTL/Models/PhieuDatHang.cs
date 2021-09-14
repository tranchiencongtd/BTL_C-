using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class PhieuDatHang
    {
        public PhieuDatHang()
        {
            DongPhieuDats = new HashSet<DongPhieuDat>();
            PhieuNhaps = new HashSet<PhieuNhap>();
        }

        public string MaPhieuDat { get; set; }
        public DateTime NgayDat { get; set; }
        public string MaNcc { get; set; }
        public string MaCuaHang { get; set; }
        public string MaNv { get; set; }

        public virtual CuaHang MaCuaHangNavigation { get; set; }
        public virtual NhaCc MaNccNavigation { get; set; }
        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual ICollection<DongPhieuDat> DongPhieuDats { get; set; }
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
    }
}
