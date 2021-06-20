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

        public int MaPhieuNhap { get; set; }
        public string MaCuaHang { get; set; }
        public string MaNcc { get; set; }
        public DateTime NgayNhap { get; set; }
        public string ThanhToan { get; set; }
        public string NguoiNhap { get; set; }

        public virtual CuaHang MaCuaHangNavigation { get; set; }
        public virtual NhaCc MaNccNavigation { get; set; }
        public virtual ICollection<DongPhieuNhap> DongPhieuNhaps { get; set; }
    }
}
