﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class NhaCc
    {
        public NhaCc()
        {
            PhieuNhaps = new HashSet<PhieuNhap>();
        }

        public string MaNcc { get; set; }
        public string TenNcc { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Fax { get; set; }
        public string SoTaiKhoan { get; set; }

        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
    }
}
