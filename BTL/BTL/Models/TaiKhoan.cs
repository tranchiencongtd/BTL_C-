using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class TaiKhoan
    {
        public string TenTk { get; set; }
        public string MatKhau { get; set; }
        public bool ChucVu { get; set; }
        public string MaNv { get; set; }

        public virtual NhanVien MaNvNavigation { get; set; }
    }
}
