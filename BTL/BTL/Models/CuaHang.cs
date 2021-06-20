﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class CuaHang
    {
        public CuaHang()
        {
            NhanViens = new HashSet<NhanVien>();
            PhieuNhaps = new HashSet<PhieuNhap>();
        }

        public string MaCuaHang { get; set; }
        public string TenCuaHang { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string SoTaiKhoan { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
    }
}
