using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
            PhieuDatHangs = new HashSet<PhieuDatHang>();
            PhieuDoiTras = new HashSet<PhieuDoiTra>();
            PhieuNhaps = new HashSet<PhieuNhap>();
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public string MaNv { get; set; }
        public string TenNv { get; set; }
        public string Anh { get; set; }
        public bool? GioiTinh { get; set; }
        public string Sdt { get; set; }
        public string MaCuaHang { get; set; }
        public string ChucVuNv { get; set; }

        public virtual CuaHang MaCuaHangNavigation { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<PhieuDatHang> PhieuDatHangs { get; set; }
        public virtual ICollection<PhieuDoiTra> PhieuDoiTras { get; set; }
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
