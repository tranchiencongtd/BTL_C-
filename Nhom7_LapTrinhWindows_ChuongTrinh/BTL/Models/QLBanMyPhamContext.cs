using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BTL.Models
{
    public partial class QLBanMyPhamContext : DbContext
    {
        public QLBanMyPhamContext()
        {
        }

        public QLBanMyPhamContext(DbContextOptions<QLBanMyPhamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CuaHang> CuaHangs { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DongPhieuDat> DongPhieuDats { get; set; }
        public virtual DbSet<DongPhieuNhap> DongPhieuNhaps { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<NhaCc> NhaCcs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuDatHang> PhieuDatHangs { get; set; }
        public virtual DbSet<PhieuDoiTra> PhieuDoiTras { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<SanPhamKm> SanPhamKms { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThongTinHd> ThongTinHds { get; set; }
        public virtual DbSet<ThongTinSpdt> ThongTinSpdts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CONGIT;Initial Catalog=QLBanMyPham;Integrated Security=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CuaHang>(entity =>
            {
                entity.HasKey(e => e.MaCuaHang)
                    .HasName("PK__CuaHang__0840BCA658A82CA0");

                entity.ToTable("CuaHang");

                entity.Property(e => e.MaCuaHang).HasMaxLength(20);

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DienThoai)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.SoTaiKhoan).HasMaxLength(100);

                entity.Property(e => e.TenCuaHang)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDm)
                    .HasName("PK__DanhMuc__2725866E9F0347F8");

                entity.ToTable("DanhMuc");

                entity.Property(e => e.MaDm)
                    .HasMaxLength(50)
                    .HasColumnName("MaDM");

                entity.Property(e => e.TenDm)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenDM");
            });

            modelBuilder.Entity<DongPhieuDat>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.MaPhieuDat })
                    .HasName("PK__DongPhie__873BA8CE34556CE8");

                entity.ToTable("DongPhieuDat");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(20)
                    .HasColumnName("MaSP");

                entity.Property(e => e.MaPhieuDat).HasMaxLength(20);

                entity.Property(e => e.GiaDat).HasColumnType("money");

                entity.HasOne(d => d.MaPhieuDatNavigation)
                    .WithMany(p => p.DongPhieuDats)
                    .HasForeignKey(d => d.MaPhieuDat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DongPhieu__MaPhi__5629CD9C");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.DongPhieuDats)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DongPhieuD__MaSP__4BAC3F29");
            });

            modelBuilder.Entity<DongPhieuNhap>(entity =>
            {
                entity.HasKey(e => new { e.MaPhieuNhap, e.MaSp })
                    .HasName("PK__DongPhie__C602BFBAF7A4D68B");

                entity.ToTable("DongPhieuNhap");

                entity.Property(e => e.MaPhieuNhap).HasMaxLength(20);

                entity.Property(e => e.MaSp)
                    .HasMaxLength(20)
                    .HasColumnName("MaSP");

                entity.Property(e => e.GiaNhap).HasColumnType("money");

                entity.HasOne(d => d.MaPhieuNhapNavigation)
                    .WithMany(p => p.DongPhieuNhaps)
                    .HasForeignKey(d => d.MaPhieuNhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DongPhieu__MaPhi__5441852A");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.DongPhieuNhaps)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DongPhieuN__MaSP__49C3F6B7");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HoaDon__2725A6E0269B5D93");

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(20)
                    .HasColumnName("MaHD");

                entity.Property(e => e.MaKh)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MaKH");

                entity.Property(e => e.MaNv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MaNV");

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.Property(e => e.TichDiemHt).HasColumnName("TichDiemHT");

                entity.Property(e => e.TongTien).HasColumnType("money");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__MaKH__46E78A0C");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__MaNV__4D94879B");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK__KhachHan__2725CF1E071D2605");

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(20)
                    .HasColumnName("MaKH");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(100)
                    .HasColumnName("TenKH");
            });

            modelBuilder.Entity<KhuyenMai>(entity =>
            {
                entity.HasKey(e => e.MaKm)
                    .HasName("PK__KhuyenMa__2725CF1586EE7BCB");

                entity.ToTable("KhuyenMai");

                entity.Property(e => e.MaKm)
                    .HasMaxLength(20)
                    .HasColumnName("MaKM");

                entity.Property(e => e.NgayBd)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayBD");

                entity.Property(e => e.NgayKt)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayKT");
            });

            modelBuilder.Entity<NhaCc>(entity =>
            {
                entity.HasKey(e => e.MaNcc)
                    .HasName("PK__NhaCC__3A185DEB98291423");

                entity.ToTable("NhaCC");

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(20)
                    .HasColumnName("MaNCC");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DienThoai)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SoTaiKhoan)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TenNcc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenNCC");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70ACE876C6B");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(20)
                    .HasColumnName("MaNV");

                entity.Property(e => e.Anh).HasMaxLength(200);

                entity.Property(e => e.ChucVuNv)
                    .HasMaxLength(20)
                    .HasColumnName("ChucVuNV");

                entity.Property(e => e.MaCuaHang)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(11)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenNv)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenNV");

                entity.HasOne(d => d.MaCuaHangNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaCuaHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NhanVien__MaCuaH__4316F928");
            });

            modelBuilder.Entity<PhieuDatHang>(entity =>
            {
                entity.HasKey(e => e.MaPhieuDat)
                    .HasName("PK__PhieuDat__01EA0D2B57820D42");

                entity.ToTable("PhieuDatHang");

                entity.Property(e => e.MaPhieuDat).HasMaxLength(20);

                entity.Property(e => e.MaCuaHang)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MaNcc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MaNCC");

                entity.Property(e => e.MaNv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MaNV");

                entity.Property(e => e.NgayDat).HasColumnType("datetime");

                entity.HasOne(d => d.MaCuaHangNavigation)
                    .WithMany(p => p.PhieuDatHangs)
                    .HasForeignKey(d => d.MaCuaHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PhieuDatH__MaCua__440B1D61");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.PhieuDatHangs)
                    .HasForeignKey(d => d.MaNcc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PhieuDatH__MaNCC__52593CB8");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.PhieuDatHangs)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PhieuDatHa__MaNV__5070F446");
            });

            modelBuilder.Entity<PhieuDoiTra>(entity =>
            {
                entity.HasKey(e => e.MaPhieuDt)
                    .HasName("PK__PhieuDoi__880CC95F13FF76F9");

                entity.ToTable("PhieuDoiTra");

                entity.Property(e => e.MaPhieuDt)
                    .HasMaxLength(20)
                    .HasColumnName("MaPhieuDT");

                entity.Property(e => e.LyDoDt)
                    .HasMaxLength(200)
                    .HasColumnName("LyDoDT");

                entity.Property(e => e.MaHd)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MaHD");

                entity.Property(e => e.MaNv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MaNV");

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.Property(e => e.TongTien)
                    .HasColumnType("money")
                    .HasColumnName("tongTien");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.PhieuDoiTras)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PhieuDoiTr__MaHD__45F365D3");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.PhieuDoiTras)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PhieuDoiTr__MaNV__4F7CD00D");
            });

            modelBuilder.Entity<PhieuNhap>(entity =>
            {
                entity.HasKey(e => e.MaPhieuNhap)
                    .HasName("PK__PhieuNha__1470EF3B87606334");

                entity.ToTable("PhieuNhap");

                entity.Property(e => e.MaPhieuNhap).HasMaxLength(20);

                entity.Property(e => e.MaNv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MaNV");

                entity.Property(e => e.MaPhieuDat)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.NgayNhap).HasColumnType("datetime");

                entity.Property(e => e.ThanhToan).HasMaxLength(50);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.PhieuNhaps)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PhieuNhap__MaNV__5165187F");

                entity.HasOne(d => d.MaPhieuDatNavigation)
                    .WithMany(p => p.PhieuNhaps)
                    .HasForeignKey(d => d.MaPhieuDat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PhieuNhap__MaPhi__571DF1D5");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081C6CF1C178");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(20)
                    .HasColumnName("MaSP");

                entity.Property(e => e.DonGia).HasColumnType("money");

                entity.Property(e => e.DonViTinh)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaDm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MaDM");

                entity.Property(e => e.Slton).HasColumnName("SLTon");

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenSP");

                entity.Property(e => e.ThuongHieu)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.XuatXu)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.MaDmNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaDm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SanPham__MaDM__534D60F1");
            });

            modelBuilder.Entity<SanPhamKm>(entity =>
            {
                entity.HasKey(e => new { e.MaKm, e.MaSp })
                    .HasName("PK__SanPhamK__F5579F9422A81D90");

                entity.ToTable("SanPhamKM");

                entity.Property(e => e.MaKm)
                    .HasMaxLength(20)
                    .HasColumnName("MaKM");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(20)
                    .HasColumnName("MaSP");

                entity.Property(e => e.GiaKm)
                    .HasColumnType("money")
                    .HasColumnName("GiaKM");

                entity.HasOne(d => d.MaKmNavigation)
                    .WithMany(p => p.SanPhamKms)
                    .HasForeignKey(d => d.MaKm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SanPhamKM__MaKM__4CA06362");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.SanPhamKms)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SanPhamKM__MaSP__48CFD27E");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.TenTk)
                    .HasName("PK__TaiKhoan__4CF9E77665E0A68D");

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.TenTk)
                    .HasMaxLength(30)
                    .HasColumnName("TenTK");

                entity.Property(e => e.MaNv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MaNV");

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TaiKhoan__MaNV__4E88ABD4");
            });

            modelBuilder.Entity<ThongTinHd>(entity =>
            {
                entity.HasKey(e => new { e.MaHd, e.MaSp })
                    .HasName("PK__ThongTin__F557F661257625DB");

                entity.ToTable("ThongTinHD");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(20)
                    .HasColumnName("MaHD");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(20)
                    .HasColumnName("MaSP");

                entity.Property(e => e.DonGiaHt)
                    .HasColumnType("money")
                    .HasColumnName("DonGiaHT");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.ThongTinHds)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ThongTinHD__MaHD__44FF419A");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ThongTinHds)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ThongTinHD__MaSP__47DBAE45");
            });

            modelBuilder.Entity<ThongTinSpdt>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.MaPhieuDt })
                    .HasName("PK__ThongTin__CFA5C489ACCBEEF5");

                entity.ToTable("ThongTinSPDT");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(20)
                    .HasColumnName("MaSP");

                entity.Property(e => e.MaPhieuDt)
                    .HasMaxLength(20)
                    .HasColumnName("MaPhieuDT");

                entity.Property(e => e.SoLuongDt).HasColumnName("SoLuongDT");

                entity.HasOne(d => d.MaPhieuDtNavigation)
                    .WithMany(p => p.ThongTinSpdts)
                    .HasForeignKey(d => d.MaPhieuDt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ThongTinS__MaPhi__5535A963");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ThongTinSpdts)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ThongTinSP__MaSP__4AB81AF0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
